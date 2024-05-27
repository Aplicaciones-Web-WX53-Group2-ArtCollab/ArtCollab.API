using Application.Monetization.Data.Persistence.EFC.Repository;
using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Domain.Model.Entities;
using Application.Monetization.Domain.Repository;
using Application.Monetization.Shared.Domain.Interfaces;
using Application.Monetization.Shared.Domain.Repository;
using Application.Monetization.Shared.Infrastructure.Persistence.EFC.Configuration.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

var connectionString = builder.Configuration.GetConnectionString("ArtCollabDb");

builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
            , options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            ));
    });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

//Config core permite que la api pueda consumir desde cualquier cliente
app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using Application.Mapper;
using Domain;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Infrastructure.MySql;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.MySql;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection
builder.Services.AddScoped<IReaderData, ReaderMySqlData>();
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(RequestToModel)
    , typeof(ModelToRequest)
    , typeof(ModelToResponse));

// Connect DB
var connectionString = builder.Configuration.GetConnectionString("ArtCollabDB");

builder.Services.AddDbContext<ArtCollabDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    });


var app = builder.Build();

//EF
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<ArtCollabDbContext>())
{
    context.Database.EnsureCreated();
}

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
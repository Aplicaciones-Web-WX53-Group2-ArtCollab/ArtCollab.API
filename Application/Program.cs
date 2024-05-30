using Application.Mapper;
using Domain;
using Domain.Interfaces;
using Infraestructure.Content.Interfaces;
using Infraestructure.Content.MySql;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Infraestructure.MySql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ITemplateData<>), typeof(TemplateMySqlData<>));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

builder.Services.AddAutoMapper(typeof(RequestToModel)
    , typeof(ModelToRequest)
    , typeof(ModelToResponse));


var connectionString = builder.Configuration.GetConnectionString("ArtCollabDb");

builder.Services.AddDbContext<TemplateDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, 
                ServerVersion.AutoDetect(connectionString) 
        );
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TemplateDBContext>();
    context.Database.EnsureCreated();
}

app.UseCors(
    b =>b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

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
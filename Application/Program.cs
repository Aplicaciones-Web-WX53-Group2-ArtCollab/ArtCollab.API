using Application.Mapper;
using Domain;
using Domain.Interfaces;
using Infraestructure;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Infraestructure.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(ISubscriptionData<>), typeof(SubscriptionData<>));
builder.Services.AddScoped(typeof(ISubscriptionDomain<>), typeof(SubscriptionDomain<>));

// Especifica explícitamente el espacio de nombres de AddAutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<RequestToModel>(), typeof(ModelToRequest), typeof(ModelToResponse));

var connectionString = builder.Configuration.GetConnectionString("ArtCollabDb");

builder.Services.AddDbContext<SubscriptionDBContext>(
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
    var context = services.GetRequiredService<SubscriptionDBContext>();
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
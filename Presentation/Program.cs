
using System.Reflection;
using Domain.Interfaces;
using Domain.Monetization.Model.Aggregates;
using Domain.Repository;
using Infrastructure.Content.Interfaces;
using Infrastructure.Content.MySql;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Monetization.Model.Entities;
using Infrastructure.Shared.Context;
using Infrastructure.Shared.Interfaces;
using Infrastructure.Shared.Middleware;
using Infrastructure.Shared.Repository;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.Mapper;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "ArtCollab API",
            Description = "ArtCollab Api documentation",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "ArtCollab Contact",
                Url = new Uri("https://ephemeral-rabanadas-a3e8b8.netlify.app/")
            },
            License = new OpenApiLicense
            {
                Name = "ArtCollab Licence",
                Url = new Uri("https://artcollab.com/license")
            }
        });
        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

//dependency injection
builder.Services.AddScoped<IReaderData, ReaderMySqlData>();
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ITemplateData<>), typeof(TemplateMySqlData<>));
builder.Services.AddAutoMapper(typeof(RequestToModel), typeof(ModelToRequest), typeof(ModelToResponse));
builder.Services.AddScoped<Observer, SubscriptionObserver>();


// Connect DB
var connectionString = builder.Configuration.GetConnectionString("ArtCollabDB");

builder.Services.AddDbContext<AppDbContext>(
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
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
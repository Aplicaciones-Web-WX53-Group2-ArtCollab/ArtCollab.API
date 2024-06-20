
using System.Reflection;
using Application.Collaboration.Internal.CommandServices;
using Application.Collaboration.Internal.QueryServices;
using Application.Content.Internal.CommandServices;
using Application.Content.Internal.QueryServices;
using Application.IAM.Internal.CommandServices;
using Application.IAM.Internal.OutboundServices;
using Application.IAM.Internal.QueryServices;
using Application.Monetization.Internal.CommandServices;
using Application.Monetization.Internal.QueryServices;
using Domain.Collaboration.Repositories;
using Domain.Collaboration.Services;
using Domain.Content.Repositories;
using Domain.Content.Services;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;
using Domain.Shared.Repositories;
using Infrastructure.Collaboration.Persistence.EFC.Repositories;
using Infrastructure.Content.Persistence.EFC.Repositories;
using Infrastructure.IAM.Hashing.Bcrypt.Services;
using Infrastructure.IAM.Persistence.EFC.Repositories;
using Infrastructure.IAM.Pipeline.Middleware.Extensions;
using Infrastructure.IAM.Tokens.JWT.Configuration;
using Infrastructure.IAM.Tokens.JWT.Services;
using Infrastructure.Monetization.Model.Entities;
using Infrastructure.Monetization.Persistence.EFC.Repositories;
using Infrastructure.Shared.Interfaces.ASP.Configuration;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.IAM.ACL;
using Presentation.IAM.ACL.Services;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));


// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);
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
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    } 
                }, 
                Array.Empty<string>()
            }
        });
        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

//dependency injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<ICommisionRepository, CommisionRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ICommentCommandService,CommentCommandService>();
builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();

builder.Services.AddScoped<ITemplateCommandService,TemplateCommandService>();
builder.Services.AddScoped<ITemplateQueryService, TemplateQueryService>();

builder.Services.AddScoped<ICommisionCommandService,CommisionCommandService>();
builder.Services.AddScoped<ICommisionQueryService, CommisionQueryService>();

builder.Services.AddScoped<ISubscriptionCommandService,SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();

//IAM dependency injection
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminCommandService, AdminCommandService>();
builder.Services.AddScoped<IAdminQueryService, AdminQueryService>();




builder.Services.AddScoped<Observer, SubscriptionObserver>();


// Connect DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

// Add authorization middleware to pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
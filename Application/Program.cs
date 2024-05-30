
using Domain.Interfaces;
using Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(ISubscriptionData<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ISubscriptionDomain<>), typeof(RepositoryGeneric<>));

builder.Services.AddAutoMapper(typeof(RequestToModel)
    , typeof(ModelToRequest)
    , typeof(ModelToResponse));


var app = builder.Build();

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
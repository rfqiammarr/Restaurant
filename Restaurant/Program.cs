using Restaurant.Infrastructure.Presistence;
using Restaurant.Infrastructure.Extentions;
using Restaurant.Infrastructure.Seeders;
using Restaurant.Application.Extentions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection For Application
builder.Services.AddApplication();
// Dependency Injection For Infrastructure
builder.Services.AddInfrastructure(builder.Configuration); // Method Add Infrastructure in Presistence

var app = builder.Build();

var scope =app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

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

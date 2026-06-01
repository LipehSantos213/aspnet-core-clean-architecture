
using api_csharp.Domain.Interfaces;
using api_csharp.Infrastructure.Data.Context;
using api_csharp.Infrastructure.Repositories;
using api_csharp.Presentation.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Pega a Connection String do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Conecta o DbContext ao Banco de Dados PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 3. Mapeia a Interface (Domain) para a Implementação Real (Infrastructure)
// Sempre que um UseCase pedir IUserRepository, o ASP.NET vai instanciar o UserRepository da Infra
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyResolvers();

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

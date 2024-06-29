using HighScoreAPI.Application.UseCases;
using HighScoreAPI.Data.Context;
using HighScoreAPI.Data.Repositories;
using HighScoreAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=HighScoreAPI;User ID=API;Password=API123;Encrypt=True;TrustServerCertificate=True;"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IHighScoreRepository, HighScoreRepository>();

builder.Services.AddScoped<RegisterGameUseCases>();
builder.Services.AddScoped<RegisterScorePlayerInGameUseCase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
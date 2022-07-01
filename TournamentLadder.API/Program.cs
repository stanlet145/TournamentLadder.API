using Microsoft.EntityFrameworkCore;
using TournamentLadder.Core.Service.Game;
using TournamentLadder.Infrastructure.Context;
using TournamentLadder.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.TournamentLadder.db",
        sqlOptions => sqlOptions.MigrationsAssembly("TournamentLadder.Infrastructure")
    )
);

 builder.Services.AddScoped<IGameRepository, GameRepository>();
 builder.Services.AddScoped<IGameService, GameService>();

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
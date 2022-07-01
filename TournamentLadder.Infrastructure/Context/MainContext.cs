using Microsoft.EntityFrameworkCore;
using TournamentLadder.Infrastructure.Entities;

namespace TournamentLadder.Infrastructure.Context;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Game> Game { get; set; }
    public DbSet<Ladder> Ladder { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Tournament> Tournament { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.TournamentLadder.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
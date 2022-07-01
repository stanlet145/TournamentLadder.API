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
        modelBuilder.Entity<Tournament>()
            .HasMany(x => x.TournamentTeams)
            .WithOne(x => x.Tournament)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Team>()
            .HasMany(x => x.Members)
            .WithOne(x => x.Team)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tournament>()
            .HasOne(x => x.Ladder)
            .WithOne(x => x.Tournament)
            .HasForeignKey<Tournament>(x => x.LadderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Ladder>()
            .HasMany(x => x.Games)
            .WithOne(x => x.Ladder)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
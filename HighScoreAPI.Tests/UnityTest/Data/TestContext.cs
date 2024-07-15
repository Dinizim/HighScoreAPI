using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Validation.notification;
using Microsoft.EntityFrameworkCore;

namespace HighScoreAPI.Tests.UnityTest.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<HighScore> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        modelBuilder.Entity<HighScore>()
            .HasOne(hs => hs.Player)
            .WithMany(p => p.HighScores)
            .HasForeignKey(fk => fk.PlayerId);

        modelBuilder.Entity<HighScore>()
             .HasOne(hs => hs.Game)
             .WithMany(game => game.HighScores)
             .HasForeignKey(fk => fk.GameId);
    }
}
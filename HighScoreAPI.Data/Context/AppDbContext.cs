using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Validation.notification;
using Microsoft.EntityFrameworkCore;

namespace HighScoreAPI.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<HighScore> HighScores { get; set; }
    public DbSet<Game> Games { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

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
using HighScoreAPI.Data.Context;
using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Validation.notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Tests.UnityTest.Data;
public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<highscore> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        modelBuilder.Entity<highscore>()
            .HasOne(hs => hs.Player)
            .WithMany(p => p.HighScores)
            .HasForeignKey(fk => fk.PlayerId);

        modelBuilder.Entity<highscore>()
             .HasOne(hs => hs.Game)
             .WithMany(game => game.HighScores)
             .HasForeignKey(fk => fk.GameId);

    }
}

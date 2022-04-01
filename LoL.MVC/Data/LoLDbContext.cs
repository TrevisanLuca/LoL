namespace LoL.MVC.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain;

public class LoLDbContext : DbContext
{
    public DbSet<Player> Player { get; set; } = null!;
    public DbSet<Legend> Legend { get; set; } = null!;
    public DbSet<Team> Team { get; set; } = null!;
    public DbSet<Game> Game { get; set; } = null!;
    public DbSet<Composition> Composition { get; set; } = null!;
    public LoLDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Team1)
            .WithMany()
            .HasForeignKey(g => g.Team1Id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Team2)
            .WithMany()
            .HasForeignKey(g => g.Team2Id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Winner)
            .WithMany()
            .HasForeignKey(g => g.WinnerId)
            .OnDelete(DeleteBehavior.NoAction);

        #region Team_Player_FKs
        //Player1
        modelBuilder.Entity<Team>()
            .HasOne(t => t.Player1)
            .WithOne()
            .HasForeignKey("Team", "Player1Id")
            .OnDelete(DeleteBehavior.NoAction);
        //Player2
        modelBuilder.Entity<Team>()
            .HasOne(t => t.Player2)
            .WithOne()
            .HasForeignKey("Team", "Player2Id")
            .OnDelete(DeleteBehavior.NoAction);
        //Player3
        modelBuilder.Entity<Team>()
            .HasOne(t => t.Player3)
            .WithOne()
            .HasForeignKey("Team", "Player3Id")
            .OnDelete(DeleteBehavior.NoAction);
        //Player4
        modelBuilder.Entity<Team>()
            .HasOne(t => t.Player4)
            .WithOne()
            .HasForeignKey("Team", "Player4Id")
            .OnDelete(DeleteBehavior.NoAction);
        //Player5
        modelBuilder.Entity<Team>()
           .HasOne(t => t.Player5)
           .WithOne()
           .HasForeignKey("Team", "Player5Id")
           .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region Composition_Legend_FKs
        //Legend 1
        modelBuilder.Entity<Composition>()
           .HasOne(c => c.Legend1)
           .WithMany()
           .HasForeignKey(c => c.Legend1Id)
           .OnDelete(DeleteBehavior.NoAction);
        //Legend 2
        modelBuilder.Entity<Composition>()
           .HasOne(c => c.Legend2)
           .WithMany()
           .HasForeignKey(c => c.Legend2Id)
           .OnDelete(DeleteBehavior.NoAction);
        //Legend 3      
        modelBuilder.Entity<Composition>()
           .HasOne(c => c.Legend3)
           .WithMany()
           .HasForeignKey(c => c.Legend3Id)
           .OnDelete(DeleteBehavior.NoAction);
        //Legend 4     
        modelBuilder.Entity<Composition>()
           .HasOne(c => c.Legend4)
           .WithMany()
           .HasForeignKey(c => c.Legend4Id)
           .OnDelete(DeleteBehavior.NoAction);
        //Legend 5
        modelBuilder.Entity<Composition>()
           .HasOne(c => c.Legend5)
           .WithMany()
           .HasForeignKey(c => c.Legend5Id)
           .OnDelete(DeleteBehavior.NoAction);
        #endregion
    }
}
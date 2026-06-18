using Microsoft.EntityFrameworkCore;
using GalaxyPets.Models;
using GalaxyPets.Data;

namespace GalaxyPets.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<ClubMember> ClubMembers { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the composite primary key for the ClubMember join table
        modelBuilder.Entity<ClubMember>()
            .HasKey(cm => new { cm.UserId, cm.ClubId });
    }

}
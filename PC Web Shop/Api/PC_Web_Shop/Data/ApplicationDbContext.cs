using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Artikal> Artikal { get; set; }


    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Administrator> Administrator { get; set; }
    public DbSet<Grad> Grad { get; set; }
    public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
    public DbSet<Kupac> Kupac { get; set; }
    public DbSet<Poruka> Poruka { get; set; }
    public DbSet<Zaposlenik> Zaposlenik { get; set; }
    public DbSet<Artikal> Artikal { get; set; }
    public DbSet<Popust> Popust { get; set; }
    public DbSet<Proizvodjac> Proizvodjac { get; set; }
    public DbSet<ArtikalKategorija> ArtikalKategorija { get; set; }
    public DbSet<Narudzba> Narudzba { get; set; }
    public DbSet<StavkaNarudzbe> StavkaNarudzbe { get; set; }
    public DbSet<Skladiste> Skladiste { get; set; }
    public DbSet<SmsLog> Smslog { get; set; }
    public DbSet<Recenzija> Recenzija { get; set; }
    public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }


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
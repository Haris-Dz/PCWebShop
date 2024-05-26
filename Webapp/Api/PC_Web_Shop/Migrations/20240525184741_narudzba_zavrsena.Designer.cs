﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PC_Web_Shop.Data;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240525184741_narudzba_zavrsena")]
    partial class narudzba_zavrsena
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Artikal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtikalKategorijaId")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KratkiOpis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PopustId")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodjacId")
                        .HasColumnType("int");

                    b.Property<int>("Sifra")
                        .HasColumnType("int");

                    b.Property<int?>("SkladisteId")
                        .HasColumnType("int");

                    b.Property<string>("SlikaArtikla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StanjeNaSkladistu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalKategorijaId");

                    b.HasIndex("PopustId");

                    b.HasIndex("ProizvodjacId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Artikal");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.ArtikalKategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtikalKategorija");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IpAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("VrijednostTokena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaKorisnika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isKupac")
                        .HasColumnType("bit");

                    b.Property<bool>("isZaposlenik")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<string>("Kontakt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<double>("UkupnaCijena")
                        .HasColumnType("float");

                    b.Property<int?>("ZaposlenikId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("Zavrsena")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Popust", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatumDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOd")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Procenat")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Popust");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Poruka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Procitano")
                        .HasColumnType("bit");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZaposlenikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Poruka");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Recenzija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KupacId");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Skladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Kapacitet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Skladiste");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.SmsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Broj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DodatniSadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Smslog");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.StavkaNarudzbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArtikalId")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("StavkaNarudzbe");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Administrator", b =>
                {
                    b.HasBaseType("PC_Web_Shop.Data.Models.KorisnickiNalog");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Kupac", b =>
                {
                    b.HasBaseType("PC_Web_Shop.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojMobitela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("GradId");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Zaposlenik", b =>
                {
                    b.HasBaseType("PC_Web_Shop.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojMobitela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasIndex("GradId");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Artikal", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.ArtikalKategorija", "ArtikalKategorija")
                        .WithMany()
                        .HasForeignKey("ArtikalKategorijaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PC_Web_Shop.Data.Models.Popust", "Popust")
                        .WithMany()
                        .HasForeignKey("PopustId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PC_Web_Shop.Data.Models.Proizvodjac", "Prozivodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PC_Web_Shop.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ArtikalKategorija");

                    b.Navigation("Popust");

                    b.Navigation("Prozivodjac");

                    b.Navigation("Skladiste");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Narudzba", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PC_Web_Shop.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("Zaposlenik");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Poruka", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Administrator", "Administrator")
                        .WithMany("Poruka")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PC_Web_Shop.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Zaposlenik");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Recenzija", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Skladiste", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.StavkaNarudzbe", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Artikal", "Artikal")
                        .WithMany()
                        .HasForeignKey("ArtikalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PC_Web_Shop.Data.Models.Narudzba", "Narudzba")
                        .WithMany("StavkaNarudzbe")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artikal");

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Administrator", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("PC_Web_Shop.Data.Models.Administrator", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Kupac", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PC_Web_Shop.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("PC_Web_Shop.Data.Models.Kupac", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Zaposlenik", b =>
                {
                    b.HasOne("PC_Web_Shop.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PC_Web_Shop.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("PC_Web_Shop.Data.Models.Zaposlenik", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Narudzba", b =>
                {
                    b.Navigation("StavkaNarudzbe");
                });

            modelBuilder.Entity("PC_Web_Shop.Data.Models.Administrator", b =>
                {
                    b.Navigation("Poruka");
                });
#pragma warning restore 612, 618
        }
    }
}

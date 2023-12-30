using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PC_Web_Shop.Data.Models
{
    public class Artikal
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string KratkiOpis { get; set; }
        public int StanjeNaSkladistu { get; set; }
        public int Sifra { get; set; }
        public string Model { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Popust))]
        public int? PopustId { get; set; }

        public Popust? Popust { get; set; }

        [ForeignKey(nameof(Proizvodjac))]
        public int? ProizvodjacId { get; set; }
        public Proizvodjac? Prozivodjac { get; set; }

        [ForeignKey(nameof(ArtikalKategorija))]
        public int? ArtikalKategorijaId { get; set; }
        public ArtikalKategorija? ArtikalKategorija { get; set; }

        [ForeignKey(nameof(Skladiste))]
        public int? SkladisteId { get; set; }
        public Skladiste? Skladiste { get; set; }
    }
}

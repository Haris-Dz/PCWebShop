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

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class StavkaNarudzbe
    {
        [Key]
        public int Id { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey(nameof(Artikal))]
        public int ArtikalId { get; set; }
        public Artikal Artikal { get; set; }

        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public string Komentari { get; set; }
        [ForeignKey(nameof(Kupac))]
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        [ForeignKey(nameof(Artikal))]
        public int ArtikalId { get; set; }
        public Artikal Artikal { get; set; }
    }
}

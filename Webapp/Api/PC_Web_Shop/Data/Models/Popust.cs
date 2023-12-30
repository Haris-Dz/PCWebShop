using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Popust
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumDo { get; set; }
        public DateTime DatumOd { get; set; }
        public float PopustCijena { get; set; }
        public List<Artikal> Artikal { get; set; }
    }
}

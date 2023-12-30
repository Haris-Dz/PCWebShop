using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class ArtikalKategorija
    {
        [Key]
        public int Id { get; set; }
        public string NazivKategorije { get; set; }
    }
}

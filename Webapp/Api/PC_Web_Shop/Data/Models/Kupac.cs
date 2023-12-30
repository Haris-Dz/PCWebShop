using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    [Table("Kupac")]
    public class Kupac:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }

    }
}

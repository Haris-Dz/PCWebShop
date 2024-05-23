using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    [Table("Zaposlenik")]
    public class Zaposlenik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Ulica { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }
        public bool isDeleted { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Skladiste
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kapacitet { get; set; }
        public string Opis { get; set; }
        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }

    }
}

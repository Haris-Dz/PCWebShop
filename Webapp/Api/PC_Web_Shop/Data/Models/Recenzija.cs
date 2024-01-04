using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    public class Recenzija
    {
        [Key]
        public int ID { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum { get; set; }

        [ForeignKey(nameof(Kupac))]
        public int KupacId { get; set; }
        public Kupac Kupac { get; set;}

    }
}

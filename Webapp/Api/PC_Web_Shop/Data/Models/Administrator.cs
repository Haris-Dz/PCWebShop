using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    [Table("Administrator")]
    public class Administrator:KorisnickiNalog
    {
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public virtual List<Poruka> Poruka { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int Id { get; set; }
        public string VrijednostTokena { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
    }
}

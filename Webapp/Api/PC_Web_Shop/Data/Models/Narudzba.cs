using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Narudzba
    {
        [Key]
        public int Id { get; set; }
        public double UkupnaCijena { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public bool Zavrsena { get; set; }
        public int  UkupnoStavki { get; set; }

        [ForeignKey(nameof(Kupac))]
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey(nameof(Zaposlenik))]
        public int? ZaposlenikId { get; set; }
        public Zaposlenik? Zaposlenik { get; set; }

        public virtual List<StavkaNarudzbe>? StavkaNarudzbe { get; set; }
    }
}

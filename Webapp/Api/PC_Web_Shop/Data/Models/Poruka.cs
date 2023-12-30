using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Poruka
    {
        [Key]
        public int Id { get; set; }

        public string Tema { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumSlanja { get; set; }
        public bool Procitano { get; set; }

        [ForeignKey(nameof(Administrator))]
        public int AdministratorId { get; set; }
        public Administrator Administrator { get; set; }

        [ForeignKey(nameof(Zaposlenik))]
        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
    }
}

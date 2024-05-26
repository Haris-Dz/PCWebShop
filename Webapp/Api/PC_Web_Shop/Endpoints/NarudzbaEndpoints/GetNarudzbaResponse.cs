using PC_Web_Shop.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints
{
    public class GetNarudzbaResponse
    {
        public int Id { get; set; }
        public double UkupnaCijena { get; set; }
        public int UkupnoStavki { get; set; }
        public virtual List<StavkaNarudzbe>? StavkaNarudzbe { get; set; }
    }
}

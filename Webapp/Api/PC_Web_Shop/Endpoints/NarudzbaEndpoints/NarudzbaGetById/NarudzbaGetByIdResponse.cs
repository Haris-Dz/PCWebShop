using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaGetById
{
    public class NarudzbaGetByIdResponse
    {
        public int Id { get; set; }
        public double UkupnaCijena { get; set; }
        public int UkupnoStavki { get; set; }
        public virtual List<StavkaNarudzbe>? StavkaNarudzbe { get; set; }
    }
}

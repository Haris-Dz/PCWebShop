using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaGetByIdKupca
{
    public class NarudzbaGetByIdKupcaResponse
    {
        public double UkupnoPlaceno { get; set; }
        public List<NarudzbaGetByIdKupcaResponseNarudzbe> Narudzbe { get; set; }
    }
    public class NarudzbaGetByIdKupcaResponseNarudzbe
    {
        public int Id { get; set; }
        public double UkupnaCijena { get; set; }
        public int UkupnoStavki { get; set; }
        public virtual List<StavkaNarudzbe>? StavkaNarudzbe { get; set; }
        public DateTime DatumKupovine { get; set; }
    }
}

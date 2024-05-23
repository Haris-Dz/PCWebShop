using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.GetByNaziv
{
    public class GetByNazivZaposlenikResponse
    {
        public List<ZaposlenikGetByNazivResponseZaposlenici> Zaposlenik { get; set; }
    }
    public class ZaposlenikGetByNazivResponseZaposlenici
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string SlikaKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojMobitela { get; set; }
        public string Ulica { get; set; }
        public string Email { get; set; }
        public Grad Grad { get; set; }
    }

}

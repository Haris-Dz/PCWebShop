using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Endpoints.ArtikalEndpoints.GetAll;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByKategorija
{
    public class GetByKategorijaResponse
    {
        public List<GetByKategorijaResponseKategorije> Artikal { get; set; }

    }

    public class GetByKategorijaResponseKategorije
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string KratkiOpis { get; set; }
        public int StanjeNaSkladistu { get; set; }
        public string SlikaArtikla { get; set; }
        public int Sifra { get; set; }
        public string Model { get; set; }
        public Popust Popust { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public ArtikalKategorija ArtikalKategorija { get; set; }
        public Skladiste Skladiste { get; set; }

    }
}
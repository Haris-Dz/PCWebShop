using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetAll
{
    public class ArtikalGetAllResponse
    {
        public List<ArtikalGetAllResponseArtikal> Artikal { get; set; }
    }

    public class ArtikalGetAllResponseArtikal
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
        public int? PopustId { get; set; }
        public Popust Popust {get; set; }
        public int? ProizvodjacId { get; set; }
        public Proizvodjac Proizvodjac { get; set;}
        public int? ArtikalKategorijaId { get; set; }
        public ArtikalKategorija ArtikalKategorija { get; set; }
        public Skladiste Skladiste { get; set;}
    }
}

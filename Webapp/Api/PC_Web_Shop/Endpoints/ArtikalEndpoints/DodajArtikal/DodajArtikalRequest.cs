using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.DodajArtikal
{
    public class DodajArtikalRequest
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string KratkiOpis { get; set; }
        public int StanjeNaSkladistu { get; set; }
        public int Sifra { get; set; }
        public string Model { get; set; }

        public int? PopustId { get; set; }

        public int? ProizvodjacId { get; set; }
        public int? ArtikalKategorijaId { get; set; }

        public int? SkladisteId { get; set; }
        public string? Slika_base64_format { get; set; }
    }
}

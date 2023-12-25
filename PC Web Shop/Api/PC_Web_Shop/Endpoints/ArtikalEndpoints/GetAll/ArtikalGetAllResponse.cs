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
        public int Sifra { get; set; }
        public string Model { get; set; }
    }
}

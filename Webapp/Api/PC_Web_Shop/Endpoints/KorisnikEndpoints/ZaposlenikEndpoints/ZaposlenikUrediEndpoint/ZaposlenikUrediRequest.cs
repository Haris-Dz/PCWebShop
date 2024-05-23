namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikUrediEndpoint
{
    public class ZaposlenikUrediRequest
    {
        public int Id { get; set; }
      
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Ulica { get; set; }
        public string BrojMobitela { get; set; }
        public int GradId { get; set; }
    }
}

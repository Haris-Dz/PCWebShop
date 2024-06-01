namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.KupacGetAll
{
    public class KupacGetAllResponse
    {
        public List<KupacGetAllResponseKupci> Kupci { get; set; }
    }
}

public class KupacGetAllResponseKupci
{
    public int Id { get; set; }
    public string KorisnickoIme { get; set; }
    public string SlikaKorisnika { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Email { get; set; }
    public string BrojMobitela { get; set; }
    public int GradId { get; set; }
}

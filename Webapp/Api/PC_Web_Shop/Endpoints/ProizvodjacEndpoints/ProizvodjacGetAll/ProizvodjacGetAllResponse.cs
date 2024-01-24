namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacGetAll
{
    public class ProizvodjacGetAllResponse
    {
        public List<ProizvodjacGetAllResponseProizvodjac> Proizvodjaci { get; set; }
    }

    public class ProizvodjacGetAllResponseProizvodjac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}

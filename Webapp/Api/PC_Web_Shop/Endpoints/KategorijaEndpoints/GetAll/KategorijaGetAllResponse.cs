namespace PC_Web_Shop.Endpoints.KategorijaEndpoints.GetAll
{
    public class KategorijaGetAllResponse
    {
        public List<KategorijaGetAllResponseKategorije> Kategorije { get; set; }
    }

    public class KategorijaGetAllResponseKategorije
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

    }
}

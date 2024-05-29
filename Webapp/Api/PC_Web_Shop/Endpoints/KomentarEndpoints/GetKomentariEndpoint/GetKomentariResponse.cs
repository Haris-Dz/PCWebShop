using PC_Web_Shop.Data.Models;

namespace PC_Web_Shop.Endpoints.KomentarEndpoints.GetKomentariEndpoint
{
    public class GetKomentariResponse
    {
        public List<KomentariGetKomentariResponse> Komentari { get; set; }
    }

    public class KomentariGetKomentariResponse
    {
        public string Komentari { get; set; }
        public string korisnickoIme {get; set;}
    }
}

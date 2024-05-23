using PC_Web_Shop.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikDodajEndpoint
{
    public class ZaposlenikDodajRequest
    {
        public string KorisnickoIme { get; set; }
        public string? Slika_base64_format { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Ulica { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }
        public int GradId { get; set; }
    }
}

using PC_Web_Shop.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.GetByIdKupacEndpoint
{
    public class GetByIdKupacResponse
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
}

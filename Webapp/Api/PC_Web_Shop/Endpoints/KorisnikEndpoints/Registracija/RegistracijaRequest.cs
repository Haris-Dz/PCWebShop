using PC_Web_Shop.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Registracija
{
    public class RegistracijaRequest
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string SlikaKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }
        public int GradId { get; set; }
    }
}

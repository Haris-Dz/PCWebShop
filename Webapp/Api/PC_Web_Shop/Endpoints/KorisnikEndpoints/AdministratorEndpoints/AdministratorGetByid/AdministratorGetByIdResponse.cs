using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.AdministratorEndpoints.AdministratorGetByid
{
    public class AdministratorGetByIdResponse
    {
       public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string SlikaKorisnika { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}

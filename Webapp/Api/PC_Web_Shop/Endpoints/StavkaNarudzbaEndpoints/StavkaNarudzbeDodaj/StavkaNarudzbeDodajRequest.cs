using PC_Web_Shop.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Endpoints.StavkaNarudzbaEndpoints.StavkaNarudzbeDodaj
{
    public class StavkaNarudzbeDodajRequest
    {
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public int ArtikalId { get; set; }
        public int NarudzbaId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Grad
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool IsDeleted { get; set; }
    }
}

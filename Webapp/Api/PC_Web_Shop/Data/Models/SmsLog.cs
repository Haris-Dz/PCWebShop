using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class SmsLog
    {
        [Key]
        public int Id { get; set; }
        public string Broj { get; set; }
        public string Poruka { get; set; }

    }
}

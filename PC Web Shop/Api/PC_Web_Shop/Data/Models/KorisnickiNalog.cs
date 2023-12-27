﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Web_Shop.Data.Models
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key] public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string SlikaKorisnika { get; set; }
        public bool isAdmin { get; set; }
        public bool isZaposlenik { get; set; }
        public bool isKupac { get; set; }
    }
}

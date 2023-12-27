﻿using System.ComponentModel.DataAnnotations;

namespace PC_Web_Shop.Data.Models
{
    public class Proizvodjac
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Artikal> Artikli { get; set; }
    }
}

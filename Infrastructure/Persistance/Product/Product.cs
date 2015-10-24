﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistance.Product
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
    }
}
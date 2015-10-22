﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Shop
{
    //TODO: inheritance
    public class ShopAddress
    {
        [Key, ForeignKey("Shop")]
        public string ShopCode { get; set; }
        
        public Shop Shop { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

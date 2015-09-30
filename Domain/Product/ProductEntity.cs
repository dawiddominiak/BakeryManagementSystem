﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product
{
    public class ProductEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TaxRate TaxRate { get; set; }
    }
}
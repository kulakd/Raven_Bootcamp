﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven
{
    public class Product
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public float PricePerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
        public int ReorderLevel { get; set; }
    }
}

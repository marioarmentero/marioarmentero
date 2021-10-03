using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{  
    public partial class ShippingHeader
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string CodVendor { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public int? Customer { get; set; }
        public Decimal Amount { get; set; }
    }
}

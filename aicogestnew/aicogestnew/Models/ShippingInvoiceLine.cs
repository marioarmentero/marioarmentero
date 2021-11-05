using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{
   public class ShippingInvoiceLine
    {
        public int Id { get; set; }
        public string DocumentNo { get; set; }
        public string Line { get; set; }
        public string Item { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
    }
}

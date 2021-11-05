using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{
    public class ItemPurchasePrice
    {
        public int id { get; set; }
        public int itemid { get; set; }
        public decimal price { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public string Codvendor { get; set; }
    }
}

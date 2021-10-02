using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Codvendor { get; set; }
        public string VendorName { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cif { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Provincia { get; set; }
        public string Cp { get; set; }
        public int? Empresa { get; set; }
    
}
}

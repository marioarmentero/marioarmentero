using System;
using System.Collections.Generic;
using System.Text;

namespace aicogestnew.Models
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Nombreempresa { get; set; }
        public string Cif { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Cp { get; set; }
        public string Provincia { get; set; }
        public string Emailcomercial { get; set; }
        public string Emailfacturacion { get; set; }
        public string Telefono { get; set; }
        public string Movil { get; set; }
        public string Cuentacotizacion { get; set; }
        public byte[] Logo { get; set; }
    }
}

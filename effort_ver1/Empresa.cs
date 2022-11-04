using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace effort_ver1
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public int Cuit { get; set; }
        public string RazonSocial {get; set; }
        public string Calle {get; set; }
        public int NumCalle { get; set; }
        public int Cp { get; set; }
        public string Localidad { get; set; }

    }
}
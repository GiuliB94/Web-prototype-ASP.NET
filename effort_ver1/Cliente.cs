using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace effort_ver1
{
    public class Cliente
    {
        public int IdUser { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int IdEmpresa { get; set; }
        public string email { get; set; }   
        public string telefono { get; set; }

    }
}
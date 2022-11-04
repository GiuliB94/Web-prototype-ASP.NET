using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace effort_ver1
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string talle { get; set; }
        public Material materiales { get; set; }
        public string color { get; set; }
    }
}
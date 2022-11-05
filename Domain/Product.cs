using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public List<Material> materialsUsed { get; set; }
        public string color { get; set; }
    }
}
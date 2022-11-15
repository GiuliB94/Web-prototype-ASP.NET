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
        public int size { get; set; }
        //public List<Material> materialsUsed { get; set; }
        public string color { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
    }
}
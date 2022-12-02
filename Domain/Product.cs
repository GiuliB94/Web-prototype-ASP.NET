using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public bool State { get; set; }
        public string ImageUrl { get; set; }
        
        
    }
}
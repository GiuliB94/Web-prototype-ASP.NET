using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class OrderElement
    {
        public int IdOrder { get; set; }
        public int LineItem { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Quantity { get; set; }
        public string Comment { get; set; }
    }
}

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
        public decimal Quantity { get; set; }
        public string Comment { get; set; }
    }
}

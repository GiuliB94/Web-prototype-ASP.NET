using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class OrderElement
    {
        public int idOrder { get; set; }
        public int lineItem { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
    }
}

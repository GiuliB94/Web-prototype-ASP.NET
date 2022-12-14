using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ItemAux
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int IdSize { get; set; }
        public string Size { get; set; }
        public int IdColor { get; set; }
        public string Color { get; set; }
        public string Comment { get; set; }
        public decimal LineCost { get; set; }
    }
}

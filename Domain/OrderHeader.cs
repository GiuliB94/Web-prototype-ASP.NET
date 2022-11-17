using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class OrderHeader
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int idClient { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; } // Cuales serian los estados?  -> Deberian nacer con un estado fijo. Ej: En proceso? / En espera de aprobación? -> Se aprueban? 
    }
}

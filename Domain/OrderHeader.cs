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

        public OrderHeader CreateOrder()
        {
            OrderHeader aux = new OrderHeader();

            aux.id = 0; //Aca podria nacer en 0 y despues cuando se acepta la orden se pone el numero real del pedido?
            aux.orderDate = new DateTime();
            aux.idClient = 0; //Tomar el ID de la sesion iniciada
            aux.amount = 0;
            aux.status = "En proceso";
            return aux;
        }
    }
}

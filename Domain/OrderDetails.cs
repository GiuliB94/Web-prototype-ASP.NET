using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }
        public int IdCompany { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; } // Cuales serian los estados?  -> Deberian nacer con un estado fijo. Ej: En proceso? / En espera de aprobación? -> Se aprueban? 

        public OrderDetails CreateOrder()
        {
            OrderDetails aux = new OrderDetails();

            aux.ID = 0; //Aca podria nacer en 0 y despues cuando se acepta la orden se pone el numero real del pedido?
            aux.OrderDate = new DateTime().Date; 
            aux.DeliveryDate = new DateTime(); //Fecha indicada por el cliente?
            aux.StatusUpdateDate = new DateTime();
            aux.IdCompany = 0; //Tomar el ID de la sesion iniciada
            aux.TotalAmount = 0;
            aux.Status = 0;
            return aux;
        }
    }
}

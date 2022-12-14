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
        public string CompanyName { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; } // Cuales serian los estados?  -> Deberian nacer con un estado fijo. Ej: En proceso? / En espera de aprobación? -> Se aprueban? 
        public string StatusDescription { get; set; }
        public decimal TotalCost { get; set; }

        public OrderDetails()
        {
            ID = 0; //Aca podria nacer en 0 y despues cuando se acepta la orden se pone el numero real del pedido?
            OrderDate = DateTime.Today;
            DeliveryDate = DateTime.Today; //Fecha indicada por el cliente?
            StatusUpdateDate = DateTime.Today;
            IdCompany = 0; //Tomar el ID de la sesion iniciada
            TotalAmount = 0;
            Status = 0;
            TotalCost = 0;
        }
    }
}

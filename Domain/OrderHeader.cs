using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    internal class OrderHeader
    {
        int id;
        DateTime orderDate;
        DateTime deliveryDate;
        int idClient;
        int amount;
        string status; // Cuales serian los estados?  -> Deberian nacer con un estado fijo. Ej: En proceso? / En espera de aprobación? -> Se aprueban? 
    }
}

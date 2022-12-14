using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CostXProduct
    {
        public int IdProduct { get; set; }
        public decimal Material { get; set; }
        public decimal Box { get; set; }
        public decimal Color { get; set; }
        public decimal Bag { get; set; }
        public decimal Handwork { get; set; }
        public decimal TotalCostxProduct { get; set; }
        public decimal TotalCost { get; set; }
    }
}

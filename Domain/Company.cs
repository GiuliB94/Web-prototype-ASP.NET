using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Company
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string CUIT { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressExtra { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
    }
}
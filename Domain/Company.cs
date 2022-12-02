using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Company
    {
        public int id { get; set; }
        public string cuit { get; set; }
        public string companyName {get; set; }
        public string streetName {get; set; }
        public int streetNumber { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }

    }
}
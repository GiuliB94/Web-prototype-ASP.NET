using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName {get; set; }
        public string password { get; set; }
        public int idCompany { get; set; }
        public string email { get; set; }   
        public string phone { get; set; }
        public int category { get; set; }

    }
}
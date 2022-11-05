using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Client
    {
        public int IdUser { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int IdCompany { get; set; }
        public string email { get; set; }   
        public string phone { get; set; }

    }
}
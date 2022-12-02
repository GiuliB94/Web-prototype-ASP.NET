using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Client
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string name { get; set; }
        public string lastName {get; set; }
        public string phone { get; set; } 
        public string province { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string dni { get; set; }
        public bool state { get; set; }

    }
}
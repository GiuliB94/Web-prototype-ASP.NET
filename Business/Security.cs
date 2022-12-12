using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class Security
    {
        public static User User { get; set; }
        public static bool ActiveSession(object userActive)
        {
            //User user = userActive != null ? (User)userActive : null;
            if(!(User != null && User.Permission != 0)){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

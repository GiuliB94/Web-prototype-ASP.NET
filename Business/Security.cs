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
        public static bool ActiveSession(object userActive)
        {
            User user = userActive != null ? (User)userActive : null;
            if(!(user != null && user.Permission != 0)){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

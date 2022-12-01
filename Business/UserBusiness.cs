using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;

namespace Business
{
    public class UserBusiness
    {
        public bool LogIn(User user)
        {
            AccessData accessData = new AccessData();
            try
            {
                accessData.setQuery("SELECT Id, userPermission FROM Users where userEmail = @Email AND pwd = @pwd;");
                accessData.SetParameter("@user", user.UserEmail);
                accessData.SetParameter("@pwd", user.Password);

                accessData.executeQuery();
                while (accessData.Reader.Read())
                {
                    user.Id = (int)accessData.Reader["Id"];
                    user.Permission = (UserPermission)accessData.Reader["userPermission"];
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}

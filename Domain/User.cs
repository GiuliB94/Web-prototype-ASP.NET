using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum UserPermission
    {
        ADMIN = 0,
        CLIENT1,
        CLIENT2,
        CLIENT3
    }
    public class User
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public UserPermission Permission { get; set; }

        public User( string userEmail, string password, int permission)
        {
            UserEmail = userEmail;
            Password = password;
            Permission = (UserPermission)permission;
        }
    }
}

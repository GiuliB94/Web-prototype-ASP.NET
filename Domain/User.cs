using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public User()
        {
            Id = -1;
            Email = string.Empty;
            Password = string.Empty;
            Permission = -1;
            IsActive = false;
        }
    }
}
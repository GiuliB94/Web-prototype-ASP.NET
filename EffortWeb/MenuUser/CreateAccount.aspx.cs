using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Data;

namespace effort_ver1.MenuUser
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserData aux = new UserData();
            User newUser = new User();
            newUser.email = TxtEmail.Text;
            newUser.password = TxtPass.Text;
            newUser.permission = 0;
            newUser.state = true;
            aux.Add(newUser);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;

namespace effort_ver1.MenuUser
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserBusiness aux = new UserBusiness();
            User newUser = new User();
            newUser.Email = TxtEmail.Text;
            newUser.Password = TxtPass.Text;
            newUser.Permission = 0;
            newUser.State = true;
            aux.Add(newUser);
        }
    }
}
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1.MenuUser
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPass.Text;

            UserData aux = new UserData();
            User user = new User();

            user = aux.CheckLogIn(email, password);
            if (user.state == true)
            {
                this.Session["UserId"] = user.id;
                if (user.permission == 1)
                {
                    Response.Redirect("../MenuAdmin/PriceList.aspx");
                }
                else 
                {
                    Response.Redirect("../MenuUser/Home.aspx");
                }
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuUser/CreateAccount.aspx");
        }
    }
}
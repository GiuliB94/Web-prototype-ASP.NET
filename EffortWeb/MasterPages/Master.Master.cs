using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MasterPages
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            //    string email = TxtEmail.Text;
            //    string password = TxtPass.Text;

            //    UserBusiness userBusiness = new UserBusiness();
            //    User user = new User();
            //    user = userBusiness.GetUser(email, password);
            //    if (user.State == true)
            //    {
            //        this.Session["UserId"] = user.Id;
            //        if (user.Permission == 1)
            //        {
            //            Response.Redirect("../MenuAdmin/PriceList.aspx");
            //        }
            //        else
            //        {
            //            Response.Redirect("../MenuUser/Home.aspx");
            //        }
            //    }
            //    else
            //    {
            //        ValidationText.Visible = true;
            //        ValidationTimer.Enabled = true;
            //        TxtPass.Text = "";
            //    }
            }
        }
}
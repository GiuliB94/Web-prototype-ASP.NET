using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*ProductBusiness
OrderDetailsBusiness
OrderElementBusiness

Domain/
OrderDetails
Products
OrderElementBusiness*/

namespace EffortWeb.MasterPages
{
    
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ValidationText.Visible = false;
                ValidationTimer.Enabled = false;
            }
        }

   
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPass.Text;
            UserBusiness userBusiness = new UserBusiness();
            User user = new User();
            user = userBusiness.GetUser(email, password);
            if (user != null)
            {
                this.Session["User"] = user;
                this.Session["UserEmail"] = user.Email;
                this.Session["UserPermission"] = user.Permission;
                Response.Redirect("../Menu/Home.aspx", false);
            }
            else
            {
                //btnLogIn.OnClientClick = "return false";
                ValidationText.Visible = true;
                ValidationTimer.Enabled = true;
                TxtPass.Text = "";
                
            }
        }
        protected void ValidationTimer_Tick(object sender, EventArgs e)
        {
            ValidationText.Visible = false;
            ValidationTimer.Enabled = true;
        }
    }
}
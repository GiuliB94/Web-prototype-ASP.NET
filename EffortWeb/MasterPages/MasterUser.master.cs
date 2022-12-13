using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MasterPages
{
    public partial class MasterUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                //DataTable table = (DataTable)Session["Cart"];
                //CartProductsCount.Text = (table.Rows.Count).ToString();
            }
        }
        protected void CartButtom_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("../MenuUser/Cart.aspx");
        }
    }
}
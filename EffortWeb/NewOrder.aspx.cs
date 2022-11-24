using Data;
using Domain;
using EffortWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1
{
    public partial class NewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderHeader newOrderHeader = new OrderHeader();
            //List<OrderElement> elementsList = new List<OrderElement>();
            if (Session["newOrder"] == null)
            {
                List<Product> productList = new List<Product>();
                Session.Add("newOrder", productList);
            }
            dgvOrderElementList.DataSource = (List<Product>)Session["newOrder"];
            dgvOrderElementList.DataBind();

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx?newOrder=addProduct");
        }
    }
}
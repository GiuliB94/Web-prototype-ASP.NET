using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1.MenuAdmin
{
    public partial class AllOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderList"] == null)
            {
                OrderList OrderList = new OrderList();
                Session.Add("OrderList", OrderList.Show());
            }

            dgvAllOrders.DataSource = Session["OrderList"];
            dgvAllOrders.DataBind();
        }

        protected void dgvAllOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var idSelected = dgvMyOrders.SelectedDataKey.Value.ToString();
            //Response.Redirect("OrderProducts.aspx?Order=" + idSelected);
        }
    }
}
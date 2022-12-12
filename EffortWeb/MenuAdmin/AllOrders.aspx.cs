using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MenuAdmin
{
    public partial class AllOrders : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if ((int)Session["UserPermission"] != 0) Response.Redirect("~/Menu/Home.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderBusiness"] == null)
            {
                OrderHeaderBusiness OrderList = new OrderHeaderBusiness();
                Session.Add("OrderBusiness", OrderList.Show());
            }

            dgvAllOrders.DataSource = Session["OrderBusiness"];
            dgvAllOrders.DataBind();
        }

        protected void dgvAllOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var idSelected = dgvMyOrders.SelectedDataKey.Value.ToString();
            //Response.Redirect("OrderProducts.aspx?Order=" + idSelected);
        }
    }
}
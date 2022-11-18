using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderList myOrderList = new OrderList();
            dgvMyOrders.DataSource = myOrderList.Show();
            dgvMyOrders.DataBind();
        }

        protected void dgvMyOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderElementList myOrderElementsList = new OrderElementList();
            dgvMyOrders.DataSource = myOrderElementsList.Show();
            dgvMyOrders.DataBind();
        }
    }
}
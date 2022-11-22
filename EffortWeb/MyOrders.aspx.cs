﻿using Data;
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
            if (Session["myOrderList"] == null) 
            {
                OrderList myOrderList = new OrderList();
                Session.Add("myOrderList", myOrderList.Show());
            }

            dgvMyOrders.DataSource = Session["myOrderList"];
            dgvMyOrders.DataBind();
        }

        protected void dgvMyOrders_SelectedIndexChanged(object sender, EventArgs e)
        {   
            var idSelected = dgvMyOrders.SelectedDataKey.Value.ToString();
            Response.Redirect("OrderProducts.aspx?Order=" + idSelected);
        }
    }
}
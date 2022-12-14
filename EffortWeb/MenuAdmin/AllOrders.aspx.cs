using Business;
using Domain;
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
            dgvCostDetails.Visible = false;
            dgvOrderElements.Visible = false;
            if (Session["OrderBusiness"] == null)
            {
                OrderDetailsBusiness OrderList = new OrderDetailsBusiness();
                Session.Add("OrderBusiness", OrderList.Show());
            }

            dgvAllOrders.DataSource = Session["OrderBusiness"];
            dgvAllOrders.DataBind();
        }



    protected void dgvAllOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrderElements.Visible = true;
            dgvCostDetails.Visible = false;
            dgvAllOrders.Visible = false;
            int idSelected = (int)dgvAllOrders.SelectedDataKey.Value;
            OrderElementBusiness aux = new OrderElementBusiness();
            List <OrderElement> orderElementsList = aux.Show(idSelected);
            dgvOrderElements.DataSource = orderElementsList;
            dgvOrderElements.DataBind();
        }

        protected void dgvOrderElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrderElements.Visible = false;
            dgvCostDetails.Visible = true;
            dgvAllOrders.Visible = false;

            int idSelected = (int)dgvOrderElements.SelectedDataKey.Value;
            CostBusiness aux = new CostBusiness();
            List<CostXProduct> list = new List<CostXProduct>();

            list = aux.GetCostForProduct(idSelected);
            dgvCostDetails.DataSource = list;
            dgvCostDetails.DataBind();
        }
    }
}
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1
{
    public partial class OrderProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["Order"]); //Obtengo el ID
            lblOrderN.Text = "Pedido N° " + id;

            OrderElementList orderElementList = new OrderElementList();
            if (Session["orderElementList" + id] == null)
            {
                Session.Add("orderElementList" + id, orderElementList.Show(id));
            }
            dgvOrderProducts.DataSource = Session["orderElementList" + id];
            dgvOrderProducts.DataBind();
        }

        protected void dgvOrderProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idSelected = dgvOrderProducts.SelectedDataKey.Value.ToString();
            var idOrder = dgvOrderProducts.SelectedRow.Cells[0].Text;
            Response.Redirect("ProductForm.aspx?productID=" + idSelected + "&Order=" + idOrder);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace EffortWeb
{
	public partial class Products : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["productList"] == null)
            {
                ProductList productList = new ProductList();
                Session.Add("productList", productList.Show());
            }

            dgvProducts.DataSource = Session["productList"];
            dgvProducts.DataBind();
        }

		protected void btnAddProduct_Click(object sender, EventArgs e)
		{
            Response.Redirect("ProductForm.aspx");
        }
	}
}
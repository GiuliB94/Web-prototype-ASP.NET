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
			ProductList productList = new ProductList();
			dgvProducts.DataSource = productList.Show();
			dgvProducts.DataBind();
        }
	}
}
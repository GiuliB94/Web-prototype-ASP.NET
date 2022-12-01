using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1.MenuUser
{
    public partial class Catalog : System.Web.UI.Page
    {
        public List<Product> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["productList"] == null)
                {
                    ProductBusiness list = new ProductBusiness();
                    ListaProductos = list.Show();

                }
                else
                {
                    ListaProductos = (List<Product>)Session["productList"];
                }

                ListView1.DataSource = ListaProductos;
                ListView1.DataBind();
            }
        }

        protected void btn_AddProduct_Click(object sender, EventArgs e)
        {
            string idSelected = ((Button)sender).CommandArgument;

        }
    }
}
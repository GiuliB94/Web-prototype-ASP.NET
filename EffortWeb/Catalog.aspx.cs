using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace effort_ver1
{
    public partial class Catalog : System.Web.UI.Page
    {
        public List<Product> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productList"] == null)
            {
                ProductList list = new ProductList();
                ListaProductos = list.Show();

            }
            else
            {
                ListaProductos = (List<Product>)Session["productList"];
            }
        }
    }
}
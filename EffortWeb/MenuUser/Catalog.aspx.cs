using Business;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

                ListView.DataSource = ListaProductos;
                ListView.DataBind();

                if (Session["Cart"] == null)
                {
                    createCart();
                }
            }
        }

        protected void createCart()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Fecha", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("IdProduct", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("NameProduct", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("UnitPrice", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Quantity", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            Session["Cart"] = dt;
        }

        protected void Events(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "AddProduct")
            {
                string idSelected = e.CommandArgument.ToString();
                ProductBusiness aux = new ProductBusiness();
                Product product = aux.GetProduct(Convert.ToInt16(idSelected));

                DataTable table = (DataTable)Session["Cart"];
                DataRow dr = table.NewRow();

                dr[0] = DateTime.Today.ToShortDateString();
                dr[1] = idSelected;
                dr[2] = product.Name;
                dr[3] = product.Price;
                dr[4] = 1;

                table.Rows.Add(dr);
                Session["Cart"] = table;
            }
        }
    }
}
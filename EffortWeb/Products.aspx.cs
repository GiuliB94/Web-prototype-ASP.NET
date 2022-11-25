using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Domain;

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

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var idSelected = dgvProducts.SelectedDataKey.Value.ToString();
            Response.Redirect("ProductForm.aspx?productID=" + idSelected);
        }


        /*public void dgvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            if(commandName == "AgregarProducto")
            {
                int selectedId = 3;

                List<Product> temporalList = (List<Product>)Session["productList"];
                Product selected = temporalList.Find(x => x.id == selectedId);


                if (Session["newOrder"] != null)
                { 
                    List<Product> list = (List<Product>)Session["newOrder"];
                    list.Add(selected);
                    Session.Add("newOrder", list);
                    Response.Redirect("NewOrder.aspx?productID=");

                }
            }
            else
            {
                var idSelected = dgvProducts.SelectedDataKey.Value.ToString();
                Response.Redirect("ProductForm.aspx?productID=" + idSelected);
            }
        }*/
    }
}
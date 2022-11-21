using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnModProduct.Visible = false;
            btnDeleteProduct.Visible = false;

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Product> temportalList = (List<Product>)Session["productList"];
                Product selected = temportalList.Find(x => x.id == id);

                txtId.Text = id.ToString();
                txtId.ReadOnly = true;
                txtName.Text = selected.name;
                txtDescription.Text = selected.description;
                txtDescription.Text = selected.description;
                txtSize.Text = selected.size.ToString();
                txtColor.Text = selected.color;
                txtPrice.Text = selected.price.ToString();

                btnModProduct.Visible = true;
                btnDeleteProduct.Visible = true;
                btnAddProduct.Visible = false;

            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product();
            newProduct.id = 0001; //Hacer que se genere automaticamente en la bd
            newProduct.name = txtName.Text;
            newProduct.description = txtDescription.Text;
            newProduct.size = int.Parse(txtSize.Text);
            newProduct.color = txtColor.Text;  
            newProduct.price = int.Parse(txtPrice.Text);

            List<Product> temportalList = (List<Product>)Session["productList"];
            temportalList.Add(newProduct);

            //Si se viene desde el agregar, oculto los botones.

            Response.Redirect("Default.aspx");
        }

        protected void btnModProduct_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
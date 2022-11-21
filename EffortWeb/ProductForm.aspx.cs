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

            ((List<Product>)Session["productList"]).Add(newProduct);
            Response.Redirect("Default.aspx");
        }
    }
}
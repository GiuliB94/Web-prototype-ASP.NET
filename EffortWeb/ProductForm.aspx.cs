using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace effort_ver1
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnModProduct.Visible = false;
            btnDeleteProduct.Visible = false;
            lblProducto.Text = "Nuevo producto"; 

            //Verifica que haya ID de producto en la URL    
            if (Request.QueryString["productID"] != null) 
            {
                lblDetails.Visible = false;
                lblProducto.Text = "Detalles";

                int id = int.Parse(Request.QueryString["productID"]); 
                if (Session["productList"] == null)
                {
                    ProductList productList = new ProductList();
                    Session.Add("productList", productList.Show());
                }
                
                List<Product> temporalList = (List<Product>)Session["productList"];
                Product selected = temporalList.Find(x => x.id == id);
                //Carga los campos 
                txtId.Text = id.ToString();
                txtId.ReadOnly = true;
                txtName.Text = selected.name;
                txtDescription.Text = selected.description;
                txtSize.Text = selected.size.ToString();
                txtColor.Text = selected.color;
                txtPrice.Text = selected.price.ToString();
                //Visibilidad de botones
                btnModProduct.Visible = true;
                btnDeleteProduct.Visible = true;
                btnAddProduct.Visible = false;

                //Si el producto es de una orden, seteo campos en read only
                if (Request.QueryString["Order"] != null)
                {
                    txtName.ReadOnly = true;
                    txtDescription.ReadOnly = true;
                    txtSize.ReadOnly = true;
                    txtColor.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    btnModProduct.Visible = false;
                    btnDeleteProduct.Visible = false;
                }

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
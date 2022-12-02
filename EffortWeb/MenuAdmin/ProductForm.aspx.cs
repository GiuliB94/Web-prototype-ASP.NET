﻿using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace effort_ver1.MenuAdmin
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnModProduct.Visible = false;
            btnDeleteProduct.Visible = false;
            lblProducto.Text = "Nuevo producto";

            txtName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtSize.ReadOnly = true;
            txtColor.ReadOnly = true;
            txtPrice.ReadOnly = true;

            BtnAccept.Visible = false;

            //Verifica que haya ID de producto en la URL    
            if (Request.QueryString["productID"] != null)
            {
                lblDetails.Visible = false;
                lblProducto.Text = "Detalles";

                int id = int.Parse(Request.QueryString["productID"]);
                if (Session["productList"] == null)
                {
                    ProductBusiness productList = new ProductBusiness();
                    Session.Add("productList", productList.Show());
                }

                List<Product> temporalList = (List<Product>)Session["productList"];
                Product selected = temporalList.Find(x => x.Id == id);
                //Carga los campos 
                if (!IsPostBack)
                {
                    txtId.Text = id.ToString();
                    txtId.ReadOnly = true;
                    txtName.Text = selected.Name;
                    txtDescription.Text = selected.Description;
                    txtSize.Text = selected.Size.ToString();
                    txtColor.Text = selected.Color;
                    txtPrice.Text = selected.Price.ToString();
                }

                //Visibilidad de botones
                btnModProduct.Visible = true;
                btnDeleteProduct.Visible = true;
                btnAddProduct.Visible = false;

                ////Si el producto es de una orden, seteo campos en read only
                if (Request.QueryString["Order"] != null)
                {
                    //    txtName.ReadOnly = true;
                    //    txtDescription.ReadOnly = true;
                    //    txtSize.ReadOnly = true;
                    //    txtColor.ReadOnly = true;
                    //    txtPrice.ReadOnly = true;
                    btnModProduct.Visible = false;
                    btnDeleteProduct.Visible = false;
                }

            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product();
            newProduct.Id = 0001; //Hacer que se genere automaticamente en la bd
            newProduct.Name = txtName.Text;
            newProduct.Description = txtDescription.Text;
            newProduct.Size = int.Parse(txtSize.Text);
            newProduct.Color = txtColor.Text;
            newProduct.Price = int.Parse(txtPrice.Text);

            List<Product> temportalList = (List<Product>)Session["productList"];
            temportalList.Add(newProduct);

            //Si se viene desde el agregar, oculto los botones.

            Response.Redirect("../MenuAdmin/PriceList.aspx");
        }

        protected void btnModProduct_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtDescription.ReadOnly = false;
            txtSize.ReadOnly = false;
            txtColor.ReadOnly = false;
            txtPrice.ReadOnly = false;

            BtnAccept.Visible = true;

        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            ProductBusiness temportalList = new ProductBusiness();
            Product ChangedProduct = new Product();
            ChangedProduct.Id = int.Parse(txtId.Text); //Hacer que se genere automaticamente en la bd
            ChangedProduct.Name = txtName.Text;
            ChangedProduct.Description = txtDescription.Text;
            ChangedProduct.Size = int.Parse(txtSize.Text);
            ChangedProduct.Color = txtColor.Text;
            ChangedProduct.Price = decimal.Parse(txtPrice.Text);



            temportalList.Modify(ChangedProduct);
            Session["productList"] = null;

        }
    }
}
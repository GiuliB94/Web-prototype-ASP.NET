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
        public bool FilteredPrice { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {   
            if(FilterDDown.SelectedItem.ToString() == "Precio")
            {
                FilteredPrice = true;
            }
            else
            {
                FilteredPrice = false;
            }
            if (!IsPostBack)
            {
                
                if (Session["productList"] == null)
                {
                    ProductBusiness list = new ProductBusiness();
                    ListaProductos = list.Show();
                    Session.Add("productList", ListaProductos);

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

        //protected void filter_TextChanged(object sender, EventArgs e)
        //{
        //    List<Product> ProductList = (List<Product>)Session["productList"];
        //    List<Product> FilteredProductList = ProductList.FindAll(x => x.name.ToUpper().Contains(filter.Text.ToUpper()));
        //    ListView1.DataSource= FilteredProductList;
        //    ListView1.DataBind();
        //}

        protected void FilterDDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterDDown.SelectedItem.ToString() == "Precio" && IsPostBack)
            {
                FilteredPrice=true;
            }
            else
            {
                FilteredPrice = false;
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ProductBusiness list = new ProductBusiness();
                ListView1.DataSource = list.Filter(FilterDDown.SelectedItem.ToString(), FilterPrice.SelectedItem.ToString(), filter.Text);
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}
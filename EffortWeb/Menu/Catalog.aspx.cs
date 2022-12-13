using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;

namespace EffortWeb.Menu
{
    public partial class Catalog : System.Web.UI.Page
    {
        public List<Product> ListaProductos { get; set; }
        public bool FilteredPrice { get; set; }
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["MasterPageString"] != null) this.MasterPageFile = Session["MasterPageString"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (FilterDDown.SelectedItem.ToString() == "Precio")
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

                }
                else
                {
                    ListaProductos = (List<Product>)Session["productList"];
                }

                ListView.DataSource = ListaProductos;
                ListView.DataBind();
            }
        }

        protected new void Events(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "AddProduct")
            {
                string idSelected = e.CommandArgument.ToString();
                ProductBusiness aux = new ProductBusiness(); //Abro conexion
                Product product = aux.GetProduct(Convert.ToInt16(idSelected)); //Obtengo el producto
                                                                               //OrderElement item = new OrderElement();
                /*  LineItem smallint,
                IdOrder int, //Cuando creo la orden, con un foreach les pongo a todos.
                IdProduct int,
                Quantity int,*/
                //List<OrderElement> itemsList = new List<OrderElement>();
                List<ItemAux> itemsCart = (List<ItemAux>)Session["Cart"];
                if (itemsCart == null)
                {
                    itemsCart = new List<ItemAux>();
                }
                ItemAux item = new ItemAux();
                item.IdProduct = product.Id;
                item.ProductName = product.Name;
                item.UnitPrice = product.Price;
                //Buscar si el producto ya esta en la lista
                ItemAux itemListed = itemsCart.Find(x => x.IdProduct == item.IdProduct);
                if (itemListed != null)
                {
                    itemListed.Quantity++;
                    itemListed.TotalAmount = itemListed.Quantity * itemListed.UnitPrice;
                }
                else
                {
                    item.Quantity = 1; //Averiguar como obtener ese numero.
                    item.TotalAmount = item.UnitPrice;
                    itemsCart.Add(item);
                }
                Session["Cart"] = itemsCart;
                Response.Redirect("../Menu/Catalog.aspx");
            }
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
                FilteredPrice = true;
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
                //ListView1.DataSource = list.Filter(FilterDDown.SelectedItem.ToString(), FilterPrice.SelectedItem.ToString(), filter.Text);
                //ListView1.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void Btn_Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuUser/Cart.aspx");
        }
    }
}
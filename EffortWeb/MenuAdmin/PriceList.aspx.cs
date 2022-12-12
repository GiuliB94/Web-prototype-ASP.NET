using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MenuAdmin
{
    public partial class PriceList : System.Web.UI.Page
    {
        public bool FilteredPrice { get; set; }
        void Page_PreInit(Object sender, EventArgs e)
        {
            if ((int)Session["UserPermission"] != 0) Response.Redirect("~/Menu/Home.aspx");
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
            if (Session["productList"] == null)
            {
                ProductBusiness productList = new ProductBusiness();
                Session.Add("productList", productList.Show());
            }
            dgvProducts.DataSource = Session["productList"];
            dgvProducts.DataBind();
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Session.Add("addProduct", true);
            Response.Redirect("../MenuAdmin/ProductForm.aspx", false);
        }

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idSelected = dgvProducts.SelectedDataKey.Value.ToString();
            Response.Redirect($"../MenuAdmin/ProductForm.aspx?productID={idSelected}", false);
        }

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
                //TODO: Ver qué hacer con el método Filter de ProductBusiness con Juli - Lucas
               // dgvProducts.DataSource = list.Filter(FilterDDown.SelectedItem.ToString(), FilterPrice.SelectedItem.ToString(), filter.Text, StateDDL.SelectedItem.ToString());
                dgvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        /*public void dgvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            if(commandName == "AgregarProducto")
            {
                int selectedId = 3;

                List<Product> temporalList = (List<Product>)Session["productList"];
                Product selected = temporalList.Find(x => x.Id == selectedId);


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
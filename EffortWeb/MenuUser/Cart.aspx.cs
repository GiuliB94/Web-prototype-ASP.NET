using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MenuUser
{
    public partial class Cart : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["UserPermission"] == null || (int)Session["UserPermission"] < 1) Response.Redirect("~/Menu/Home.aspx", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvCart.DataSource = (List<ItemAux>)Session["Cart"];
            dgvCart.DataBind();
        }

        protected void gdr_Cart_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "EliminarElementoInd" || e.CommandName == "EliminarElemento")
            {
                /* int pos = int.Parse(e.CommandArgument.ToString());
                string titulo = gdr_Carrito2.Rows[pos].Cells[3].Text;
                for (int i = 0; i < gdr_Carrito.Rows.Count; i++)
                {
                    string tituloToCompare = gdr_Carrito.Rows[i].Cells[3].Text;
                    if (tituloToCompare.Trim() == titulo.Trim())
                    {
                        DataTable dt = (DataTable)Session["Carrito"];
                        dt.Rows.RemoveAt(i);
                        gdr_Carrito.DataSource = dt;
                        gdr_Carrito.DataBind();
                        i = -1;
                        totalCompra = 0;
                        txt_TotalCompra.Text = totalCompra.ToString();
                        gdr_Carrito2.DataSource = null;
                        gdr_Carrito2.DataBind();
                        crearcarrito();
                        bindearCarrito();

                        if (e.CommandName == "EliminarElementoInd")
                        {
                            return;
                        }
                    }
                }*/
            }
        }

        protected void BtnToOrder_Click(object sender, EventArgs e)
        {
            OrderDetails newOrder = new OrderDetails();
            newOrder.CreateOrder();   
            List<ItemAux> itemsList = (List<ItemAux>)Session["Cart"];
            foreach (ItemAux x in itemsList)
            {
                newOrder.TotalAmount += x.TotalAmount;
            }

        }
    }
}
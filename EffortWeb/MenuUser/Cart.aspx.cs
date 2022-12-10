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
        protected void Page_Load(object sender, EventArgs e)
        {
            gdr_Cart.DataSource = Session["Cart"];
            gdr_Cart.DataBind();

            /*for (int i = 0; i < gdr_Cart.Rows.Count; i++)
            {
                string idProduct = gdr_Cart.Rows[i].Cells[3].Text;
                int quantity = Convert.ToInt16(gdr_Cart.Rows[i].Cells[6].Text);

                for (int j = 1; j < gdr_Cart.Rows.Count; j++)
                {
                    string idProductToCompare = gdr_Cart.Rows[j].Cells[3].Text;
                    if (idProduct == idProductToCompare)
                    {
                        quantity += Convert.ToInt16(gdr_Cart.Rows[j].Cells[6].Text);
                    }
                }
                gdr_Cart.Rows[i].Cells[6].Text = quantity.ToString();
            }*/

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
    }
}
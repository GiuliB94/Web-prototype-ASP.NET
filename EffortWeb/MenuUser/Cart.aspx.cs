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

            }
        }

        protected void BtnToOrder_Click(object sender, EventArgs e)
        {
            OrderDetails newOrder = new OrderDetails();
            //Total Amount
            List<ItemAux> itemsList = (List<ItemAux>)Session["Cart"];
            foreach (ItemAux x in itemsList)
            {
                newOrder.TotalAmount += x.TotalAmount; //Suma total del pedido
            }
            //IdCompany
            CompanyBusiness auxCompany = new CompanyBusiness();
            User user = (User)Session["User"];
            int idUser = user.Id;
            Company company = auxCompany.GetCompany(idUser);
            newOrder.IdCompany = company.Id;

            OrderDetailsBusiness auxOrderDetails = new OrderDetailsBusiness();
            auxOrderDetails.Add(newOrder);
            int idOrder = auxOrderDetails.GetLastId();
            LoadItems(itemsList, idOrder);
            Session["Cart"] = null;
        }

        protected void LoadItems(List<ItemAux> list, int IdOrder)
        {
            OrderElementBusiness auxOrderElement = new OrderElementBusiness();
            var count = 0;
            foreach (ItemAux x in list)
            {
                count++;
                OrderElement newLine = new OrderElement();
                newLine.IdOrder = IdOrder;
                newLine.LineItem = count;
                newLine.IdProduct = x.IdProduct;
                newLine.Quantity = x.Quantity;
                newLine.Comment = x.Comment;
                auxOrderElement.Add(newLine);
            }
        }
    }
}

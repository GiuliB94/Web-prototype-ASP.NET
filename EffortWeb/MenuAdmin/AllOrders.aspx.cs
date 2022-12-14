using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MenuAdmin
{
    public partial class AllOrders : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if ((int)Session["UserPermission"] != 0) Response.Redirect("~/Menu/Home.aspx");

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null && !IsPostBack)
            {
                lblChangeStatus.Visible = true;
                BtnChangeStatus.Visible = true;
                DDLChangeStatus.Visible = true;
                dgvOrderElements.Visible = true;
                dgvCostDetails.Visible = false;
                dgvAllOrders.Visible = false;
                OrderElementBusiness aux = new OrderElementBusiness();
                List<OrderElement> orderElementsList = aux.Show(int.Parse(Request.QueryString["OrderID"]));
                dgvOrderElements.DataSource = orderElementsList;
                OrderDetailsBusiness status = new OrderDetailsBusiness();
                string che = status.GetOrder(int.Parse(Request.QueryString["OrderID"])).StatusDescription;
                DDLChangeStatus.Text = status.GetOrder(int.Parse(Request.QueryString["OrderID"])).StatusDescription;
                dgvOrderElements.DataBind();
            }

            else if (!IsPostBack)
            {
                lblChangeStatus.Visible = false;
                BtnChangeStatus.Visible = false;
                DDLChangeStatus.Visible = false;
                dgvCostDetails.Visible = false;
                dgvOrderElements.Visible = false;
                if (Session["OrderBusiness"] == null)
                {
                    OrderDetailsBusiness OrderList = new OrderDetailsBusiness();
                    Session.Add("OrderBusiness", OrderList.Show());
                }

                dgvAllOrders.DataSource = Session["OrderBusiness"];
                dgvAllOrders.DataBind();
            }

        }




        protected void dgvAllOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelected = (int)dgvAllOrders.SelectedDataKey.Value;
            Response.Redirect($"../MenuAdmin/AllOrders.aspx?OrderID={idSelected}");

        }

        protected void dgvOrderElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrderElements.Visible = false;
            dgvCostDetails.Visible = true;
            dgvAllOrders.Visible = false;

            int idSelected = (int)dgvOrderElements.SelectedDataKey.Value;
            CostBusiness aux = new CostBusiness();
            List<CostXProduct> list = new List<CostXProduct>();

            list = aux.GetCostForProduct(idSelected);
            dgvCostDetails.DataSource = list;
            dgvCostDetails.DataBind();
        }

        protected void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            OrderDetailsBusiness aux = new OrderDetailsBusiness();
            int idSelected = int.Parse(Request.QueryString["OrderID"]);
            CompanyBusiness Comp = new CompanyBusiness();
            UserBusiness user= new UserBusiness();
            string mail = user.GetUser(Comp.GetCompany(aux.GetOrder(idSelected).IdCompany).IdUser).Email;
            string name = Comp.GetCompany(aux.GetOrder(idSelected).IdCompany).Name;

            if (DDLChangeStatus.Text == "Aprobado")
            {
                aux.UpdateStatus(idSelected, 1);
            }
            if (DDLChangeStatus.Text == "En proceso de fabricación")
            {
                aux.UpdateStatus(idSelected, 2);
            }
            if (DDLChangeStatus.Text == "Listo para entrega")
            {
                aux.UpdateStatus(idSelected, 3);
            }
            if (DDLChangeStatus.Text == "Entregado")
            {
                aux.UpdateStatus(idSelected, 4);
            }
            if (DDLChangeStatus.Text == "Rechazado")
            {
                aux.UpdateStatus(idSelected, 5);
            }

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("../Extras/Templates/UpdateEmail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Name}", name);
            body = body.Replace("{Id}", idSelected.ToString());
            body = body.Replace("{Status}", DDLChangeStatus.Text);

            string to = mail;
            string from = "effort.fabrica.soporte@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Novedades sobre tu pedido";
            SmtpClient client = MessageSender.Initialize();
            message.IsBodyHtml = true;

            message.Body = body;


            try
            {
                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }

            Session.Add("OrderBusiness", aux.Show());

            Response.Redirect("~/MenuAdmin/AllOrders.aspx");
        }
    }
}
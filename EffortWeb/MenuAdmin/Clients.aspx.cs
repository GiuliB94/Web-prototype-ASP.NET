using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.MenuAdmin
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Si es la primera vez que carga la pagina...
            {
                dgvPendingClients.Visible = false;
                dgvClients.Visible = true;

                lblClients.Text = "Lista de clientes";
                CompanyBusiness clientList = new CompanyBusiness();
                if (Session["clientList"] == null)
                {
                    Session.Add("clientList", clientList.Show());
                }
                dgvClients.DataSource = Session["clientList"];
                dgvClients.DataBind();
            }
        }

        protected void dgvClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idSelected = dgvClients.SelectedDataKey.Value.ToString();
            Response.Redirect("../Menu/CreateAccount.aspx?ClientID=" + idSelected);
        }

        protected void btnPendings_Click(object sender, EventArgs e)
        {
            lblClients.Text = "Seleccione el cliente para dar de alta";
            btnPendings.Visible = false;
            dgvPendingClients.Visible = true;
            dgvClients.Visible = false;
            CompanyBusiness pendingClientList = new CompanyBusiness();
            if (Session["pendingClientList"] == null)
            {
                Session.Add("pendingClientList", pendingClientList.ShowPendings());
            }
            dgvPendingClients.DataSource = Session["pendingClientList"];
            dgvPendingClients.DataBind();
        }

        protected void dgvPendingClients_SelectedIndexChanged(object sender, EventArgs e)
        {
             var idSelected = dgvPendingClients.SelectedDataKey.Value.ToString();
             Response.Redirect("../Menu/CreateAccount.aspx?ClientID=" + idSelected);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                CompanyBusiness clientList = new CompanyBusiness();
                dgvClients.DataSource = clientList.Filter(FilterDDown.SelectedItem.ToString(), StateDDL.SelectedItem.ToString(), filter.Text);
                dgvClients.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }
    }
}
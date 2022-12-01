using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1.MenuAdmin
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
                ClientBusiness clientList = new ClientBusiness();
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
            /*var idSelected = dgvClients.SelectedDataKey.Value.ToString();
            Response.Redirect("ClientForm.aspx?id=" + idSelected);*/
        }

        protected void btnPendings_Click(object sender, EventArgs e)
        {
            lblClients.Text = "Seleccione el cliente para dar de alta";
            btnPendings.Visible = false;
            dgvPendingClients.Visible = true;
            dgvClients.Visible = false;
            ClientBusiness pendingClientList = new ClientBusiness();
            if (Session["pendingClientList"] == null)
            {
                Session.Add("pendingClientList", pendingClientList.ShowPendings());
            }
            dgvPendingClients.DataSource = Session["pendingClientList"];
            dgvPendingClients.DataBind();
        }

        protected void dgvPendingClients_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* var idSelected = dgvPendingClients.SelectedDataKey.Value.ToString();
            Response.Redirect("ClientForm.aspx?ClientID=" + idSelected);*/
        }
    }
}
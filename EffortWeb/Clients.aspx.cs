using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effort_ver1
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientList myOrderList = new ClientList();
            dgvClients.DataSource = myOrderList.Show();
            dgvClients.DataBind();
        }

        protected void dgvClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aca se deberia mostrar el perfil del cliente
        }
    }
}
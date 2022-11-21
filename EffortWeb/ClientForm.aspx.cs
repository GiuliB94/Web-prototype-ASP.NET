using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Domain;

namespace effort_ver1
{
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSendClientForm_Click(object sender, EventArgs e)
        {
            Client newClient = new Client();
            newClient.id = 0001; //Hacer que se genere automaticamente en la bd
            newClient.name = txtName.Text;
            newClient.lastName = txtLastName.Text;
            newClient.idCompany = Convert.ToInt16(txtIdCompany.Text);
            newClient.email = txtEmail.Text;
            newClient.phone = txtPhone.Text;
            newClient.category = 1; //Lo selecciona el usuario o el admin cuando le da el alta? 
            newClient.active = false; //Llega en false, cuando el admin le da el alta pasa a true.
            //Serviria de algo tenes la fecha de alta del usuario?

            ((List<Client>)Session["clientList"]).Add(newClient);
            //List <Client> temporalList = (List<Client>)Session["clientList"];
           //temporalList.Add(newClient);
            Response.Redirect("Default.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Domain;

namespace effort_ver1
{
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ClientBusiness clientList = new ClientBusiness();
            if (Session["clientList"] == null)
            {
                Session.Add("clientList", clientList.Show());
            }

            if (Request.QueryString["ClientID"] != null)
            {
                int id = int.Parse(Request.QueryString["ClientID"]); //Obtengo el ID

                List<Client> temportalList = (List<Client>)Session["clientList"]; //Busco al cliente seleccionado en la lista de clientes activos
                Client selected = temportalList.Find(x => x.Id == id);
                if (selected == null) //Si no lo encuentro, lo busco en la lista de pendientes.
                {
                    temportalList = (List<Client>)Session["pendingClientList"];
                    selected = temportalList.Find(x => x.Id == id);
                }
                txtName.Text = selected.Name;
                txtLastName.Text = selected.LastName;
                txtPhone.Text = selected.Phone;

                btnSendClientForm.Visible = false;

                if (Convert.ToBoolean(selected.State) == false)
                {
                    btnSignUp.Visible = true;
                }
            }
        }

        protected void btnSendClientForm_Click(object sender, EventArgs e)
        {
            /*Client newClient = new Client();
            newClient.Id = 0001; //Hacer que se genere automaticamente en la bd
            newClient.Name = txtName.Text;
            newClient.LastName = txtLastName.Text;
            newClient.idCompany = Convert.ToInt16(txtIdCompany.Text);
            newClient.email = txtEmail.Text;
            newClient.Phone = txtPhone.Text;
            newClient.category = 1; //Lo selecciona el usuario o el admin cuando le da el alta? 
            newClient.State = false; //Llega en false, cuando el admin le da el alta pasa a true.
            //Serviria de algo tenes la fecha de alta del usuario?
            
            if (Session["pendingClientList"] == null)
            {
                ClientBusiness pendingClientList = new ClientBusiness();
                Session.Add("pendingClientList", pendingClientList.ShowPendings());
            }
            List<Client> temporalList = (List<Client>)Session["pendingClientList"];
            temporalList.Add(newClient);
            Response.Redirect("Clients.aspx");*/
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["ClientId"]); //Obtengo el ID
            List<Client> temportalList = (List<Client>)Session["pendingClientList"]; //Busco al cliente seleccionado en la lista de clientes activos
            Client selected = temportalList.Find(x => x.Id == id);
            selected.State = true;

            List<Client> clientList = (List<Client>)Session["ClientBusiness"];
            clientList.Add(selected);
            Response.Redirect("Clients.aspx");
        }
    }
}
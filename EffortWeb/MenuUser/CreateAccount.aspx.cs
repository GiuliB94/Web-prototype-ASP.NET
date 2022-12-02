using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;

namespace effort_ver1.MenuUser
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            Client newClient = new Client();
            UserBusiness auxUser = new UserBusiness();
            ClientBusiness auxClient = new ClientBusiness();

            newUser.Email = TxtEmail.Text;
            newUser.Password = TxtPass.Text;
            newUser.Permission = 0;
            newUser.State = true;
            auxUser.Add(newUser);

            newClient.IdUser = auxUser.GetUser(newUser.Email, newUser.Password).Id; //TODO: Validar ID
            newClient.Name = TxtFirstName.Text;
            newClient.LastName = TxtLastName.Text;
            newClient.Phone = TxtPhone.Text;   
            newClient.DNI = TxtDNI.Text;
            newClient.Adress = TxtAdress.Text;
            newClient.City = TxtCity.Text;
            newClient.Province = TxtProvince.Text;
            newClient.PostalCode = TxtPostalCode.Text;
            newClient.State = true;
            auxClient.Add(newClient);

        }
    }
}
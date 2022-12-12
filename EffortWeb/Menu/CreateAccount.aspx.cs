using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Runtime.Remoting.Lifetime;

namespace EffortWeb.Menu
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["UserPermission"] == null) Session["UserPermission"] = -1;
            else if ((int)Session["UserPermission"] != -1) Response.Redirect("~/Menu/Home.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            bool DataCheck = true;
            User newUser = new User();
            Company newCompany = new Company();
            UserBusiness auxUser = new UserBusiness();
            CompanyBusiness auxCompany = new CompanyBusiness();

            newUser.Email = TxtEmail.Text;
            newUser.Password = TxtPass.Text;
            newUser.Permission = 0;
            newUser.IsActive = true;

            newCompany.Name = TxtFirstName.Text;
            newCompany.Phone = TxtPhone.Text;
            newCompany.CUIT = TxtCUIT.Text;
            newCompany.Address = TxtAddress.Text;
            newCompany.AddressExtra = TxtAddressExtra.Text;
            newCompany.City = TxtCity.Text;
            newCompany.Province = TxtProvince.Text;
            newCompany.PostalCode = TxtPostalCode.Text;
            newCompany.IsActive = false;




            if(TxtFirstName.Text=="" || TxtPhone.Text == "" || TxtCUIT.Text == "" || TxtAddress.Text == "" || TxtCity.Text == "" || TxtProvince.Text == "" || TxtPostalCode.Text == "" || TxtEmail.Text=="" || TxtPass.Text=="" || TxtRetryPass.Text=="")
            {
                DataCheck = false;
                lblErrorMSG.Text = "Por favor, complete todos los campos para que su solicitud pueda ser completada";
                lblErrorMSG.Visible = true;
            }



            else
            {
                List<User> users = auxUser.Show();
                List<Company> Companies = auxCompany.Show();

                foreach (User x in users)
                {
                    if (x.Email.ToLower() == newUser.Email.ToLower())
                    {
                        DataCheck = false;
                        lblErrorMSG.Text = "Email ya registrado, intente recuperar su contraseña a través de nuestra página de login o bien contactese con nosotros si nunca se registró con anterioridad";
                        lblErrorMSG.Visible = true;
                    }
                }

                foreach (Company x in Companies)
                {
                    if (x.CUIT == newCompany.CUIT)
                    {
                        User aux = auxUser.GetUser(x.IdUser);
                        DataCheck = false;

                        if (!aux.IsActive & !x.IsActive)
                        {
                            lblErrorMSG.Text = "Error de prosesamiento, por favor contactenos a través de nuestros canales oficiales para validar su registro";
                        }

                        else if (aux.IsActive & !x.IsActive)
                        {
                            lblErrorMSG.Text = "Recibimos su solicitud con anterioridad, por favor aguarde nuestro correo de confirmación";
                        }

                        else if (!aux.IsActive & x.IsActive)
                        {
                            lblErrorMSG.Text = "Parece que ya estás registrado como compañía , contactate con nosotros para reactivar tu cuenta";
                        }

                        else if (aux.IsActive & x.IsActive)
                        {
                            lblErrorMSG.Text = "Parece que ya estás registrado como compañía, intenta recuperar su contraseña a través de nuestra página de login";
                        }

                        lblErrorMSG.Visible = true;
                    }
                }

            }

            if (DataCheck)
            {
                if (newUser.Password== TxtRetryPass.Text)
                {
                    auxUser.Add(newUser);
                    User checkUser;
                    checkUser = auxUser.GetUser(newUser.Email, newUser.Password);
                    newCompany.IdUser = checkUser.Id;
                    auxCompany.Add(newCompany);
                    lblErrorMSG.Text = "Solicitud recibida con éxito, estaremos enviando una confirmación a su correo una vez que la misma sea aprobada";
                    lblErrorMSG.Visible = true;
                }

                else
                {
                    lblErrorMSG.Text = "Las contraseñas no coinciden";
                    lblErrorMSG.Visible = true;
                }

            }
        }
    }
}
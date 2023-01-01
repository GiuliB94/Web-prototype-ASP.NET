using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Runtime.Remoting.Lifetime;
using System.EnterpriseServices;
using System.IO;
using System.Net.Mail;
using System.Xml.Linq;

namespace EffortWeb.Menu
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["UserPermission"] == null) Session["UserPermission"] = -1;
            else if ((int)Session["UserPermission"] != -1 && (int)Session["UserPermission"] != 0) Response.Redirect("~/Menu/Home.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            //para modificación/aprobación
            //busco ID de elemento seleccionado y lo cargo para su modificación - aprobación
            if (Request.QueryString["ClientID"] != null && !IsPostBack)
            {
                Company aux = new Company();
                CompanyBusiness search = new CompanyBusiness();
                aux = search.GetCompany(Request.QueryString["ClientID"].ToString());

                TxtAddress.Text = aux.Address;
                TxtCity.Text = aux.City;
                TxtAddressExtra.Text = aux.AddressExtra;
                TxtCUIT.Text = aux.CUIT;
                TxtFirstName.Text = aux.Name;
                TxtPhone.Text = aux.Phone;
                TxtPostalCode.Text = aux.PostalCode;
                TxtProvince.Text = aux.Province;

                User AccessData = new User();
                UserBusiness DataCheck = new UserBusiness();
                AccessData = DataCheck.GetUser(aux.IdUser);

                TxtEmail.Text = AccessData.Email;
                TxtPass.Text = AccessData.Password;
                TxtRetryPass.Text = AccessData.Password;

                if (aux.IsActive == false)
                {
                    BtnActive.Visible = true;
                    BtnReject.Visible = true;
                    TxtAddress.ReadOnly = true;
                    TxtAddressExtra.ReadOnly = true;
                    TxtCity.ReadOnly = true;
                    TxtCUIT.ReadOnly = true;
                    TxtEmail.ReadOnly = true;
                    TxtFirstName.ReadOnly = true;
                    TxtPhone.ReadOnly = true;
                    TxtPostalCode.ReadOnly = true;
                    TxtProvince.ReadOnly = true;
                    TxtRetryPass.ReadOnly = true;
                    TxtPass.ReadOnly = true;

                }

                else
                        
                {
                    btnModify.Visible = true;
                }

                TxtIdCompany.Visible = true;
                TxtIdCompany.Text = aux.Id.ToString();
                lblId.Visible = true;
                btnCreateUser.Visible = false;
                LblIdUser.Visible = true;
                TxtIdUser.Text = aux.IdUser.ToString();
                TxtIdUser.Visible = true;


            }

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
            newUser.Permission = 1;
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




            if (TxtFirstName.Text == "" || TxtPhone.Text == "" || TxtCUIT.Text == "" || TxtAddress.Text == "" || TxtCity.Text == "" || TxtProvince.Text == "" || TxtPostalCode.Text == "" || TxtEmail.Text == "" || TxtPass.Text == "" || TxtRetryPass.Text == "")
            {
                DataCheck = false;
                LabelMSG.Text= "Por favor, complete todos los campos para que su solicitud pueda ser completada";
            }



            else
            {
                List<User> users = auxUser.Show(1);
                List<Company> Companies = auxCompany.Show(1);

                foreach (User x in users)
                {
                    if (x.Email.ToLower() == newUser.Email.ToLower())
                    {
                        DataCheck = false;
                        LabelMSG.Text = "Email ya registrado, intente recuperar su contraseña a través de nuestra página de login o bien contactese con nosotros si nunca se registró con anterioridad";
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
                            LabelMSG.Text = "Error de prosesamiento, por favor contactenos a través de nuestros canales oficiales para validar su registro";
                            
                        }

                        else if (aux.IsActive & !x.IsActive)
                        {
                            LabelMSG.Text = "Recibimos su solicitud con anterioridad, por favor aguarde nuestro correo de confirmación";
                        }

                        else if (!aux.IsActive & x.IsActive)
                        {
                            LabelMSG.Text = "Parece que ya estás registrado como compañía , contactate con nosotros para reactivar tu cuenta";
                        }

                        else if (aux.IsActive & x.IsActive)
                        {
                            LabelMSG.Text = "Parece que ya estás registrado como compañía, intenta recuperar su contraseña a través de nuestra página de login";
                        }

                    }
                }
                
            }

            if (DataCheck)
            {
                if (newUser.Password == TxtRetryPass.Text)
                {
                    auxUser.Add(newUser);
                    User checkUser;
                    checkUser = auxUser.GetUser(newUser.Email, newUser.Password);
                    newCompany.IdUser = checkUser.Id;
                    auxCompany.Add(newCompany);
                    LabelMSG.Text = "Solicitud recibida con éxito, estaremos enviando una confirmación a su correo una vez que la misma sea aprobada";
                }

                else
                {
                    LabelMSG.Text = "Las contraseñas no coinciden";
                }

            }

            ModalPopupExtender1.Show();

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            bool DataCheck = true;
            User ModUser = new User();
            Company ModCompany = new Company();
            UserBusiness auxUser = new UserBusiness();
            CompanyBusiness auxCompany = new CompanyBusiness();



            ModUser.Email = TxtEmail.Text;
            ModUser.Password = TxtPass.Text;
            ModUser.Permission = 0;
            ModUser.Id = int.Parse(TxtIdUser.Text);
            ModUser.IsActive = auxUser.GetUser(ModUser.Id).IsActive;

            ModCompany.Name = TxtFirstName.Text;
            ModCompany.Phone = TxtPhone.Text;
            ModCompany.CUIT = TxtCUIT.Text;
            ModCompany.Address = TxtAddress.Text;
            ModCompany.AddressExtra = TxtAddressExtra.Text;
            ModCompany.City = TxtCity.Text;
            ModCompany.Province = TxtProvince.Text;
            ModCompany.PostalCode = TxtPostalCode.Text;
            ModCompany.IsActive = false;
            ModCompany.Id = int.Parse(TxtIdCompany.Text);
            ModCompany.IdUser = int.Parse(TxtIdUser.Text);
            ModCompany.IsActive = auxCompany.GetCompany(ModCompany.Id.ToString()).IsActive;


            if (TxtFirstName.Text == "" || TxtPhone.Text == "" || TxtCUIT.Text == "" || TxtAddress.Text == "" || TxtCity.Text == "" || TxtProvince.Text == "" || TxtPostalCode.Text == "" || TxtEmail.Text == "" || TxtPass.Text == "" || TxtRetryPass.Text == "")
            {
                DataCheck = false;
                LabelMSG.Text = "Por favor, complete todos los campos para que su solicitud pueda ser completada";
            }



            else
            {
                List<User> users = auxUser.Show(1);
                List<Company> Companies = auxCompany.Show(1);

                foreach (User x in users)
                {
                    if (x.Email.ToLower() == ModUser.Email.ToLower() && x.Id != ModUser.Id)
                    {
                        DataCheck = false;
                        LabelMSG.Text = "Este correo pertenece a otro usuario registrado";
                    }
                }

                foreach (Company x in Companies)
                {
                    if (x.CUIT == ModCompany.CUIT && x.Id != ModCompany.Id)
                    {
                        User aux = auxUser.GetUser(x.IdUser);
                        DataCheck = false;

                        LabelMSG.Text = "Este CUIT ya pertenece a otro cliente";

                    }
                }

            }

            if (DataCheck)
            {
                try
                {
                    auxUser.Modify(ModUser);
                    auxCompany.Modify(ModCompany);
                    LabelMSG.Text = "Cambios registrados con exito";
                }
                catch (Exception ex)
                {
                    LabelMSG.Text = "La acción no pudo completarse";
                    throw ex;
                }

                finally
                {
                    Session.Add("clientList", auxCompany.Show());
                    Response.Redirect("../MenuAdmin/Clients.aspx");
                }

            }

            ModalPopupExtender1.Show();
        }

        protected void BtnActive_Click(object sender, EventArgs e)
        {
            UserBusiness auxUser = new UserBusiness();
            CompanyBusiness auxCompany = new CompanyBusiness();
            bool mail = true;

            User ModUser = auxUser.GetUser(int.Parse(TxtIdUser.Text));
            Company ModCompany = auxCompany.GetCompany(TxtIdCompany.Text);
            ModCompany.IsActive = true;
            ModUser.IsActive = true;

            try
            {
                auxCompany.Modify(ModCompany);
                auxUser.Modify(ModUser);
            }

            catch (Exception ex)
            {
                LabelMSG.Text = "La acción no pudo completarse";
                mail = false;
                throw ex;
            }

            if (mail) {


                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("../Extras/Templates/WelcomeEmail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{Name}", ModCompany.Name);
                body = body.Replace("{Id}", ModCompany.Id.ToString());
                body = body.Replace("{UserMail}", ModUser.Email);

                string to = ModUser.Email;
                string from = "effort.fabrica.soporte@gmail.com";
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Tu Usuario con Effort fue confirmado con éxito";
                SmtpClient client = MessageSender.Initialize();
                message.IsBodyHtml = true;

                message.Body = body;

                LabelMSG.Text = "Acción completada con éxito";

                

                try
                {
                    client.Send(message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                        ex.ToString());
                }

                Session.Add("clientList", auxCompany.Show());
                Response.Redirect("../MenuAdmin/Clients.aspx");
            }

            ModalPopupExtender1.Show();


        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            User ModUser = new User();
            Company ModCompany = new Company();
            UserBusiness auxUser = new UserBusiness();
            CompanyBusiness auxCompany = new CompanyBusiness();

            ModUser = auxUser.GetUser(int.Parse(TxtIdUser.Text));
            ModCompany = auxCompany.GetCompany(TxtIdCompany.Text);

            ModCompany.IsActive = false;
            ModUser.IsActive = false;

            try
            {
                auxCompany.Modify(ModCompany);
                auxUser.Modify(ModUser);
            }

            catch (Exception ex)
            {
                LabelMSG.Text = "La acción no pudo completarse";
                throw ex;
            }

            finally
            {
                Response.Redirect("../MenuAdmin/Clients.aspx");
            }

            ModalPopupExtender1.Show();

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {   
            if ((int)Session["UserPermission"] != 0)
            {
                Response.Redirect("~/Menu/Home.aspx");
            }
            else
            {
                Response.Redirect("../MenuAdmin/Clients.aspx");
            }
            
        }

        

    }

}
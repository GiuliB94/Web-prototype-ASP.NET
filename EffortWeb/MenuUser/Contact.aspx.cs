using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Security.Policy;
using Business;
using System.Collections;
using System.Numerics;
using System.Web.Services.Description;
using System.Web.UI.WebControls.WebParts;

namespace EffortWeb.MenuUser
{
    public partial class Contact : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            //if ((int)Session["UserPermission"] < 1) Response.Redirect("~/Menu/Home.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string LstName = txtLastName.Text;
            string Id = txtID.Text;
            string Mail = txtMail.Text;
            string Phone = txtPhone.Text;
            string UserMsg = txtMsj.Text;

            if (Name == "" || LstName == "" || Mail == "" || Phone == "" || UserMsg == "")
            {
                LabelMSG.Text = "Ups! Por favor complete toda su información para que el mensaje pueda ser enviado. Si no posee ID de empresa puede omitirlo.";
                ModalPopupExtender1.Show();
            }
            else
            {
                lblError.Visible = false;
                //toma el templade de html y reemplaza las partes que son variables por los datos del usuario
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("../Extras/Templates/DefaultEmail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", Name);
                body = body.Replace("{LastName}", LstName);
                body = body.Replace("{Id}", Id);
                body = body.Replace("{UserMail}", Mail);
                body = body.Replace("{UserPhone}", Phone);
                body = body.Replace("{UserText}", UserMsg);

                string to = "effort.fabrica.soporte@gmail.com";
                string from = "effort.fabrica.soporte@gmail.com";
                MailMessage message = new MailMessage(from, to);
                message.Subject = Name + " " + LstName + ", " + Id;
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
                LabelMSG.Text = "Gracias por tu mensaje, te estaremos respondiendo a la brevedad";
                
            }
            ModalPopupExtender1.Show();
        }

    }
}
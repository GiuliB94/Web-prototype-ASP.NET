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

namespace EffortWeb
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string Name= txtName.Text;
            string LstName= txtLastName.Text;
            string Id = txtID.Text;
            string Mail= txtMail.Text;
            string Phone= txtPhone.Text;
            string UserMsg=txtMsj.Text;

            if(Name=="" || LstName=="" || Mail== "" || Phone == "" || UserMsg=="")
            {
                lblError.Visible=true;
            }
            else
            {
                lblError.Visible = false;
                //toma el templade de html y reemplaza las partes que son variables por los datos del usuario
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("/DefaultMail.html")))
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
                //también puede ser puerto 587 o 465, verificar si el puerto 25 funciona en todas las pc
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                message.IsBodyHtml = true;
                //falso para que utilice las credenciales descritas más abajo
                client.UseDefaultCredentials = false;
                //se creó una contraseña especial segura para poder utilizar gmail
                client.Credentials = new NetworkCredential("effort.fabrica.soporte@gmail.com", "jgzoeaepshviphlu");
                //habilita ssl para una conexión segura y cifrada, solicitada por gmail
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
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
                txtMsj.Text = "Gracias por tu mensaje, te estaremos respondiendo a la brevedad";
            }



        }
    }
}
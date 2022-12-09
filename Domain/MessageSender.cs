using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Security.Policy;


namespace Business
{
    public class MessageSender
    {
        public static SmtpClient Initialize()
        {
            //también puede ser puerto 587 o 465, verificar si el puerto 25 funciona en todas las pc
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            //falso para que utilice las credenciales descritas más abajo
            client.UseDefaultCredentials = false;
            //se creó una contraseña especial segura para poder utilizar gmail
            client.Credentials = new NetworkCredential("effort.fabrica.soporte@gmail.com", "jgzoeaepshviphlu");
            //habilita ssl para una conexión segura y cifrada, solicitada por gmail
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;

        }

    }
}

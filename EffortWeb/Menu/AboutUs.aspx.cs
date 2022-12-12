using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.Menu
{
    public partial class AboutUs : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["MasterPageString"] != null) this.MasterPageFile = Session["MasterPageString"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
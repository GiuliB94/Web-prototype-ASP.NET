using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EffortWeb.Menu
{
    public partial class Home : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            int test = 0;
            if(test == 0)
            {
                this.MasterPageFile = "~/MasterPages/MasterAdmin.Master";
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

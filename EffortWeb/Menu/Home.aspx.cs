using Business;
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
        private Dictionary<int, string> PermissionMasterPages = new Dictionary<int, string>();
        private Home()
        {
            PermissionMasterPages.Add(-1, "~/MasterPages/Master.Master");
            PermissionMasterPages.Add(0, "~/MasterPages/MasterAdmin.Master");
            PermissionMasterPages.Add(1, "~/MasterPages/MasterUser.Master");
            PermissionMasterPages.Add(2, "~/MasterPages/MasterUser.Master");
            PermissionMasterPages.Add(3, "~/MasterPages/MasterUser.Master");
        }
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["User"]!=null)
            {
                this.MasterPageFile = PermissionMasterPages[(int)Session["UserPermission"]];
            }
            else
            {
                this.MasterPageFile = "~/MasterPages/Master.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

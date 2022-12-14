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
        private static Dictionary<int, string> PermissionMasterPages = new Dictionary<int, string>();

        void Page_PreInit(Object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PermissionMasterPages = new Dictionary<int, string>();
                PermissionMasterPages.Add(-1, "~/MasterPages/Master.Master");
                PermissionMasterPages.Add(0, "~/MasterPages/MasterAdmin.Master");
                PermissionMasterPages.Add(1, "~/MasterPages/MasterUser.Master");
                PermissionMasterPages.Add(2, "~/MasterPages/MasterUser.Master");
                PermissionMasterPages.Add(3, "~/MasterPages/MasterUser.Master");
                if (Session["UserPermission"] == null) Session["UserPermission"] = -1;
                Session["MasterPageString"] = PermissionMasterPages[(int)Session["UserPermission"]];
            }   
            this.MasterPageFile = Session["MasterPageString"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

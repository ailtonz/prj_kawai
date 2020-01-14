using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiEnt;
using System.Web.Security;

namespace kawaiWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "scripts1", ResolveClientUrl("~/scripts/jquery-1.4.1.min.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "scripts2", ResolveClientUrl("~/scripts/scripts.js"));

            NavigationMenu.DataSourceID = "SMDS";

            if (!Page.User.Identity.IsAuthenticated)
            {
                SMDS.SiteMapProvider = "Login";
            }
            else
            {
                FormsIdentity fi = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket tkt = fi.Ticket;
                SiteMapPathMenu.SiteMapProvider = SMDS.SiteMapProvider = tkt.UserData;
            }
        }

        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {

        }
    }
}

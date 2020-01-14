using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kawaiWeb
{
    public partial class Erro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Server.GetLastError() != null)
            {
                lblErro.Text = (Server.GetLastError().InnerException != null ? "InnerException -> " + Server.GetLastError().InnerException.ToString() : "");
                lblErro.Text += (Server.GetLastError().Message != null ? "<br /><br />Message -> " + Server.GetLastError().Message.ToString() : "");
                lblErro.Text += (Server.GetLastError().Source != null ? "<br /><br />Source -> " + Server.GetLastError().Source.ToString() : "");
                lblErro.Text += (Server.GetLastError().StackTrace != null ? "<br /><br />StackTrace -> " + Server.GetLastError().StackTrace.ToString() : "");
                lblErro.Text += (Server.GetLastError().TargetSite != null ? "<br /><br />TargetSite -> " + Server.GetLastError().TargetSite.ToString() : "");
            }
        }
    }
}
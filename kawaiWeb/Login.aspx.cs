using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiNeg;
using System.Web.Security;
using kawaiEnt;
using System.Configuration;

namespace kawaiWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            neKawai oKawai = new neKawai();
            etUsuario oUsuario =  oKawai.Logar(txtLogin.Text, txtSenha.Text);

            if (oUsuario != null)
            {

                FormsAuthentication.Initialize();

                //Definimos quanto tempo o usuário irá permanecer logado após deixar o site sem efetuar o logout
                FormsAuthenticationTicket tkt;
                int tempoLogin = Convert.ToInt16(ConfigurationManager.AppSettings["tempoLogin"].ToString());
                tkt = new FormsAuthenticationTicket(1, oUsuario.login, DateTime.Now, DateTime.Now.AddMinutes(tempoLogin), false, oUsuario.perfil, FormsAuthentication.FormsCookiePath);
                //Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)))
                //Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsuario.Text, False))

                string cookiestr;
                HttpCookie ck;

                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                Session.Add("oUsuario", oUsuario);

                Response.Redirect("logado.aspx");
            }
            else
            {
                txtSenha.Text = "";
                txtLogin.Text = "";
            }
        }
    }
}
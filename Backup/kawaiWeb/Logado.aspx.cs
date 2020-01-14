using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiEnt;

namespace kawaiWeb
{
    public partial class Logado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["oUsuario"] != null)
            {
                etUsuario oUsuario = (etUsuario)Session["oUsuario"];

                lblNome.Text = oUsuario.nome;
                lblPerfil.Text = oUsuario.perfil;
                lblLogin.Text = oUsuario.login;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
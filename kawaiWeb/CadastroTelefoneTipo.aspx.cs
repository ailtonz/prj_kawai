using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiBco;
using kawaiNeg;
using System.Data;

namespace kawaiWeb
{
    public partial class CadastroTelefoneTipo : System.Web.UI.Page
    {
        neTelefoneTipo oNegocioTelefoneTipo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaLista();
            }
        }

        #region metódos

        public void carregaLista()
        {
            oNegocioTelefoneTipo = new neTelefoneTipo();

            gvLista.DataSource = oNegocioTelefoneTipo.busca();
            gvLista.DataBind();
        }

        public void carregaCampos(TelefoneTipo oPerfil)
        {
            txtCodigo.Text = oPerfil.codigo.ToString();
            txtDescricao.Text = oPerfil.descricao;
        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioTelefoneTipo = new neTelefoneTipo();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioTelefoneTipo.busca(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioTelefoneTipo.busca(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioTelefoneTipo = new neTelefoneTipo();

            TelefoneTipo oPerfil = new TelefoneTipo();
            
            oPerfil.descricao = txtDescricao.Text;

            if (txtCodigo.Text == "")
            {
                if (oNegocioTelefoneTipo.incluir(oPerfil))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oPerfil.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioTelefoneTipo.alterar(oPerfil))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioTelefoneTipo.excluir(oPerfil.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }
        }
        #endregion
    }
}
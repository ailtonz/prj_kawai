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
    public partial class CadastroContrato : System.Web.UI.Page
    {
        neContrato oNegocioContrato;

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
            oNegocioContrato = new neContrato();

            gvLista.DataSource = oNegocioContrato.busca();
            gvLista.DataBind();
        }

        public void carregaCampos(Contrato oPerfil)
        {
            txtCodigo.Text = oPerfil.codigo.ToString();
            //txtDescricao.Text = oPerfil.descricao;
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
            oNegocioContrato = new neContrato();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioContrato.busca(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioContrato.busca(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioContrato = new neContrato();

            Contrato oPerfil = new Contrato();
            
            //oPerfil.descricao = txtDescricao.Text;

            if (txtCodigo.Text == "")
            {
                if (oNegocioContrato.incluir(oPerfil))
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
                    if (oNegocioContrato.alterar(oPerfil))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioContrato.excluir(oPerfil.codigo))
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
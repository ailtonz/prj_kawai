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
    public partial class CadastroPlanoGrupo : System.Web.UI.Page
    {
        neMovimentoGrupo oNegocioGrupo;

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
            oNegocioGrupo = new neMovimentoGrupo();

            gvLista.DataSource = oNegocioGrupo.buscaGrupo();
            gvLista.DataBind();
        }

        public void carregaCampos(MovimentoGrupo oGrupo)
        {
            hfCodigo.Value = oGrupo.codigo.ToString();
            txtGrupo.Text = oGrupo.Grupo;
        }

        public void limpaCampos()
        {
            hfCodigo.Value = string.Empty;
            txtGrupo.Text = string.Empty;
            txtFiltrarGrupo.Text = string.Empty;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioGrupo = new neMovimentoGrupo();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioGrupo.buscaGrupo(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioGrupo.buscaGrupo(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregaLista();
            divFiltrarDados.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioGrupo = new neMovimentoGrupo();

            MovimentoGrupo oGrupo = new MovimentoGrupo();

            oGrupo.Grupo = txtGrupo.Text;

            if (hfCodigo.Value == "")
            {
                if (oNegocioGrupo.incluirGrupo(oGrupo))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oGrupo.codigo = Convert.ToInt32(hfCodigo.Value);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioGrupo.alterarGrupo(oGrupo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioGrupo.excluirGrupo(oGrupo.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }
        }
        #endregion

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divFiltrarDados.Visible = true;
        }

        protected void btnFiltrarGrupo_Click(object sender, EventArgs e)
        {
            if (txtFiltrarGrupo.Text == "")
            {
                carregaLista();
            }
            else
            {
                FiltrarListaGrupo(txtFiltrarGrupo.Text);
            }
        }


        public void FiltrarListaGrupo(string procura)
        {
            oNegocioGrupo = new neMovimentoGrupo();

            gvLista.DataSource = oNegocioGrupo.FiltrarGrupo(procura);
            gvLista.DataBind();
        }



        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;
            carregaLista();            
        }

    }
}
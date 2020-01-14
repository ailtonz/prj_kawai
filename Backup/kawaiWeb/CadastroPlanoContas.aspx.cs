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
    public partial class CadastroPlanoContas : System.Web.UI.Page
    {
        neMovimentoGrupoConta oNegocioConta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaLista();
                carregaListaPlanoConta();
            }
        }

        #region metódos


        public void carregaLista()
        {
            oNegocioConta = new neMovimentoGrupoConta();

            gvLista.DataSource = oNegocioConta.busca();
            gvLista.DataBind();

        }

        public void carregaListaPlanoConta()
        {
            neMovimentoGrupo oNegocioGrupo = new neMovimentoGrupo();

            ddlPlanoConta.Items.Clear();

            ddlPlanoConta.DataValueField = "Codigo";
            ddlPlanoConta.DataTextField = "Grupo";
            ddlPlanoConta.DataSource = oNegocioGrupo.buscaGrupo();
            ddlPlanoConta.DataBind();

            ddlPlanoConta.Items.Insert(0, "Selecione");

        }


        public void carregaCampos(MovimentoGrupoConta oConta)
        {
            hfCodigo.Value = oConta.codigo.ToString();
            txtConta.Text = oConta.Conta;
            ddlPlanoConta.SelectedValue = oConta.codigoGrupo.ToString();
        }

        public void limpaCampos()
        {
            hfCodigo.Value = string.Empty;
            txtConta.Text = string.Empty;
            txtFiltrarConta.Text = string.Empty;
            ddlPlanoConta.SelectedIndex = -1;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioConta = new neMovimentoGrupoConta();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioConta.buscaConta(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioConta.buscaConta(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregaLista();
            divFiltrarConta.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioConta = new neMovimentoGrupoConta();

            MovimentoGrupoConta oConta = new MovimentoGrupoConta();

            oConta.Conta = txtConta.Text;
            oConta.codigoGrupo = Convert.ToInt32(ddlPlanoConta.SelectedValue);

            if (hfCodigo.Value == "")
            {
                if (oNegocioConta.incluirConta(oConta))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oConta.codigo = Convert.ToInt32(hfCodigo.Value);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioConta.alterarConta(oConta))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioConta.excluirConta(oConta.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                    else
                    {
                        lblMsg.Text = "ok";//oNegocio.Retorno;
                    }
                }
            }
        }
        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            fechaMsg();
        }

        public void fechaMsg()
        {
            divFlutuante.Attributes["class"] = "divFlutuante hidden";
            divFlutuanteMsg.Attributes["class"] = "divPosiciona hidden";
            lblMsg.Text = "";
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divFiltrarConta.Visible = true;
        }

        protected void btnFiltrarConta_Click(object sender, EventArgs e)
        {

            if (txtFiltrarConta.Text == "")
            {
                carregaLista();
            }
            else
            {
                FiltrarListaConta(txtFiltrarConta.Text);
            }


        }

        public void FiltrarListaConta(string procura)
        {
            oNegocioConta = new neMovimentoGrupoConta();

            gvLista.DataSource = oNegocioConta.FiltrarPlanosContas(procura);
            gvLista.DataBind();
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;
            carregaLista();  
        }


    }
}
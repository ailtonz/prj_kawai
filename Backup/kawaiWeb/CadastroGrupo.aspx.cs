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
    public partial class CadastroGrupo : System.Web.UI.Page
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
            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.MovimentoGrupo
                         select tbl);

            gvLista.DataSource = lista;
            gvLista.DataBind();
        }

        public void carregaListaConta(Int32 codigoGrupo)
        {

            divConta.Visible = true;
            btnIncluirConta.Visible = true;

            neMovimentoGrupoConta oNegocioConta = new neMovimentoGrupoConta();

            gvConta.DataSource = oNegocioConta.buscaContaGrupo(codigoGrupo);
            gvConta.DataBind();
        }

        public void carregaCampos(MovimentoGrupo oGrupo)
        {
            txtCodigo.Text = oGrupo.codigo.ToString();
            txtGrupo.Text = oGrupo.Grupo;
            divPlanos.Visible = false;
            divConta.Visible = true;
        }

        public void carregaCamposConta(MovimentoGrupoConta oConta)
        {
            hfCodigoConta.Value = oConta.codigo.ToString();
            txtConta.Text = oConta.Conta;
        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            btnSalvar.Text = "Salvar";
        }

        public void limpaCamposConta()
        {
            txtConta.Text = string.Empty;
            btnIncluirConta.Text = "Incluir Nova Conta";
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
                carregaListaConta(codigo);
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
            divPlanos.Visible = true;
            divConta.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioGrupo = new neMovimentoGrupo();

            MovimentoGrupo oGrupo = new MovimentoGrupo();

            oGrupo.Grupo = txtGrupo.Text;


            if (txtCodigo.Text == "")
            {
                if (oNegocioGrupo.incluirGrupo(oGrupo))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oGrupo.codigo = Convert.ToInt32(txtCodigo.Text);

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

        protected void btnIncluirConta_Click(object sender, EventArgs e)
        {
            neMovimentoGrupo oNegocioGrupo = new neMovimentoGrupo();
            neMovimentoGrupoConta oNegocioConta = new neMovimentoGrupoConta();

            oNegocioGrupo = new neMovimentoGrupo();
            MovimentoGrupo oGrupo = oNegocioGrupo.buscaGrupo(Convert.ToInt32(txtCodigo.Text));

            MovimentoGrupoConta oConta = new MovimentoGrupoConta();


            oConta.codigoGrupo = Convert.ToInt32(txtCodigo.Text);
            oConta.Conta = txtConta.Text;


            if (btnIncluirConta.Text.Equals("Incluir Nova Conta"))
            {
                oNegocioConta.incluirConta(oConta);

                carregaListaConta(Convert.ToInt32(txtCodigo.Text));
                limpaCamposConta();

            }
            else if (btnIncluirConta.Text.Equals("Salvar"))
            {
                oConta.codigo = Convert.ToInt32(hfCodigoConta.Value);
                if (oNegocioConta.alterarConta(oConta))
                {
                    carregaListaConta(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposConta();
                }
            }
            else
            {
                oConta.codigo = Convert.ToInt32(hfCodigoConta.Value);
                if (oNegocioConta.excluirConta(oConta.codigo))
                {
                    carregaListaConta(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposConta();
                }
            }
        }

        protected void gvContas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            neMovimentoGrupoConta oNegocioConta = new neMovimentoGrupoConta();

            if (e.CommandName == "EditarConta")
            {
                limpaCamposConta();
                carregaCamposConta(oNegocioConta.buscaConta(codigo));
                btnIncluirConta.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirConta")
            {
                limpaCamposConta();
                carregaCamposConta(oNegocioConta.buscaConta(codigo));
                btnIncluirConta.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelarConta_Click(object sender, EventArgs e)
        {
            limpaCamposConta();
        }

    }
}
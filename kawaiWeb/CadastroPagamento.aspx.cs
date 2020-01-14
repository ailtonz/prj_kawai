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
    public partial class CadastroPagamento : System.Web.UI.Page
    {
        neMovimentoPagamento oNegocioPagamento;

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

            var lista = (from tbl in oBanco.MovimentoPagamento
                         select tbl);

            gvLista.DataSource = lista;
            gvLista.DataBind();
        }

        public void carregaCampos(MovimentoPagamento oPagamento)
        {
            txtCodigo.Text = oPagamento.codigo.ToString();
            txtPagamento.Text = oPagamento.FormaPagamento;

        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtPagamento.Text = string.Empty;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioPagamento = new neMovimentoPagamento();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioPagamento.buscaPagamento(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioPagamento.buscaPagamento(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioPagamento = new neMovimentoPagamento();

            MovimentoPagamento oPagamento = new MovimentoPagamento();

            oPagamento.FormaPagamento = txtPagamento.Text;


            if (txtCodigo.Text == "")
            {
                if (oNegocioPagamento.incluirPagamento(oPagamento))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oPagamento.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioPagamento.alterarPagamento(oPagamento))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioPagamento.excluirPagamento(oPagamento.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }
        }
        #endregion

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;
            carregaLista();
        }
    }
}
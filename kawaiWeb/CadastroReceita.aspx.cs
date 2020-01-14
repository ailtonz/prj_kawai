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
    public partial class CadastroReceita : System.Web.UI.Page
    {
        neMovimento oNegocioReceita;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpaCampos();
                carregaLista();
            }
        }

        #region metódos

        public void carregaLista()
        {
            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.Movimento
                         join tblCta in oBanco.Empresa on tbl.codigoConta equals tblCta.codigo
                         where tbl.codigoMovimento.Equals(1) 
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tblCta.nomeFantasia,
                             tbl.Documento,
                             tbl.Observacao,
                             tbl.dataVencimento,
                             tbl.ValorOriginal,
                             tbl.dataPagamento,
                             tbl.ValorFinal
                             
                         });

            gvLista.DataSource = lista;
            gvLista.DataBind();

            carregaListaEmpresa();

            carregaListaPagamento();
        }

        public void carregaListaEmpresa()
        {
            ddlCliente.Items.Clear();

            neEmpresa oNegocioEmpresa = new neEmpresa();
            
            ddlCliente.DataTextField = "nomeFantasia";
            ddlCliente.DataValueField = "codigo";
            ddlCliente.DataSource = oNegocioEmpresa.busca();
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(0, "Selecione");

        }


        public void carregaFiltroEmpresa()
        {
            ddlFiltrarCliente.Items.Clear();

            neEmpresa oNegocioEmpresa = new neEmpresa();

            ddlFiltrarCliente.Items.Clear();

            ddlFiltrarCliente.DataTextField = "nomeFantasia";
            ddlFiltrarCliente.DataValueField = "codigo";
            ddlFiltrarCliente.DataSource = oNegocioEmpresa.busca();
            ddlFiltrarCliente.DataBind();

            ddlFiltrarCliente.Items.Insert(0, "Selecione");


        }

        public void carregaListaPagamento()
        {
            ddlPagamento.Items.Clear();

            neMovimentoPagamento oNegocioPagamento = new neMovimentoPagamento();

            ddlPagamento.DataValueField = "Codigo";
            ddlPagamento.DataTextField = "FormaPagamento";
            ddlPagamento.DataSource = oNegocioPagamento.buscaPagamento();
            ddlPagamento.DataBind();

            ddlPagamento.Items.Insert(0, "Selecione");

        }

        public void carregaCampos(Movimento oReceita)
        {
            txtCodigo.Text = oReceita.codigo.ToString();
            txtDataEmissao.Text = oReceita.dataEmissao.ToString("dd/MM/yyyy");
            ddlCliente.SelectedValue = oReceita.codigoConta.ToString();
            txtDataVencimento.Text = oReceita.dataVencimento.ToString("dd/MM/yyyy");
            txtValorOriginal.Text = string.Format("{0:c}", oReceita.ValorOriginal.ToString());

            if (oReceita.Documento != null)
            {
                txtDocumento.Text = oReceita.Documento;
            }

            if (oReceita.Observacao != null)
            {
                txtObservacao.Text = oReceita.Observacao;
            }
            
            ddlPagamento.SelectedValue = oReceita.codigoPagamento.ToString();

            if (oReceita.dataPagamento != null)
            {
                txtDataPagamento.Text = oReceita.dataPagamento.Value.ToString("dd/MM/yyyy");
            }

            if (oReceita.ValorFinal != null)
            {
                txtValorFinal.Text = string.Format("{0:c}", oReceita.ValorFinal.ToString()); 
            }


        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlCliente.SelectedIndex = -1;
            txtDataVencimento.Text = string.Empty;
            txtValorOriginal.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            ddlPagamento.SelectedIndex = -1;
            txtDataPagamento.Text = string.Empty;
            txtValorFinal.Text = string.Empty;
            btnSalvar.Text = "Salvar";

            ddlFiltrarCliente.SelectedValue = "Selecione";

        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            Int32 codigoMovimento = Convert.ToInt32(1); // 1 - RECEITA
            oNegocioReceita = new neMovimento();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioReceita.busca(codigo, codigoMovimento));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioReceita.busca(codigo, codigoMovimento));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregaLista();
            divFiltro.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioReceita = new neMovimento();

            Movimento oReceita = new Movimento();
            
            oReceita.codigoMovimento = 1;
            oReceita.dataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
            oReceita.codigoConta = Convert.ToInt32(ddlCliente.SelectedValue);
            oReceita.dataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
            oReceita.ValorOriginal = Convert.ToDecimal(txtValorOriginal.Text);

            if (txtDocumento.Text != "")
            {
                oReceita.Documento = txtDocumento.Text;
            }

            if (txtObservacao.Text != "")
            {
                oReceita.Observacao = txtObservacao.Text;
            }

            oReceita.codigoPagamento = Convert.ToInt32(ddlPagamento.SelectedValue);

            if (txtDataPagamento.Text != "")
            {
                oReceita.dataPagamento = Convert.ToDateTime(txtDataPagamento.Text);
            }

            if (txtValorFinal.Text != "")
            {
                oReceita.ValorFinal = Convert.ToDecimal(txtValorFinal.Text);
            }
            
            if (txtCodigo.Text == "")
            {
                if (oNegocioReceita.incluir(oReceita))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oReceita.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioReceita.alterar(oReceita))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioReceita.excluir(oReceita.codigo))
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

            if (ddlFiltrarCliente.SelectedValue == "Selecione" || ddlFiltrarCliente.SelectedValue == "")
            {
                carregaLista();
            }
            else
            {
                FiltrarListaCliente(Convert.ToInt32(ddlFiltrarCliente.SelectedValue));
            }

        }

        public void FiltrarListaCliente(int codigoEmpresa)
        {
            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.Movimento
                         join tblCta in oBanco.Empresa on tbl.codigoConta equals tblCta.codigo
                         where tbl.codigoMovimento.Equals(1) && tbl.codigoConta.Equals(codigoEmpresa)
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tblCta.nomeFantasia,
                             tbl.Documento,
                             tbl.Observacao,
                             tbl.dataVencimento,
                             tbl.ValorOriginal,
                             tbl.dataPagamento,
                             tbl.ValorFinal

                         });

            gvLista.DataSource = lista;
            gvLista.DataBind();
        }

        protected void btnFiltroCliente_Click(object sender, EventArgs e)
        {
            if (ddlFiltrarCliente.SelectedValue == "Selecione")
            {
                limpaCampos();
                carregaLista();
            }
            else
            {
                FiltrarListaCliente(Convert.ToInt32(ddlFiltrarCliente.SelectedValue));
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            carregaFiltroEmpresa();
            divFiltro.Visible = true;
        }
    }
}
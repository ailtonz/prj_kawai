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
    public partial class CadastroDespesa : System.Web.UI.Page
    {
        neMovimento oNegocioDespesa;

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
            neMovimento oNegocioMovimento = new neMovimento();

            gvLista.DataSource = oNegocioMovimento.buscaMovimento(2);
            gvLista.DataBind();

            // CONTA
            ddlConta.Items.Clear();

            neMovimentoGrupoConta oNegocioConta = new neMovimentoGrupoConta();

            ddlConta.DataValueField = "Codigo";
            ddlConta.DataTextField = "Conta";
            ddlConta.DataSource = oNegocioConta.buscaConta();
            ddlConta.DataBind();

            ddlConta.Items.Insert(0, "Selecione");

            // PAGAMENTO
            ddlPagamento.Items.Clear();

            neMovimentoPagamento oNegocioPagamento = new neMovimentoPagamento();

            ddlPagamento.DataValueField = "Codigo";
            ddlPagamento.DataTextField = "FormaPagamento";
            ddlPagamento.DataSource = oNegocioPagamento.buscaPagamento();
            ddlPagamento.DataBind();

            ddlPagamento.Items.Insert(0, "Selecione");
        }




        public void carregaCampos(Movimento oDespesa)
        {
            txtCodigo.Text = oDespesa.codigo.ToString();
            txtDataEmissao.Text = oDespesa.dataEmissao.ToString("dd/MM/yyyy");
            ddlConta.SelectedValue = oDespesa.codigoConta.ToString();
            txtDataVencimento.Text = oDespesa.dataVencimento.ToString("dd/MM/yyyy");
            txtValorOriginal.Text = string.Format("{0:c}", oDespesa.ValorOriginal.ToString());

            if (oDespesa.Documento != null)
            {
                txtDocumento.Text = oDespesa.Documento;
            }

            if (oDespesa.Observacao != null)
            {
                txtObservacao.Text = oDespesa.Observacao;
            }

            ddlPagamento.SelectedValue = oDespesa.codigoPagamento.ToString();

            if (oDespesa.dataPagamento != null)
            {
                txtDataPagamento.Text = oDespesa.dataPagamento.Value.ToString("dd/MM/yyyy");
            }

            if (oDespesa.ValorFinal != null)
            {
                txtValorFinal.Text = string.Format("{0:c}", oDespesa.ValorFinal.ToString());
            }


        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlConta.SelectedIndex = -1;
            txtDataVencimento.Text = string.Empty;
            txtValorOriginal.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            ddlPagamento.SelectedIndex = -1;
            txtDataPagamento.Text = string.Empty;
            txtValorFinal.Text = string.Empty;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            Int32 codigoMovimento = Convert.ToInt32(2); // 2 - DESPESA
            oNegocioDespesa = new neMovimento();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioDespesa.busca(codigo, codigoMovimento));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioDespesa.busca(codigo, codigoMovimento));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregaLista();
            divFiltro.Visible = false;
            divParcelamento.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioDespesa = new neMovimento();

            Movimento oDespesa = new Movimento();

            oDespesa.codigoMovimento = 2;
            oDespesa.dataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
            oDespesa.codigoConta = Convert.ToInt32(ddlConta.SelectedValue);
            oDespesa.dataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
            oDespesa.ValorOriginal = Convert.ToDecimal(txtValorOriginal.Text);

            if (txtDocumento.Text != "")
            {
                oDespesa.Documento = txtDocumento.Text;
            }

            if (txtObservacao.Text != "")
            {
                oDespesa.Observacao = txtObservacao.Text;
            }

            oDespesa.codigoPagamento = Convert.ToInt32(ddlPagamento.SelectedValue);

            if (txtDataPagamento.Text != "")
            {
                oDespesa.dataPagamento = Convert.ToDateTime(txtDataPagamento.Text);
            }

            if (txtValorFinal.Text != "")
            {
                oDespesa.ValorFinal = Convert.ToDecimal(txtValorFinal.Text);
            }


            if (txtCodigo.Text == "")
            {
                if (oNegocioDespesa.incluir(oDespesa))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oDespesa.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioDespesa.alterar(oDespesa))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioDespesa.excluir(oDespesa.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }
        }
        #endregion

        protected void btnParcelamento_Click(object sender, EventArgs e)
        {
            Int32 x = Convert.ToInt32(txtNumeroDeParcelas.Text);
            Int32 diaAtual = Convert.ToInt32(txtDiaDoVencimento.Text);
            Int32 mesAtual = Convert.ToInt32(Convert.ToDateTime(txtDataVencimento.Text).Month);
            Int32 anoAtual = Convert.ToInt32(Convert.ToDateTime(txtDataVencimento.Text).Year);

            oNegocioDespesa = new neMovimento();

            for (int i = 1; i < x; i++)
            {


                Movimento oDespesa = new Movimento();

                oDespesa.codigoMovimento = 2;
                oDespesa.dataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
                oDespesa.codigoConta = Convert.ToInt32(ddlConta.SelectedValue);

                //new DateTime(2007, 8, 31).AddMonths(1);
                //oDespesa.dataVencimento = Convert.ToDateTime(txtDataVencimento.Text);

                oDespesa.dataVencimento = Convert.ToDateTime(new DateTime(anoAtual, mesAtual, diaAtual).AddMonths(1));
                mesAtual++;

                if (mesAtual == (Convert.ToInt32("13")))
                {
                    mesAtual = Convert.ToInt32("1");
                    anoAtual++;
                }
                
                oDespesa.ValorOriginal = Convert.ToDecimal(txtValorOriginal.Text);

                if (txtDocumento.Text != "")
                {
                    oDespesa.Documento = txtDocumento.Text;
                }


                //if (txtObservacao.Text != "")
                //{
                //    oDespesa.Observacao = txtObservacao.Text;
                //}

                oDespesa.codigoPagamento = Convert.ToInt32(ddlPagamento.SelectedValue);

                if (txtDataPagamento.Text != "")
                {
                    oDespesa.dataPagamento = Convert.ToDateTime(txtDataPagamento.Text);
                }

                if (txtValorFinal.Text != "")
                {
                    oDespesa.ValorFinal = Convert.ToDecimal(txtValorFinal.Text);
                }
                
                oDespesa.Observacao = "[" + Convert.ToString(i) + "-" + x + "]";


                oNegocioDespesa.incluir(oDespesa);

            }
            carregaLista();
        }





        protected void btnParcelar_Click(object sender, EventArgs e)
        {
            divParcelamento.Visible = true;
        }

        protected void btnCancelarParcelamento_Click(object sender, EventArgs e)
        {
            divParcelamento.Visible = false;
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;

            carregaFiltroConta();          
        }

        public void FiltrarListaConta(int codigoEmpresa)
        {
            neMovimento oNegocioMovimento = new neMovimento();

            gvLista.DataSource = oNegocioMovimento.buscaConta(2, codigoEmpresa);
            gvLista.DataBind();

        }

        public void carregaListaConta()
        {
            ddlFiltrarConta.Items.Clear();

            neMovimentoGrupoConta oNegocioConta = new neMovimentoGrupoConta();

            ddlFiltrarConta.DataValueField = "Codigo";
            ddlFiltrarConta.DataTextField = "Conta";
            ddlFiltrarConta.DataSource = oNegocioConta.buscaConta();
            ddlFiltrarConta.DataBind();

            ddlFiltrarConta.Items.Insert(0, "Selecione");

        }

        public void carregaFiltroConta()
        {

            if (ddlFiltrarConta.SelectedValue == "Selecione" || ddlFiltrarConta.SelectedValue == "")
            {
                limpaCampos();
                carregaLista();
            }
            else
            {
                FiltrarListaConta(Convert.ToInt32(ddlFiltrarConta.SelectedValue));
            }

        }

        protected void btnFiltroCliente_Click(object sender, EventArgs e)
        {
            carregaFiltroConta();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            carregaListaConta();
            divFiltro.Visible = true;
        }


    }
}
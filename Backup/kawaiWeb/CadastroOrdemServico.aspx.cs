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
    public partial class CadastroOrdemServico : System.Web.UI.Page
    {
        neOS oNegocioOS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpaCampos();
                carregaLista();
                carregaListaEmpresa();
                carregaListaStatus("ABERTO");
                carregaListaItem();
            }
        }

        #region metódos

        public void carregaLista()
        {
            oNegocioOS = new neOS();

            gvLista.DataSource = oNegocioOS.busca();
            gvLista.DataBind();
        }

        public void carregaListaConta(Int32 codigoGrupo)
        {
            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.OSItem
                         join tblCta in oBanco.Item on tbl.codigoServico equals tblCta.codigo
                         where tbl.codigoControle.Equals(1) && tbl.codigoOS.Equals(codigoGrupo)
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tblCta.descricao,
                             tbl.Observacao,
                             tbl.valorServico

                         });

            gvConta.DataSource = lista;
            gvConta.DataBind();

        }

        public void carregaListaObservacao(Int32 codigoGrupo)
        {

            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.OSItem
                         where tbl.codigoControle.Equals(2) && tbl.codigoOS.Equals(codigoGrupo)
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tbl.Observacao
                         });

            gvObservacao.DataSource = lista;
            gvObservacao.DataBind();

        }

        public void carregaListaEmpresa()
        {
            neEmpresa oNegocioEmpresa = new neEmpresa();

            ddlCliente.Items.Clear();
            ddlCliente.DataTextField = "nomeFantasia";
            ddlCliente.DataValueField = "codigo";
            ddlCliente.DataSource = oNegocioEmpresa.busca();
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(0, "Selecione");

            // LISTA DE EMPRESA PARA FILTRO DE RESERVAS
            ddlFiltrarCliente.Items.Clear();
            ddlFiltrarCliente.DataTextField = "nomeFantasia";
            ddlFiltrarCliente.DataValueField = "codigo";
            ddlFiltrarCliente.DataSource = oNegocioEmpresa.busca();
            ddlFiltrarCliente.DataBind();

            ddlFiltrarCliente.Items.Insert(0, "Selecione");

        }

        public void carregaListaStatus(string strStatus)
        {
            neOSStatus oNegocioOSStatus = new neOSStatus();

            ddlStatus.Items.Clear();
            ddlStatus.DataTextField = "Status";
            ddlStatus.DataValueField = "codigo";
            ddlStatus.DataSource = oNegocioOSStatus.busca();
            ddlStatus.DataBind();

            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(strStatus));

            // LISTA DE STATUS PARA FILTRO DE RESERVAS
            ddlFiltrarStatus.Items.Clear();
            ddlFiltrarStatus.DataTextField = "Status";
            ddlFiltrarStatus.DataValueField = "codigo";
            ddlFiltrarStatus.DataSource = oNegocioOSStatus.busca();
            ddlFiltrarStatus.DataBind();

            ddlFiltrarStatus.Items.Insert(0, "Selecione");

        }

        public void carregaListaItem()
        {
            neItem oNegocioItem = new neItem();

            ddlItem.Items.Clear();
            ddlItem.DataTextField = "descricao";
            ddlItem.DataValueField = "codigo";
            ddlItem.DataSource = oNegocioItem.busca();
            ddlItem.DataBind();

            ddlItem.Items.Insert(0, "Selecione");
        }

        public void carregaCampos(OS oOS)
        {

            txtCodigo.Text = oOS.codigo.ToString();
            
            txtDataInicio.Text = Convert.ToDateTime(oOS.dataInicio.ToString()).ToString("dd/MM/yyyy");
            if (!oOS.dataTerminio.ToString().Equals(""))
            {
                txtDataTerminio.Text = Convert.ToDateTime(oOS.dataTerminio.ToString()).ToString("dd/MM/yyyy");
            }

            ddlCliente.SelectedValue = oOS.codigoEmpresa.ToString();

            txtRequisitante.Text = oOS.nomeRequisitante.ToString();
            txtResponsavel.Text = oOS.nomeResponsavel.ToString();
            txtFilme.Text = oOS.Trabalho.ToString();
            txtControleCliente.Text = oOS.controleCliente.ToString();

            divPlanos.Visible = false;
            divConta.Visible = true;
            divObservacao.Visible = true;

        }

        public void carregaCamposConta(OSItem oOSItem)
        {
            hfCodigoConta.Value = oOSItem.codigo.ToString();

            ddlItem.SelectedValue = oOSItem.codigoServico.ToString();
            txtObservacao.Text = oOSItem.Observacao.ToString();
            txtvalorServico.Text = oOSItem.valorServico.ToString();
        }

        public void carregaCamposObservacao(OSItem oOSItem)
        {
            hfCodigoObservacao.Value = oOSItem.codigo.ToString();
            txtObservacaoAdicional.Text = oOSItem.Observacao.ToString();
        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDataInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDataTerminio.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //ddlEstudio.SelectedIndex = -1;

            txtDataInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //ddlHoraInicio.SelectedIndex = -1;

            txtDataTerminio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //ddlHoraTerminio.SelectedIndex = -1;

            ddlCliente.SelectedIndex = -1;

            txtRequisitante.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            txtFilme.Text = string.Empty;
            //txtCor.Text = string.Empty;
            txtControleCliente.Text = string.Empty;

            btnSalvar.Text = "Salvar";
            
            ddlFiltrarCliente.SelectedIndex = ddlFiltrarCliente.Items.IndexOf(ddlFiltrarCliente.Items.FindByValue("Selecione"));
            ddlFiltrarStatus.SelectedIndex = ddlFiltrarStatus.Items.IndexOf(ddlFiltrarStatus.Items.FindByValue("Selecione"));

            carregaLista();
        }

        public void limpaCamposConta()
        {
            ddlItem.SelectedIndex = -1;
            txtObservacao.Text = string.Empty;
            txtvalorServico.Text = string.Empty;
            btnIncluirConta.Text = "Incluir Novo Item";
        }

        public void limpaCamposObservacao()
        {
            txtObservacaoAdicional.Text = string.Empty;
            btnIncluirObservacao.Text = "Incluir Nova Observação";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioOS = new neOS();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioOS.buscaOS(codigo));
                carregaListaConta(codigo);
                carregaListaObservacao(codigo);
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioOS.buscaOS(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelarConta_Click(object sender, EventArgs e)
        {
            limpaCamposConta();
        }

        protected void btnCancelarObservacao_Click(object sender, EventArgs e)
        {
            limpaCamposObservacao();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            divPlanos.Visible = true;
            divConta.Visible = false;
            divObservacao.Visible = false;

        }



        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioOS = new neOS();

            OS oOS = new OS();

            //neItem oNegocioItem = new neItem();
            //Item oItem = oNegocioItem.busca(Convert.ToInt32(ddlEstudio.SelectedValue));

            //oOS.codigoEstudio = Convert.ToInt32(ddlEstudio.SelectedValue);
            //oOS.dataInicio = Convert.ToDateTime(txtDataInicio.Text + " " + ddlHoraInicio.SelectedValue);
            //oOS.dataTerminio = Convert.ToDateTime(txtDataTerminio.Text + " " + ddlHoraTerminio.SelectedValue);

            oOS.dataInicio = Convert.ToDateTime(txtDataInicio.Text);
            oOS.dataTerminio = Convert.ToDateTime(txtDataTerminio.Text);

            
            oOS.codigoEmpresa = Convert.ToInt32(ddlCliente.SelectedValue);


            oOS.nomeRequisitante = txtRequisitante.Text;
            oOS.nomeResponsavel = txtResponsavel.Text;
            oOS.Trabalho = txtFilme.Text;
            oOS.controleCliente = txtControleCliente.Text;
            oOS.codigoStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            oOS.codigoTipo = 1;

            if (txtCodigo.Text == "")
            {
                if (oNegocioOS.incluir(oOS))
                {
                    carregaLista();
                    limpaCampos();
                    divPlanos.Visible = true;
                    divConta.Visible = false;
                    divObservacao.Visible = false;
                }
            }
            else
            {
                oOS.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioOS.alterar(oOS))
                    {
                        carregaLista();
                        limpaCampos();
                        divPlanos.Visible = true;
                        divConta.Visible = false;
                        divObservacao.Visible = false;
                    }
                }
                else
                {
                    if (oNegocioOS.excluir(oOS.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                        divPlanos.Visible = true;
                        divConta.Visible = false;
                        divObservacao.Visible = false;
                    }
                }
            }

        }

        #endregion

        public void incluiItem(int codigoOS, int codigoServico, string observacao, decimal valorServico, string acao)
        {
            Int32 codigoControle = Convert.ToInt32(1); // 1 - SERVIÇO

            neOS oNegocioOS = new neOS();
            neOSItem oNegocioOSItem = new neOSItem();

            oNegocioOS = new neOS();
            OS oOS = oNegocioOS.buscaOS(codigoOS);

            OSItem oOSItem = new OSItem();

            oOSItem.codigoOS = codigoOS;
            oOSItem.codigoControle = codigoControle;
            oOSItem.codigoServico = codigoServico;
            oOSItem.Observacao = observacao;
            oOSItem.valorServico = valorServico;

            if (acao.Equals("Incluir Novo Item"))
            {
                oNegocioOSItem.incluirOSItem(oOSItem);

                carregaListaConta(codigoOS);
                limpaCamposConta();

            }
            else if (acao.Equals("Salvar"))
            {
                oOSItem.codigo = Convert.ToInt32(hfCodigoConta.Value);
                if (oNegocioOSItem.alterarOSItem(oOSItem))
                {
                    carregaListaConta(codigoOS);
                    limpaCamposConta();
                }
            }
            else
            {
                oOSItem.codigo = Convert.ToInt32(hfCodigoConta.Value);
                if (oNegocioOSItem.excluirOSItem(oOSItem.codigo))
                {
                    carregaListaConta(codigoOS);
                    limpaCamposConta();
                }
            }
        }

        public void incluiObservacao(int codigoOS, string observacao, string acao)
        {
            Int32 codigoControle = Convert.ToInt32(2); // 2 - OBSERVAÇÃO

            neOS oNegocioOS = new neOS();
            neOSItem oNegocioOSItem = new neOSItem();

            oNegocioOS = new neOS();
            OS oOS = oNegocioOS.buscaOS(codigoOS);

            OSItem oOSItem = new OSItem();

            oOSItem.codigoOS = codigoOS;
            oOSItem.codigoControle = codigoControle;
            oOSItem.Observacao = observacao;


            if (acao.Equals("Incluir Nova Observação"))
            {
                oNegocioOSItem.incluirOSItem(oOSItem);

                carregaListaObservacao(codigoOS);
                limpaCamposObservacao();

            }
            else if (acao.Equals("Salvar"))
            {
                oOSItem.codigo = Convert.ToInt32(hfCodigoObservacao.Value);
                if (oNegocioOSItem.alterarOSItem(oOSItem))
                {
                    carregaListaObservacao(codigoOS);
                    limpaCamposObservacao();
                }
            }
            else
            {
                oOSItem.codigo = Convert.ToInt32(hfCodigoObservacao.Value);
                if (oNegocioOSItem.excluirOSItem(oOSItem.codigo))
                {
                    carregaListaObservacao(codigoOS);
                    limpaCamposObservacao();
                }
            }
        }


        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            neItem oNegocioItem = new neItem();
            Item oItem = oNegocioItem.busca(Convert.ToInt32(ddlItem.SelectedValue));

            //hfCodigoConta.Value = ddlItem.SelectedValue.ToString();

            txtvalorServico.Text = oItem.valor.Value.ToString();
        }

        protected void btnIncluirConta_Click(object sender, EventArgs e)
        {
            divConta.Visible = true;
            btnIncluirConta.Visible = true;
            incluiItem(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(ddlItem.SelectedValue), txtObservacao.Text, Convert.ToDecimal(txtvalorServico.Text), btnIncluirConta.Text);
        }

        protected void btnIncluirObservacao_Click(object sender, EventArgs e)
        {
            divObservacao.Visible = true;
            btnIncluirObservacao.Visible = true;
            incluiObservacao(Convert.ToInt32(txtCodigo.Text), txtObservacaoAdicional.Text, btnIncluirObservacao.Text);
        }


        protected void gvContas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            neOSItem oNegocioOSItem = new neOSItem();

            if (e.CommandName == "EditarConta")
            {
                limpaCamposConta();
                carregaCamposConta(oNegocioOSItem.buscaOSItem(codigo));
                btnIncluirConta.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirConta")
            {
                limpaCamposConta();
                carregaCamposConta(oNegocioOSItem.buscaOSItem(codigo));
                btnIncluirConta.Text = "Confirma Exclusão?";
            }
        }


        protected void gvObservacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            neOSItem oNegocioOSItem = new neOSItem();

            if (e.CommandName == "EditarObservacao")
            {
                limpaCamposObservacao();
                carregaCamposObservacao(oNegocioOSItem.buscaOSItem(codigo));
                btnIncluirObservacao.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirObservacao")
            {
                limpaCamposObservacao();
                carregaCamposObservacao(oNegocioOSItem.buscaOSItem(codigo));
                btnIncluirObservacao.Text = "Confirma Exclusão?";
            }
        }

        protected void gvConta_DataBound(object sender, EventArgs e)
        {

        }

        private decimal valorTotal = 0;

        protected void gvConta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
                valorTotal += Convert.ToDecimal(e.Row.Cells[3].Text.Replace("R$ ", ""));

            if (e.Row.RowType.Equals(DataControlRowType.Footer))
                e.Row.Cells[3].Text = "R$ " + string.Format("{0:d}", valorTotal.ToString());
        }


        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;

            carregaLista();
        }


        public void FiltrarListaCliente(int codigoEmpresa)
        {
            
            oNegocioOS = new neOS();
            
            gvLista.DataSource = oNegocioOS.buscaOSEmpresa(codigoEmpresa);
            gvLista.DataBind();
        }

        public void FiltrarListaStatus(int codigoStatus)
        {
            oNegocioOS = new neOS();

            gvLista.DataSource = oNegocioOS.buscaOSStatus(codigoStatus);
            gvLista.DataBind();
        }

        public void FiltrarListaClienteStatus(int codigoEmpresa, int codigoStatus)
        {

            oNegocioOS = new neOS();

            gvLista.DataSource = oNegocioOS.buscaOSEmpresaStatus(codigoEmpresa, codigoStatus);
            gvLista.DataBind();
        }

        protected void btnFiltroCliente_Click(object sender, EventArgs e)
        {
            FiltrarListaCliente(Convert.ToInt32(ddlFiltrarCliente.SelectedValue));
        }

        protected void btnFiltroStatus_Click(object sender, EventArgs e)
        {

            if (!ddlFiltrarCliente.SelectedValue.Equals("Selecione") && !ddlFiltrarStatus.SelectedValue.Equals("Selecione"))
            {
                FiltrarListaClienteStatus(Convert.ToInt32(ddlFiltrarCliente.SelectedValue), Convert.ToInt32(ddlFiltrarStatus.SelectedValue));
            }

            if (!ddlFiltrarCliente.SelectedValue.Equals("Selecione"))
            {
                FiltrarListaCliente(Convert.ToInt32(ddlFiltrarCliente.SelectedValue));
            }

            if (!ddlFiltrarStatus.SelectedValue.Equals("Selecione"))
            {
                FiltrarListaStatus(Convert.ToInt32(ddlFiltrarStatus.SelectedValue));
            }                      
            
        }


        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divFiltro.Visible = true;
        }

    }
}
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
    public partial class CadastroServico : System.Web.UI.Page
    {
        neItem oNegocioItem;

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
            ddlTipo.Items.Clear();

            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.Item
                         join tblSrv in oBanco.AluguelTipo on tbl.codigoAluguelTipo equals tblSrv.codigo
                         orderby tblSrv.descricao descending
                         select new
                         {
                             tbl.codigo,
                             tipoServico = tblSrv.descricao,
                             tbl.descricao,
                             tbl.valor
                         });

            gvLista.DataSource = lista;
            gvLista.DataBind();
            

            neAluguelTipo oNegocioAluguelTipo = new neAluguelTipo();

            ddlTipo.DataValueField = "Codigo";
            ddlTipo.DataTextField = "Descricao";
            ddlTipo.DataSource = oNegocioAluguelTipo.busca();
            ddlTipo.DataBind();

            ddlTipo.Items.Insert(0, "Selecione");

            // filtro de serviços
            ddlFiltrarTipo.DataValueField = "Codigo";
            ddlFiltrarTipo.DataTextField = "Descricao";
            ddlFiltrarTipo.DataSource = oNegocioAluguelTipo.busca();
            ddlFiltrarTipo.DataBind();

            ddlFiltrarTipo.Items.Insert(0, "Selecione");

        }

        public void carregaCampos(Item oItem)
        {
            txtCodigo.Text = oItem.codigo.ToString();
            txtDescricao.Text = oItem.descricao;
            txtValor.Text = oItem.valor.ToString();
            ddlTipo.SelectedValue = oItem.codigoAluguelTipo.ToString();
        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtValor.Text = string.Empty;
            ddlTipo.SelectedIndex = -1;
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioItem = new neItem();

            if (e.CommandName == "Editar")
            {
                carregaCampos(oNegocioItem.busca(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioItem.busca(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioItem = new neItem();

            Item oItem = new Item();
            
            oItem.descricao = txtDescricao.Text;
            oItem.valor = Convert.ToDecimal(txtValor.Text);
            oItem.codigoAluguelTipo = Convert.ToInt32(ddlTipo.SelectedValue);

            if (txtCodigo.Text == "")
            {
                if (oNegocioItem.incluir(oItem))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oItem.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioItem.alterar(oItem))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioItem.excluir(oItem.codigo))
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

        protected void gvListaItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

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

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;

            carregaLista();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divFiltro.Visible = true;
        }

        protected void btnFiltroTipo_Click(object sender, EventArgs e)
        {
            FiltrarListaTipo(Convert.ToInt32(ddlFiltrarTipo.SelectedValue));
        }

        public void FiltrarListaTipo(int codigoAluguelTipo)
        {
            oNegocioItem = new neItem();

            gvLista.DataSource = oNegocioItem.buscaAluguelTipo(codigoAluguelTipo);
            gvLista.DataBind();
        }

    }
}
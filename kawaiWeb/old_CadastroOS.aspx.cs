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
    public partial class CadastroOS : System.Web.UI.Page
    {

        neOS oNegocioOS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaListaEmpresa();
                carregaListaEstudio();
                carregaLista();
                carregaItem();
            }
        }

        #region metódos

        public void carregaListaEmpresa()
        {
            neEmpresa oNegocioEmpresa = new neEmpresa();

            ddlCliente.DataTextField = "nomeFantasia";
            ddlCliente.DataValueField = "codigo";
            ddlCliente.DataSource = oNegocioEmpresa.busca();
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(0, "Selecione");

        }

        public void carregaListaEstudio()
        {
            neItem oNegocioItem = new neItem();

            ddlEstudio.DataTextField = "descricao";
            ddlEstudio.DataValueField = "codigo";
            ddlEstudio.DataSource = oNegocioItem.buscaEstudio();
            ddlEstudio.DataBind();

            ddlEstudio.Items.Insert(0, "Selecione");

        }
        
        public void carregaItem()
        {
            ddlItem.Items.Clear();
            neItem oNegocioItem = new neItem();
            ddlItem.DataTextField = "descricao";
            ddlItem.DataValueField = "codigo";

            ddlItem.DataSource = oNegocioItem.busca();
            ddlItem.DataBind();

            ddlItem.Items.Insert(0, "Selecione");
        }

        public void carregaListaOS()
        {
            neOS oNegocioOS = new neOS();
            gvLista.DataSource = oNegocioOS.buscaOSEmpresa(Convert.ToInt32(ddlCliente.SelectedValue));
        }

        public void carregaCampos(OS oOS)
        {
            txtDataInicio.Text = oOS.dataInicio.ToString();
            txtDataTerminio.Text = oOS.dataTerminio.ToString();

            //oOS.codigoEstudio = Convert.ToInt32(ddlEstudio.SelectedValue);

            txtDataInicio.Text = oOS.dataInicio.ToString("dd/MM/yyy");
            //ddlHoraInicio.SelectedValue

            txtDataTerminio.Text = oOS.dataTerminio.ToString("dd/MM/yyy");
            //ddlHoraTerminio.SelectedValue

            //ddlCliente.SelectedValue

            txtRequisitante.Text = oOS.nomeRequisitante.ToString();
            txtResponsavel.Text = oOS.nomeResponsavel.ToString();
            txtFilme.Text = oOS.Trabalho.ToString();
            txtCor.Text = oOS.Cor.ToString();
            txtControleCliente.Text = oOS.controleCliente.ToString();




            btnSalvar.Text = "Salvar";
        }

        public void carregaLista()
        {
            dbKawaiBanco oBanco = new dbKawaiBanco();

            var lista = (from tbl in oBanco.OS
                         join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tblEmp.nomeFantasia,
                             tbl.Trabalho,
                             tbl.dataInicio,
                             tbl.dataTerminio
                         });

            gvLista.DataSource = lista;
            gvLista.DataBind();

        }


        public void carregaListaItem()
        {
            Int32 codigo = Convert.ToInt32(txtCodigo.Text);

            //camada de negocio
            neOSItem oNegocioOSItem = new neOSItem();
            gvItens.DataSource = oNegocioOSItem.buscaListaOSItem(codigo);
            gvItens.DataBind();

        }

        public void limpaCamposOS()
        {
            txtCodigo.Text = string.Empty;
            txtDataInicio.Text = string.Empty;
            ddlHoraInicio.SelectedValue.Equals("00:00");
            txtDataTerminio.Text = string.Empty;
            ddlHoraTerminio.SelectedValue.Equals("00:00");
            //ddlPessoa.SelectedIndex = -1;
            ddlCliente.SelectedIndex = -1;
            //divListaOS.Visible = false;
            btnSalvar.Text = "Incluir Nova OS";
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
                carregaListaItem();
                divItem.Visible = true;
                
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioOS.buscaOS(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            OSItem oItem = new OSItem();

            //oItem.dataInicioAluguel = Convert.ToDateTime(txtItemDataInicio.Text);
            //oItem.dataFinalAluguel = Convert.ToDateTime(txtItemDataFim.Text);
            oItem.Observacao = txtObservacao.Text;
        }
        #endregion

        //protected void ddlAluguelTipo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    divItem.Visible = true;
        //    carregaListaItem();
        //}

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            neItem oNegocioItem = new neItem();
            Item oItem = oNegocioItem.busca(Convert.ToInt32(ddlItem.SelectedValue));

            txtPreco.Text = oItem.valor.Value.ToString();
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //carregaListaPessoa();
            //divRequisitante.Visible = true;
            //divListaOS.Visible = true;
            //carregaListaOS(Convert.ToInt32(ddlCliente.SelectedValue));
        }

        public void fechaMsg()
        {
            divFlutuante.Attributes["class"] = "divFlutuante hidden";
            divFlutuanteMsg.Attributes["class"] = "divPosiciona hidden";
            lblMsg.Text = "";
        }

        public void showMsg(string msg)
        {
            divFlutuante.Attributes["class"] = "divFlutuante";
            divFlutuanteMsg.Attributes["class"] = "divPosiciona";
            lblMsg.Text = msg;
        }

        protected void btnCancelarOS_Click(object sender, EventArgs e)
        {
            limpaCamposOS();
        }

        protected void btnSalvarOS_Click(object sender, EventArgs e)
        {
            oNegocioOS = new neOS();
            OS oOS = new OS();

            oOS.codigoEstudio = Convert.ToInt32(ddlEstudio.SelectedValue);
            oOS.dataInicio = Convert.ToDateTime(txtDataInicio.Text + " " + ddlHoraInicio.SelectedValue);
            oOS.dataTerminio = Convert.ToDateTime(txtDataTerminio.Text + " " + ddlHoraTerminio.SelectedValue);
            oOS.codigoEmpresa = Convert.ToInt32(ddlCliente.SelectedValue);
            oOS.nomeRequisitante = txtRequisitante.Text;
            oOS.nomeResponsavel = txtResponsavel.Text;
            oOS.Trabalho = txtFilme.Text;
            oOS.Cor = txtCor.Text;
            oOS.controleCliente = txtControleCliente.Text;

            if (txtCodigo.Text == "")
            {
                #region incluir
                if (oNegocioOS.incluir(oOS))
                {
                    limpaCamposOS();
                    showMsg("OS salva com Sucesso!");
                }
                #endregion
            }
            else
            {
                oOS.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioOS.alterar(oOS))
                    {
                        showMsg("OS salva com Sucesso!");
                        limpaCamposOS();
                    }
                }
                else
                {
                    if (oNegocioOS.excluir(oOS.codigo))
                    {
                        showMsg("OS excluida com Sucesso!");
                        limpaCamposOS();
                    }
                }
            }

            carregaLista();
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            fechaMsg();
        }
    }
}
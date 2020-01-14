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
    public partial class CadastroPessoa : System.Web.UI.Page
    {
        neEmpresa oNegocioEmpresa;
        nePessoa oNegocioPessoa;
        Empresa oEmpresaSelecionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oEmpresaSelecionada = null;
                carregaListaEmpresa();

                lbMudarEmpresa.Visible = Session["oEmpresa"] != null;

                if (Session["oEmpresa"] != null)
                {
                    oEmpresaSelecionada = (Empresa)Session["oEmpresa"];
                    ddlEmpresa.SelectedValue = oEmpresaSelecionada.codigo.ToString();

                    ddlEmpresa.Enabled = false;

                    if (Session["oPessoa"] != null)
                    {
                       // txtCodigo.Text = ((Pessoa)Session["oPessoa"]).codigo.ToString();
                        carregaCamposPessoa((Pessoa)Session["oPessoa"]);
                    }

                    if (Session["flagexcluir"] != null)
                    {
                        btnSalvar.Text = "Confirma Exclusão?";
                    }
                }

                carregaListaPessoas();
            }
        }

        #region metódos

        public void carregaListaEmpresa()
        {
            oNegocioEmpresa = new neEmpresa();
            ddlEmpresa.DataTextField = "nomefantasia";
            ddlEmpresa.DataValueField = "codigo";
            ddlEmpresa.DataSource = oNegocioEmpresa.busca();
            ddlEmpresa.DataBind();
        }

        public void carregaListaPessoas()
        {
            oNegocioPessoa = new nePessoa();

            gvLista.DataSource = oNegocioPessoa.buscaPessoaEmpresa(Convert.ToInt32(ddlEmpresa.SelectedValue));
            gvLista.DataBind();
        }

        public void carregaCamposPessoa(Pessoa oPessoa)
        {
            txtCodigo.Text = oPessoa.codigo.ToString();
            txtNome.Text = oPessoa.nome;
            txtCPF.Text = oPessoa.CPF;
            txtRG.Text = oPessoa.RG;

            btnSalvar.Text = "Salvar";
        }

        public void limpaCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioPessoa = new nePessoa();

            if (e.CommandName == "Editar")
            {
                limpaCampos();
                carregaCamposPessoa(oNegocioPessoa.buscaPessoa(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                limpaCampos();
                carregaCamposPessoa(oNegocioPessoa.buscaPessoa(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioPessoa = new nePessoa();

            Pessoa oPessoa = new Pessoa();

            oPessoa.nome = txtNome.Text;
            oPessoa.CPF = txtCPF.Text;
            oPessoa.RG = txtRG.Text;
            oPessoa.codigoEmpresa = Convert.ToInt32(ddlEmpresa.SelectedValue);

            if (txtCodigo.Text == "")
            {
                #region incluir
                if (oNegocioPessoa.incluir(oPessoa))
                {
                    carregaListaPessoas();
                    limpaCampos();

                    if (Session["oEmpresa"] != null)
                    {
                        Response.Redirect("CadastroEmpresa.aspx");
                    }
                }
                #endregion
            }
            else
            {
                oPessoa.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioPessoa.alterar(oPessoa))
                    {
                        carregaListaPessoas();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioPessoa.excluir(oPessoa.codigo))
                    {
                        carregaListaPessoas();
                        limpaCampos();
                    }
                }
            }

            divFlutuante.Visible = true;
            lblMsg.Text = "Dados salvos com sucesso!";

            Session["oPessoa"] = null;
            Session["flagexcluir"] = null;

        }
        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            divFlutuante.Visible = false;
        }

        protected void btnIncluirPessoa_Click(object sender, EventArgs e)
        {

        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaListaPessoas();
            limpaCampos();
        }

        protected void lbMudarEmpresa_Click(object sender, EventArgs e)
        {
            Session["oEmpresa"] = null;
            Response.Redirect("CadastroPessoa.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroEmpresa.aspx");
        }

    }
}
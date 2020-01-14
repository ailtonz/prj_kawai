using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiBco;
using kawaiNeg;
using System.Data;
using System.Threading;

namespace kawaiWeb
{
    public partial class CadastroEmpresa : System.Web.UI.Page
    {
        neEmpresa oNegocioEmpresa;
        //nePessoa oNegocioPessoa;
        Empresa oEmpresaSelecionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            oEmpresaSelecionada = null;

            if (!IsPostBack)
            {
                carregaLista();

                if (Session["oEmpresa"] != null)
                {
                    oEmpresaSelecionada = (Empresa)Session["oEmpresa"];
                    carregaCampos(oEmpresaSelecionada);
                }
            }

            btnIncluirPessoa.Visible = !txtCodigo.Text.Equals("");
            //divEndereco.Visible = !txtCodigo.Text.Equals("");
            //divTelefone.Visible = !txtCodigo.Text.Equals("");
        }

        #region metódos

        public void carregaLista()
        {
            oNegocioEmpresa = new neEmpresa();

            gvLista.DataSource = oNegocioEmpresa.busca();
            gvLista.DataBind();

            neUF oNegocioUF = new neUF();

            ddlUF.DataValueField = "Codigo";
            ddlUF.DataTextField = "Descricao";
            ddlUF.DataSource = oNegocioUF.buscaUF();
            ddlUF.DataBind();

            neEnderecoTipo oTipoEndereco = new neEnderecoTipo();

            ddlTipoEndereco.DataValueField = "Codigo";
            ddlTipoEndereco.DataTextField = "Descricao";
            ddlTipoEndereco.DataSource = oTipoEndereco.busca();
            ddlTipoEndereco.DataBind();


            neTelefoneTipo oTipoTelefone = new neTelefoneTipo();

            ddlTipoTelefone.DataValueField = "Codigo";
            ddlTipoTelefone.DataTextField = "Descricao";
            ddlTipoTelefone.DataSource = oTipoTelefone.busca();
            ddlTipoTelefone.DataBind();

            nePessoaTipo oPessoaTipo = new nePessoaTipo();

            ddlTipoContato.DataValueField = "Codigo";
            ddlTipoContato.DataTextField = "Descricao";
            ddlTipoContato.DataSource = oPessoaTipo.busca();
            ddlTipoContato.DataBind();


        }


        //public void carregaPessoa()
        //{
        //    oNegocioEmpresa = new neEmpresa();

        //    gvLista.DataSource = oNegocioEmpresa.busca();
        //    gvLista.DataBind();
            
        //}


        //public void carregaTelefone()
        //{

        //    neTelefoneTipo oTipoTelefone = new neTelefoneTipo();

        //    ddlTipoTelefone.DataValueField = "Codigo";
        //    ddlTipoTelefone.DataTextField = "Descricao";
        //    ddlTipoTelefone.DataSource = oTipoTelefone.busca();
        //    ddlTipoTelefone.DataBind();

        //}

        //public void carregaEndereco()
        //{

        //    neEnderecoTipo oTipoEndereco = new neEnderecoTipo();

        //    ddlTipoEndereco.DataValueField = "Codigo";
        //    ddlTipoEndereco.DataTextField = "Descricao";
        //    ddlTipoEndereco.DataSource = oTipoEndereco.busca();
        //    ddlTipoEndereco.DataBind();

        //}

        public void carregaListaPessoa(Int32 codigoEmpresa)
        {
            divPessoa.Visible = true;
            btnIncluirPessoa.Visible = true;

            nePessoa oNegocioPesso = new nePessoa();

            gvPessoa.DataSource = oNegocioPesso.buscaPessoaEmpresa(codigoEmpresa);
            gvPessoa.DataBind();
        }

        //public void carregaListaPessoa(Int32 codigoEmpresa, txt)
        //{
        //    divPessoa.Visible = true;
        //    btnIncluirPessoa.Visible = true;

        //    nePessoa oNegocioPesso = new nePessoa();

        //    gvPessoa.DataSource = oNegocioPesso.buscaPessoaEmpresa(codigoEmpresa);
        //    gvPessoa.DataBind();
        //}

        public void carregaListaTelefone(Int32 codigoEmpresa)
        {
            divlistaTelefone.Visible = true;
            btnIncluirTelefone.Visible = true;

            neTelefone oNegocioTelefone = new neTelefone();

            gvTelefone.DataSource = oNegocioTelefone.buscaTelefoneEmpresa(codigoEmpresa);
            gvTelefone.DataBind();
        }

        public void carregaListaEndereco(Int32 codigoEmpresa)
        {

            divListaEndereco.Visible = true;
            btnIncluirEndereco.Visible = true;

            neEndereco oNegocioEndereco = new neEndereco();

            gvEndereco.DataSource = oNegocioEndereco.buscaEnderecoEmpresa(codigoEmpresa);
            gvEndereco.DataBind();
        }


        public void limpaCampos()
        {
            divPessoa.Visible = btnIncluirPessoa.Visible = false;

            txtCNPJ.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtInscricaoEstadual.Text = string.Empty;
            txtNomeFantasia.Text = string.Empty;
            txtRazaoSocial.Text = string.Empty;
            txtSite.Text = string.Empty;

            btnSalvar.Text = "Incluir Nova Empresa";

            divPessoa.Visible = false;
            btnIncluirPessoa.Visible = false;

            divListaEndereco.Visible = false;
            divEndereco.Visible = false;
            
            divlistaTelefone.Visible = false;
            divTelefone.Visible = false;

            divListaEmpresa.Visible = true;

            txtFiltrarNomeFantasia.Text = string.Empty;

        }


        public void limpaCamposTelefone()
        {
            txtDDI.Text = string.Empty;
            txtDDD.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            ddlTipoTelefone.SelectedIndex = -1;

            btnIncluirTelefone.Text = "Incluir Novo Telefone";
        }

        public void limpaCamposPessoa()
        {
            txtContato.Text = string.Empty;
            txtDDIContato.Text = string.Empty;
            txtDDDContato.Text = string.Empty;
            txtTelefoneContato.Text = string.Empty;
            ddlTipoContato.SelectedIndex = -1;

            btnIncluirPessoa.Text = "Incluir Novo Contato";
        }


        public void limpaCamposEndereco()
        {
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtCidade.Text = string.Empty;
            ddlUF.SelectedIndex = -1;
            ddlTipoEndereco.SelectedIndex = -1;

            btnIncluirEndereco.Text = "Incluir Novo Endereço";

        }
        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                string[] args = e.CommandArgument.ToString().Split(';');
                Int32 codigo = Convert.ToInt32(args[0]);
                oNegocioEmpresa = new neEmpresa();

                limpaCampos();
                oEmpresaSelecionada = oNegocioEmpresa.busca(codigo);
                carregaCampos(oEmpresaSelecionada);
            }

            if (e.CommandName == "Editar")
            {
                divEndereco.Visible = !txtCodigo.Text.Equals("");
                divTelefone.Visible = !txtCodigo.Text.Equals("");

                carregaListaEndereco(oEmpresaSelecionada.codigo);
                carregaListaPessoa(oEmpresaSelecionada.codigo);
                carregaListaTelefone(oEmpresaSelecionada.codigo);

                btnSalvar.Text = "Salvar Empresa";
                divPessoa.Visible = true;
                divListaEmpresa.Visible = false;
                divFiltrarDados.Visible = false;
                btnFiltro.Visible = false;
            }

            if (e.CommandName == "Excluir")
            {
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregaLista();
            btnFiltro.Visible = true;
            divFiltrarDados.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioEmpresa = new neEmpresa();

            Empresa oEmpresa = new Empresa();
            neTelefone oNegocioTelefone = new neTelefone();

            oEmpresa.CNPJ = txtCNPJ.Text;
            oEmpresa.IE = txtInscricaoEstadual.Text;
            oEmpresa.nomeFantasia = txtNomeFantasia.Text;
            oEmpresa.razaoSocial = txtRazaoSocial.Text;
            oEmpresa.site = txtSite.Text;
            oEmpresa.controleCliente = txtControleCliente.Text;

            if (txtCodigo.Text == "")
            {
                #region incluir
                if (oNegocioEmpresa.incluir(oEmpresa))
                {
                    carregaLista();
                    limpaCampos();
                    //Session.Add("oEmpresa", oEmpresa);
                    //Response.Redirect("CadastroPessoa.aspx");
                }
                #endregion
            }
            else
            {
                oEmpresa.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar Empresa"))
                {
                    if (oNegocioEmpresa.alterar(oEmpresa))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
                else
                {
                    if (oNegocioEmpresa.excluir(oEmpresa.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }

            showMsg("Dados salvos com sucesso!");

        }
        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            fechaMsg();
        }

        protected void btnIncluirPessoa_Click(object sender, EventArgs e)
        {

            neEmpresa oNegocioEmpresa = new neEmpresa();
            nePessoa oNegocioPessoa = new nePessoa();

            oNegocioEmpresa = new neEmpresa();
            Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));

            Pessoa oPessoa = new Pessoa();

            oPessoa.codigoEmpresa = Convert.ToInt32(txtCodigo.Text);
            oPessoa.nome = txtContato.Text;
            oPessoa.codigoTipo = Convert.ToInt32(ddlTipoContato.SelectedValue);

         
            if (!txtDDIContato.Text.Equals(""))
                oPessoa.ddi = Convert.ToInt32(txtDDIContato.Text);
            if (!txtDDDContato.Text.Equals(""))
                oPessoa.ddd = Convert.ToInt32(txtDDDContato.Text);
            if (!txtTelefoneContato.Text.Equals(""))
                oPessoa.numero = txtTelefoneContato.Text;



            if (btnIncluirPessoa.Text.Equals("Incluir Novo Contato"))
            {
                oNegocioPessoa.incluir(oPessoa);

                carregaListaPessoa(Convert.ToInt32(txtCodigo.Text));
                limpaCamposPessoa();

            }
            else if (btnIncluirPessoa.Text.Equals("Salvar"))
            {
                oPessoa.codigo = Convert.ToInt32(hfCodigoPessoa.Value);
                if (oNegocioPessoa.alterar(oPessoa))
                {
                    carregaListaPessoa(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposPessoa();
                }
            }
            else
            {
                oPessoa.codigo = Convert.ToInt32(hfCodigoPessoa.Value);
                if (oNegocioPessoa.excluir(oPessoa.codigo))
                {
                    carregaListaPessoa(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposPessoa();
                }
            }

            //oNegocioEmpresa = new neEmpresa();
            //Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));
            //Session.Add("oEmpresa", oEmpresa);
            //Response.Redirect("CadastroPessoa.aspx");
        }

        public void carregaCampos(Empresa oEmpresa)
        {
            txtCodigo.Text = oEmpresa.codigo.ToString();
            txtRazaoSocial.Text = oEmpresa.razaoSocial;
            txtNomeFantasia.Text = oEmpresa.nomeFantasia;
            txtCNPJ.Text = oEmpresa.CNPJ;
            txtInscricaoEstadual.Text = oEmpresa.IE;
            txtSite.Text = oEmpresa.site;

            
        }

        public void carregaCamposTelefones(Telefone oTelefone)
        {
            hfCodigoTelefone.Value = oTelefone.codigo.ToString();
            txtDDI.Text = oTelefone.ddi.ToString();
            txtDDD.Text = oTelefone.ddd.ToString();
            txtTelefone.Text = oTelefone.numero.ToString();
            ddlTipoTelefone.SelectedValue = oTelefone.codigoTipo.ToString();

            carregaListaTelefone(Convert.ToInt32(txtCodigo.Text));

            divlistaTelefone.Visible = true;

        }

        public void carregaCamposPessoa(Pessoa oPessoa)
        {
            hfCodigoPessoa.Value = oPessoa.codigo.ToString();
            txtContato.Text = oPessoa.nome.ToString();
            txtDDIContato.Text = oPessoa.ddi.ToString();
            txtDDDContato.Text = oPessoa.ddd.ToString();
            txtTelefoneContato.Text = oPessoa.numero.ToString();
            ddlTipoContato.SelectedValue = oPessoa.codigoTipo.ToString();

            //if (!oPessoa.codigoTipo.Value.Equals(null))
            //{
            //    ddlTipoContato.SelectedValue = oPessoa.codigoTipo.ToString();
            //}
            

            carregaListaPessoa(Convert.ToInt32(txtCodigo.Text));

            divPessoa.Visible = true;

        }

        public void carregaCamposEndereco(Endereco oEndereco)
        {
            hfCodigoEndereco.Value = oEndereco.codigo.ToString();
            txtLogradouro.Text = oEndereco.logradouro.ToString();
            txtNumero.Text = oEndereco.numero.ToString();
            txtComplemento.Text = oEndereco.complemento.ToString();
            txtBairro.Text = oEndereco.bairro.ToString();
            txtCEP.Text = oEndereco.CEP.ToString();
            txtCidade.Text = oEndereco.Cidade.ToString();
            ddlUF.SelectedValue = oEndereco.codigoUF.ToString();
            ddlTipoEndereco.SelectedValue = oEndereco.codigoTipo.ToString();

            carregaListaTelefone(Convert.ToInt32(txtCodigo.Text));

            divlistaTelefone.Visible = true;

        }

        protected void gvPessoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            nePessoa oNegocioPessoa = new nePessoa();

            if (e.CommandName == "EditarPessoa")
            {
                limpaCamposPessoa();
                carregaCamposPessoa(oNegocioPessoa.buscaPessoa(codigo));
                btnIncluirPessoa.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirPessoa")
            {
                limpaCamposPessoa();
                carregaCamposPessoa(oNegocioPessoa.buscaPessoa(codigo));
                btnIncluirPessoa.Text = "Confirma Exclusão?";
            }


            //if (e.CommandName == "EditarPessoa")
            //{

            //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //    int codigoPessoa = Convert.ToInt32(gvPessoa.DataKeys[row.RowIndex].Value);
            //    oNegocioPessoa = new nePessoa();
            //    Pessoa oPessoa = oNegocioPessoa.buscaPessoa(codigoPessoa);
            //    Session.Add("oPessoa", oPessoa);

            //    oNegocioEmpresa = new neEmpresa();
            //    Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));
            //    Session.Add("oEmpresa", oEmpresa);
            //    Response.Redirect("CadastroPessoa.aspx");
            //}

            //if (e.CommandName == "ExcluirPessoa")
            //{

            //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //    int codigoPessoa = Convert.ToInt32(gvPessoa.DataKeys[row.RowIndex].Value);
            //    oNegocioPessoa = new nePessoa();
            //    Pessoa oPessoa = oNegocioPessoa.buscaPessoa(codigoPessoa);
            //    Session.Add("oPessoa", oPessoa);

            //    oNegocioEmpresa = new neEmpresa();
            //    Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));
            //    Session.Add("oEmpresa", oEmpresa);

            //    Session.Add("flagExcluir", true);

            //    Response.Redirect("CadastroPessoa.aspx");
            //}

        }

        protected void btnIncluiEndereco_Click(object sender, EventArgs e)
        {

            neEmpresa oNegocioEmpresa = new neEmpresa();
            neEndereco oNegocioEndereco = new neEndereco();

            oNegocioEmpresa = new neEmpresa();
            Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));

            Endereco oEndereco = new Endereco();

            oEndereco.logradouro = txtLogradouro.Text;
            oEndereco.numero = txtNumero.Text;
            oEndereco.complemento = txtComplemento.Text;
            oEndereco.bairro = txtBairro.Text;
            oEndereco.CEP = txtCEP.Text;
            oEndereco.Cidade = txtCidade.Text;
            oEndereco.codigoUF = Convert.ToInt32(ddlUF.SelectedValue);
            oEndereco.codigoTipo = Convert.ToInt32(ddlTipoEndereco.SelectedValue);


            if (btnIncluirEndereco.Text.Equals("Incluir Novo Endereço"))
            {
                oEndereco = oNegocioEndereco.incluir(oEndereco);
                oNegocioEndereco.incluirEmpresaEndereco(oEmpresa.codigo, oEndereco.codigo);
                carregaListaEndereco(Convert.ToInt32(txtCodigo.Text));
                limpaCamposEndereco();

            }
            else if (btnIncluirEndereco.Text.Equals("Salvar"))
            {
                oEndereco.codigo = Convert.ToInt32(hfCodigoEndereco.Value);
                if (oNegocioEndereco.alterar(oEndereco))
                {
                    carregaListaEndereco(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposEndereco();
                }
            }

            else
            {
                oEndereco.codigo = Convert.ToInt32(hfCodigoEndereco.Value);
                if (oNegocioEndereco.excluir(oEndereco.codigo))
                {
                    carregaListaEndereco(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposEndereco();
                }
            }

        }

        protected void btnIncluirTelefone_Click(object sender, EventArgs e)
        {

            neEmpresa oNegocioEmpresa = new neEmpresa();
            neTelefone oNegocioTelefone = new neTelefone();

            oNegocioEmpresa = new neEmpresa();
            Empresa oEmpresa = oNegocioEmpresa.busca(Convert.ToInt32(txtCodigo.Text));

            Telefone oTelefone = new Telefone();


            oTelefone.ddi = Convert.ToInt32(txtDDI.Text);
            oTelefone.ddd = Convert.ToInt32(txtDDD.Text);
            oTelefone.numero = txtTelefone.Text;
            oTelefone.codigoTipo = Convert.ToInt32(ddlTipoTelefone.SelectedValue);
            

            if (btnIncluirTelefone.Text.Equals("Incluir Novo Telefone"))
            {
                oTelefone = oNegocioTelefone.incluir(oTelefone);
                oNegocioTelefone.incluirEmpresaTelefone(oEmpresa.codigo, oTelefone.codigo);
                carregaListaTelefone(Convert.ToInt32(txtCodigo.Text));
                limpaCamposTelefone();

            }
            else if (btnIncluirTelefone.Text.Equals("Salvar"))
            {
                oTelefone.codigo = Convert.ToInt32(hfCodigoTelefone.Value);
                if (oNegocioTelefone.alterar(oTelefone))
                {
                    carregaListaTelefone(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposTelefone();
                }
            }
            else
            {
                oTelefone.codigo = Convert.ToInt32(hfCodigoTelefone.Value);
                if (oNegocioTelefone.excluir(oTelefone.codigo))
                {
                    carregaListaTelefone(Convert.ToInt32(txtCodigo.Text));
                    limpaCamposTelefone();
                }
            }


        }

        protected void gvTelefone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            neTelefone oNegocioTelefone = new neTelefone();

            if (e.CommandName == "EditarTelefone")
            {
                limpaCamposTelefone();
                carregaCamposTelefones(oNegocioTelefone.buscaTelefone(codigo));
                btnIncluirTelefone.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirTelefone")
            {
                limpaCamposTelefone();
                carregaCamposTelefones(oNegocioTelefone.buscaTelefone(codigo));
                btnIncluirTelefone.Text = "Confirma Exclusão?";
            }
        }

        protected void gvEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);

            neEndereco oNegocioEndereco = new neEndereco();

            if (e.CommandName == "EditarEndereco")
            {
                limpaCamposEndereco();
                carregaCamposEndereco(oNegocioEndereco.buscaEndereco(codigo));
                btnIncluirEndereco.Text = "Salvar";
            }

            if (e.CommandName == "ExcluirEndereco")
            {
                limpaCamposEndereco();
                carregaCamposEndereco(oNegocioEndereco.buscaEndereco(codigo));
                btnIncluirEndereco.Text = "Confirma Exclusão?";
            }
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;

            carregaLista();
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

        protected void btnCancelarEndereco_Click(object sender, EventArgs e)
        {
            limpaCamposEndereco();
        }

        protected void btnCancelarTelefone_Click(object sender, EventArgs e)
        {
            limpaCamposTelefone();
        }

        protected void btnCancelarPessoa_Click(object sender, EventArgs e)
        {
            limpaCamposPessoa();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divFiltrarDados.Visible = true;
        }

        protected void btnFiltrarNomeFantasia_Click(object sender, EventArgs e)
        {
            if (txtFiltrarNomeFantasia.Text == "")
            {
                carregaLista();
            }
            else
            {
                FiltrarListaEmpresas(txtFiltrarNomeFantasia.Text);
            }
        }

        public void FiltrarListaEmpresas(string procura)
        {
            oNegocioEmpresa = new neEmpresa();

            gvLista.DataSource = oNegocioEmpresa.FiltrarNomeFantasia(procura);
            gvLista.DataBind();

        }

        protected void gvEndereco_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEndereco.PageIndex = e.NewPageIndex;
            Int32 codigo = Convert.ToInt32(txtCodigo.Text);
            oNegocioEmpresa = new neEmpresa();
                        
            oEmpresaSelecionada = oNegocioEmpresa.busca(codigo);
            carregaListaEndereco(oEmpresaSelecionada.codigo);

        }

        protected void gvPessoa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPessoa.PageIndex = e.NewPageIndex;
            Int32 codigo = Convert.ToInt32(txtCodigo.Text);
            oNegocioEmpresa = new neEmpresa();

            oEmpresaSelecionada = oNegocioEmpresa.busca(codigo);
            carregaListaPessoa(oEmpresaSelecionada.codigo);
        }

        protected void gvTelefone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTelefone.PageIndex = e.NewPageIndex;
            Int32 codigo = Convert.ToInt32(txtCodigo.Text);
            oNegocioEmpresa = new neEmpresa();

            oEmpresaSelecionada = oNegocioEmpresa.busca(codigo);
            carregaListaTelefone(oEmpresaSelecionada.codigo);
        }


    }
}
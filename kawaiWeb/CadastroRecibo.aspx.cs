//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using kawaiBco;
//using kawaiNeg;
//using System.Data;

//namespace kawaiWeb
//{
//    public partial class CadastroPerfil : System.Web.UI.Page
//    {
//        nePerfil oNegocioPerfil;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                carregaLista();
//            }
//        }

//        #region metódos

//        public void carregaLista()
//        {
//            dbKawaiBanco oBanco = new dbKawaiBanco();

//            var lista = (from tbl in oBanco.Perfil
//                         select tbl);

//            gvLista.DataSource = lista;
//            gvLista.DataBind();
//        }

//        public void carregaCampos(Perfil oPerfil)
//        {
//            txtCodigo.Text = oPerfil.codigo.ToString();
//            txtPerfil.Text = oPerfil.perfil;
//            txtDescricao.Text = oPerfil.descricao;
//        }

//        public void limpaCampos()
//        {
//            txtCodigo.Text = string.Empty;
//            txtPerfil.Text = string.Empty;
//            txtDescricao.Text = string.Empty;
//            btnSalvar.Text = "Salvar";
//        }

//        #endregion

//        #region Eventos

//        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
//        {
//            string[] args = e.CommandArgument.ToString().Split(';');
//            Int32 codigo = Convert.ToInt32(args[0]);
//            oNegocioPerfil = new nePerfil();

//            if (e.CommandName == "Editar")
//            {
//                carregaCampos(oNegocioPerfil.buscaPerfil(codigo));
//            }

//            if (e.CommandName == "Excluir")
//            {
//                carregaCampos(oNegocioPerfil.buscaPerfil(codigo));
//                btnSalvar.Text = "Confirma Exclusão?";
//            }
//        }

//        protected void btnCancelar_Click(object sender, EventArgs e)
//        {
//            limpaCampos();
//        }

//        protected void btnSalvar_Click(object sender, EventArgs e)
//        {

//            oNegocioPerfil = new nePerfil();

//            Perfil oPerfil = new Perfil();
            
//            oPerfil.descricao = txtDescricao.Text;
//            oPerfil.perfil = txtPerfil.Text;

//            if (txtCodigo.Text == "")
//            {
//                if (oNegocioPerfil.incluirPerfil(oPerfil))
//                {
//                    carregaLista();
//                    limpaCampos();
//                }
//            }
//            else
//            {
//                oPerfil.codigo = Convert.ToInt32(txtCodigo.Text);

//                if (btnSalvar.Text.Equals("Salvar"))
//                {
//                    if (oNegocioPerfil.alterarPerfil(oPerfil))
//                    {
//                        carregaLista();
//                        limpaCampos();
//                    }
//                }
//                else
//                {
//                    if (oNegocioPerfil.excluirPerfil(oPerfil.codigo))
//                    {
//                        carregaLista();
//                        limpaCampos();
//                    }
//                }
//            }
//        }
//        #endregion
//    }
//}
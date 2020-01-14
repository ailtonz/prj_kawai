//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using kawaiBco;
//using kawaiNeg;
//using System.Data;
//using kawaiEnt;

//namespace kawaiWeb
//{
//    public partial class ListaOS : System.Web.UI.Page
//    {
//        neOrdemServico oNegocioOnderServico;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                carregaLista(DateTime.Today);
//            }
//        }

//        #region metódos

//        public void carregaLista()
//        {

//        }

//        public void carregaLista(DateTime data)
//        {
//            oNegocioOnderServico = new neOrdemServico();

//            if (((etUsuario)Session["oUsuario"]).perfil.Equals("Cliente"))
//            {
//                gvLista.DataSource = oNegocioOnderServico.buscaOrdemServico(data, ((etUsuario)Session["oUsuario"]).codigoEmpresa);
//                gvLista.DataBind();
//            }
//            else
//            {
//                gvLista.DataSource = oNegocioOnderServico.buscaOrdemServico(data);
//                gvLista.DataBind();
//            }
//        }



//        #endregion

//        #region Eventos

//        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
//        {
//            string[] args = e.CommandArgument.ToString().Split(';');
//            Int32 codigo = Convert.ToInt32(args[0]);

//            Response.Redirect("CadastroOS.aspx");
//        }

//        #endregion

//        protected void Calandario_SelectionChanged(object sender, EventArgs e)
//        {

//            carregaLista(CalandarioOS.SelectedDate.Date);
//        }
//    }
//}
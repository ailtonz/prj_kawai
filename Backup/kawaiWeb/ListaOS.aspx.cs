using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiBco;
using kawaiNeg;
using System.Data;
using kawaiEnt;

namespace kawaiWeb
{
    public partial class ListaOS : System.Web.UI.Page
    {
        neOS oNegocioOnderServico;
        List<itemData> listaItemData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaLista(DateTime.Today);
                CalandarioOS.SelectedDate = DateTime.Today;
            }
        }

        #region metódos

        public void carregaLista()
        {

        }

        public void carregaLista(DateTime data)
        {
            oNegocioOnderServico = new neOS();


            List<DateTime> listaData = new List<DateTime>();

            for (int i = 0; i < 24; i++)
            {
                listaData.Add(data.AddHours(i));
            }

            gvLista.DataSource = listaData;
            gvLista.DataBind();
        }



        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            string TimeOfDay = args[0];

            string dataHorario = CalandarioOS.SelectedDate.ToString("dd/MM/yyyy");
            dataHorario = dataHorario + " " + TimeOfDay;

            DateTime data = Convert.ToDateTime(dataHorario);

            listaItemData = (List<itemData>) Session["listaItemData"];

            itemData oData = new itemData();
            oData.CodigoItem = Convert.ToInt32(ddlServico.SelectedValue);
            oData.Data = data;

            listaItemData.Add(oData);

            Session["listaItemData"] = listaItemData;

            carregaHorariosReservados();
        }

        public void carregaHorariosReservados()
        {
            listaItemData = (List<itemData>)Session["listaItemData"];
            gvHorarioReservado.DataSource = listaItemData;
            gvHorarioReservado.DataBind();
        }

        #endregion

        protected void Calandario_SelectionChanged(object sender, EventArgs e)
        {

            carregaLista(CalandarioOS.SelectedDate.Date);
        }

        protected void ddlservico_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaItemData = new List<itemData>();
            Session["listaItemData"] = listaItemData;
        }

        protected void gvListaItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }

    public class itemData
    {
        private int _codigoItem;
        public int CodigoItem
        {
            get { return _codigoItem; }
            set { _codigoItem = value; }
        }
       
        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
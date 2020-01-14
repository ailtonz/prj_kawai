using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kawaiBco;
using kawaiNeg;
using System.Data;
using System.Drawing;

namespace kawaiWeb
{
    public partial class CadastroReserva : System.Web.UI.Page
    {
        neReserva oNegocioReserva;
        neOS oNegocioOS;

        //dbKawaiBanco oBanco;

        List<DateTime> listDataEvento;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   

                carregaLista();
                limpaCampos();
                carregaListaEstudio();
                carregaListaEmpresa();
                carregaListaOrdemServico();
                carregaListaStatus();

            }
        }

        #region metódos

        public void carregaLista()
        {
            oNegocioReserva = new neReserva();
            listDataEvento = new List<DateTime>();

            gvLista.DataSource = oNegocioReserva.buscaEvento(listDataEvento);
            gvLista.DataBind();
        }

        public void carregaListaDia(DateTime Dia)
        {
            oNegocioReserva = new neReserva();

            gvLista.DataSource = oNegocioReserva.buscaDia(Dia);
            gvLista.DataBind();
        }


        public void FiltrarListaClienteStatus(int codigoEmpresa, int codigoStatus)
        {
            oNegocioReserva = new neReserva();

            gvLista.DataSource = oNegocioReserva.buscaClienteStatus(codigoEmpresa, codigoStatus);
            gvLista.DataBind();
        }

        public void FiltrarListaCliente(int codigoEmpresa)
        {
            oNegocioReserva = new neReserva();

            gvLista.DataSource = oNegocioReserva.buscaCliente(codigoEmpresa);
            gvLista.DataBind();
        }

        public void FiltrarListaStatus(int codigoStatus)
        {
            oNegocioReserva = new neReserva();

            gvLista.DataSource = oNegocioReserva.buscaStatus(codigoStatus);
            gvLista.DataBind();
        }

        public void carregaListaEstudio()
        {
            neItem oNegocioEstudio = new neItem();

            ddlEstudio.Items.Clear();
            ddlEstudio.DataTextField = "descricao";
            ddlEstudio.DataValueField = "codigo";
            ddlEstudio.DataSource = oNegocioEstudio.buscaEstudio();
            ddlEstudio.DataBind();

            ddlEstudio.Items.Insert(0, "Selecione");

        }

        public void carregaListaEmpresa()
        {
            neEmpresa oNegocioEmpresa = new neEmpresa();

            // LISTA DE EMPRESA PARA CADASTRO DA RESERVA
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

        
        public void carregaListaOrdemServico()
        {
            //neItem oNegocioEstudio = new neItem();

            //ddlEstudio.Items.Clear();
            //ddlEstudio.DataTextField = "descricao";
            //ddlEstudio.DataValueField = "codigo";
            //ddlEstudio.DataSource = oNegocioEstudio.buscaEstudio();
            //ddlEstudio.DataBind();

            //ddlEstudio.Items.Insert(0, "Selecione");

        }

        public void carregaListaStatus()
        {
            neReservaTipo oNegocioReservaStatus = new neReservaTipo();

            // LISTA DE STATUS PARA CADASTRO DA RESERVA
            ddlStatus.Items.Clear();
            ddlStatus.DataTextField = "Status";
            ddlStatus.DataValueField = "codigo";
            ddlStatus.DataSource = oNegocioReservaStatus.busca();
            ddlStatus.DataBind();

            //ddlStatus.Items.Insert(0, "Selecione");
            ddlStatus.SelectedIndex = 1;

            // LISTA DE STATUS PARA FILTRO DE RESERVAS
            ddlFiltrarStatus.Items.Clear();
            ddlFiltrarStatus.DataTextField = "Status";
            ddlFiltrarStatus.DataValueField = "codigo";
            ddlFiltrarStatus.DataSource = oNegocioReservaStatus.busca();
            ddlFiltrarStatus.DataBind();

            ddlFiltrarStatus.Items.Insert(0, "Selecione");


        }


        public void carregaCampos(Reserva oReserva)
        {
            txtCodigo.Text = oReserva.codigo.ToString();
            
            if (!oReserva.dataCadastro.ToString().Equals("") )
            {
                txtDataCadastro.Text = Convert.ToDateTime(oReserva.dataCadastro.ToString()).ToString("dd/MM/yyyy hh:mm");
            }
            
            ddlEstudio.SelectedValue = oReserva.codigoEstudio.ToString();
            ddlCliente.SelectedValue = oReserva.codigoEmpresa.ToString();
            ddlStatus.SelectedValue = oReserva.codigoStatus.ToString();

            txtDataReserva.Text = Convert.ToDateTime(oReserva.dataReserva.ToString()).ToString("dd/MM/yyyy");
            ddlHoraInicio.SelectedValue = oReserva.horaInicio.ToString();
            ddlHoraTerminio.SelectedValue = oReserva.horaTerminio.ToString();

            txtRequisitante.Text = oReserva.nomeRequisitante.ToString();
            txtResponsavel.Text = oReserva.nomeResponsavel.ToString();

        }

        public void limpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDataCadastro.Text = string.Empty;

            ddlEstudio.SelectedIndex = -1;
            ddlCliente.SelectedIndex = -1;
            ddlOrdemServico.SelectedIndex = -1;
            ddlStatus.SelectedIndex = 1;

            txtDataReserva.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlHoraInicio.SelectedIndex = -1;
            ddlHoraTerminio.SelectedIndex = -1;

            txtRequisitante.Text = string.Empty;
            txtResponsavel.Text = string.Empty;

            btnSalvar.Text = "Salvar";
        }

        #endregion

        #region Eventos

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(';');
            Int32 codigo = Convert.ToInt32(args[0]);
            oNegocioReserva = new neReserva();

            divReserva.Visible = true;

            if (e.CommandName == "Editar")
            {
                limpaCampos();
                carregaCampos(oNegocioReserva.busca(codigo));
            }

            if (e.CommandName == "Excluir")
            {
                carregaCampos(oNegocioReserva.busca(codigo));
                btnSalvar.Text = "Confirma Exclusão?";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            divReserva.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            oNegocioReserva = new neReserva();

            Reserva oReserva = new Reserva();

            oReserva.codigoEstudio = Convert.ToInt32(ddlEstudio.SelectedValue);
            //oReserva.codigoEmpresa = Convert.ToInt32(ddlCliente.SelectedValue);

            if (!ddlCliente.ToString().Equals("Selecione") || !ddlCliente.ToString().Equals(""))
            {
                oReserva.codigoEmpresa = Convert.ToInt32(ddlCliente.SelectedValue);
            }

            oReserva.codigoStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            oReserva.dataReserva = Convert.ToDateTime(txtDataReserva.Text);
            oReserva.horaInicio = ddlHoraInicio.SelectedValue;
            oReserva.horaTerminio = ddlHoraTerminio.SelectedValue;
            oReserva.nomeRequisitante = txtRequisitante.Text;
            oReserva.nomeResponsavel = txtResponsavel.Text;
            //oReserva.dataCadastro = Convert.ToDateTime(txtDataCadastro.Text);

            if (txtCodigo.Text == "")
            {
                oReserva.dataCadastro = DateTime.Now;
                if (oNegocioReserva.incluir(oReserva))
                {
                    carregaLista();
                    limpaCampos();
                }
            }
            else
            {
                oReserva.codigo = Convert.ToInt32(txtCodigo.Text);

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    if (oNegocioReserva.alterar(oReserva))
                    {
                        carregaLista();
                        limpaCampos();

                        if (ddlStatus.SelectedItem.Text.Equals("RESERVADO"))
                        {
                            txtResponsavel.Text = "RESERVADO";
                        }

                    }
                }
                else
                {
                    if (oNegocioReserva.excluir(oReserva.codigo))
                    {
                        carregaLista();
                        limpaCampos();
                    }
                }
            }

            //divReserva.Visible = false;
        }
        #endregion

        protected void CalendarioReservas_SelectionChanged(object sender, EventArgs e)
        {
            listDataEvento = new List<DateTime>();
            carregaListaDia(CalendarioReservas.SelectedDate.Date);
        }

        protected void btnHoje_Click(object sender, EventArgs e)
        {
            CalendarioReservas.SelectedDate = DateTime.Now;
            carregaListaDia(CalendarioReservas.SelectedDate.Date);
            divFiltro.Visible = false;
            divReserva.Visible = false;

        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            divFiltro.Visible = false;
            divReserva.Visible = true;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            divReserva.Visible = false;
            divFiltro.Visible = true;
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

        public void incluir() 
        {
            oNegocioOS = new neOS();

            OS oOS = new OS();

            oOS.dataInicio = Convert.ToDateTime(txtDataReserva.Text);
            oOS.dataTerminio = Convert.ToDateTime(txtDataReserva.Text);

            oOS.codigoEmpresa = Convert.ToInt32(ddlCliente.SelectedValue);
            oOS.nomeRequisitante = txtRequisitante.Text;
            oOS.nomeResponsavel = txtResponsavel.Text;
            oOS.codigoStatus = Convert.ToInt32(ddlStatus.SelectedValue);

            oNegocioOS.incluir(oOS);

        }

        protected void CalendarioReservas_DayRender(object sender, DayRenderEventArgs e)
        {

            // If the month is CurrentMonth

            //carregaLista();


            //if (!e.Day.IsOtherMonth)
            //{
            //    foreach (var item in listDataEvento)
            //    {
            //        if (item.Equals(e.Day.Date))
            //        {
            //            e.Cell.BackColor = Color.PaleVioletRed;
            //        }
            //    }




            //    //foreach (DataRow dr in listDataEvento)
            //    //{
            //    //    if ((dr["EventDate"].ToString() != DBNull.Value.ToString()))
            //    //    {
            //    //        DateTime dtEvent = (DateTime)dr["EventDate"];
            //    //        if (dtEvent.Equals(e.Day.Date))
            //    //        {
            //    //            e.Cell.BackColor = Color.PaleVioletRed;
            //    //        }
            //    //    }
            //    //}
            //}
            ////If the month is not CurrentMonth then hide the Dates
            //else
            //{
            //    e.Cell.Text = "";
            //}
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;

            carregaLista();
        }




    }
}
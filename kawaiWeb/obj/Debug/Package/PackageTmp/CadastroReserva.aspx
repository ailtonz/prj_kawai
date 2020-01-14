<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroReserva.aspx.cs" Inherits="kawaiWeb.CadastroReserva" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Reserva
    </h2>
    <h3>
        Calendario
    </h3>
    <p>
    </p>
    <div id="divCalendario" runat="server" visible="true">
        <div class="fleft m10r">
            <asp:Calendar ID="CalendarioReservas" runat="server" BackColor="White" BorderColor="#3366CC"
                BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                Font-Size="8pt" ForeColor="#003399" Height="200px" Width="269px" OnSelectionChanged="CalendarioReservas_SelectionChanged">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                    Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
        </div>
        <div class="fleft m10l">
            <div id="divFuncoes" runat="server" visible="true">
                <asp:Button ID="btnHoje" runat="server" CssClass="padButton" Text="HOJE" OnClick="btnHoje_Click" />
                <asp:Button ID="btnReserva" runat="server" CssClass="padButton" Text="RESERVA" OnClick="btnReserva_Click" />
                <asp:Button ID="btnFiltro" runat="server" CssClass="padButton" Text="FILTRAR RESERVAS" OnClick="btnFiltro_Click" />
            </div>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10l">
            <div id="divFiltro" runat="server" visible="false">
                <h3>
                    Filtro de reservas
                </h3>
                <p>
                </p>
                <div class="fleft m10r">
                    Cliente:
                    <br />
                    <asp:DropDownList ID="ddlFiltrarCliente" runat="server" Width="750px">
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnFiltroCliente" runat="server" CssClass="padButton" Text="FILTRO" OnClick="btnFiltroCliente_Click" />
                <div class="cleared">
                </div>
                <div class="fleft m10r">
                    Status:
                    <br />
                    <asp:DropDownList ID="ddlFiltrarStatus" runat="server" Width="750px">
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnFiltroStatus" runat="server" CssClass="padButton" Text="FILTRO" OnClick="btnFiltroStatus_Click" />
            </div>
        </div>
    </div>
    <div class="cleared">
    </div>
    <div id="divReserva" runat="server" visible="false">
        <h3>
            Cadastrar uma nova Reserva
        </h3>
        <p>
        </p>
        <div class="fleft m10r">
            Codigo:
            <br />
            <asp:TextBox ID="txtCodigo" runat="server" Enabled="False" Width="100px"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Status:
            <br />
            <asp:DropDownList ID="ddlStatus" runat="server" Width="205px">
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            Data da Reserva:
            <br />
            <asp:TextBox ID="txtDataReserva" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            INICIO:
            <br />
            <asp:DropDownList ID="ddlHoraInicio" runat="server">
                <asp:ListItem>00:00</asp:ListItem>
                <asp:ListItem>01:00</asp:ListItem>
                <asp:ListItem>02:00</asp:ListItem>
                <asp:ListItem>03:00</asp:ListItem>
                <asp:ListItem>04:00</asp:ListItem>
                <asp:ListItem>05:00</asp:ListItem>
                <asp:ListItem>06:00</asp:ListItem>
                <asp:ListItem>07:00</asp:ListItem>
                <asp:ListItem>08:00</asp:ListItem>
                <asp:ListItem>09:00</asp:ListItem>
                <asp:ListItem>10:00</asp:ListItem>
                <asp:ListItem>11:00</asp:ListItem>
                <asp:ListItem>12:00</asp:ListItem>
                <asp:ListItem>13:00</asp:ListItem>
                <asp:ListItem>14:00</asp:ListItem>
                <asp:ListItem>15:00</asp:ListItem>
                <asp:ListItem>16:00</asp:ListItem>
                <asp:ListItem>17:00</asp:ListItem>
                <asp:ListItem>18:00</asp:ListItem>
                <asp:ListItem>19:00</asp:ListItem>
                <asp:ListItem>20:00</asp:ListItem>
                <asp:ListItem>21:00</asp:ListItem>
                <asp:ListItem>22:00</asp:ListItem>
                <asp:ListItem>23:00</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            TERMINIO:
            <br />
            <asp:DropDownList ID="ddlHoraTerminio" runat="server">
                <asp:ListItem>00:00</asp:ListItem>
                <asp:ListItem>01:00</asp:ListItem>
                <asp:ListItem>02:00</asp:ListItem>
                <asp:ListItem>03:00</asp:ListItem>
                <asp:ListItem>04:00</asp:ListItem>
                <asp:ListItem>05:00</asp:ListItem>
                <asp:ListItem>06:00</asp:ListItem>
                <asp:ListItem>07:00</asp:ListItem>
                <asp:ListItem>08:00</asp:ListItem>
                <asp:ListItem>09:00</asp:ListItem>
                <asp:ListItem>10:00</asp:ListItem>
                <asp:ListItem>11:00</asp:ListItem>
                <asp:ListItem>12:00</asp:ListItem>
                <asp:ListItem>13:00</asp:ListItem>
                <asp:ListItem>14:00</asp:ListItem>
                <asp:ListItem>15:00</asp:ListItem>
                <asp:ListItem>16:00</asp:ListItem>
                <asp:ListItem>17:00</asp:ListItem>
                <asp:ListItem>18:00</asp:ListItem>
                <asp:ListItem>19:00</asp:ListItem>
                <asp:ListItem>20:00</asp:ListItem>
                <asp:ListItem>21:00</asp:ListItem>
                <asp:ListItem>22:00</asp:ListItem>
                <asp:ListItem>23:00</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Estudio:
            <br />
            <asp:DropDownList ID="ddlEstudio" runat="server" Width="750px">
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Cliente:
            <br />
            <asp:DropDownList ID="ddlCliente" runat="server" Width="750px">
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Ordem De Serviço:
            <br />
            <asp:DropDownList ID="ddlOrdemServico" runat="server" Width="750px">
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Nome do Requisitante:
            <br />
            <asp:TextBox ID="txtRequisitante" runat="server" Width="356px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Responsavel Kawai:
            <br />
            <asp:TextBox ID="txtResponsavel" runat="server" Width="356px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p>
            <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelar_Click" />
            <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click" />

        </p>
    </div>
    <h3>
        Reservados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="dataReserva" HeaderText="DATA" SortExpression="dataReserva"
                DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField HeaderText="INICIO" DataField="horaInicio" SortExpression="horaInicio" />
            <asp:BoundField DataField="horaTerminio" HeaderText="TERMINIO" SortExpression="horaTerminio">
            </asp:BoundField>
            <asp:BoundField HeaderText="CLIENTE" DataField="nomeFantasia" SortExpression="nomeFantasia" />
            <asp:BoundField HeaderText="ESTUDIO" DataField="Estudio" SortExpression="Estudio" />
            <asp:BoundField DataField="Status" HeaderText="STATUS" SortExpression="Status" />
            <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                        CommandName="Editar" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                </ItemTemplate>
                <ItemStyle CssClass="w1pct nowrap" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                <ItemTemplate>
                    <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                        CommandName="Excluir" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
                </ItemTemplate>
                <ItemStyle CssClass="w1pct nowrap" />
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="odd" />
        <PagerStyle CssClass="paginacaoPesquisa" />
        <RowStyle CssClass="even" />
        <HeaderStyle CssClass="headerTable1 p3" />
    </asp:GridView>
    <p>
        &nbsp;</p>
</asp:Content>

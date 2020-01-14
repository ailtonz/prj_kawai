<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaOS.aspx.cs" Inherits="kawaiWeb.ListaOS" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Reserva</h2>
    <p>
        Selecione um Cliente:
        <br />
        <asp:DropDownList ID="ddlEmpresa" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Selecione o Requisitante:
        <br />
        <asp:DropDownList ID="ddlEmpresa0" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Selecione uma Ordem de Serviço:
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    <h3>
        Cadastrar uma nova reserva</h3>
    <p>
        Selecione a Categoria do Serviço:
        <br />
        <asp:DropDownList ID="ddlCategoriaServiço" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Selecione o Serviço:
        <br />
        <asp:DropDownList ID="ddlServico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlservico_SelectedIndexChanged">
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Selecione a Data da Reserva:
        <asp:Calendar ID="CalandarioOS" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="#003399" Width="36%" OnSelectionChanged="Calandario_SelectionChanged"
            Height="218px">
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
    </p>
    <div>
        <div class="fleft">
            Selecione os horários livres:
            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
                EmptyDataText="&lt;h3 class='blue'&gt;Nenhuma data selecionada.&lt;br/&gt;Por favor, selecione uma data.&lt;/h3&gt;"
                GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand"
                Width="300px">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderStyle-CssClass="tleft" HeaderText="Data" ItemStyle-CssClass="tleft"
                        SortExpression="codigo">
                        <HeaderStyle CssClass="tleft" />
                        <ItemStyle CssClass="tleft" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TimeOfDay" HeaderText="Horário">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Selecionar" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("TimeOfDay") %>'
                                CommandName="Editar" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                        </ItemTemplate>
                        <ItemStyle CssClass="w1pct nowrap" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="odd" />
                <PagerStyle CssClass="paginacaoPesquisa" />
                <RowStyle CssClass="even" />
                <HeaderStyle CssClass="headerTable1 p3" />
            </asp:GridView>
        </div>
        <div class="fleft m10l">
            Horários reservados para o Serviço:
            <asp:GridView ID="gvHorarioReservado" runat="server" AutoGenerateColumns="False"
                CssClass="table1 w100pct tcenter m10t ui-corner-all" EmptyDataText="&lt;h3 class='blue'&gt;Nenhum registro foi encontrado.&lt;br/&gt;Por favor, selecione uma data.&lt;/h3&gt;"
                GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand"
                Width="300px">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderStyle-CssClass="tleft" HeaderText="Data" ItemStyle-CssClass="tleft"
                        SortExpression="codigo">
                        <HeaderStyle CssClass="tleft" />
                        <ItemStyle CssClass="tleft" Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("Data") %>'
                                CommandName="Editar" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                        </ItemTemplate>
                        <ItemStyle CssClass="w1pct nowrap" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="odd" />
                <PagerStyle CssClass="paginacaoPesquisa" />
                <RowStyle CssClass="even" />
                <HeaderStyle CssClass="headerTable1 p3" />
            </asp:GridView>
        </div>
        <div class="fleft m10l">
                Selecione o Serviço:
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlservico_SelectedIndexChanged">
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
        </asp:DropDownList>
        </div>
        
    </div>
    <div class="cleared"></div>
    <h3>
        Lista de Itens da Ordem de Serviço</h3>
    <asp:GridView ID="gvListaItem" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" 
        OnRowCommand="gvListaItem_RowCommand">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="descricao" HeaderText="Serviço" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="descricao">
                <ItemStyle Width="200px" CssClass="tleft" />
            </asp:BoundField>
            <asp:BoundField DataField="valor" HeaderText="Valor" SortExpression="valor">
                <ItemStyle CssClass="tleft" />
            </asp:BoundField>
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
</asp:Content>

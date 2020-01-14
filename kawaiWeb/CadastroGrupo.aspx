<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroGrupo.aspx.cs" Inherits="kawaiWeb.CadastroGrupo" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Planos de Contas
    </h2>
    <h3>
        Cadastrar um novo Plano de Contas
    </h3>
    <p>
        Codigo:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Plano:
        <br />
        <asp:TextBox ID="txtGrupo" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click" />
    </p>
    <div id="divConta" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            cadastro de Conta<asp:HiddenField ID="hfCodigoConta" runat="server" />
        </h3>
        <p class="fleft m10r">
            Conta:
            <br />
            <asp:TextBox ID="txtConta" runat="server" Width="500px" MaxLength="500"></asp:TextBox>
        </p>
        <div class="cleared">
        </div>
        <p class="fleft m10r">
                    <asp:Button ID="btnCancelarConta" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarConta_Click" />
            <asp:Button ID="btnIncluirConta" runat="server" CssClass="padButton" Text="Incluir Nova Conta"
                OnClick="btnIncluirConta_Click" />
        </p>
        <div class="cleared">
        </div>
        <h3>
            Lista de Contas</h3>
        <asp:GridView ID="gvConta" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
            GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvContas_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Conta" HeaderText="Conta" ItemStyle-CssClass="w1pct nowrap"
                    SortExpression="Conta">
                    <ItemStyle Width="200px" CssClass="tleft" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="EditarConta" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                    </ItemTemplate>
                    <ItemStyle CssClass="w1pct nowrap" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="ExcluirConta" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
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
    <div id="divPlanos" runat="server" visible="true">
        <h3>
            Lista de Planos</h3>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
            GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Grupo" HeaderText="Plano de conta" ItemStyle-CssClass="w1pct nowrap"
                    SortExpression="Grupo">
                    <ItemStyle Width="200px" CssClass="tleft" />
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
    </div>
    <p>
        &nbsp;</p>
</asp:Content>

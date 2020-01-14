<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroEmailTipo.aspx.cs" Inherits="kawaiWeb.CadastroEmailTipo" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Tipo de E-MAIL
    </h2>
    <h3>
        Cadastrar um novo Tipo de E-MAIL</h3>
    <p>
        Codigo:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Descrição:
        <br />
        <asp:TextBox ID="txtDescricao" runat="server" Width="500px" MaxLength="500"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" 
            onclick="btnSalvar_Click" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" 
            Text="Cancelar" onclick="btnCancelar_Click" />
    </p>
    <h3>
        Lista de cadastrados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" 
        onrowcommand="gvLista_RowCommand">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao">
                <ItemStyle CssClass="tleft" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                        CommandName="Editar" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                </ItemTemplate>
                <ItemStyle CssClass="w1pct nowrap" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
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

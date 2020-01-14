<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroPagamento.aspx.cs" Inherits="kawaiWeb.CadastroPagamento" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Formas de Pagamentos
    </h2>
    <h3>
        Cadastrar um nova forma de pagamento
    </h3>
    <p>
        Codigo:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Forma de pagamento:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPagamento"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="formCadastro">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtPagamento" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" 
            Text="Cancelar" onclick="btnCancelar_Click" />
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" 
            onclick="btnSalvar_Click" ValidationGroup="formCadastro" />

    </p>
    <h3>
        Lista de cadastrados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" 
        onrowcommand="gvLista_RowCommand" AllowPaging="True" 
        onpageindexchanging="gvLista_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo" Visible="False">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="FormaPagamento">
                <ItemStyle Width="200px" CssClass="tleft"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                        CommandName="Editar" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                </ItemTemplate>
                <ItemStyle CssClass="w1pct nowrap" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir" 
                ItemStyle-CssClass="w1pct nowrap">
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

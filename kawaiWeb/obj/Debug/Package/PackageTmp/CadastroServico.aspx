<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroServico.aspx.cs" Inherits="kawaiWeb.CadastroServico" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Serviço
    </h2>
    <h3>
        Cadastrar um novo Serviço
    </h3>
    <div class="fleft m10r">
        Codigo:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10r">
        Tipo De Serviço:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTipo"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServicos">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:DropDownList ID="ddlTipo" runat="server" Width="290px">
        </asp:DropDownList>
    </div>
    <div class="fleft m10r">
        Descricao:
        <br />
        <asp:TextBox ID="txtDescricao" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Valor:
        <br />
        <asp:TextBox ID="txtValor" runat="server" Width="100px" MaxLength="500"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <p>
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
            ValidationGroup="frmServicos" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
    </p>
    <h3>
        Lista de cadastrados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="tipoServico" HeaderText="Tipo de serviço" SortExpression="tipoServico" />
            <asp:BoundField DataField="descricao" HeaderText="Descrição" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="descricao">
                <ItemStyle Width="200px" CssClass="tleft" Wrap="False"/>
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
    <div id="divFlutuante" runat="server" class="divFlutuante hidden">
    </div>
    <div id="divFlutuanteMsg" runat="server" class="posiciona hidden">
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="btnOK" runat="server" CssClass="padButton" Text="OK" OnClick="btnOK_Click" />
    </div>
</asp:Content>

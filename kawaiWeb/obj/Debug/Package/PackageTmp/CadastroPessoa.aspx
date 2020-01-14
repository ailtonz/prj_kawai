<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroPessoa.aspx.cs" Inherits="kawaiWeb.CadastroPessoa" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Pessoa
    </h2>
    <h3>
        Empresa</h3>
    <p>
        Selecione uma empresa:
        <br />
        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlEmpresa_SelectedIndexChanged">
        </asp:DropDownList>
    &nbsp;<asp:LinkButton ID="lbMudarEmpresa" runat="server" 
            onclick="lbMudarEmpresa_Click">Mudar de Empresa</asp:LinkButton>
    </p>
    <h3>
        Cadastrar uma nova Pessoa</h3>
    <p>
        Código:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p class="fleft m10r">
        Nome:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="formCadastro">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </p>
    <p class="fleft">
        CPF:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCPF"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="formCadastro">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtCPF" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </p>
    <p class="fleft m10r">
        RG:
        <br />
        <asp:TextBox ID="txtRG" runat="server" Width="300px" MaxLength="14"></asp:TextBox>
    </p>
    <div class="clear">
    </div>
    <p>
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
            ValidationGroup="formCadastro" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
        <asp:Button ID="btnVoltar" runat="server" CssClass="padButton" Text="Voltar para a Empresa"
            OnClick="btnVoltar_Click" />
    </p>
    <hr width="100%" size="1px" noshade="noshade" />
    <h3>
        Lista de Pessoas da Empresa Selecionada</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
        PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome">
                <ItemStyle CssClass="tleft" />
            </asp:BoundField>
            <asp:BoundField DataField="CPF" HeaderText="CPF" SortExpression="CPF">
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
    <div id="divFlutuante" runat="server" class="divFlutuante" visible="false">
        <div class="posiciona">
            <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="btnOK" runat="server" CssClass="padButton" Text="OK" OnClick="btnOK_Click" />
        </div>
    </div>
</asp:Content>

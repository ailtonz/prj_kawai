<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroPlanoGrupo.aspx.cs" Inherits="kawaiWeb.CadastroPlanoGrupo" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de grupo de planos de contas
    </h2>
    <h3>
        Cadastrar um novo grupo de planos de contas<asp:HiddenField ID="hfCodigo" runat="server" />
    </h3>
    <div id="divGrupo" runat="server" visible="true">
        <div class="fleft m10r">
            Grupo de plano de conta:
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrupo"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmDados">Campo Obrigatório</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtGrupo" runat="server" Width="500px" MaxLength="500"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p>
            <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelar_Click" />
            <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
                ValidationGroup="frmDados" />
            <asp:Button ID="btnFiltro" runat="server" CssClass="padButton" Text="Filtrar dados"
                OnClick="btnFiltro_Click" />
        </p>
    </div>
    <div id="divFiltrarDados" runat="server" visible="false">
        <h3>
            Filtro de grupos de Planos de Conta
        </h3>
        <p>
        </p>
        <div class="fleft m10r">
            Grupo de plano de conta:
            <br />
            <asp:TextBox ID="txtFiltrarGrupo" runat="server" Width="700px" MaxLength="255"></asp:TextBox>
        </div>
        <asp:Button ID="btnFiltrarGrupo" runat="server" CssClass="padButton" Text="FILTRO"
            OnClick="btnFiltrarGrupo_Click" />
        <div class="cleared">
        </div>
    </div>
    <hr width="100%" size="1px" noshade="noshade" />
    <h3>
        Lista de cadastrados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" 
        OnRowCommand="gvLista_RowCommand" AllowPaging="True" 
        onpageindexchanging="gvLista_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo" Visible="False">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="grupo" HeaderText="Grupo de plano de contas" SortExpression="grupo">
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

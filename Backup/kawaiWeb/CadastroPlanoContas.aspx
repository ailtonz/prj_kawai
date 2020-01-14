<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroPlanoContas.aspx.cs" Inherits="kawaiWeb.CadastroPlanoContas" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Planos de Contas
    </h2>
    <h3>
        Cadastrar um novo Plano de Conta<asp:HiddenField ID="hfCodigo" runat="server" />
    </h3>
    <div id="divPlanoConta" runat="server" visible="true">
        <div class="fleft m10r">
            Grupo do Plano de Conta:
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlanoConta"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmContas">Campo Obrigatório</asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlPlanoConta" runat="server" Width="290px">
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            Plano de Conta:
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConta"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmContas">Campo Obrigatório</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtConta" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p>
            <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelar_Click" />
            <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
                ValidationGroup="frmContas" />
            <asp:Button ID="btnFiltro" runat="server" CssClass="padButton" Text="Filtrar dados"
                OnClick="btnFiltro_Click" />
        </p>
    </div>
    <div id="divFiltrarConta" runat="server" visible="false">
        <h3>
            Filtro de Planos de Conta
        </h3>
        <p>
        </p>
        <div class="fleft m10r">
            Plano de Conta:
            <br />
            <asp:TextBox ID="txtFiltrarConta" runat="server" Width="700px" MaxLength="255"></asp:TextBox>
        </div>
        <asp:Button ID="btnFiltrarConta" runat="server" CssClass="padButton" Text="FILTRO"
            OnClick="btnFiltrarConta_Click" />
        <div class="cleared">
        </div>
    </div>
    <hr width="100%" size="1px" noshade="noshade" />
    <h3>
        Lista de cadastrados</h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
        EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
        GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="20" 
        OnRowCommand="gvLista_RowCommand" AllowPaging="True" 
        onpageindexchanging="gvLista_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                ItemStyle-CssClass="tleft" SortExpression="codigo" Visible="False">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="grupo" HeaderText="Plano de conta" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="grupo">
                <ItemStyle Width="150px" CssClass="tleft" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="conta" HeaderText="Conta" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="conta">
                <ItemStyle Width="300px" CssClass="tleft" Wrap="False" />
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

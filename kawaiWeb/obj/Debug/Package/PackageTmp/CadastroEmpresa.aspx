<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroEmpresa.aspx.cs" Inherits="kawaiWeb.CadastroEmpresa" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Empresa
    </h2>
    <h3>
        Cadastrar da Empresa</h3>
    <div>
        Código:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Razão Social:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRazaoSocial"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="formCadastro">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtRazaoSocial" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Nome Fantasia:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNomeFantasia"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="formCadastro">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtNomeFantasia" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        CNPJ:
        <br />
        <asp:TextBox ID="txtCNPJ" runat="server" Width="300px" MaxLength="14"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Inscrição Estadual:
        <br />
        <asp:TextBox ID="txtInscricaoEstadual" runat="server" Width="300px" 
            MaxLength="12"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Site:
        <br />
        <asp:TextBox ID="txtSite" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Controle do Cliente:
        <br />
        <asp:TextBox ID="txtControleCliente" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <p>
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Incluir Nova Empresa"
            OnClick="btnSalvar_Click" ValidationGroup="formCadastro" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
    </p>
    <div class="cleared">
    </div>
    <div id="divEndereco" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            cadastro do Endereço<asp:HiddenField ID="hfCodigoEndereco" runat="server" />
        </h3>
        <div class="fleft m10r">
            Endereço:
            <br />
            <asp:TextBox ID="txtLogradouro" runat="server" Width="500px" MaxLength="500"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Numero:
            <br />
            <asp:TextBox ID="txtNumero" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Complemento:
            <br />
            <asp:TextBox ID="txtComplemento" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Bairro:
            <br />
            <asp:TextBox ID="txtBairro" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            CEP:
            <br />
            <asp:TextBox ID="txtCEP" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Cidade:
            <br />
            <asp:TextBox ID="txtCidade" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Estado:
            <br />
            <asp:DropDownList ID="ddlUF" runat="server">
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            <asp:Button ID="btnIncluirEndereco" runat="server" CssClass="padButton" Text="Incluir Novo Endereço"
                OnClick="btnIncluiEndereco_Click" />
            <asp:Button ID="btnCancelarEndereco" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarEndereco_Click" />
        </div>
        <div class="cleared">
        </div>
        <div id="divListaEndereco" visible="false" runat="server">
            <h3>
                Lista de endereços</h3>
            <asp:GridView ID="gvEndereco" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
                EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
                PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" DataKeyNames="codigo" OnRowCommand="gvEndereco_RowCommand">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                        ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="logradouro" HeaderText="Endereço" SortExpression="logradouro">
                    </asp:BoundField>
                    <asp:BoundField DataField="numero" HeaderText="Nº " SortExpression="numero">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                                CommandName="EditarEndereco" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                        </ItemTemplate>
                        <ItemStyle CssClass="w1pct nowrap" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                                CommandName="ExcluirEndereco" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
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
    </div>
    <div class="clear">
    </div>
    <div id="divTelefone" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Cadastro de Telefone<asp:HiddenField ID="hfCodigoTelefone" runat="server" />
        </h3>
        <div class="fleft m10r">
            DDI:
            <br />
            <asp:TextBox ID="txtDDI" runat="server" Width="100px" MaxLength="3"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            DDD:
            <br />
            <asp:TextBox ID="txtDDD" runat="server" Width="100px" MaxLength="3"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Número:
            <br />
            <asp:TextBox ID="txtTelefone" runat="server" Width="200px" MaxLength="10"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p class="fleft m10r">
            <asp:Button ID="btnIncluirTelefone" runat="server" CssClass="padButton" Text="Incluir Novo Telefone"
                OnClick="btnIncluirTelefone_Click" />
            <asp:Button ID="btnCancelarTelefone" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarTelefone_Click" />
        </p>
        <div class="cleared">
        </div>
        <div id="divlistaTelefone" visible="false" runat="server">
            <h3>
                Lista de telefones</h3>
            <asp:GridView ID="gvTelefone" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
                EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
                PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" DataKeyNames="codigo" OnRowCommand="gvTelefone_RowCommand">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                        ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ddi" HeaderText="DDI" SortExpression="ddi">
                    <ItemStyle CssClass="tleft" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ddd" HeaderText="DDD" SortExpression="ddd">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numero" HeaderText="Número" SortExpression="numero" />
                    <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                                CommandName="EditarTelefone" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                        </ItemTemplate>
                        <ItemStyle CssClass="w1pct nowrap" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                                CommandName="ExcluirTelefone" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
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
    </div>
    <div class="clear">
    </div>
    <div id="divPessoa" visible="false" runat="server">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Cadastrar Contato<asp:HiddenField ID="hfCodigoPessoa" runat="server" />
        </h3>
        <div class="fleft m10r">
            Nome:
            <br />
            <asp:TextBox ID="txtContato" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="clear">
            <div class="fleft m10r">
                DDI:
                <br />
                <asp:TextBox ID="txtDDIContato" runat="server" Width="100px" MaxLength="3"></asp:TextBox>
            </div>
            <div class="fleft m10r">
                DDD:
                <br />
                <asp:TextBox ID="txtDDDContato" runat="server" Width="100px" MaxLength="3"></asp:TextBox>
            </div>
            <div class="fleft m10r">
                Telefone:
                <br />
                <asp:TextBox ID="txtTelefoneContato" runat="server" Width="150px" MaxLength="255"></asp:TextBox>
            </div>
        </div>
        <p>
            <asp:Button ID="btnIncluirPessoa" runat="server" CssClass="padButton" Text="Incluir Novo Contato"
                OnClick="btnIncluirPessoa_Click" />
        </p>
        <div class="cleared">
        </div>
        <h3>
            Lista de pessoas
        </h3>
        <asp:GridView ID="gvPessoa" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
            PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvPessoa_RowCommand"
            DataKeyNames="codigo">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome">
                <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="numero" HeaderText="TELEFONE" SortExpression="numero" />
                <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="EditarPessoa" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                    </ItemTemplate>
                    <ItemStyle CssClass="w1pct nowrap" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="ExcluirPessoa" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
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
    <div id="divListaEmpresa" runat="server">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Lista de empresas
        </h3>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
            PagerStyle-CssClass="paginacaoPesquisa" OnRowCommand="gvLista_RowCommand" AllowPaging="True"
            OnPageIndexChanging="gvLista_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                <HeaderStyle CssClass="tleft" />
                <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="nomeFantasia" HeaderText="Nome Fantasia" SortExpression="nomeFantasia">
                <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ">
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
    </div>
    <div id="divFlutuante" runat="server" class="divFlutuante hidden">
    </div>
    <div id="divFlutuanteMsg" runat="server" class="posiciona hidden">
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnOK" runat="server" CssClass="padButton" Text="OK" OnClick="btnOK_Click" />
    </div>
</asp:Content>

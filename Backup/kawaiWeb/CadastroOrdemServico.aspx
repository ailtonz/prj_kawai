<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroOrdemServico.aspx.cs" Inherits="kawaiWeb.CadastroOrdemServico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Ordem de Serviço
    </h2>
    <h3>
        Cadastrar uma nova Ordem de Serviço
    </h3>
    <p>
    </p>
    <div class="fleft m10r">
        Codigo:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Status:
        <br />
        <asp:DropDownList ID="ddlStatus" runat="server" Width="150px" Enabled="false">
        </asp:DropDownList>
    </div>
    <%--    <div class="fleft m10r">
        Estudio:
        <br />
        <asp:DropDownList ID="ddlEstudio" runat="server" Width="750px">
        </asp:DropDownList>
    </div>--%>
    <%--    <div class="cleared">
    </div>--%>
    <div class="fleft m10r">
        Data do Inicio:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDataInicio"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServico">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtDataInicio" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
    </div>
    <%--    <div class="fleft m10r">
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
    </div>--%>
    <div class="fleft m10r">
        Data do Terminio:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDataTerminio"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServico">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtDataTerminio" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10r">
        Cliente:
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCliente"
            Operator="NotEqual" ValueToCompare="Selecione" ErrorMessage="*" ForeColor="Red"
            SetFocusOnError="True" ValidationGroup="frmServico"></asp:CompareValidator>
        <br />
        <asp:DropDownList ID="ddlCliente" runat="server" Width="300px">
        </asp:DropDownList>
    </div>
    <div class="fleft m10r">
        FILME:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFilme"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServico">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtFilme" runat="server" Width="290px" MaxLength="255"></asp:TextBox>
    </div>
    <%--    <div class="fleft m10r">
        COR:
        <br />
        <asp:TextBox ID="txtCor" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
    </div>--%>
    <div class="fleft m10r">
        Controle do Cliente:
        <br />
        <asp:TextBox ID="txtControleCliente" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10r">
        Nome do Requisitante:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRequisitante"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServico">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtRequisitante" runat="server" Width="290px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Responsavel Kawai:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtResponsavel"
            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServico">Campo Obrigatório</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtResponsavel" runat="server" Width="290px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <p>
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
            ValidationGroup="frmServico" />
        <asp:Button ID="btnFiltro" runat="server" CssClass="padButton" Text="Filtrar" OnClick="btnFiltro_Click" />
    </p>
    <div id="divConta" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Cadastro de serviço<asp:HiddenField ID="hfCodigoConta" runat="server" />
        </h3>
        <div class="fleft m10r">
            Selecione um Serviço:<br />
            <asp:DropDownList ID="ddlItem" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            Observação:
            <br />
            <asp:TextBox ID="txtObservacao" runat="server" Width="350px" MaxLength="500"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Preço:
            <br />
            <asp:TextBox ID="txtvalorServico" runat="server" Width="150px" MaxLength="255" Enabled="false"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p class="fleft m10r">
            <asp:Button ID="btnCancelarConta" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarConta_Click" />
            <asp:Button ID="btnIncluirConta" runat="server" CssClass="padButton" Text="Incluir Novo Item"
                OnClick="btnIncluirConta_Click" />
        </p>
        <div class="cleared">
        </div>
        <h3>
            Listagem de serviços</h3>
        <asp:GridView ID="gvConta" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
            GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvContas_RowCommand"
            OnDataBound="gvConta_DataBound" OnRowDataBound="gvConta_RowDataBound" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo" Visible="False">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="SERVIÇO" ItemStyle-CssClass="w1pct nowrap" DataField="descricao"
                    SortExpression="descricao">
                    <ItemStyle Width="200px" CssClass="tleft" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Observacao" HeaderText="OBSERVAÇÃO" SortExpression="Observacao" />
                <asp:BoundField DataField="valorServico" DataFormatString="{0:c}" HeaderText="VALOR"
                    SortExpression="valorServico" FooterText="teste" />
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
            <FooterStyle CssClass="headerTable1 p3" Font-Size="15px" Font-Bold="true" />
        </asp:GridView>
    </div>
    <div id="divObservacao" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Cadastro de observação<asp:HiddenField ID="hfCodigoObservacao" runat="server" />
        </h3>
        <div class="fleft m10r">
            Observação:
            <br />
            <asp:TextBox ID="txtObservacaoAdicional" runat="server" Width="900px" MaxLength="500"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <p class="fleft m10r">
            <asp:Button ID="btnCancelarObservacao" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarObservacao_Click" />
            <asp:Button ID="btnIncluirObservacao" runat="server" CssClass="padButton" Text="Incluir Nova Observação"
                OnClick="btnIncluirObservacao_Click" />
        </p>
        <div class="cleared">
        </div>
        <h3>
            OBSERVAÇÕES</h3>
        <asp:GridView ID="gvObservacao" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
            GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvObservacao_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo" Visible="False">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Observacao" HeaderText="OBSERVAÇÃO" SortExpression="Observacao">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="EditarObservacao" ImageUrl="~/images/btn-editar-p.png" ToolTip="Editar" />
                    </ItemTemplate>
                    <ItemStyle CssClass="w1pct nowrap" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="w1pct nowrap">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("codigo") %>'
                            CommandName="ExcluirObservacao" ImageUrl="~/images/btn-excluir-p.png" ToolTip="Excluir" />
                    </ItemTemplate>
                    <ItemStyle CssClass="w1pct nowrap" />
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle CssClass="odd" />
            <PagerStyle CssClass="paginacaoPesquisa" />
            <RowStyle CssClass="even" />
            <HeaderStyle CssClass="headerTable1 p3" />
            <FooterStyle CssClass="headerTable1 p3" Font-Size="15px" Font-Bold="true" />
        </asp:GridView>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10l">
        <div id="divFiltro" runat="server" visible="false">
            <h3>
                Filtro de serviços
            </h3>
            <p>
            </p>
            <div class="fleft m10r">
                Cliente:
                <br />
                <asp:DropDownList ID="ddlFiltrarCliente" runat="server" Width="380px">
                </asp:DropDownList>
            </div>
<%--            <asp:Button ID="btnFiltroCliente" runat="server" CssClass="padButton" Text="FILTRO"
                OnClick="btnFiltroCliente_Click" />--%>
<%--            <div class="cleared">
            </div>--%>
            <div class="fleft m10r">
                Status:
                <br />
                <asp:DropDownList ID="ddlFiltrarStatus" runat="server" Width="380px">
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnFiltroStatus" runat="server" CssClass="padButton" Text="FILTRO"
                OnClick="btnFiltroStatus_Click" />
        </div>
    </div>
    <div class="cleared">
    </div>
    <div id="divPlanos" runat="server" visible="true">
        <h3>
            Listagem de ordens de serviços</h3>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há avaliações registradas.&lt;br/&gt;Por favor, clique em “Adicionar”.&lt;/h3&gt;"
            GridLines="None" PagerStyle-CssClass="paginacaoPesquisa" PageSize="20" OnRowCommand="gvLista_RowCommand"
            AllowPaging="True" OnPageIndexChanging="gvLista_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="STATUS" SortExpression="Status" />
                <asp:BoundField DataField="dataInicio" HeaderText="INICIO" SortExpression="dataInicio"
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="dataTerminio" HeaderText="TERMINIO" SortExpression="dataTerminio"
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="nomeFantasia" HeaderText="CLIENTE" ItemStyle-CssClass="w1pct nowrap"
                    SortExpression="nomeFantasia">
                    <ItemStyle CssClass="w1pct nowrap" Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Trabalho" HeaderText="TRABALHO" SortExpression="Trabalho">
                    <ItemStyle Width="200px" />
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

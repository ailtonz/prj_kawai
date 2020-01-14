<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="old_CadastroOS.aspx.cs" Inherits="kawaiWeb.CadastroOS" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        &nbsp;Ordem de Serviço
    </h2>
    <h3>
        Cadastro da Ordem de Serviço</h3>
    <div class="fleft m10r">
        Código:
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" Width="100px" Enabled="False"></asp:TextBox>
    </div>
    <div class="fleft m10r">
        Estudio:
        <br />
        <asp:DropDownList ID="ddlEstudio" runat="server" Width="180px">
        </asp:DropDownList>
    </div>
    <div class="fleft m10r">
        Data do Inicio:
        <br />
        <asp:TextBox ID="txtDataInicio" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="fleft m10r">
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
    </div>
    <div class="fleft m10r">
        Data do Terminio:
        <br />
        <asp:TextBox ID="txtDataTerminio" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10r">
        Cliente:
        <br />
        <asp:DropDownList ID="ddlCliente" runat="server" Width="300px" AutoPostBack="True"
            OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div id="divRequisitante" runat="server" visible="true">
        <div class="fleft m10r">
            Nome do Requisitante:
            <br />
            <asp:TextBox ID="txtRequisitante" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Responsavel Kawai:
            <br />
            <asp:TextBox ID="txtResponsavel" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            FILME:
            <br />
            <asp:TextBox ID="txtFilme" runat="server" Width="290px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            COR:
            <br />
            <asp:TextBox ID="txtCor" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Controle do Cliente:
            <br />
            <asp:TextBox ID="txtControleCliente" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="btnSalvarOS" runat="server" CssClass="padButton" Text="Incluir Novo OS"
                OnClick="btnSalvarOS_Click" ValidationGroup="formCadastro" />
            <asp:Button ID="btnCancelarOS" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelarOS_Click" />
        </p>
        <div class="cleared">
        </div>
    </div>
    <div id="divItem" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            Cadastro dos Itens</h3>
        <div class="fleft m10r">
            Selecione um Produto:<br />
            <asp:DropDownList ID="ddlItem" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div id="divCamposItem" runat="server" visible="true">
            <div class="fleft m10r">
                Observação:
                <br />
                <asp:TextBox ID="txtObservacao" runat="server" Width="350px" MaxLength="500"></asp:TextBox>
            </div>
            <div class="fleft m10r">
                Preço:
                <br />
                <asp:TextBox ID="txtPreco" runat="server" Width="150px" MaxLength="255" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="cleared">
        </div>
        <p>
            <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Incluir Novo Item da OS"
                OnClick="btnSalvar_Click" ValidationGroup="formCadastro" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
                OnClick="btnCancelar_Click" />
        </p>
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            PRESTAÇÃO DE SERVIÇO</h3>
        <asp:GridView ID="gvItens" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
            PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="SERVIÇO">
                    <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="Observacao" HeaderText="OBSERVAÇÃO" SortExpression="Observacao">
                    <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="valorServico" HeaderText="VALOR" SortExpression="valorServico"
                    DataFormatString="{0:c}" />
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
    <hr width="100%" size="1px" noshade="noshade" />
    <div id="divListaOS" runat="server" visible="True">
        <h3>
            Lista de Ordens de Serviços</h3>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CssClass="table1 w100pct tcenter m10t ui-corner-all"
            EmptyDataText="&lt;h3 class='blue'&gt;Não há registros.&lt;/h3&gt;" GridLines="None"
            PagerStyle-CssClass="paginacaoPesquisa" PageSize="50" OnRowCommand="gvLista_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderStyle-CssClass="tleft" HeaderText="Código"
                    ItemStyle-CssClass="tleft" SortExpression="codigo">
                    <HeaderStyle CssClass="tleft" />
                    <ItemStyle CssClass="tleft" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="nomeFantasia" HeaderText="CLIENTE" SortExpression="nomeFantasia">
                    <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="Trabalho" HeaderText="TRABALHO" SortExpression="Trabalho">
                    <ItemStyle CssClass="tleft" />
                </asp:BoundField>
                <asp:BoundField DataField="dataInicio" HeaderText="INICIO" SortExpression="dataInicio" />
                <asp:BoundField DataField="dataTerminio" HeaderText="TERMINIO" SortExpression="dataTerminio" />
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
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="btnOK" runat="server" CssClass="padButton" Text="OK" OnClick="btnOK_Click" />
    </div>
</asp:Content>

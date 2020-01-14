<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroDespesa.aspx.cs" Inherits="kawaiWeb.CadastroDespesa" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Despesas
    </h2>
    <h3>
        Cadastrar um nova Despesa
    </h3>
    <div>
        <div class="fleft m10r">
            Codigo:
            <br />
            <asp:TextBox ID="txtCodigo" runat="server" Width="100px" Enabled="False"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Data de Emissão:
            <br />
            <asp:TextBox ID="txtDataEmissao" runat="server" Width="100px" Enabled="False"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Despesa:
            <asp:RequiredFieldValidator ID="rfvConta" runat="server" ControlToValidate="ddlConta"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServicos">Campo Obrigatório</asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlConta" runat="server" Width="290px">
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            Data de Venvimento:
            <asp:RequiredFieldValidator ID="rfvVencimento" runat="server" ControlToValidate="txtDataVencimento"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServicos">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtDataVencimento" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Valor Original:
            <asp:RequiredFieldValidator ID="rfvValorOriginal" runat="server" ControlToValidate="txtValorOriginal"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServicos">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtValorOriginal" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Forma de recebimento:
            <asp:RequiredFieldValidator ID="frvPagamento" runat="server" ControlToValidate="ddlPagamento"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="frmServicos">Campo Obrigatório</asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlPagamento" runat="server" Width="290px">
            </asp:DropDownList>
        </div>
        <div class="fleft m10r">
            Data de Pagamento:
            <br />
            <asp:TextBox ID="txtDataPagamento" runat="server" Width="100px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Valor Final:
            <br />
            <asp:TextBox ID="txtValorFinal" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="cleared">
        </div>
        <div class="fleft m10r">
            Documento:
            <br />
            <asp:TextBox ID="txtDocumento" runat="server" Width="280px" MaxLength="255"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Observação:
            <br />
            <asp:TextBox ID="txtObservacao" runat="server" Width="340px" MaxLength="255"></asp:TextBox>
        </div>
    </div>
    <div class="cleared">
    </div>
    <div class="fleft m10r">
        <asp:Button ID="btnCancelar" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelar_Click" />
        <asp:Button ID="btnParcelar" runat="server" CssClass="padButton" Text="Parcelar"
            OnClick="btnParcelar_Click" />
        <asp:Button ID="btnSalvar" runat="server" CssClass="padButton" Text="Salvar" OnClick="btnSalvar_Click"
            ValidationGroup="frmServicos" />
    </div>
    <div class="cleared">
    </div>
    <div id="divParcelamento" runat="server" visible="false">
        <hr width="100%" size="1px" noshade="noshade" />
        <h3>
            PARCELAMENTO
        </h3>
        <div class="fleft m10r">
            Numero De Parcelas:
            <br />
            <asp:TextBox ID="txtNumeroDeParcelas" runat="server" Width="100px" MaxLength="100"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Dia do Vencimento:
            <br />
            <asp:TextBox ID="txtDiaDoVencimento" runat="server" Width="100px" MaxLength="100"></asp:TextBox>
        </div>
        <div class="fleft m10r">
            Valor Parcela:
            <br />
            <asp:DropDownList ID="ddlValorParcela" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="cleared">
        </div>
        <p class="fleft m10r">
        <asp:Button ID="btnCancelarParcelamento" runat="server" CssClass="padButton" Text="Cancelar"
            OnClick="btnCancelarParcelamento_Click" />
            <asp:Button ID="btnParcelamento" runat="server" CssClass="padButton" Text="Gerar Parcelamento"
                OnClick="btnParcelamento_Click" />
        </p>
    </div>
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
            <asp:BoundField HeaderText="Movimento" DataField="Conta">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Documento" HeaderText="Documento" />
            <asp:BoundField DataField="dataVencimento" HeaderText="Vencimento" ItemStyle-CssClass="w1pct nowrap"
                SortExpression="dataVencimento" DataFormatString="{0:d}">
                <ItemStyle CssClass="w1pct nowrap"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ValorOriginal" HeaderText="Val. Original" SortExpression="ValorOriginal"
                DataFormatString="{0:c}">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="dataPagamento" HeaderText="Recebimento" SortExpression="dataPagamento"
                DataFormatString="{0:d}">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="ValorFinal" HeaderText="Val.Final" SortExpression="ValorFinal"
                DataFormatString="{0:c}">
                <ItemStyle Width="50px" />
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
    <p>
        &nbsp;</p>
</asp:Content>

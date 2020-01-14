<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Envio.aspx.cs" Inherits="kawaiWeb.Envio" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Tipo de SERVIÇO
    </h2>
    <h3>
        Cadastrar um novo Tipo de SERVIÇO
    </h3>
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
    
    <p>
        &nbsp;</p>
</asp:Content>

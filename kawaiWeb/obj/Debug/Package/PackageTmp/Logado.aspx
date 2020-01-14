<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Logado.aspx.cs" Inherits="kawaiWeb.Logado" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Dados do Usuário
    </h2>
    <p>
        Atenção!
        Se os dados não corresponde com o seu login e senha, saia do Sistema e informe o
        administrador
    </p>
    <p>
        Nome:
        <asp:Label ID="lblNome" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
    </p>
    <p>
        Login:
        <asp:Label ID="lblLogin" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
    </p>
    <p>
        Perfil:
        <asp:Label ID="lblPerfil" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
    </p>
</asp:Content>

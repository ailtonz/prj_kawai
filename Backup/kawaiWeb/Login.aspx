<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="kawaiWeb.Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Login
    </h2>
    <p>
        Digite o seu login e senha.
    </p>
    <p>
        Login:<BR/>
        <asp:TextBox ID="txtLogin" runat="server" Width="200px"></asp:TextBox>
    </p>
    <p>
        Senha:<BR/>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnLogin" runat="server" onclick="Button1_Click" 
            Text="Entrar" CssClass="padButton" />
    </p>
</asp:Content>

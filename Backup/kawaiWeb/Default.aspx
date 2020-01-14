<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="kawaiWeb._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Seja Bem Vindo!
    </h2>
    <p>
        Esse sistema requer um Login e Senha.
    </p>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login.aspx">Clique aqui</asp:LinkButton>
&nbsp;para fazer o Login e Senha.
    </p>
</asp:Content>

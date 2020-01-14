<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Erro.aspx.cs" Inherits="kawaiWeb.Erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Erro
    </h2>
    <h3>
        Atenção! Aconteceu um erro.
    </h3>
    <p>
        <asp:Label ID="lblErro" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>

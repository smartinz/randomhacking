<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinksAndButtons.aspx.cs" Inherits="SpikeJQueryCss.LinksAndButtons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="button" runat="server" Text="Button" />
    <asp:LinkButton ID="linkButton" runat="server">LinkButton</asp:LinkButton>
</asp:Content>

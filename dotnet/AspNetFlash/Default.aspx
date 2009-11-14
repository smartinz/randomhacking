<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetFlash.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Button ID="Button1" runat="server" Text="Set message and redirect" 
		onclick="Button1_Click" />
	<asp:Button ID="Button2" runat="server" Text="Redirect" 
		onclick="Button2_Click" />
	<asp:Button ID="Button3" runat="server" Text="Set message and Postback" 
		onclick="Button3_Click" />
    <asp:Button ID="Button4" runat="server" Text="Postback" 
        onclick="Button4_Click" />
</asp:Content>

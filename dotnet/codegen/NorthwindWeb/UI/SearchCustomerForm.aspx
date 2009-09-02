<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCustomerForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchCustomerForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchCustomerControl.ascx" TagName="SearchCustomerControl" TagPrefix="SearchCustomerControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchCustomerControl:SearchCustomerControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

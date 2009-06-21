<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchSupplierForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchSupplierForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchSupplierControl.ascx" TagName="SearchSupplierControl" TagPrefix="SearchSupplierControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchSupplierControl:SearchSupplierControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

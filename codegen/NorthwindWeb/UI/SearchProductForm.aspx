<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchProductForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchProductForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchProductControl.ascx" TagName="SearchProductControl" TagPrefix="SearchProductControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchProductControl:SearchProductControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

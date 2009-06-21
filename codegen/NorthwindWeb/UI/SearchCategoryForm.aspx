<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCategoryForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchCategoryForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchCategoryControl.ascx" TagName="SearchCategoryControl" TagPrefix="SearchCategoryControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchCategoryControl:SearchCategoryControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

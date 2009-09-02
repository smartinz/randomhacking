<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchOrderForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchOrderForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchOrderControl.ascx" TagName="SearchOrderControl" TagPrefix="SearchOrderControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchOrderControl:SearchOrderControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchShipperForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchShipperForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchShipperControl.ascx" TagName="SearchShipperControl" TagPrefix="SearchShipperControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchShipperControl:SearchShipperControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

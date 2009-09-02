<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployeeForm.aspx.cs" Inherits="NorthwindWeb.UI.SearchEmployeeForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SearchEmployeeControl.ascx" TagName="SearchEmployeeControl" TagPrefix="SearchEmployeeControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<SearchEmployeeControl:SearchEmployeeControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
</asp:Content>

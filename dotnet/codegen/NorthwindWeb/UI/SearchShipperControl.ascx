<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchShipperControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchShipperControl" %>
		
<%@ Register Src="~/UI/ShipperListControl.ascx" TagName="ShipperListControl" TagPrefix="ShipperListControl" %>
<ul>
		
	<li>
		companyName:
		<asp:TextBox ID="companyNameTextBox" runat="server" />
	</li>
	
	<li>
		phone:
		<asp:TextBox ID="phoneTextBox" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<ShipperListControl:ShipperListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

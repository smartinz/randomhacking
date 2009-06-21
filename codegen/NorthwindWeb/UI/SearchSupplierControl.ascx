<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchSupplierControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchSupplierControl" %>
		
<%@ Register Src="~/UI/SupplierListControl.ascx" TagName="SupplierListControl" TagPrefix="SupplierListControl" %>
<ul>
		
	<li>
		companyName:
		<asp:TextBox ID="companyNameTextBox" runat="server" />
	</li>
	
	<li>
		contactName:
		<asp:TextBox ID="contactNameTextBox" runat="server" />
	</li>
	
	<li>
		counrty:
		<asp:TextBox ID="counrtyTextBox" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<SupplierListControl:SupplierListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

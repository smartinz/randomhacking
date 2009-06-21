<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchCustomerControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchCustomerControl" %>
		
<%@ Register Src="~/UI/CustomerListControl.ascx" TagName="CustomerListControl" TagPrefix="CustomerListControl" %>
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
		contactTitle:
		<asp:TextBox ID="contactTitleTextBox" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<CustomerListControl:CustomerListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

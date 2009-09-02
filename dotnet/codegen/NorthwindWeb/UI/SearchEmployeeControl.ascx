<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployeeControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchEmployeeControl" %>
		
<%@ Register Src="~/UI/EmployeeListControl.ascx" TagName="EmployeeListControl" TagPrefix="EmployeeListControl" %>
<ul>
		
	<li>
		lastName:
		<asp:TextBox ID="lastNameTextBox" runat="server" />
	</li>
	
	<li>
		firstName:
		<asp:TextBox ID="firstNameTextBox" runat="server" />
	</li>
	
	<li>
		title:
		<asp:TextBox ID="titleTextBox" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<EmployeeListControl:EmployeeListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchOrderControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchOrderControl" %>
		
<%@ Register Src="~/UI/OrderListControl.ascx" TagName="OrderListControl" TagPrefix="OrderListControl" %>
<%@ Register Src="~/UI/EmployeeReferenceControl.ascx" TagName="EmployeeReferenceControl" TagPrefix="EmployeeReferenceControl" %>
<ul>
		
	<li>
		employee:
		<EmployeeReferenceControl:EmployeeReferenceControl ID="employeeReferenceControl" runat="server" />
	</li>
	
	<li>
		dateFrom:
		<DateTimeControl:DateTimeControl ID="dateFromControl" runat="server" />
	</li>
	
	<li>
		dateTo:
		<DateTimeControl:DateTimeControl ID="dateToControl" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<OrderListControl:OrderListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeListControl.ascx.cs" Inherits="NorthwindWeb.UI.EmployeeListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="EmployeeID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
	
		<asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
	
		<asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
	
		<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
	
		<asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
	
		<asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
	
		<asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
	
		<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
	
		<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
	
		<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
	
		<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
	
		<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
	
		<asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
	
		<asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
	
		<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
	
		<asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.EmployeeListControl"/>

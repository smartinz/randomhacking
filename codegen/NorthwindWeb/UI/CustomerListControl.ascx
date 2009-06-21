<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerListControl.ascx.cs" Inherits="NorthwindWeb.UI.CustomerListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="CustomerID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
	
		<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
	
		<asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
	
		<asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
	
		<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
	
		<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
	
		<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
	
		<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
	
		<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
	
		<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
	
		<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.CustomerListControl"/>

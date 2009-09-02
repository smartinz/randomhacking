<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderListControl.ascx.cs" Inherits="NorthwindWeb.UI.OrderListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="OrderID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
	
		<asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
	
		<asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
	
		<asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
	
		<asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
	
		<asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
	
		<asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
	
		<asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
	
		<asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
	
		<asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
	
		<asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
	
		<asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
	
		<asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
	
		<asp:BoundField DataField="Shipper" HeaderText="Shipper" SortExpression="Shipper" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.OrderListControl"/>

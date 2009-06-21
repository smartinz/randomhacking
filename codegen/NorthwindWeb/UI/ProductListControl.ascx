<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListControl.ascx.cs" Inherits="NorthwindWeb.UI.ProductListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="ProductID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
	
		<asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
	
		<asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
	
		<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
	
		<asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
	
		<asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
	
		<asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
	
		<asp:BoundField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
	
		<asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
	
		<asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.ProductListControl"/>

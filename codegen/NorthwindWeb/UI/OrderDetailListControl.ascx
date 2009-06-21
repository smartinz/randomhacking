<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailListControl.ascx.cs" Inherits="NorthwindWeb.UI.OrderDetailListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" >
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="OrderDetailID" HeaderText="OrderDetailID" SortExpression="OrderDetailID" />
	
		<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
	
		<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
	
		<asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
	
		<asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.OrderDetailListControl"/>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplierListControl.ascx.cs" Inherits="NorthwindWeb.UI.SupplierListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="SupplierID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
	
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
	
		<asp:BoundField DataField="HomePage" HeaderText="HomePage" SortExpression="HomePage" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.SupplierListControl"/>

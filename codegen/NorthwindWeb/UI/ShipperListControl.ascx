<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShipperListControl.ascx.cs" Inherits="NorthwindWeb.UI.ShipperListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="ShipperID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="ShipperID" HeaderText="ShipperID" SortExpression="ShipperID" />
	
		<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
	
		<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.ShipperListControl"/>

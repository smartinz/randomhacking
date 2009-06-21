<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryListControl.ascx.cs" Inherits="NorthwindWeb.UI.CategoryListControl" %>
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="dataSource" DataKeyNames="CategoryID" onselectedindexchanged="gridView_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
		
		<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
	
		<asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
	
		<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
	
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.CategoryListControl"/>

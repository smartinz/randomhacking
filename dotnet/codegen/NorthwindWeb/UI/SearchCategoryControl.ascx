<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchCategoryControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchCategoryControl" %>
		
<%@ Register Src="~/UI/CategoryListControl.ascx" TagName="CategoryListControl" TagPrefix="CategoryListControl" %>
<ul>
		
	<li>
		categoryName:
		<asp:TextBox ID="categoryNameTextBox" runat="server" />
	</li>
	
	<li>
		description:
		<asp:TextBox ID="descriptionTextBox" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<CategoryListControl:CategoryListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

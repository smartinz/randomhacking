<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchProductControl.ascx.cs" Inherits="NorthwindWeb.UI.SearchProductControl" %>
		
<%@ Register Src="~/UI/ProductListControl.ascx" TagName="ProductListControl" TagPrefix="ProductListControl" %>
<%@ Register Src="~/UI/CategoryReferenceControl.ascx" TagName="CategoryReferenceControl" TagPrefix="CategoryReferenceControl" %>
<%@ Register Src="~/UI/SupplierReferenceControl.ascx" TagName="SupplierReferenceControl" TagPrefix="SupplierReferenceControl" %>
<ul>
		
	<li>
		category:
		<CategoryReferenceControl:CategoryReferenceControl ID="categoryReferenceControl" runat="server" />
	</li>
	
	<li>
		supplier:
		<SupplierReferenceControl:SupplierReferenceControl ID="supplierReferenceControl" runat="server" />
	</li>
	
	<li>
		<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
	</li>
</ul>
<ProductListControl:ProductListControl ID="listControl" runat="server" OnListLoading="listControl_ListLoading" />

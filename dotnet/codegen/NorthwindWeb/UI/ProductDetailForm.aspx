<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.ProductDetailForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/SupplierReferenceControl.ascx" TagName="SupplierReferenceControl" TagPrefix="SupplierReferenceControl" %>
<%@ Register Src="~/UI/CategoryReferenceControl.ascx" TagName="CategoryReferenceControl" TagPrefix="CategoryReferenceControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Product</legend>
	
					<p>
		ProductID:
						<Int32Control:Int32Control ID="ProductIDControl" runat="server" Value='<%# Bind("ProductID") %>' />
			
					</p>
	
					<p>
		ProductName:
						<asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
			
					</p>
	
					<p>
		QuantityPerUnit:
						<asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<DecimalControl:DecimalControl ID="UnitPriceControl" runat="server" Value='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		UnitsInStock:
						<Int16Control:Int16Control ID="UnitsInStockControl" runat="server" Value='<%# Bind("UnitsInStock") %>' />
			
					</p>
	
					<p>
		UnitsOnOrder:
						<Int16Control:Int16Control ID="UnitsOnOrderControl" runat="server" Value='<%# Bind("UnitsOnOrder") %>' />
			
					</p>
	
					<p>
		ReorderLevel:
						<Int16Control:Int16Control ID="ReorderLevelControl" runat="server" Value='<%# Bind("ReorderLevel") %>' />
			
					</p>
	
					<p>
		Discontinued:
						<asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' />
			
					</p>
	
					<p>
		Supplier:
						<SupplierReferenceControl:SupplierReferenceControl ID="SupplierReferenceControl" runat="server" Item='<%# Bind("Supplier") %>' />
			
					</p>
	
					<p>
		Category:
						<CategoryReferenceControl:CategoryReferenceControl ID="CategoryReferenceControl" runat="server" Item='<%# Bind("Category") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchProductForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Product</legend>
	
					<p>
		ProductID:
						<Int32Control:Int32Control ID="ProductIDControl" runat="server" Value='<%# Bind("ProductID") %>' />
			
					</p>
	
					<p>
		ProductName:
						<asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
			
					</p>
	
					<p>
		QuantityPerUnit:
						<asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<DecimalControl:DecimalControl ID="UnitPriceControl" runat="server" Value='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		UnitsInStock:
						<Int16Control:Int16Control ID="UnitsInStockControl" runat="server" Value='<%# Bind("UnitsInStock") %>' />
			
					</p>
	
					<p>
		UnitsOnOrder:
						<Int16Control:Int16Control ID="UnitsOnOrderControl" runat="server" Value='<%# Bind("UnitsOnOrder") %>' />
			
					</p>
	
					<p>
		ReorderLevel:
						<Int16Control:Int16Control ID="ReorderLevelControl" runat="server" Value='<%# Bind("ReorderLevel") %>' />
			
					</p>
	
					<p>
		Discontinued:
						<asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' />
			
					</p>
	
					<p>
		Supplier:
						<SupplierReferenceControl:SupplierReferenceControl ID="SupplierReferenceControl" runat="server" Item='<%# Bind("Supplier") %>' />
			
					</p>
	
					<p>
		Category:
						<CategoryReferenceControl:CategoryReferenceControl ID="CategoryReferenceControl" runat="server" Item='<%# Bind("Category") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
					|
					<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				</p>
			</fieldset>
		</EditItemTemplate>
		<ItemTemplate>
			<fieldset>
				<legend>Product Details</legend>
	
					<p>
		ProductID:
						<asp:Label ID="ProductIDLabel" runat="server" Text='<%# Bind("ProductID") %>' />
			
					</p>
	
					<p>
		ProductName:
						<asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>' />
			
					</p>
	
					<p>
		QuantityPerUnit:
						<asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Bind("QuantityPerUnit") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		UnitsInStock:
						<asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Bind("UnitsInStock") %>' />
			
					</p>
	
					<p>
		UnitsOnOrder:
						<asp:Label ID="UnitsOnOrderLabel" runat="server" Text='<%# Bind("UnitsOnOrder") %>' />
			
					</p>
	
					<p>
		ReorderLevel:
						<asp:Label ID="ReorderLevelLabel" runat="server" Text='<%# Bind("ReorderLevel") %>' />
			
					</p>
	
					<p>
		Discontinued:
						<asp:Label ID="DiscontinuedLabel" runat="server" Text='<%# Bind("Discontinued") %>' />
			
					</p>
	
					<p>
		Supplier:
						<asp:HyperLink ID="SupplierHyperLink" runat="server" NavigateUrl='<%# Eval("Supplier.SupplierID", "~/UI/SupplierDetailForm.aspx?id={0}") %>' Text='<%# Eval("Supplier") %>' />
			
					</p>
	
					<p>
		Category:
						<asp:HyperLink ID="CategoryHyperLink" runat="server" NavigateUrl='<%# Eval("Category.CategoryID", "~/UI/CategoryDetailForm.aspx?id={0}") %>' Text='<%# Eval("Category") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Product" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.ProductDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

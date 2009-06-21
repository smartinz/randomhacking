<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailDetailControl.ascx.cs" Inherits="NorthwindWeb.UI.OrderDetailDetailControl" %>
		
<%@ Register Src="~/UI/ProductReferenceControl.ascx" TagName="ProductReferenceControl" TagPrefix="ProductReferenceControl" %>
<asp:FormView ID="formView" runat="server" DataSourceID="dataSource">
	<EditItemTemplate>
		
					<p>
		OrderDetailID:
						<Int32Control:Int32Control ID="OrderDetailIDControl" runat="server" Value='<%# Bind("OrderDetailID") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<DecimalControl:DecimalControl ID="UnitPriceControl" runat="server" Value='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		Quantity:
						<Int16Control:Int16Control ID="QuantityControl" runat="server" Value='<%# Bind("Quantity") %>' />
			
					</p>
	
					<p>
		Discount:
						<DoubleControl:DoubleControl ID="DiscountControl" runat="server" Value='<%# Bind("Discount") %>' />
			
					</p>
	
					<p>
		Product:
						<ProductReferenceControl:ProductReferenceControl ID="ProductReferenceControl" runat="server" Item='<%# Bind("Product") %>' />
			
					</p>
	
	</EditItemTemplate>
	<ItemTemplate>
		
					<p>
		OrderDetailID:
						<asp:Label ID="OrderDetailIDLabel" runat="server" Text='<%# Bind("OrderDetailID") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		Quantity:
						<asp:Label ID="QuantityLabel" runat="server" Text='<%# Bind("Quantity") %>' />
			
					</p>
	
					<p>
		Discount:
						<asp:Label ID="DiscountLabel" runat="server" Text='<%# Bind("Discount") %>' />
			
					</p>
	
					<p>
		Product:
						<asp:HyperLink ID="ProductHyperLink" runat="server" NavigateUrl='<%# Eval("Product.ProductID", "~/UI/ProductDetailForm.aspx?id={0}") %>' Text='<%# Eval("Product") %>' />
			
					</p>
	
	</ItemTemplate>
	<InsertItemTemplate>
		
					<p>
		OrderDetailID:
						<Int32Control:Int32Control ID="OrderDetailIDControl" runat="server" Value='<%# Bind("OrderDetailID") %>' />
			
					</p>
	
					<p>
		UnitPrice:
						<DecimalControl:DecimalControl ID="UnitPriceControl" runat="server" Value='<%# Bind("UnitPrice") %>' />
			
					</p>
	
					<p>
		Quantity:
						<Int16Control:Int16Control ID="QuantityControl" runat="server" Value='<%# Bind("Quantity") %>' />
			
					</p>
	
					<p>
		Discount:
						<DoubleControl:DoubleControl ID="DiscountControl" runat="server" Value='<%# Bind("Discount") %>' />
			
					</p>
	
					<p>
		Product:
						<ProductReferenceControl:ProductReferenceControl ID="ProductReferenceControl" runat="server" Item='<%# Bind("Product") %>' />
			
					</p>
	
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.OrderDetail" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.OrderDetailDetailControl" UpdateMethod="UpdateForDataSource" InsertMethod="InsertForDataSource" />

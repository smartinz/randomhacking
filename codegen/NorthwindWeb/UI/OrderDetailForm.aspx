<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.OrderDetailForm" MasterPageFile="~/Site.Master" %>
		
<%@ Register Src="~/UI/OrderDetailListControl.ascx" TagName="OrderDetailListControl" TagPrefix="OrderDetailListControl" %>
<%@ Register Src="~/UI/CustomerReferenceControl.ascx" TagName="CustomerReferenceControl" TagPrefix="CustomerReferenceControl" %>
<%@ Register Src="~/UI/EmployeeReferenceControl.ascx" TagName="EmployeeReferenceControl" TagPrefix="EmployeeReferenceControl" %>
<%@ Register Src="~/UI/ShipperReferenceControl.ascx" TagName="ShipperReferenceControl" TagPrefix="ShipperReferenceControl" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Order</legend>
	
					<p>
		OrderID:
						<Int32Control:Int32Control ID="OrderIDControl" runat="server" Value='<%# Bind("OrderID") %>' />
			
					</p>
	
					<p>
		OrderDate:
						<DateTimeControl:DateTimeControl ID="OrderDateControl" runat="server" NullableValue='<%# Bind("OrderDate") %>' />
			
					</p>
	
					<p>
		RequiredDate:
						<DateTimeControl:DateTimeControl ID="RequiredDateControl" runat="server" NullableValue='<%# Bind("RequiredDate") %>' />
			
					</p>
	
					<p>
		ShippedDate:
						<DateTimeControl:DateTimeControl ID="ShippedDateControl" runat="server" NullableValue='<%# Bind("ShippedDate") %>' />
			
					</p>
	
					<p>
		Freight:
						<DecimalControl:DecimalControl ID="FreightControl" runat="server" Value='<%# Bind("Freight") %>' />
			
					</p>
	
					<p>
		ShipName:
						<asp:TextBox ID="ShipNameTextBox" runat="server" Text='<%# Bind("ShipName") %>' />
			
					</p>
	
					<p>
		ShipAddress:
						<asp:TextBox ID="ShipAddressTextBox" runat="server" Text='<%# Bind("ShipAddress") %>' />
			
					</p>
	
					<p>
		ShipCity:
						<asp:TextBox ID="ShipCityTextBox" runat="server" Text='<%# Bind("ShipCity") %>' />
			
					</p>
	
					<p>
		ShipRegion:
						<asp:TextBox ID="ShipRegionTextBox" runat="server" Text='<%# Bind("ShipRegion") %>' />
			
					</p>
	
					<p>
		ShipPostalCode:
						<asp:TextBox ID="ShipPostalCodeTextBox" runat="server" Text='<%# Bind("ShipPostalCode") %>' />
			
					</p>
	
					<p>
		ShipCountry:
						<asp:TextBox ID="ShipCountryTextBox" runat="server" Text='<%# Bind("ShipCountry") %>' />
			
					</p>
	
					<p>
		OrderDetails:
						<OrderDetailListControl:OrderDetailListControl ID="OrderDetailsListControl" runat="server" List='<%# Bind("OrderDetails") %>' OnListLoading="OrderDetailsListControl_ListLoading" AllowSelection="false" />
			
					</p>
	
					<p>
		Customer:
						<CustomerReferenceControl:CustomerReferenceControl ID="CustomerReferenceControl" runat="server" Item='<%# Bind("Customer") %>' />
			
					</p>
	
					<p>
		Employee:
						<EmployeeReferenceControl:EmployeeReferenceControl ID="EmployeeReferenceControl" runat="server" Item='<%# Bind("Employee") %>' />
			
					</p>
	
					<p>
		Shipper:
						<ShipperReferenceControl:ShipperReferenceControl ID="ShipperReferenceControl" runat="server" Item='<%# Bind("Shipper") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchOrderForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Order</legend>
	
					<p>
		OrderID:
						<Int32Control:Int32Control ID="OrderIDControl" runat="server" Value='<%# Bind("OrderID") %>' />
			
					</p>
	
					<p>
		OrderDate:
						<DateTimeControl:DateTimeControl ID="OrderDateControl" runat="server" NullableValue='<%# Bind("OrderDate") %>' />
			
					</p>
	
					<p>
		RequiredDate:
						<DateTimeControl:DateTimeControl ID="RequiredDateControl" runat="server" NullableValue='<%# Bind("RequiredDate") %>' />
			
					</p>
	
					<p>
		ShippedDate:
						<DateTimeControl:DateTimeControl ID="ShippedDateControl" runat="server" NullableValue='<%# Bind("ShippedDate") %>' />
			
					</p>
	
					<p>
		Freight:
						<DecimalControl:DecimalControl ID="FreightControl" runat="server" Value='<%# Bind("Freight") %>' />
			
					</p>
	
					<p>
		ShipName:
						<asp:TextBox ID="ShipNameTextBox" runat="server" Text='<%# Bind("ShipName") %>' />
			
					</p>
	
					<p>
		ShipAddress:
						<asp:TextBox ID="ShipAddressTextBox" runat="server" Text='<%# Bind("ShipAddress") %>' />
			
					</p>
	
					<p>
		ShipCity:
						<asp:TextBox ID="ShipCityTextBox" runat="server" Text='<%# Bind("ShipCity") %>' />
			
					</p>
	
					<p>
		ShipRegion:
						<asp:TextBox ID="ShipRegionTextBox" runat="server" Text='<%# Bind("ShipRegion") %>' />
			
					</p>
	
					<p>
		ShipPostalCode:
						<asp:TextBox ID="ShipPostalCodeTextBox" runat="server" Text='<%# Bind("ShipPostalCode") %>' />
			
					</p>
	
					<p>
		ShipCountry:
						<asp:TextBox ID="ShipCountryTextBox" runat="server" Text='<%# Bind("ShipCountry") %>' />
			
					</p>
	
					<p>
		OrderDetails:
						<OrderDetailListControl:OrderDetailListControl ID="OrderDetailsListControl" runat="server" List='<%# Bind("OrderDetails") %>' OnListLoading="OrderDetailsListControl_ListLoading" AllowSelection="false" />
			
					</p>
	
					<p>
		Customer:
						<CustomerReferenceControl:CustomerReferenceControl ID="CustomerReferenceControl" runat="server" Item='<%# Bind("Customer") %>' />
			
					</p>
	
					<p>
		Employee:
						<EmployeeReferenceControl:EmployeeReferenceControl ID="EmployeeReferenceControl" runat="server" Item='<%# Bind("Employee") %>' />
			
					</p>
	
					<p>
		Shipper:
						<ShipperReferenceControl:ShipperReferenceControl ID="ShipperReferenceControl" runat="server" Item='<%# Bind("Shipper") %>' />
			
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
				<legend>Order Details</legend>
	
					<p>
		OrderID:
						<asp:Label ID="OrderIDLabel" runat="server" Text='<%# Bind("OrderID") %>' />
			
					</p>
	
					<p>
		OrderDate:
						<asp:Label ID="OrderDateLabel" runat="server" Text='<%# Bind("OrderDate") %>' />
			
					</p>
	
					<p>
		RequiredDate:
						<asp:Label ID="RequiredDateLabel" runat="server" Text='<%# Bind("RequiredDate") %>' />
			
					</p>
	
					<p>
		ShippedDate:
						<asp:Label ID="ShippedDateLabel" runat="server" Text='<%# Bind("ShippedDate") %>' />
			
					</p>
	
					<p>
		Freight:
						<asp:Label ID="FreightLabel" runat="server" Text='<%# Bind("Freight") %>' />
			
					</p>
	
					<p>
		ShipName:
						<asp:Label ID="ShipNameLabel" runat="server" Text='<%# Bind("ShipName") %>' />
			
					</p>
	
					<p>
		ShipAddress:
						<asp:Label ID="ShipAddressLabel" runat="server" Text='<%# Bind("ShipAddress") %>' />
			
					</p>
	
					<p>
		ShipCity:
						<asp:Label ID="ShipCityLabel" runat="server" Text='<%# Bind("ShipCity") %>' />
			
					</p>
	
					<p>
		ShipRegion:
						<asp:Label ID="ShipRegionLabel" runat="server" Text='<%# Bind("ShipRegion") %>' />
			
					</p>
	
					<p>
		ShipPostalCode:
						<asp:Label ID="ShipPostalCodeLabel" runat="server" Text='<%# Bind("ShipPostalCode") %>' />
			
					</p>
	
					<p>
		ShipCountry:
						<asp:Label ID="ShipCountryLabel" runat="server" Text='<%# Bind("ShipCountry") %>' />
			
					</p>
	
					<p>
		OrderDetails:
						<OrderDetailListControl:OrderDetailListControl ID="OrderDetailsListControl" runat="server" List='<%# Bind("OrderDetails") %>' OnListLoading="OrderDetailsListControl_ListLoading" AllowSelection="false" />
			
					</p>
	
					<p>
		Customer:
						<asp:HyperLink ID="CustomerHyperLink" runat="server" NavigateUrl='<%# Eval("Customer.CustomerID", "~/UI/CustomerDetailForm.aspx?id={0}") %>' Text='<%# Eval("Customer") %>' />
			
					</p>
	
					<p>
		Employee:
						<asp:HyperLink ID="EmployeeHyperLink" runat="server" NavigateUrl='<%# Eval("Employee.EmployeeID", "~/UI/EmployeeDetailForm.aspx?id={0}") %>' Text='<%# Eval("Employee") %>' />
			
					</p>
	
					<p>
		Shipper:
						<asp:HyperLink ID="ShipperHyperLink" runat="server" NavigateUrl='<%# Eval("Shipper.ShipperID", "~/UI/ShipperDetailForm.aspx?id={0}") %>' Text='<%# Eval("Shipper") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Order" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.OrderDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

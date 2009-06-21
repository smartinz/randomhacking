<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.CustomerDetailForm" MasterPageFile="~/Site.Master" %>
		
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Customer</legend>
	
					<p>
		CustomerID:
						<asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		ContactName:
						<asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' />
			
					</p>
	
					<p>
		ContactTitle:
						<asp:TextBox ID="ContactTitleTextBox" runat="server" Text='<%# Bind("ContactTitle") %>' />
			
					</p>
	
					<p>
		Address:
						<asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
			
					</p>
	
					<p>
		City:
						<asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
			
					</p>
	
					<p>
		Region:
						<asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
			
					</p>
	
					<p>
		PostalCode:
						<asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
			
					</p>
	
					<p>
		Country:
						<asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
			
					</p>
	
					<p>
		Fax:
						<asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchCustomerForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Customer</legend>
	
					<p>
		CustomerID:
						<asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		ContactName:
						<asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' />
			
					</p>
	
					<p>
		ContactTitle:
						<asp:TextBox ID="ContactTitleTextBox" runat="server" Text='<%# Bind("ContactTitle") %>' />
			
					</p>
	
					<p>
		Address:
						<asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
			
					</p>
	
					<p>
		City:
						<asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
			
					</p>
	
					<p>
		Region:
						<asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
			
					</p>
	
					<p>
		PostalCode:
						<asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
			
					</p>
	
					<p>
		Country:
						<asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
			
					</p>
	
					<p>
		Fax:
						<asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
			
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
				<legend>Customer Details</legend>
	
					<p>
		CustomerID:
						<asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Bind("CustomerID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		ContactName:
						<asp:Label ID="ContactNameLabel" runat="server" Text='<%# Bind("ContactName") %>' />
			
					</p>
	
					<p>
		ContactTitle:
						<asp:Label ID="ContactTitleLabel" runat="server" Text='<%# Bind("ContactTitle") %>' />
			
					</p>
	
					<p>
		Address:
						<asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
			
					</p>
	
					<p>
		City:
						<asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>' />
			
					</p>
	
					<p>
		Region:
						<asp:Label ID="RegionLabel" runat="server" Text='<%# Bind("Region") %>' />
			
					</p>
	
					<p>
		PostalCode:
						<asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Bind("PostalCode") %>' />
			
					</p>
	
					<p>
		Country:
						<asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
			
					</p>
	
					<p>
		Fax:
						<asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Customer" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.CustomerDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

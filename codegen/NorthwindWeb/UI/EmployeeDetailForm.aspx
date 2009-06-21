<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.EmployeeDetailForm" MasterPageFile="~/Site.Master" %>
		
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Employee</legend>
	
					<p>
		EmployeeID:
						<Int32Control:Int32Control ID="EmployeeIDControl" runat="server" Value='<%# Bind("EmployeeID") %>' />
			
					</p>
	
					<p>
		LastName:
						<asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
			
					</p>
	
					<p>
		FirstName:
						<asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
			
					</p>
	
					<p>
		Title:
						<asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
			
					</p>
	
					<p>
		TitleOfCourtesy:
						<asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
			
					</p>
	
					<p>
		BirthDate:
						<DateTimeControl:DateTimeControl ID="BirthDateControl" runat="server" NullableValue='<%# Bind("BirthDate") %>' />
			
					</p>
	
					<p>
		HireDate:
						<DateTimeControl:DateTimeControl ID="HireDateControl" runat="server" NullableValue='<%# Bind("HireDate") %>' />
			
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
		HomePhone:
						<asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
			
					</p>
	
					<p>
		Extension:
						<asp:TextBox ID="ExtensionTextBox" runat="server" Text='<%# Bind("Extension") %>' />
			
					</p>
	
					<p>
		Notes:
						<asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' />
			
					</p>
	
					<p>
		PhotoPath:
						<asp:TextBox ID="PhotoPathTextBox" runat="server" Text='<%# Bind("PhotoPath") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchEmployeeForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Employee</legend>
	
					<p>
		EmployeeID:
						<Int32Control:Int32Control ID="EmployeeIDControl" runat="server" Value='<%# Bind("EmployeeID") %>' />
			
					</p>
	
					<p>
		LastName:
						<asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
			
					</p>
	
					<p>
		FirstName:
						<asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
			
					</p>
	
					<p>
		Title:
						<asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
			
					</p>
	
					<p>
		TitleOfCourtesy:
						<asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
			
					</p>
	
					<p>
		BirthDate:
						<DateTimeControl:DateTimeControl ID="BirthDateControl" runat="server" NullableValue='<%# Bind("BirthDate") %>' />
			
					</p>
	
					<p>
		HireDate:
						<DateTimeControl:DateTimeControl ID="HireDateControl" runat="server" NullableValue='<%# Bind("HireDate") %>' />
			
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
		HomePhone:
						<asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
			
					</p>
	
					<p>
		Extension:
						<asp:TextBox ID="ExtensionTextBox" runat="server" Text='<%# Bind("Extension") %>' />
			
					</p>
	
					<p>
		Notes:
						<asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' />
			
					</p>
	
					<p>
		PhotoPath:
						<asp:TextBox ID="PhotoPathTextBox" runat="server" Text='<%# Bind("PhotoPath") %>' />
			
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
				<legend>Employee Details</legend>
	
					<p>
		EmployeeID:
						<asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Bind("EmployeeID") %>' />
			
					</p>
	
					<p>
		LastName:
						<asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
			
					</p>
	
					<p>
		FirstName:
						<asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
			
					</p>
	
					<p>
		Title:
						<asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>' />
			
					</p>
	
					<p>
		TitleOfCourtesy:
						<asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
			
					</p>
	
					<p>
		BirthDate:
						<asp:Label ID="BirthDateLabel" runat="server" Text='<%# Bind("BirthDate") %>' />
			
					</p>
	
					<p>
		HireDate:
						<asp:Label ID="HireDateLabel" runat="server" Text='<%# Bind("HireDate") %>' />
			
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
		HomePhone:
						<asp:Label ID="HomePhoneLabel" runat="server" Text='<%# Bind("HomePhone") %>' />
			
					</p>
	
					<p>
		Extension:
						<asp:Label ID="ExtensionLabel" runat="server" Text='<%# Bind("Extension") %>' />
			
					</p>
	
					<p>
		Notes:
						<asp:Label ID="NotesLabel" runat="server" Text='<%# Bind("Notes") %>' />
			
					</p>
	
					<p>
		PhotoPath:
						<asp:Label ID="PhotoPathLabel" runat="server" Text='<%# Bind("PhotoPath") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Employee" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.EmployeeDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

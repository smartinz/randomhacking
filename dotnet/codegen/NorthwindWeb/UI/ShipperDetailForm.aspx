<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipperDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.ShipperDetailForm" MasterPageFile="~/Site.Master" %>
		
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Shipper</legend>
	
					<p>
		ShipperID:
						<Int32Control:Int32Control ID="ShipperIDControl" runat="server" Value='<%# Bind("ShipperID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchShipperForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Shipper</legend>
	
					<p>
		ShipperID:
						<Int32Control:Int32Control ID="ShipperIDControl" runat="server" Value='<%# Bind("ShipperID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
			
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
				<legend>Shipper Details</legend>
	
					<p>
		ShipperID:
						<asp:Label ID="ShipperIDLabel" runat="server" Text='<%# Bind("ShipperID") %>' />
			
					</p>
	
					<p>
		CompanyName:
						<asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Bind("CompanyName") %>' />
			
					</p>
	
					<p>
		Phone:
						<asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Shipper" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.ShipperDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

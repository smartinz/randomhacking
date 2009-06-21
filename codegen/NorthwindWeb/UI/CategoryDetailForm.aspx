<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDetailForm.aspx.cs" Inherits="NorthwindWeb.UI.CategoryDetailForm" MasterPageFile="~/Site.Master" %>
		
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
	<asp:FormView ID="formView" runat="server" DataSourceID="dataSource" OnItemInserted="formView_ItemInserted">
		<InsertItemTemplate>
			<fieldset>
				<legend>New Category</legend>
	
					<p>
		CategoryID:
						<Int32Control:Int32Control ID="CategoryIDControl" runat="server" Value='<%# Bind("CategoryID") %>' />
			
					</p>
	
					<p>
		CategoryName:
						<asp:TextBox ID="CategoryNameTextBox" runat="server" Text='<%# Bind("CategoryName") %>' />
			
					</p>
	
					<p>
		Description:
						<asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
					|
					<asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl="~/UI/SearchCategoryForm.aspx">Cancel</asp:HyperLink>
				</p>
			</fieldset>
		</InsertItemTemplate>
		<EditItemTemplate>
			<fieldset>
				<legend>Edit Category</legend>
	
					<p>
		CategoryID:
						<Int32Control:Int32Control ID="CategoryIDControl" runat="server" Value='<%# Bind("CategoryID") %>' />
			
					</p>
	
					<p>
		CategoryName:
						<asp:TextBox ID="CategoryNameTextBox" runat="server" Text='<%# Bind("CategoryName") %>' />
			
					</p>
	
					<p>
		Description:
						<asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
			
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
				<legend>Category Details</legend>
	
					<p>
		CategoryID:
						<asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Bind("CategoryID") %>' />
			
					</p>
	
					<p>
		CategoryName:
						<asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Bind("CategoryName") %>' />
			
					</p>
	
					<p>
		Description:
						<asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' />
			
					</p>
	
				<p>
					<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
				</p>
			</fieldset>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="dataSource" runat="server" DataObjectTypeName="NorthwindWeb.Business.Category" InsertMethod="InsertForDataSource" SelectMethod="SelectForDataSource" TypeName="NorthwindWeb.UI.CategoryDetailForm" UpdateMethod="UpdateForDataSource" />
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductReferenceControl.ascx.cs"
	Inherits="NorthwindWeb.UI.ProductReferenceControl" %>
<%@ Register Src="~/UI/SearchProductControl.ascx" TagName="SearchProductControl"
	TagPrefix="SearchProductControl" %>
<asp:HiddenField ID="idHiddenField" runat="server" />
<asp:MultiView ID="multiView" runat="server" ActiveViewIndex="0">
	<asp:View ID="descriptionView" runat="server">
		<asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Select...</asp:LinkButton>
	</asp:View>
	<asp:View ID="selectionView" runat="server">

		<script type="text/javascript">
			$(function() {
				$('#<%= selectionView.ClientID %>_dialogDiv').dialog({
					height: 300,
					width: 600,
					modal: true
				});
			});
		</script>

		<div id="<%= selectionView.ClientID %>_dialogDiv" style="overflow: auto; display: none;"
			title="Select Item">
			<SearchProductControl:SearchProductControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
			<asp:Button ID="cancelButton" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
		</div>
	</asp:View>
</asp:MultiView>

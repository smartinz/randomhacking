<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerReferenceControl.ascx.cs"
	Inherits="NorthwindWeb.UI.CustomerReferenceControl" %>
<%@ Register Src="~/UI/SearchCustomerControl.ascx" TagName="SearchCustomerControl"
	TagPrefix="SearchCustomerControl" %>
<asp:HiddenField ID="idHiddenField" runat="server" />
<asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Select...</asp:LinkButton>
<asp:Panel runat="server" ID="dialogHandlingPanel" Visible="false">
	<style type="text/css">
		.dialog
		{
			overflow: auto;
			display: none;
		}
		.dialog-serverside-buttons
		{
			display: none;
		}
	</style>

	<script type="text/javascript">
		$(function() {
			$('#<%= selectionPanel.ClientID %>').dialog({
				title: 'Select Item',
				height: 300,
				width: 600,
				modal: true,
				buttons: {
					Cancel: function() {
						eval("<%= Page.ClientScript.GetPostBackEventReference(cancelLinkButton, string.Empty) %>;");
					},
					'Select None': function() {
						eval("<%= Page.ClientScript.GetPostBackEventReference(selectNoneLinkButton, string.Empty) %>;");
					}
				},
				closeOnEscape: false,
				close: function() {
					eval("<%= Page.ClientScript.GetPostBackEventReference(cancelLinkButton, string.Empty) %>;");
				}
			});
		});
	</script>

	<asp:Panel runat="server" ID="selectionPanel" CssClass="dialog">
		<SearchCustomerControl:SearchCustomerControl ID="searchControl" runat="server" OnSelectedItemChanged="searchControl_SelectedItemChanged" />
		<%-- A simple asp:Button doesn't work with jquery UI Dialog. See http://groups.google.com/group/jquery-ui/browse_thread/thread/8791be4f5969debc?pli=1 --%>
		<asp:LinkButton ID="cancelLinkButton" runat="server" CssClass="dialog-serverside-buttons"
			OnClick="cancelLinkButton_Click" />
		<asp:LinkButton ID="selectNoneLinkButton" runat="server" CssClass="dialog-serverside-buttons"
			OnClick="selectNoneLinkButton_Click" />
	</asp:Panel>
</asp:Panel>

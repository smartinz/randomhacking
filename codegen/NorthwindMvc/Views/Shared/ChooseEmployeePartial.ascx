<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Employee>" %>
<%@ Import Namespace="NorthwindWeb.Business"%>
<%
	string dialogId = string.Format("{0}-dialog", ViewData["property"]);
	string dialogLinkId = string.Format("choose-{0}", ViewData["property"]);
	string hiddenFieldId = string.Format("{0}Id", ViewData["property"]);
%>

<script type="text/javascript">
	$(function() {
		var dialogIdString = '<%=dialogId%>';
		var dialogLinkIdString = '<%=dialogLinkId%>';
		var hiddenFieldIdString = '<%=hiddenFieldId%>';

		var dialogDivJQuery = $('<div />').attr('id', dialogIdString).attr('style', 'overflow:auto;').appendTo('body');
		dialogDivJQuery.dialog({
			title: 'Select Item',
			bgiframe: true,
			autoOpen: false,
			height: 300,
			width: 600,
			modal: true,
			buttons: {
				Cancel: function() {
					$(this).dialog('close');
				},
				'Select None': function() {
					selectItem('', 'Choose');
					$(this).dialog('close');
				}
			},
			close: function() {
			}
		});

		$('#' + dialogLinkIdString).click(function(event) {
			var dialogContentLink = $(this).attr('href');
			dialogDivJQuery.load(dialogContentLink);

			dialogDivJQuery.dialog('open');
			event.preventDefault();
		});

		$('#' + dialogIdString + ' a.item-selector').live('click', function(event) {
			var itemId = $(this).siblings('.data-id').text();
			var itemDescription = $(this).siblings('.data-description').text();
			selectItem(itemId, itemDescription);
			dialogDivJQuery.dialog('close');
			event.preventDefault();
		});

		var selectItem = function(id, description) {
			$('#' + hiddenFieldIdString).attr('value', id);
			$('#' + dialogLinkIdString).text(description);
		}
	});
</script>

<input id="<%=hiddenFieldId%>" name="<%=hiddenFieldId%>" type="hidden" value="<%=(Model == null ? "" : Model.EmployeeID.ToString())%>" />
<a id="<%=dialogLinkId%>" href="<%=Url.Action("Search", "Employee")%>">
	<%=(Model == null ? "Choose" : Model.ToString())%></a>
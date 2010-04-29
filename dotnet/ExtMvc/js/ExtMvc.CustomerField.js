"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	onTriggerClick: function () {
		var searchPanel = new ExtMvc.CustomerSearchPanel();
		var window = new Ext.Window({
			modal: true,
			title: 'Search Customer',
			width: 600,
			height: 300,
			layout: 'fit',
			items: searchPanel
		});
		searchPanel.resultGridPanel.on('rowdblclick', function (grid, rowIndex, event) {
			var customer = grid.getStore().getAt(rowIndex).data;
			this.setValue(customer.CustomerId);
			window.close();
		}, this);
		window.show();
	}
});
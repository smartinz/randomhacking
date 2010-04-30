"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	onTriggerClick: function () {
		var searchPanel = new ExtMvc.CustomerSearchPanel();
		this.window = new Ext.Window({
			modal: true,
			title: 'Search Customer',
			width: 600,
			height: 300,
			layout: 'fit',
			items: searchPanel
		});
		searchPanel.on('itemselected', this.searchPanel_itemSelected, this);
		this.window.show();
	},

	searchPanel_itemSelected: function (sender, item) {
		this.setValue(item.CustomerId);
		this.window.close();
	}
});
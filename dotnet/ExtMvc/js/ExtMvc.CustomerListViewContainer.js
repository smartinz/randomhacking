"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerListViewContainer = Ext.extend(Ext.Container, {
	layout: 'fit',
	initComponent: function () {
		this.gridPanel = new ExtMvc.CustomerGridPanel();
		this.items = this.gridPanel;

		this.addEvents('itemselected');

		this.gridPanel.on('rowdblclick', this.gridPanel_rowDblClick, this);

		ExtMvc.CustomerListViewContainer.superclass.initComponent.call(this);
	},

	gridPanel_rowDblClick: function (grid, rowIndex, event) {
		var item = grid.getStore().getAt(rowIndex).data;
		this.fireEvent('itemselected', this, item);
	},

	loadItems: function (args) {
		this.gridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.gridPanel.getBottomToolbar().pageSize
			}, args)
		});
	}
});
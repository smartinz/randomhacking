"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerSearchPanel = Ext.extend(Ext.Panel, {
	border: false,
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},
	initComponent: function () {
		this.listViewContainer = new ExtMvc.CustomerListViewContainer({
			flex: 1
		});

		this.searchFormPanel = new Ext.form.FormPanel({
			labelWidth: 100,
			border: false,
			padding: 10,
			items: [{
				name: 'companyName',
				xtype: 'textfield',
				fieldLabel: 'Company Name',
				anchor: '100%'
			}, {
				name: 'contactName',
				xtype: 'textfield',
				fieldLabel: 'Contact Name',
				anchor: '100%'
			}, {
				name: 'contactTitle',
				xtype: 'textfield',
				fieldLabel: 'Contact Title',
				anchor: '100%'
			}],
			buttons: [{
				xtype: 'button',
				text: 'Search',
				handler: this.searchClick,
				scope: this
			}]
		});

		this.items = [this.searchFormPanel, this.listViewContainer];
		ExtMvc.CustomerSearchPanel.superclass.initComponent.call(this);
	},

	searchClick: function (b, e) {
		var args = this.searchFormPanel.getForm().getFieldValues();
		this.listViewContainer.loadItems(args);
	}
});
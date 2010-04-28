"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 600,
	height: 300,
	layout: 'vbox',
	initComponent: function () {
		this.resultGridPanel = new ExtMvc.CustomerGridPanel({
			flex: 1,
			border: false
		});

		this.layoutConfig = {
			align: 'stretch',
			pack: 'start'
		};

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

		this.items = [this.searchFormPanel, this.resultGridPanel];
		ExtMvc.SearchCustomerWindow.superclass.initComponent.call(this);
	},

	searchClick: function (b, e) {
		var vals = this.searchFormPanel.getForm().getFieldValues();
		this.resultGridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.resultGridPanel.getBottomToolbar().pageSize // TODO not very good (break encapsulation)
			}, vals)
		});
	}
});
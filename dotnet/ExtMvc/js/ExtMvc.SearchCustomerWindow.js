"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 300,
	height: 300,
	layout: 'vbox',
	initComponent: function () {
		this.resultPageSize = 25;

		var resultStore = new Ext.data.Store({
			proxy: Rpc.buildDataProxy('/Customer/Find'),
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "CustomerId",
				totalProperty: 'count',
				fields: ['CustomerId', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax']
			})
		});

		this.resultGridPanel = new Ext.grid.GridPanel({
			flex: 1,
			border: false,
			store: resultStore,
			columns: [
			{
				header: "Id",
				width: 60,
				sortable: true
			},
			{
				header: "Company",
				width: 60,
				sortable: true
			},
			{
				header: "Contact name",
				width: 60,
				sortable: true
			},
			{
				header: "Contact title",
				width: 60,
				sortable: true
			},
			{
				header: "Address",
				width: 60,
				sortable: true
			},
			{
				header: "City",
				width: 60,
				sortable: true
			},
			{
				header: "Region",
				width: 60,
				sortable: true
			},
			{
				header: "Postal code",
				width: 60,
				sortable: true
			},
			{
				header: "Country",
				width: 60,
				sortable: true
			},
			{
				header: "Phone",
				width: 60,
				sortable: true
			},
			{
				header: "Fax",
				width: 60,
				sortable: true
			}
			],
			bbar: new Ext.PagingToolbar({
				store: resultStore, // grid and PagingToolbar using same store
				displayInfo: true,
				pageSize: this.resultPageSize,
				prependButtons: true
			})
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
				limit: 25
			}, vals)
		});
	}
});
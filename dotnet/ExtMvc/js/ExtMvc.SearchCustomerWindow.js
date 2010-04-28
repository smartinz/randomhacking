"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 300,
	height: 300,
	layout: 'vbox',
	initComponent: function () {
		var resultStore = new Ext.data.Store({
			proxy: Rpc.buildDataProxy('/Customer/Find'),
			remoteSort: true,
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "CustomerId",
				totalProperty: 'count',
				fields: ['CustomerId', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax']
			})
		});

		this.resultPagingToolbar = new Ext.PagingToolbar({
			store: resultStore, // grid and PagingToolbar using same store
			displayInfo: true,
			pageSize: 25,
			prependButtons: true
		});

		this.resultGridPanel = new Ext.grid.GridPanel({
			flex: 1,
			border: false,
			store: resultStore,
			colModel: new Ext.grid.ColumnModel({
				defaults: {
					width: 60,
					sortable: true
				},
				columns: [
					{ header: "Id" },
					{ header: "Company", width: 180 },
					{ header: "Contact name", width: 120 },
					{ header: "Contact title", width: 120 },
					{ header: "Address", width: 120 },
					{ header: "City" },
					{ header: "Region" },
					{ header: "Postal code" },
					{ header: "Country" },
					{ header: "Phone", width: 120 },
					{ header: "Fax", width: 120 }
				]
			}),
			bbar: this.resultPagingToolbar
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
				limit: this.resultPagingToolbar.pageSize
			}, vals)
		});
	}
});
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.store = new Ext.data.Store({
			proxy: new Rpc.JsonPostHttpProxy({
				url: '/Customer/Find'
			}),
			remoteSort: true,
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "CustomerId",
				totalProperty: 'count',
				fields: ['CustomerId', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax']
			})
		});

		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [
				{ dataIndex: 'CustomerId', header: "Id" },
				{ dataIndex: 'CompanyName', header: "Company", width: 180 },
				{ dataIndex: 'ContactName', header: "Contact name", width: 120 },
				{ dataIndex: 'ContactTitle', header: "Contact title", width: 120 },
				{ dataIndex: 'Address', header: "Address", width: 120 },
				{ dataIndex: 'City', header: "City" },
				{ dataIndex: 'Region', header: "Region" },
				{ dataIndex: 'PostalCode', header: "Postal code" },
				{ dataIndex: 'Country', header: "Country" },
				{ dataIndex: 'Phone', header: "Phone", width: 120 },
				{ dataIndex: 'Fax', header: "Fax", width: 120 }
			]
		});

		this.bbar = new Ext.PagingToolbar({
			store: this.store,
			displayInfo: true,
			pageSize: 25,
			prependButtons: true
		});

		ExtMvc.CustomerGridPanel.superclass.initComponent.call(this);
	}
});
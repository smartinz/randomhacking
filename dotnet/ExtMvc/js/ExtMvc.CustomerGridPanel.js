/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
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
		ExtMvc.CustomerGridPanel.superclass.initComponent.call(this);
	}
});
/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SupplierGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'SupplierId', header: 'SupplierId' }
								, 
								{ dataIndex: 'CompanyName', header: 'CompanyName' }
								, 
								{ dataIndex: 'ContactName', header: 'ContactName' }
								, 
								{ dataIndex: 'ContactTitle', header: 'ContactTitle' }
								, 
								{ dataIndex: 'Address', header: 'Address' }
								, 
								{ dataIndex: 'City', header: 'City' }
								, 
								{ dataIndex: 'Region', header: 'Region' }
								, 
								{ dataIndex: 'PostalCode', header: 'PostalCode' }
								, 
								{ dataIndex: 'Country', header: 'Country' }
								, 
								{ dataIndex: 'Phone', header: 'Phone' }
								, 
								{ dataIndex: 'Fax', header: 'Fax' }
								, 
								{ dataIndex: 'HomePage', header: 'HomePage' }
								
			]
		});
		ExtMvc.SupplierGridPanel.superclass.initComponent.call(this);
	}
});
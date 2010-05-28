/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.ProductGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'ProductId', header: 'ProductId' }
								, 
								{ dataIndex: 'ProductName', header: 'ProductName' }
								, 
								{ dataIndex: 'QuantityPerUnit', header: 'QuantityPerUnit' }
								, 
								{ dataIndex: 'UnitPrice', header: 'UnitPrice' }
								, 
								{ dataIndex: 'UnitsInStock', header: 'UnitsInStock' }
								, 
								{ dataIndex: 'UnitsOnOrder', header: 'UnitsOnOrder' }
								, 
								{ dataIndex: 'ReorderLevel', header: 'ReorderLevel' }
								, 
								{ dataIndex: 'Discontinued', header: 'Discontinued' }
								, 
								{ dataIndex: 'Category', header: 'Category' }
								, 
								{ dataIndex: 'Supplier', header: 'Supplier' }
								
			]
		});
		ExtMvc.ProductGridPanel.superclass.initComponent.call(this);
	}
});
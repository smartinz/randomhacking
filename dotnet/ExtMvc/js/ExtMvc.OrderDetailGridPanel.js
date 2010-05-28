/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderDetailGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'OrderId', header: 'OrderId' }
								, 
								{ dataIndex: 'ProductId', header: 'ProductId' }
								, 
								{ dataIndex: 'UnitPrice', header: 'UnitPrice' }
								, 
								{ dataIndex: 'Quantity', header: 'Quantity' }
								, 
								{ dataIndex: 'Discount', header: 'Discount' }
								
			]
		});
		ExtMvc.OrderDetailGridPanel.superclass.initComponent.call(this);
	}
});
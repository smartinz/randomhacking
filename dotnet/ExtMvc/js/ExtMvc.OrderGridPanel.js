/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'OrderId', header: 'OrderId' }
								, 
								{ dataIndex: 'OrderDate', header: 'OrderDate' }
								, 
								{ dataIndex: 'RequiredDate', header: 'RequiredDate' }
								, 
								{ dataIndex: 'ShippedDate', header: 'ShippedDate' }
								, 
								{ dataIndex: 'Freight', header: 'Freight' }
								, 
								{ dataIndex: 'ShipName', header: 'ShipName' }
								, 
								{ dataIndex: 'ShipAddress', header: 'ShipAddress' }
								, 
								{ dataIndex: 'ShipCity', header: 'ShipCity' }
								, 
								{ dataIndex: 'ShipRegion', header: 'ShipRegion' }
								, 
								{ dataIndex: 'ShipPostalCode', header: 'ShipPostalCode' }
								, 
								{ dataIndex: 'ShipCountry', header: 'ShipCountry' }
								, 
								{ dataIndex: 'Customer', header: 'Customer' }
								, 
								{ dataIndex: 'Employee', header: 'Employee' }
								, 
								{ dataIndex: 'Shipper', header: 'Shipper' }
								
			]
		});
		ExtMvc.OrderGridPanel.superclass.initComponent.call(this);
	}
});
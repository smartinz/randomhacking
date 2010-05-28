/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.TerritoryGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'TerritoryId', header: 'TerritoryId' }
								, 
								{ dataIndex: 'TerritoryDescription', header: 'TerritoryDescription' }
								, 
								{ dataIndex: 'Region', header: 'Region' }
								
			]
		});
		ExtMvc.TerritoryGridPanel.superclass.initComponent.call(this);
	}
});
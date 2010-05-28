/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CategoryGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'CategoryId', header: 'CategoryId' }
								, 
								{ dataIndex: 'CategoryName', header: 'CategoryName' }
								, 
								{ dataIndex: 'Description', header: 'Description' }
								, 
								{ dataIndex: 'Picture', header: 'Picture' }
								
			]
		});
		ExtMvc.CategoryGridPanel.superclass.initComponent.call(this);
	}
});
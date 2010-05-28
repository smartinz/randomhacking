/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SysdiagramGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'Name', header: 'Name' }
								, 
								{ dataIndex: 'PrincipalId', header: 'PrincipalId' }
								, 
								{ dataIndex: 'DiagramId', header: 'DiagramId' }
								, 
								{ dataIndex: 'Version', header: 'Version' }
								, 
								{ dataIndex: 'Definition', header: 'Definition' }
								
			]
		});
		ExtMvc.SysdiagramGridPanel.superclass.initComponent.call(this);
	}
});
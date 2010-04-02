"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.SearchWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 300,
	height: 300,
	layout: 'vbox',
	initComponent: function () {
		this.layoutConfig = {
			align: 'stretch',
			pack: 'start'
		};
		this.items = [{
			xtype: 'form',
			labelWidth: 75,
			layout: 'form',
			border: false,
			padding: 10,
			items: [{
				xtype: 'textfield',
				fieldLabel: 'Text Filter',
				anchor: '100%'
			},
			{
				xtype: 'button',
				text: 'MyButton'
			}]
		}/*,
		{
			xtype: 'grid',
			flex: 1,
			border: false,
			columns: [{
				xtype: 'gridcolumn',
				header: 'Column',
				sortable: true,
				resizable: true,
				width: 100,
				dataIndex: 'string'
			},
			{
				xtype: 'gridcolumn',
				header: 'Column',
				sortable: true,
				resizable: true,
				width: 100,
				dataIndex: 'string'
			},
			{
				xtype: 'gridcolumn',
				header: 'Column',
				sortable: true,
				resizable: true,
				width: 100,
				dataIndex: 'string'
			}]
		}*/];
		SpikeWcf.SearchWindow.superclass.initComponent.call(this);
	}
});
/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.ProductSearchContainer = Ext.extend(Ext.Container, {
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},
	initComponent: function () {
		var store = new Ext.data.Store({
			proxy: new Rpc.JsonPostHttpProxy({
				url: '/Product/Search'
			}),
			remoteSort: true,
			reader: new ExtMvc.ProductJsonReader()
		});
		this.gridPanel = new ExtMvc.ProductGridPanel({
			flex: 1,
			store: store,
			bbar: new Ext.PagingToolbar({
				store: store,
				displayInfo: true,
				pageSize: 25,
				prependButtons: true
			}),
			listeners: {
				rowdblclick: {
					fn: this.gridPanel_rowDblClick,
					scope: this
				}
			}
		});

		this.searchFormPanel = new Ext.form.FormPanel({
			labelWidth: 100,
			border: false,
			padding: 10,
			items: [{
				name: 'productId',
				xtype: 'textfield',
				fieldLabel: 'productId',
				anchor: '100%'
			}, {
				name: 'productName',
				xtype: 'textfield',
				fieldLabel: 'productName',
				anchor: '100%'
			}, {
				name: 'quantityPerUnit',
				xtype: 'textfield',
				fieldLabel: 'quantityPerUnit',
				anchor: '100%'
			}, {
				name: 'unitPrice',
				xtype: 'textfield',
				fieldLabel: 'unitPrice',
				anchor: '100%'
			}, {
				name: 'unitsInStock',
				xtype: 'textfield',
				fieldLabel: 'unitsInStock',
				anchor: '100%'
			}, {
				name: 'unitsOnOrder',
				xtype: 'textfield',
				fieldLabel: 'unitsOnOrder',
				anchor: '100%'
			}, {
				name: 'reorderLevel',
				xtype: 'textfield',
				fieldLabel: 'reorderLevel',
				anchor: '100%'
			}, {
				name: 'discontinued',
				xtype: 'textfield',
				fieldLabel: 'discontinued',
				anchor: '100%'
			}],
			buttons: [{
				xtype: 'button',
				text: 'Search',
				handler: this.searchClick,
				scope: this
			}]
		});

		this.items = [this.searchFormPanel, this.gridPanel];

		this.addEvents('itemselected');

		ExtMvc.ProductSearchContainer.superclass.initComponent.call(this);
	},

	gridPanel_rowDblClick: function (grid, rowIndex, event) {
		var item = grid.getStore().getAt(rowIndex).data;
		this.fireEvent('itemselected', this, item);
	},

	searchClick: function (b, e) {
		var args = this.searchFormPanel.getForm().getFieldValues();
		this.gridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.gridPanel.getBottomToolbar().pageSize
			}, args)
		});
	}
});
/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.CustomerSearchContainer = Ext.extend(Ext.Container, {
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},
	initComponent: function () {
		var store = new Ext.data.Store({
			proxy: new Rpc.JsonPostHttpProxy({
				url: '/Customer/Search'
			}),
			remoteSort: true,
			reader: new ExtMvc.CustomerJsonReader()
		});
		this.gridPanel = new ExtMvc.CustomerGridPanel({
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
				name: 'customerId',
				xtype: 'textfield',
				fieldLabel: 'customerId',
				anchor: '100%'
			}, {
				name: 'companyName',
				xtype: 'textfield',
				fieldLabel: 'companyName',
				anchor: '100%'
			}, {
				name: 'contactName',
				xtype: 'textfield',
				fieldLabel: 'contactName',
				anchor: '100%'
			}, {
				name: 'contactTitle',
				xtype: 'textfield',
				fieldLabel: 'contactTitle',
				anchor: '100%'
			}, {
				name: 'address',
				xtype: 'textfield',
				fieldLabel: 'address',
				anchor: '100%'
			}, {
				name: 'city',
				xtype: 'textfield',
				fieldLabel: 'city',
				anchor: '100%'
			}, {
				name: 'region',
				xtype: 'textfield',
				fieldLabel: 'region',
				anchor: '100%'
			}, {
				name: 'postalCode',
				xtype: 'textfield',
				fieldLabel: 'postalCode',
				anchor: '100%'
			}, {
				name: 'country',
				xtype: 'textfield',
				fieldLabel: 'country',
				anchor: '100%'
			}, {
				name: 'phone',
				xtype: 'textfield',
				fieldLabel: 'phone',
				anchor: '100%'
			}, {
				name: 'fax',
				xtype: 'textfield',
				fieldLabel: 'fax',
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

		ExtMvc.CustomerSearchContainer.superclass.initComponent.call(this);
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
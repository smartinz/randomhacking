/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.SupplierFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},

	initComponent: function () {
		// see http://www.extjs.com/forum/showthread.php?98131
		this.items = [{
			layout: 'form',
			border: false,
			padding: 10,
			items: [
				{ name: 'StringId', xtype: 'hidden' },
				{ name: 'SupplierId', fieldLabel: 'SupplierId', xtype: 'textfield', anchor: '100%' },
				{ name: 'CompanyName', fieldLabel: 'CompanyName', xtype: 'textfield', anchor: '100%' },
				{ name: 'ContactName', fieldLabel: 'ContactName', xtype: 'textfield', anchor: '100%' },
				{ name: 'ContactTitle', fieldLabel: 'ContactTitle', xtype: 'textfield', anchor: '100%' },
				{ name: 'Address', fieldLabel: 'Address', xtype: 'textfield', anchor: '100%' },
				{ name: 'City', fieldLabel: 'City', xtype: 'textfield', anchor: '100%' },
				{ name: 'Region', fieldLabel: 'Region', xtype: 'textfield', anchor: '100%' },
				{ name: 'PostalCode', fieldLabel: 'PostalCode', xtype: 'textfield', anchor: '100%' },
				{ name: 'Country', fieldLabel: 'Country', xtype: 'textfield', anchor: '100%' },
				{ name: 'Phone', fieldLabel: 'Phone', xtype: 'textfield', anchor: '100%' },
				{ name: 'Fax', fieldLabel: 'Fax', xtype: 'textfield', anchor: '100%' },
				{ name: 'HomePage', fieldLabel: 'HomePage', xtype: 'textfield', anchor: '100%' }
			]
		}];

		this.buttons = [
			{ text: 'Save', handler: this.saveItemButtonHandler, scope: this }
		];

		ExtMvc.SupplierFormPanel.superclass.initComponent.call(this);
	},

	loadItem: function (stringId) {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: '/Supplier/Read',
			params: { stringId: stringId },
			success: function (ret) {
				this.getForm().setValues(ret.data);
			},
			callback: function () {
				this.el.unmask();
			},
			scope: this
		});
	},

	saveItemButtonHandler: function () {
		if (!this.getForm().isValid()) {
			return;
		}
		this.el.mask('Saving...', 'x-mask-loading');
		Rpc.call({
			url: '/Supplier/Update',
			params: { item: this.getForm().getFieldValues() },
			scope: this,
			success: function (result) {
				if (!result.success) {
					this.getForm().markInvalid(result.errors.item);
				}
			},
			callback: function () {
				this.el.unmask();
			}
		});
	}
});
/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.RegionFormPanel = Ext.extend(Ext.form.FormPanel, {
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
				{ name: 'RegionId', fieldLabel: 'RegionId', xtype: 'textfield', anchor: '100%' },
				{ name: 'RegionDescription', fieldLabel: 'RegionDescription', xtype: 'textfield', anchor: '100%' }
			]
		}];

		this.buttons = [
			{ text: 'Save', handler: this.saveItemButtonHandler, scope: this }
		];

		ExtMvc.RegionFormPanel.superclass.initComponent.call(this);
	},

	loadItem: function (stringId) {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: '/Region/Read',
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
			url: '/Region/Update',
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
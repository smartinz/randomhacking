/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.CategoryFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},

	initComponent: function () {
		this.buttons = [{
			text: 'Load',
			handler: this.loadClick,
			scope: this
		}, {
			text: 'Save',
			handler: this.saveClick,
			scope: this
		}];

		// see http://www.extjs.com/forum/showthread.php?98131
		this.items = [{
			layout: 'form',
			border: false,
			padding: 10,
			items: [

								{ name: 'CategoryId', fieldLabel: 'CategoryId', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'CategoryName', fieldLabel: 'CategoryName', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Description', fieldLabel: 'Description', xtype: 'textfield', anchor: '100%' }
								
			]
		}];

		ExtMvc.CategoryFormPanel.superclass.initComponent.call(this);

		this.getForm().on('actionfailed', this.actionFailedHandler, this);
	},

	loadClick: function () {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: '/Category/Read',
			params: { stringId: 'ALFKI' },
			scope: this,
			success: function (ret) {
				this.getForm().setValues(ret.data);
			},
			callback: function () {
				this.el.unmask();
			}
		});
	},

	saveClick: function () {
		if (!this.getForm().isValid()) {
			return;
		}
		this.el.mask('Saving...', 'x-mask-loading');
		Rpc.call({
			url: '/Category/Update',
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
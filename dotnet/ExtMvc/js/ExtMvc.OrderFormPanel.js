/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.OrderFormPanel = Ext.extend(Ext.form.FormPanel, {
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

								{ name: 'OrderId', fieldLabel: 'OrderId', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'OrderDate', fieldLabel: 'OrderDate', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'RequiredDate', fieldLabel: 'RequiredDate', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShippedDate', fieldLabel: 'ShippedDate', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Freight', fieldLabel: 'Freight', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipName', fieldLabel: 'ShipName', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipAddress', fieldLabel: 'ShipAddress', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipCity', fieldLabel: 'ShipCity', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipRegion', fieldLabel: 'ShipRegion', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipPostalCode', fieldLabel: 'ShipPostalCode', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'ShipCountry', fieldLabel: 'ShipCountry', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Customer', fieldLabel: 'Customer', xtype: 'ExtMvc.CustomerField', anchor: '100%' }
								, 
								{ name: 'Employee', fieldLabel: 'Employee', xtype: 'ExtMvc.EmployeeField', anchor: '100%' }
								
			]
		}];

		ExtMvc.OrderFormPanel.superclass.initComponent.call(this);

		this.getForm().on('actionfailed', this.actionFailedHandler, this);
	},

	loadClick: function () {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: '/Order/Read',
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
			url: '/Order/Update',
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
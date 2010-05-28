/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.EmployeeFormPanel = Ext.extend(Ext.form.FormPanel, {
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

								{ name: 'EmployeeId', fieldLabel: 'EmployeeId', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'LastName', fieldLabel: 'LastName', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'FirstName', fieldLabel: 'FirstName', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Title', fieldLabel: 'Title', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'TitleOfCourtesy', fieldLabel: 'TitleOfCourtesy', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'BirthDate', fieldLabel: 'BirthDate', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'HireDate', fieldLabel: 'HireDate', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Address', fieldLabel: 'Address', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'City', fieldLabel: 'City', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Region', fieldLabel: 'Region', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'PostalCode', fieldLabel: 'PostalCode', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Country', fieldLabel: 'Country', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'HomePhone', fieldLabel: 'HomePhone', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Extension', fieldLabel: 'Extension', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'Notes', fieldLabel: 'Notes', xtype: 'textfield', anchor: '100%' }
								, 
								{ name: 'PhotoPath', fieldLabel: 'PhotoPath', xtype: 'textfield', anchor: '100%' }
								
			]
		}];

		ExtMvc.EmployeeFormPanel.superclass.initComponent.call(this);

		this.getForm().on('actionfailed', this.actionFailedHandler, this);
	},

	loadClick: function () {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: '/Employee/Read',
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
			url: '/Employee/Update',
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
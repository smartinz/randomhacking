/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";
Ext.namespace('ExtMvc');

ExtMvc.ShipperField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	onTriggerClick: function () {
		var searchPanel = new ExtMvc.ShipperNormalSearchContainer({
			listeners: {
				itemselected: this.searchPanel_itemSelected,
				scope: this
			}
		});
		this.window = this.window || new Ext.Window({
			modal: true,
			title: 'Search Shipper',
			width: 600,
			height: 300,
			layout: 'fit',
			items: searchPanel,
			closeAction: 'hide',
			buttons: [
				{ text: 'Select None', handler: this.selectNoneButton_click, scope: this },
				{ text: 'Select', handler: this.selectButton_click, scope: this },
				{ text: 'Cancel', handler: this.cancelButton_click, scope: this }
			]
		});
		this.window.show();
	},

	searchPanel_itemSelected: function (sender, item) {
		this.setValue(item);
		this.window.hide();
	},

	selectButton_click: function (button, event) {
		var item = searchPanel.getSelectedItem();
		this.setValue(item);
		this.window.hide();
	},

	selectNoneButton_click: function (button, event) {
		this.setValue(null);
		this.window.hide();
	},

	setValue: function (v) {
		this.selectedItem = v;
		return ExtMvc.ShipperField.superclass.setValue.call(this, ExtMvc.Shipper.getDescription(v));
	},

	cancelButton_click: function (button, event) {
		this.window.hide();
	},

	getValue: function () {
		return this.selectedItem;
	}
});

Ext.reg('ExtMvc.ShipperField', ExtMvc.ShipperField);
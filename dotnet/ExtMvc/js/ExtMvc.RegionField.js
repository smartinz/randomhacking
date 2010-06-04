/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";
Ext.namespace('ExtMvc');

ExtMvc.RegionField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	onTriggerClick: function () {
		var searchPanel = new ExtMvc.RegionNormalSearchContainer({
			listeners: {
				itemselected: this.searchPanel_itemSelected,
				scope: this
			}
		});
		this.window = this.window || new Ext.Window({
			modal: true,
			title: 'Search Region',
			width: 600,
			height: 300,
			layout: 'fit',
			items: searchPanel
		});
		this.window.show();
	},

	searchPanel_itemSelected: function (sender, item) {
		this.setValue(item);
		this.window.hide();
	},

	setValue: function (v) {
		this.selectedItem = v;
		return ExtMvc.RegionField.superclass.setValue.call(this, ExtMvc.Region.getDescription(v));
	},

	getValue: function () {
		return this.selectedItem;
	}
});

Ext.reg('ExtMvc.RegionField', ExtMvc.RegionField);
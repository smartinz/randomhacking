/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc, Rpc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderListField = Ext.extend(Ext.form.Field, {
	initComponent: function () {
		var cfg = Ext.copyTo({
			id: this.id + '-gridpanel'
		}, this.initialConfig, []);
		this.gridPanel = new ExtMvc.OrderGridPanel({
			store: new Ext.data.Store({
				proxy: new Ext.data.MemoryProxy({ items: [] }),
				remoteSort: false,
				reader: new ExtMvc.OrderJsonReader()
			})
		});
		ExtMvc.OrderListField.superclass.initComponent.call(this);
	},

	onRender: function (ct, position) {
		this.autoCreate = {
			id: this.id,
			name: this.name,
			type: 'hidden',
			tag: 'input'
		};
		ExtMvc.OrderListField.superclass.onRender.call(this, ct, position);
		this.wrap = this.el.wrap({ cls: 'x-form-field-wrap' });
		this.resizeEl = this.positionEl = this.wrap;
		this.gridPanel.render(this.wrap);
	},

	onResize: function (w, h, aw, ah) {
		ExtMvc.OrderListField.superclass.onResize.call(this, w, h, aw, ah);
		this.gridPanel.setSize(w, h);
	},

	onEnable: function () {
		ExtMvc.OrderListField.superclass.onEnable.call(this);
		this.gridPanel.enable();
	},

	onDisable: function () {
		ExtMvc.OrderListField.superclass.onDisable.call(this);
		this.gridPanel.disable();
	},

	beforeDestroy: function () {
		Ext.destroy(this.gridPanel);
		ExtMvc.OrderListField.superclass.beforeDestroy.call(this);
	},

	setValue: function (v) {
		this.gridPanel.getStore().proxy.data.items = v;
		this.gridPanel.getStore().load();
		return ExtMvc.OrderListField.superclass.setValue.call(this, v);
	},

	getValue: function () {
		return this.gridPanel.getStore().proxy.data.items;
	}
});
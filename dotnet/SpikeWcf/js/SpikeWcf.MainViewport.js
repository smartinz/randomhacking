"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'fit',
	hideBorders: true,
	initComponent: function () {
		this.items = [{
			xtype: 'panel',
			tbar: {
				xtype: 'toolbar',
				items: [{
					xtype: 'button',
					text: 'Grid',
					handler: this.gridButtonClick,
					scope: this
				}]
			}
		}];
		SpikeWcf.MainViewport.superclass.initComponent.call(this);
	},
	
	gridButtonClick: function () {
		var window = new SpikeWcf.SearchCustomerWindow();
		window.show();
	}
});
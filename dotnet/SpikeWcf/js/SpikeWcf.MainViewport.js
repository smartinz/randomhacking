﻿"use strict";
Ext.namespace("SpikeWcf");

SpikeWcf.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'fit',
	hideBorders: true,
	initComponent: function() {
		this.items = [
            {
            	xtype: 'panel',
            	tbar: {
            		xtype: 'toolbar',
            		items: [
                        {
                        	xtype: 'button',
                        	text: 'Grid'
                        }
                    ]
            	}
            }
        ];
		SpikeWcf.MainViewport.superclass.initComponent.call(this);
	}
});

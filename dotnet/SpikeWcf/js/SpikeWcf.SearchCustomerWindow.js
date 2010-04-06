"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 300,
	height: 300,
	layout: 'vbox',
	initComponent: function () {
		this.resultGridPanel = new Ext.grid.GridPanel({
			flex: 1,
			border: false,
			store: new Ext.data.Store({
				proxy: Wcf.buildDataProxy('/RootEntityService.svc/GetAll', { 
					rootEntity: { StringId: "3", Name: 'Root entity from javascript', "DetailEntities": [], "ExternalEntity": { StringId: "5", Description: "external entity 5" } } 
				}),
				reader: new Ext.data.JsonReader({
					root: 'items',
					idProperty: "StringId",
					fields: [
						{ name: 'StringId', type: 'string', mapping: 'StringId' },
						{ name: 'Name', type: 'string', mapping: 'Name' }
					]
				})
			}),
			columns: [
				{ header: "String id", width: 60, sortable: true },
				{ header: "Name", width: 150, sortable: true }
			]
		});
		
		this.layoutConfig = {
			align: 'stretch',
			pack: 'start'
		};
		
		this.items = [{
			xtype: 'form',
			labelWidth: 75,
			layout: 'form',
			border: false,
			padding: 10,
			items: [{
				xtype: 'textfield',
				fieldLabel: 'Text Filter',
				anchor: '100%'
			},
			{
				xtype: 'button',
				text: 'Search',
				handler: this.searchClick,
				scope: this
			}]
		}, this.resultGridPanel];
		SpikeWcf.SearchCustomerWindow.superclass.initComponent.call(this);
	},
	
	searchClick: function(b, e) {
		this.resultGridPanel.getStore().load();
	}
});
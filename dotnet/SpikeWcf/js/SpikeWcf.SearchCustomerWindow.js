"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Grid',
	width: 300,
	height: 300,
	layout: 'vbox',
	initComponent: function() {
		this.resultPageSize = 25;
		
		var resultStore = new Ext.data.Store({
			proxy: Wcf.buildDataProxy('/CustomerService.svc/Find'),
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "customerId",
				totalProperty: 'count',
				fields: ['customerId', 'companyName', 'contactName', 'contactTitle', 'address', 'city', 'region', 'postalCode', 'country', 'phone', 'fax']
			})
		});
		
		this.resultGridPanel = new Ext.grid.GridPanel({
			flex: 1,
			border: false,
			store: resultStore,
			columns: [
				{ header: "Id", width: 60, sortable: true },
				{ header: "Company", width: 60, sortable: true },
				{ header: "Contact name", width: 60, sortable: true },
				{ header: "Contact title", width: 60, sortable: true },
				{ header: "Address", width: 60, sortable: true },
				{ header: "City", width: 60, sortable: true },
				{ header: "Region", width: 60, sortable: true },
				{ header: "Postal code", width: 60, sortable: true },
				{ header: "Country", width: 60, sortable: true },
				{ header: "Phone", width: 60, sortable: true },
				{ header: "Fax", width: 60, sortable: true }
			],
			bbar: new Ext.PagingToolbar({
				store: resultStore, // grid and PagingToolbar using same store
				displayInfo: true,
				pageSize: this.resultPageSize,
				prependButtons: true
			})
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
			}]}, this.resultGridPanel];
			SpikeWcf.SearchCustomerWindow.superclass.initComponent.call(this);
		},

		searchClick: function(b, e) {
			this.resultGridPanel.getStore().load({params:{start:0, limit:25}});
		}
	});
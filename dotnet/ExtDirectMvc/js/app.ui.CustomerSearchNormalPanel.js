Ext.namespace('app.ui');

app.ui.CustomerSearchNormalPanel = Ext.extend(Ext.Panel, {
	constructor: function(config){
		this.customerName = new Ext.form.TextField({
			fieldLabel: 'Customer name'
		});

		this.searchButtonHandler = function(){
			Ext.Msg.alert('Search');
		};

		config = Ext.apply({
			title: 'Search Customer Normal',
			layout: {
				type: 'vbox',
				pack: 'start',
				align: 'stretch'
			},
			items: [{
				title: 'Search parameters',
				xtype: 'panel',
				layout: 'form',
				items: [
				this.customerName
				],
				buttons: [{
					text: 'Search',
					handler: this.searchButtonHandler,
					scope: this
				}
				]
			}]
		}, config);
		
		app.ui.CustomerSearchNormalPanel.superclass.constructor.call(this, config);
	}
});
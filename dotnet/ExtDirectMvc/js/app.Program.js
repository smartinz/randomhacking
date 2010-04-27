Ext.namespace('app');

app.Program = Ext.extend(Object, {
	newTab: function() {
		this.tabPanel.add({
			title: 'New Tab',
			closable: true,
			html: '<p>New Tab</p>'
		})
	},

	showMsg: function(btn) {
		Ext.Msg.alert('Click', btn.text);
	},

	findCustomer: function(btn) {
		var that = this;
		Home.Find('Maria Anders', function(result, response) {
			that.currentCustomer = result[0];
			alert('ok');
		});
	},

	updateCustomer: function(btn) {
		Home.Update(this.currentCustomer, function(result, response) {
			alert('ok');
		});
	},

	debugWindow: function(btn) {
		var window = new Ext.Window({
			title: 'Debug Window',
			width: 300,
			height: 300,
			layout: 'fit',
			items: new app.ui.CustomerSearchNormalPanel()
		});
		window.show();
	},

	main: function() {
		this.tabPanel = new Ext.TabPanel({
			flex: 1,
			activeTab: 0,
			border: false,
			items: [{
				title: 'Tab 1',
				html: '<p>Center</p>'
			}, {
				title: 'Tab 2',
				closable: true,
				html: '<p>Center2</p>'
			}]
		});

		this.viewport = new Ext.Viewport({
			layout: {
				type: 'vbox',
				pack: 'start',
				align: 'stretch'
			},
			items: [{
				xtype: 'toolbar',
				items: [{
					text: 'File',
					menu: {
						xtype: 'menu',
						items: [{
							text: 'New Tab',
							handler: this.newTab,
							scope: this
						}, {
							text: 'Debug Window',
							handler: this.debugWindow,
							scope: this
						}, {
							text: 'Find Customer',
							handler: this.findCustomer,
							scope: this
						}, {
							text: 'Update Customer',
							handler: this.updateCustomer,
							scope: this
						}, {
							text: 'Save',
							handler: this.showMsg,
							scope: this
						}, '-', {
							text: 'Exit',
							handler: this.showMsg,
							scope: this
						}]
					}
				}, {
					text: 'Help'
				}]
			}, this.tabPanel]
		});
	}
});

Ext.namespace('exampleApp');

exampleApp.app = function() {
	new Ext.Viewport( {
		layout : {
			type : 'vbox',
			pack : 'start',
			align : 'stretch'
		},
		items : [ {
			xtype : 'toolbar',
			items : [ {
				text : 'File',
				menu : {
					xtype : 'menu',
					items : [ {
						text : 'Open..',
						handler: exampleApp.menuClickHandler
					}, {
						text : 'Save',
						handler: exampleApp.menuClickHandler
					}, '-', {
						text : 'Exit',
						handler: exampleApp.menuClickHandler
					} ]
				}
			}, {
				text : 'Help'
			} ]
		}, {
			flex : 1,
			xtype : 'tabpanel',
			activeTab : 0,
			border : false,
			items : [ {
				title : 'Tab 1',
				html : '<p>Center</p>'
			}, {
				title : 'Tab 2',
				closable : true,
				html : '<p>Center2</p>'
			} ]
		} ]
	});
};

exampleApp.menuClickHandler = function(btn){
	Ext.Msg.alert('Click', btn.text);
}

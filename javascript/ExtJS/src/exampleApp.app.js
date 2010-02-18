Ext.namespace('exampleApp');

exampleApp.app = function() {
	var viewport;
	var tabPanel;

	var newTab = function(btn) {
		tabPanel.add( {
			title : 'New Tab',
			closable : true,
			html : '<p>New Tab</p>'
		});
	};

	var showMsg = function(btn) {
		Ext.Msg.alert('Click', btn.text);
	};

	return {
		init : function() {
			tabPanel = new Ext.TabPanel( {
				flex : 1,
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
			});

			viewport = new Ext.Viewport( {
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
								text : 'New Tab',
								handler : newTab
							}, {
								text : 'Open..',
								handler : showMsg
							}, {
								text : 'Save',
								handler : showMsg
							}, '-', {
								text : 'Exit',
								handler : showMsg
							} ]
						}
					}, {
						text : 'Help'
					} ]
				}, tabPanel ]
			});
		}
	};
}();


Ext.namespace('exampleApp');

exampleApp.app = function() {
	new Ext.Viewport({
		layout: 'border',
		items: [{
			region: 'north',
			height: 200,
			border: false,
			split: true,
			items: [
				new Ext.Panel({title: 'P 1'}),
				new Ext.Panel({title: 'P 2'}),
			]
		}, {
			region: 'west',
			width: 200,
			html: '<p>West</p>',
			border: false,
			split: true,
		}, {
			region: 'south',
			height: 200,
			html: '<p>South</p>',
			border: false,
			split: true,
		}, {
			region: 'east',
			width: 200,
			html: '<p>East</p>',
			border: false,
			split: true,
		}, {
			region: 'center',
			html: '<p>Center</p>',
			border: false,
			split: true,
		}]
	});
};


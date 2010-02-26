Ext.namespace('extMvc');

extMvc.Window = function(modal) {
	this.window = new Ext.Window({
        title: 'A Window',
        modal: modal,
//        width: 500,
//        height: 300,
//        minWidth: 300,
//        minHeight: 200,
//        layout: 'fit',
//        plain: true,
//        bodyStyle: 'padding:5px;',
//        buttonAlign: 'center',
        html: '<p>Window content</p>',
        buttons: [{
            text: 'Send'
        },{
            text: 'Cancel'
        }]
    });
};

extMvc.Window.prototype.show = function() {
	this.window.show();
};
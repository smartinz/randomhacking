Rpc = {
	call: function (url, params, callback) {
		var reviver = function (key, value) {
			if (typeof value === 'string') {
				var re = new RegExp('\\/Date\\(([-+])?(\\d+)(?:[+-]\\d{4})?\\)\\/');
				var r = value.match(re);
				if (r) {
					return new Date(((r[1] || '') + r[2]) * 1);
				}
			}
			return value;
		};

		Ext.Ajax.request({
			url: url,
			method: 'POST',
			jsonData: JSON.stringify(params),
			callback: function (options, success, response) {
				var isJson = (response.getResponseHeader('content-type') || '').toLowerCase().indexOf('application/json') != -1;
				var ret = isJson ? JSON.parse(response.responseText, reviver) : null;
				callback(success, ret);
			}
		});
	},

	buildDataProxy: function (url) {
		var proxy = new JsonPostHttpProxy({
			// Same parameters as Ext.Ajax.request
			url: url,
			method: 'POST'
		});
		return proxy;
	}
};

JsonPostHttpProxy = Ext.extend(Ext.data.HttpProxy, {
	doRequest: function (action, rs, params, reader, cb, scope, arg) {
		JsonPostHttpProxy.superclass.doRequest.call(this, action, rs, { jsonData: params }, reader, cb, scope, arg);
	}
});

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
				var ret = JSON.parse(response.responseText, reviver);
				callback(success, ret);
			}
		});
	}
};
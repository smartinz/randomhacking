Rpc = {
	msDatesReviver: function (key, value) {
		if (typeof value === 'string') {
			var re = new RegExp('\\/Date\\(([-+])?(\\d+)(?:[+-]\\d{4})?\\)\\/');
			var r = value.match(re);
			if (r) {
				return new Date(((r[1] || '') + r[2]) * 1);
			}
		}
		return value;
	},

	call: function (url, data, callback) {
		$.ajax({
			type: 'POST',
			url: url,
			contentType: "application/json",
			processData: false,
			data: JSON.stringify(data),
			dataType: 'json',
			dataFilter: function(data, type) {
				return JSON.parse(data, Rpc.msDatesReviver);
			},
			success: function (data, textStatus, xmlHttpRequest) {
				callback(true, data);
			},
			error: function (xmlHttpRequest, textStatus, errorThrown) {
				callback(false);
			}
		});
	}
};

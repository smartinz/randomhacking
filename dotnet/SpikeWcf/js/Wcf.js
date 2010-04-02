﻿"use strict";

Ext.namespace('Wcf');

Wcf.init = function() {
	Ext.util.JSON.encodeDate = function(d) {
		// This is for serialize Date in JSON the same way as WCF
		// http://www.extjs.com/forum/archive/index.php/t-31599.html
		// http://www.extjs.com/deploy/dev/docs/?class=Ext.util.JSON&member=encodeDate
		// http://www.extjs.com/deploy/dev/docs/?class=Date&member=format
		return '"' + d.format('M$') + '"';
	};
};

Wcf.invoke = function(url, params, success) {
	Ext.Ajax.request({
		url: url,
		method: 'POST',
		jsonData: params,
		success: function(response, options) {
			var ret = Wcf.jsonDecode(response.responseText);
			success(ret);
		},
		failure: function(response, options) {
			alert('ko');
		}
	});
};

Wcf.jsonDecode = function(json) {
	var adjustedJson = json.replace(new RegExp('(^|[^\\\\])\\"\\\\/Date\\((-?[0-9]+)(?:[a-zA-Z]|(?:\\+|-)[0-9]{4})?\\)\\\\/\\"', 'g'), "$1new Date($2)");
	return Ext.util.JSON.decode(adjustedJson);
};

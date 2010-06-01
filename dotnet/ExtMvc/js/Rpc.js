/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc: true */
"use strict";

Rpc = {
	call: function (opts) {
		var reviver = function (key, value) {
			if (typeof value === 'string') {
				var re, r;
				re = new RegExp('\\/Date\\(([-+])?(\\d+)(?:[+-]\\d{4})?\\)\\/');
				r = value.match(re);
				if (r) {
					return new Date(((r[1] || '') + r[2]) * 1);
				}
			}
			return value;
		};

		opts = Ext.apply({
			params: {},
			success: Ext.emptyFn,
			failure: function () {
				alert('Error occured while trying to interact with the server.');
			},
			callback: Ext.emptyFn,
			scope: this
		}, opts);

		Ext.Ajax.request({
			url: opts.url,
			method: 'POST',
			jsonData: JSON.stringify(opts.params),
			success: function (response, options) {
				var isJson = (response.getResponseHeader('content-type') || '').toLowerCase().indexOf('application/json') !== -1;
				opts.success.call(opts.scope, isJson ? JSON.parse(response.responseText, reviver) : null);
			},
			failure: function (response, options) {
				opts.failure.call(opts.scope);
			},
			callback: function (options, success, response) {
				opts.callback.call(opts.scope);
			}
		});
	},

	JsonPostHttpProxy: Ext.extend(Ext.data.HttpProxy, {
		method: 'POST',
		doRequest: function (action, rs, params, reader, cb, scope, arg) {
			params = {
				jsonData: JSON.stringify(params)
			};
			Rpc.JsonPostHttpProxy.superclass.doRequest.call(this, action, rs, params, reader, cb, scope, arg);
		}
	}),

	/*
	// TODO Work in progress
	JsonReader: Ext.extend(Ext.data.JsonReader, {
		read: function (response) {
			var json = response.responseText;
			var o = Ext.decode(json);
			if (!o) {
				throw { message: 'JsonReader.read: Json object not found' };
			}
			return this.readRecords(o);
		}
	})
	*/
};


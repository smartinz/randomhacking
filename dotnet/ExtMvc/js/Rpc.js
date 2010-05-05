/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc: true */
"use strict";

Rpc = {
	call: function (url, params, callback) {
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

		Ext.Ajax.request({
			url: url,
			method: 'POST',
			jsonData: JSON.stringify(params),
			callback: function (options, success, response) {
				var isJson, ret;
				isJson = (response.getResponseHeader('content-type') || '').toLowerCase().indexOf('application/json') !== -1;
				ret = isJson ? JSON.parse(response.responseText, reviver) : null;
				callback(success, ret);
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

	JsonLoadFormAction: Ext.extend(Ext.form.Action.Load, {
		type: 'jsonload',
		run: function () {
			Ext.Ajax.request(Ext.apply(this.createCallback(this.options), {
				method: this.getMethod(),
				url: this.getUrl(false),
				headers: this.options.headers,
				//params:this.getParams()
				jsonData: JSON.stringify(Ext.applyIf(this.options.params || {}, this.form.baseParams))
			}));
		}
	}),

	JsonSubmitFormAction: Ext.extend(Ext.form.Action.Submit, {
		type: 'jsonsubmit',
		run: function () {
			var o = this.options,
            method = this.getMethod(),
            isGet = method == 'GET';
			if (o.clientValidation === false || this.form.isValid()) {
				if (o.submitEmptyText === false) {
					var fields = this.form.items,
                    emptyFields = [];
					fields.each(function (f) {
						if (f.el.getValue() == f.emptyText) {
							emptyFields.push(f);
							f.el.dom.value = "";
						}
					});
				}
				Ext.Ajax.request(Ext.apply(this.createCallback(o), {
					//form: this.form.el.dom,
					url: this.getUrl(isGet),
					method: method,
					headers: o.headers,
					//params: !isGet ? this.getParams() : null,
					jsonData: JSON.stringify(Ext.apply({
						item: this.form.getFieldValues()
					}, !isGet ? Ext.applyIf(this.options.params || {}, this.form.baseParams) : {})),
					isUpload: this.form.fileUpload
				}));
				if (o.submitEmptyText === false) {
					Ext.each(emptyFields, function (f) {
						if (f.applyEmptyText) {
							f.applyEmptyText();
						}
					});
				}
			} else if (o.clientValidation !== false) { // client validation failed
				this.failureType = Ext.form.Action.CLIENT_INVALID;
				this.form.afterAction(this, false);
			}
		}
	})
};


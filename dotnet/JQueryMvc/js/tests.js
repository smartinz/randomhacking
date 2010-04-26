"use strict";
$(function () {
	module('Rpc calls handling');

	test("Should pass and return parameters as expected", function () {
		var params = {
			objectValue: {
				stringValue: 'first property value',
				objectValue: [{
					stringValue: 'inner object 1 first property value',
					objectValue: null
				},{
					stringValue: 'inner object 2 first property value',
					objectValue: null
				}]
			},
			arrayValue: ['array value 1', 'array value 2'],
			stringValue: 'string value',
			numberValue: 101,
			trueValue: true,
			falseValue: false,
			nullValue: null
		};
		expect(2);
		stop(10000);
		Rpc.call('/Home/Rpc', params, function (success, retData) {
			ok(success);
			same(retData, params);
			start();
		});
	});

	test("Should pass and return date as expected", function () {
		var params = {
			dateValue: new Date(2010, 4, 26, 11, 49, 33, 44).toJSON()
		};
		expect(2);
		stop(10000);
		Rpc.call('/Home/RpcWithDate', params, function (success, retData) {
			ok(success);
			same(retData, params);
			start();
		});
	});
});
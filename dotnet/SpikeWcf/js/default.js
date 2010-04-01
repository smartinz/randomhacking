"use strict";
Ext.BLANK_IMAGE_URL = 'extjs/resources/images/default/s.gif';
Ext.util.JSON.encodeDate = function(d) {
	// This is for serialize Date in JSON the same way as WCF
	// http://www.extjs.com/forum/archive/index.php/t-31599.html
	// http://www.extjs.com/deploy/dev/docs/?class=Ext.util.JSON&member=encodeDate
	// http://www.extjs.com/deploy/dev/docs/?class=Date&member=format
	return '"' + d.format('M$') + '"';
};

Ext.namespace('Wcf');
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

Ext.onReady(function() {
	module('Json/Wcf date handling');

	test("Should encode date as expected by Wcf", function() {
		var actualJson = Ext.util.JSON.encode({ datePar: new Date(2010, 4, 1, 11, 1, 0, 0) });
		var expectedJson = '{"datePar":"\\/Date(1272704460000)\\/"}';
		equals(actualJson, expectedJson);
	});

	test('Should decode date from Wcf', function() {
		var expectedObj = { datePar: new Date(2010, 4, 1, 11, 1, 0, 0) };
		var actualObj = Wcf.jsonDecode('{"datePar":"\\/Date(1272704460000)\\/"}');
		same(actualObj, expectedObj);
	});

	module('Wcf service invocation');

	test('Should call service with complex object as parameter and return value', function() {
		expect(1);
		stop(10000);
		Wcf.invoke('/RootEntityService.svc/GetAll', { rootEntity: { Id: 3, Name: 'Root entity from javascript'} }, function(ret) {
			same(ret, [{ "Id": 3, "Name": "Root entity from javascript" }, { "Id": 1, "Name": "Uno" }, { "Id": 2, "Name": "Due"}]);
			start();
		});
	});

	test('Simple types should be passed and returned unchanged', function() {
		var parameters = {
			stringPar: 'string par',
			intPar: 102,
			boolPar: true,
			arrayPar: ['arr par 1', 'arr par 2'],
			datePar: new Date(2010, 4, 1, 11, 1, 0, 0),
			doublePar: 3.14,
			decimalPar: 6.28,
			guidPar: 'ae8ad936-0464-4758-aaaf-b51cf0669e3a'
		};
		expect(1);
		stop(10000);
		Wcf.invoke('/RootEntityService.svc/JsonDataTypeTest', parameters, function(ret) {
			same(ret, parameters);
			start();
		});
	});
});
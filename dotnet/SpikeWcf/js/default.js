﻿"use strict";
Ext.BLANK_IMAGE_URL = 'extjs/resources/images/default/s.gif';

Ext.onReady(function() {
	Wcf.init();
	
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
		Wcf.invoke('/RootEntityService.svc/GetAll', { rootEntity: { StringId: "3", Name: 'Root entity from javascript', "DetailEntities": [], "ExternalEntity": { StringId: "5", Description: "external entity 5"}} }, function(ret) {
			same(ret, [
				{ "StringId": "3", "DetailEntities": [], "ExternalEntity": { StringId: "5", Description: "external entity 5" }, "Name": "Root entity from javascript" },
				{ "StringId": "1", "DetailEntities": [], "ExternalEntity": { StringId: "3", Description: "external entity 3" }, "Name": "Uno" },
				{ "StringId": "2", "DetailEntities": [], "ExternalEntity": { StringId: "4", Description: "external entity 4" }, "Name": "Due" }
			]);
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
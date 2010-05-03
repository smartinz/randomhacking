/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderJsonReader = Ext.extend(Ext.data.JsonReader, {
	constructor: function (meta, recordType) {
		var cfg = {
			root: 'items',
			idProperty: "OrderId",
			totalProperty: 'count',
			fields: ['OrderId', 'OrderDate', 'RequiredDate', 'ShippedDate', 'Freight', 'ShipName', 'ShipAddress', 'ShipCity', 'ShipRegion', 'ShipPostalCode', 'ShipCountry']
		};
		ExtMvc.OrderJsonReader.superclass.constructor.call(this, Ext.apply(meta || {}, cfg), recordType);
	}
});

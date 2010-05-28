/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.TerritoryJsonReader = Ext.extend(Ext.data.JsonReader, {
	constructor: function (meta, recordType) {
		var cfg = {
			root: 'items',
			idProperty: 'StringId',
			totalProperty: 'count',
			fields: ['StringId', 'TerritoryId', 'TerritoryDescription', 'Employees', 'Region']
		};
		ExtMvc.TerritoryJsonReader.superclass.constructor.call(this, Ext.apply(meta || {}, cfg), recordType);
	}
});
/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";
Ext.namespace('ExtMvc');

ExtMvc.CustomerColumn = Ext.extend(Ext.grid.Column, {
    constructor: function(cfg){
        ExtMvc.CustomerColumn.superclass.constructor.call(this, cfg);
        this.renderer = function(value, metadata, record, rowIndex, colIndex, store) {
            return value.Description;
        };
    }
});

Ext.grid.Column.types['ExtMvc.CustomerColumn'] = ExtMvc.CustomerColumn;
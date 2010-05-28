/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.EmployeeGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [

								{ dataIndex: 'EmployeeId', header: 'EmployeeId' }
								, 
								{ dataIndex: 'LastName', header: 'LastName' }
								, 
								{ dataIndex: 'FirstName', header: 'FirstName' }
								, 
								{ dataIndex: 'Title', header: 'Title' }
								, 
								{ dataIndex: 'TitleOfCourtesy', header: 'TitleOfCourtesy' }
								, 
								{ dataIndex: 'BirthDate', header: 'BirthDate' }
								, 
								{ dataIndex: 'HireDate', header: 'HireDate' }
								, 
								{ dataIndex: 'Address', header: 'Address' }
								, 
								{ dataIndex: 'City', header: 'City' }
								, 
								{ dataIndex: 'Region', header: 'Region' }
								, 
								{ dataIndex: 'PostalCode', header: 'PostalCode' }
								, 
								{ dataIndex: 'Country', header: 'Country' }
								, 
								{ dataIndex: 'HomePhone', header: 'HomePhone' }
								, 
								{ dataIndex: 'Extension', header: 'Extension' }
								, 
								{ dataIndex: 'Photo', header: 'Photo' }
								, 
								{ dataIndex: 'Notes', header: 'Notes' }
								, 
								{ dataIndex: 'PhotoPath', header: 'PhotoPath' }
								, 
								{ dataIndex: 'Employee_1', header: 'Employee_1' }
								
			]
		});
		ExtMvc.EmployeeGridPanel.superclass.initComponent.call(this);
	}
});
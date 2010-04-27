<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<link rel="stylesheet" href="http://github.com/jquery/qunit/raw/master/qunit/qunit.css"
		type="text/css" />
	<script type="text/javascript" src="http://github.com/jquery/qunit/raw/master/qunit/qunit.js"></script>
	<script type="text/javascript">
		"use strict";

		Ext.onReady(function () {
			module('Rpc calls handling');

			test("Should pass and return parameters as expected", function () {
				var params = {
					objectValue: {
						StringValue: 'first property value',
						ObjectValue: [{
							StringValue: 'inner object 1 first property value',
							ObjectValue: null
						}, {
							StringValue: 'inner object 2 first property value',
							ObjectValue: null
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
				Rpc.call('/Test/Rpc', params, function (success, retData) {
					ok(success);
					same(retData, params);
					start();
				});
			});

			test("Should pass and return date as expected", function () {
				var params = {
					dateValue: new Date(2010, 4, 26, 11, 49, 33, 44)
				};
				expect(2);
				stop(10000);
				Rpc.call('/Test/RpcWithDate', params, function (success, retData) {
					ok(success);
					same(retData, params);
					start();
				});
			});

			test("Should fail when server exception occur", function () {
				expect(1);
				stop(10000);
				Rpc.call('/Test/RpcWithDate', null, function (success, retData) {
					ok(!success);
					start();
				});
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
	<h1 id="qunit-header">
		Spike Wcf</h1>
	<h2 id="qunit-banner">
	</h2>
	<h2 id="qunit-userAgent">
	</h2>
	<ol id="qunit-tests">
	</ol>
</asp:Content>

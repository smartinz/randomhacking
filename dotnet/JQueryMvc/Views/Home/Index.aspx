<!doctype html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Home Page</title>
	<link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/ui-lightness/jquery-ui.css" type="text/css" />
	<link rel="stylesheet" href="<%=Url.Content ("~/css/ui.jqgrid.css")%>" type="text/css" />
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.js"></script>
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.js"></script>
	<script type="text/javascript" src="<%=Url.Content ("~/js/i18n/grid.locale-en.js")%>"></script>
	<script type="text/javascript" src="<%=Url.Content ("~/js/jquery.jqGrid.min.js")%>"></script>
	<script type="text/javascript" src="<%=Url.Content ("~/js/Rpc.js")%>"></script>
	<script type="text/javascript">
		$(function () {
			jQuery("#list").jqGrid({
				url: '/Customer/GetAll',
				datatype: 'json',
				mtype: 'GET',
				colNames: ['Inv No', 'Date', 'Amount', 'Tax', 'Total', 'Notes'],
				colModel: [
					{ name: 'invid', index: 'invid', width: 55 },
					{ name: 'invdate', index: 'invdate', width: 90 },
					{ name: 'amount', index: 'amount', width: 80, align: 'right' },
					{ name: 'tax', index: 'tax', width: 80, align: 'right' },
					{ name: 'total', index: 'total', width: 80, align: 'right' },
					{ name: 'note', index: 'note', width: 150, sortable: false }
			    ],
				pager: '#pager',
				rowNum: 10,
				rowList: [10, 20, 30],
				sortname: 'invid',
				sortorder: 'desc',
				viewrecords: true,
				caption: 'My first grid'
			});
		}); 
	</script>
</head>
<body>
	<table id="list">
	</table>
	<div id="pager">
	</div>
</body>
</html>

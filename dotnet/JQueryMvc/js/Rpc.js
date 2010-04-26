Rpc = {
	call: function (url, data, callback) {
		$.ajax({
			type: 'POST',
			url: url,
			contentType: "application/json",
			processData: false,
			data: JSON.stringify(data),
			dataType: 'json',
			success: function (data, textStatus, xmlHttpRequest) {
				callback(true, data);
			},
			error: function (xmlHttpRequest, textStatus, errorThrown) {
				callback(false);
			}
		});
	}
};

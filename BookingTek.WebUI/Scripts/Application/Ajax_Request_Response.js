AjaxRequestResponse = {
    Send: function (url, data, type, dataType, async, callback, contentType, headers) {
        $.ajax({
            contentType: contentType,
            headers: headers,
            url: url,
            data: data,
            crossDomain : true,
            async: async,
            type: type,
            dataType: dataType,
            cache: false,

            success: function (serverResponse) {
                if (typeof callback === "function")
                    callback(serverResponse);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                if (typeof callback === "function")
                    callback(xhr);
                else if (xhr.status == 401) {
                    alert('unauthorized');
                }
                else
                    alert('Error');
            }
        });

    }
};
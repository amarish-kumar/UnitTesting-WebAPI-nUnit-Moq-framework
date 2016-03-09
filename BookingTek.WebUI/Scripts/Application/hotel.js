
$(document).ready(function () {
    var form = $('#__AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
   

    $("#search_button").click(
 
        function () {
            //Api base URL
            var _url = window.ApplicationSettings.ApiURL() + "/API/Hotels/GetHotels?search_text=" + $("#search_text").val();
            $("#loading").show();
            AjaxRequestResponse.Send(_url,
                         null,
                         'Get',
                         'json',
                         true,
                         function (serverResponse) {
                             $("#loading").hide();
                             $('#results').html('');
                             $('#results').append('<tr><th>Search Results</th><td align="left"  >' + serverResponse.length + '</td></tr>');
                             for (var i = 0; i < serverResponse.length; i++) {                                 
                                 
                                
                                 $('#results').append('<tr><td>' + serverResponse[i].Hotel_Name + '</td><td>£' + serverResponse[i].Price + '</td></tr>');
                                 $('#results').append('<tr><td><img width="20px" height="20px" src="' + serverResponse[i].ImagePath + '" alt="Hotel Image" /></td><td>' + serverResponse[i].Description + '</td></tr>');
                             }
                         },
                     'application/json; charset=utf-8', null);
        }

        );


});


$(function() {


    if ($('#ddlDetails').find(":selected").text() === 'None') {
        var trs = $('#Items').html();
        sessionStorage.setItem('Items', trs);
        console.log(sessionStorage.getItem('Items'));


    }

    $('#txtSearch').autocomplete(
        {
            source: function(request, response) {

                $.ajax(
                    {
                        url: webApiUrl + 'api/Items?item=' + request.term,
                        type: 'get',
                        contentType: 'application/json',
                        dataType: 'json',
                        accepts: '*/*',
                        origin: 'http://localhost:56231',
                        success: function(data) {

                            response(data);
                        },
                        error: function(error) {
                            console.log(error);

                        }
                    }
                );


            }

        });

});


function filterItemsByMenuType() {
    var item = $('#ddlDetails').find(":selected").text();
    var searchItem = sessionStorage.getItem('txtSearchValue');
    if (item === 'None' && searchItem !== null)
    {
        window.location.pathname = '/AdminArea/Items/';
        return;
  
    }
    if (item === 'None') {
        $('#Items').html(null);
        $('#Items').append(sessionStorage.getItem('Items'));
        return;
    }
    $.ajax(
        {
            url: webApiUrl + 'api/Items?menuType=' + item,
            type: 'get',
            contentType: 'application/json',
            dataType: 'json',
            accepts: '*/*',
            origin: 'http://localhost:56231',
            success: function(response) {
                var jsonResponse = JSON.stringify(response);
                console.log(jsonResponse);
                $('#Items').html(null);
                $('#Items').append('<tr class="success"><th>MenuDetails</th><th>Name</th><th>Price</th><th></th></tr>');
                $.each($.parseJSON(jsonResponse),
                    function(index, data) {
                        console.log("Index =" + index + " Data =" + data);
                        $('#Items').append('<tr><td>' +
                            item +
                            '</td><td>' +
                            data.Name +
                            '</td><td>' +
                            data.Price +
                            '</td><td><a href="/AdminArea/Items/Edit/' +
                            data.ItemId +
                            '"> Edit</a> |<a href="/AdminArea/Items/Details/' +
                            data.ItemId +
                            '">Details</a> | <a href="/AdminArea/Items/Delete/' +
                            data.ItemId +
                            '">Delete</a></td ></tr > ');

                    });

            },
            error: function(error) {
                console.log(error);

            }

        });
}






    


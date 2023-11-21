function deleteTodo(i) 
{
    console.log(i)
    $.ajax({
        url: 'Home/Delete',
        type: 'POST',
        data: {
            id: i
        },
        success: function() {
            window.location.reload();
        }
    });
}

function populateForm(i) {

    $.ajax({
        url: 'Home/Update',
        type: 'POST',
        data: {
            id: i
        },
        dataType: 'json',
        success: function (response) {
            debugger
            $("#Todo_Name").val(response.name);
            $("#Todo_Id").val(response.id);
            $("#form-button").val("Listeyi Güncelle");
            $("#form-action").attr("action", "/Home/Update?id=" + i + "&name=" + $("#Todo_Name").val());
        }
    });
}

showInPopUp = (url, title) => {
    $.ajax({
        type: "Get",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');

        }
    })
}
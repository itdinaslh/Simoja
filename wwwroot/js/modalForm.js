function bindForm(dialog) {
    $('form', dialog).submit(function () {
        var form = $(this).closest("form");
        var formData = new FormData(form[0]);

        $.ajax({
            url: this.action,
            type: this.method,
            processData: false,
            contentType: false,
            dataType: "json",
            data: formData,
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    showSuccessMessage();
                } else if (result.invalid) {
                    showInvalidMessage();
                } else {
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}

function showSuccessMessage() {
    Swal.fire(
        {
            position: 'top-end',
            type: 'success',
            title: 'Data berhasil disimpan!',
            showConfirmButton: false,
            timer: 1000
        }).then(function () {
            loadContent();
        });
}

function showInvalidMessage() {
    $('.mod-warning').css("visibility", "visible");
}

$(document).on('shown.bs.modal', function () {
    $(this).find('[autofocus]').focus();
});

$(document).on('click', '.showMe', function () {
    $('#myModalContent').load($(this).attr('data-href'), function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});

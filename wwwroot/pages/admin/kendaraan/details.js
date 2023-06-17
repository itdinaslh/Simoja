$('#FormUpdateKendaraan').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        method: 'POST',
        data: $(this).serialize(),
        success: function (result) {
            if (result.success) {
                showSuccessMessage();
            }
        }
    });
});

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Data berhasil disimpan!',
        showConfirmButton: false,
        timer: 1000
    }).then(function () {
        /*loadContent();*/
    });
}
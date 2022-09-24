$(document).ready(function () {
    PopulateKota();

    PopulateJenis();

    var idkota = $('#cbIdKota option:selected').val();
    var idkecamatan = $('#cbIdKecamatan option:selected').val();

    loadKecamatan(idkota);
    loadKelurahan(idkecamatan);

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

function PopulateJenis() {
    $('#JenisUsaha').select2();
}

$(document).on('click', '#btnVerify', function() {
    var id = $('#theID').val();
    Swal.fire(
    {
        title: "Yakin Verifikasi?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Ya, Verifikasi!"
    }).then(function(result)
    {
        if (result.value)
        {
            $.ajax({
                url: '/admin/clients/verifikasi',
                method: 'POST',
                data: {
                    theID: id
                },
                success: function(result) {
                    if (result.success) {
                        showSuccessMessage();
                    } else {
                        alert('Data gagal disimpan');
                    }
                }
            });
        }
    });
});

$('#frmUpdate').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function (result) {
            if (result.success) {
                showSuccessMessage();
            } else {
                showFailedMessage();
            }
        }
    })
})

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Berhasil simpan data',
        showConfirmButton: false,
        timer: 1000
    });
}

function showFailedMessage() {
    Swal.fire(
        {
            position: 'top-end',            
            title: 'Gagal simpan data',
            type: 'error',
            showConfirmButton: false,
            timer: 1000
        });
}

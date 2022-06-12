$(document).ready(function() {
    PopulateJenis();

    PopulateKota();

    var idkota = $('#cbIdKota option:selected').val();
    var idkecamatan = $('#cbIdKecamatan option:selected').val();

    loadKecamatan(idkota);
    loadKelurahan(idkecamatan);

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
})

function PopulateJenis() {
    $('#comtype').select2({
        placeholder: 'Pilih jenis usaha...',
            ajax: {
                url: '/master/jasa/findjenis',
                data: function(params) {
                    return {
                        q: params.term
                    }
                },
                dataType: 'json',
                delay: 100,
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.NamaJenis,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
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

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Berhasil Diverifikasi',
        showConfirmButton: false,
        timer: 1000
    });
}

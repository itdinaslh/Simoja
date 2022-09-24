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

$('#changepass').submit(function(e) {
    e.preventDefault();
    var pass = $('#passwd').val();
    var conf = $('#passconfirm').val();

    if (pass != conf) {
        warningChangePass();
        return;
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    showSuccessMessage();
                    $('#passwd').val('');
                    $('#passconfirm').val('');
                }
            }
        })
    }

});

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Password Berhasil Diganti',
        showConfirmButton: false,
        timer: 1000
    });
}

function warningChangePass() {
    Swal.fire(
        {
            position: 'center',
            type: 'warning',
            title: 'Password & Konfirmasi Tidak Sama!',
            showConfirmButton: false,
            timer: 1000
        });
}

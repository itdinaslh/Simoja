$(document).ready(function () {
    PopulateKotaDefault();

    PopulateLokasiAngkut();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

$(document).on('load', function () {
    $('#imgadded').val('');
});

$('#locationForm').submit(function (e) {
    e.preventDefault();
    var data = $('#imgadded').val();

    if (data.length == 0) {
        alert('Harap Upload Dokumen Kontrak Kerjasama!');
    }
    else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    window.location.href = '/clients/jasa/angkutan/lokasi';
                }
            }
        });
    }
});

function PopulateLokasiAngkut() {
    $('.sLokasi').select2({
        placeholder: 'Pilih Lokasi Angkut...',        
        ajax: {
            url: '/api/master/usaha-kegiatan/kawasan/search',
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            dataType: 'json',
            delay: 100,
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.data,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}


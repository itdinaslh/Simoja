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

//$('#locationForm').submit(function (e) {
//    e.preventDefault();
//    $.ajax({
//        url: this.action,
//        method: this.method,
//        data: $(this).serialize(),
//        success: function (result) {
//            if (result.success) {
//                window.location.href = '/clients/jasa/angkutan/lokasi';
//            }
//        }
//    });
//});

function PopulateLokasiAngkut() {
    $('.sLokasi').select2({
        placeholder: 'Pilih Lokasi Angkut...',        
        ajax: {
            url: '/api/clients/usaha-kegiatan/kawasan/search',
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
    }).on('change', function () {        
        var theName = $('.sLokasi option:selected').text();
        var theID = $('.sLokasi option:selected').val();
        $.ajax({
            url: '/api/clients/usaha-kegiatan/kawasan/getbyid/?id=' + theID,
            method: 'GET',
            success: function (result) {
                $('#CityName').val(result.kota);
                $('#DistrictName').val(result.kecamatan);
                $('#KelurahanName').val(result.kelurahan);
                $('#Alamat').val(result.alamat);

                $('#LocName').val(theName);
            }
        })
    });
}


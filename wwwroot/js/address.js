$(document).ready(function() {
    PopulateKota();
})

$('#cbIdKota').on('change', function() {
    var idkec = $('#cbIdKota option:selected').val();
    $('#cbIdKecamatan').val(null).trigger('change');
    loadKecamatan(idkec);
});

$('#cbIdKecamatan').on('change', function() {
    var idkel = $('#cbIdKecamatan option:selected').val();
    $('#cbIdKelurahan').val(null).trigger('change');
    loadKelurahan(idkel);
});

function PopulateKota() {
    $('#cbIdKota').select2({
        placeholder: 'Pilih Kota / Kabupaten...',
            ajax: {
                url: '/api/address/kabupaten/search',
                contentType: "application/json; charset=utf-8",
                data: function(params) {
                    var query = {
                        term: params.term,
                    };
                    return query;
                },                
                delay: 100,
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.namaKabupaten,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
}

function loadKecamatan(theID) {
    $('#cbIdKecamatan').select2({
        placeholder: 'Pilih Kecamatan...',
        ajax: {
            url: '/api/address/kecamatan/search/?theID=' + theID,
            data: function(params) {
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
                            text: item.namaKecamatan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function loadKelurahan(theID) {
    $('#cbIdKelurahan').select2({
        placeholder: 'Pilih Kelurahan...',
        ajax: {
            url: '/api/address/kelurahan/search/?theID=' + theID,
            data: function(params) {
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
                            text: item.namaKelurahan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

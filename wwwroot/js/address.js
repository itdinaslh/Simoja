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
                url: '/master/kota/search',
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
                                text: item.NamaKota,
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
            url: '/master/kecamatan/search/' + theID,
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
                            text: item.NamaKecamatan,
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
            url: '/master/kelurahan/search/' + theID,
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
                            text: item.NamaKelurahan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

$(document).on('select2:open', () => {
    document.querySelector('.select2-search__field').focus();
});

$('#sKabupaten').select2({
    placeholder: 'Pilih Kabupaten...',
    allowClear: true
});

$('#sKecamatan').select2({
    placeholder: 'Pilih Kecamatan...',
    allowClear: true
});

$('#sKelurahan').select2({
    placeholder: 'Pilih Kelurahan...',
    allowClear: true
});

function PopulateProvinsi() {
    $('#sProvinsi').select2({
        placeholder: 'Pilih Provinsi...',
        allowClear: true,
        ajax: {
            url: "/api/address/provinsi/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
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
        $('#sKabupaten').val(null).trigger('change');
        var theID = $('#sProvinsi option:selected').val();
        PopulateKabupaten(theID);
        $('#sKabupaten').select2('focus');
    });
}

function PopulateKabupaten(provID) {
    $('#sKabupaten').select2({
        placeholder: 'Pilih Kota/Kabupaten...',
        allowClear: true,
        ajax: {
            url: "/api/address/kabupaten/search?provID=" + provID,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
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
        $('#sKecamatan').val(null).trigger('change');
        var theID = $('#sKabupaten option:selected').val();
        PopulateKecamatan(theID);
        $('#sKecamatan').select2('focus');
    });
}

function PopulateKecamatan(kab) {
    $('#sKecamatan').select2({
        placeholder: 'Pilih Kecamatan...',
        allowClear: true,
        ajax: {
            url: "/api/address/kecamatan/search?kab=" + kab,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
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
        $('#sKelurahan').val(null).trigger('change');
        var theID = $('#sKecamatan option:selected').val();
        PopulateKelurahan(theID);
        $('#sKelurahan').select2('focus');
    });
}

function PopulateKelurahan(kec) {
    $('#sKelurahan').select2({
        placeholder: 'Pilih Kelurahan...',
        allowClear: true,
        ajax: {
            url: "/api/address/kelurahan/search?kec=" + kec,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
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
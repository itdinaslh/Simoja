$(document).ready(function () {
    $('.statuslola').select2({
        placeholder: 'Pilih Status Pengelolaan...',
        ajax: {
            url: '/api/master/kawasan/status/search',
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
                            text: item.namaStatus,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });

    $('.jKegiatan').select2({
        placeholder: 'Pilih Jenis Kegiatan...',
        ajax: {
            url: '/api/master/kawasan/jenis/search',
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
});
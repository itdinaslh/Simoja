$(document).ready(function() {
    $('#cbJenisUsaha').select2({
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



    $('#jkeg').select2({
        placeholder: 'Pilih jenis Kegiaan...',
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
    $('#jkegkawasan').select2({
        placeholder: 'Pilih jenis Kegiaan...',
            ajax: {
                url: '/master/kawasan/jenis/ajaxReg',
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


    $('#statuslola').select2({
        placeholder: 'Pilih Status Pengelolaan...',
            ajax: {
                url: '/master/kawasan/status/ajaxReg',
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
                                text: item.NamaStatus,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });

    $('#pihakangkut').select2({
        placeholder: 'Pilih Pihak Pengangkutan...',
            ajax: {
                url: '/master/kawasan/pihak/ajaxReg',
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
                                text: item.NamaPihak,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });

    PopulateKota();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
})

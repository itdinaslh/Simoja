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
});

$("#fileIzin").dropzone({
    url: "/clients/upload/izin",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#IzinIsAdded').val('IzinIsAdded');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#fileNIB").dropzone({
    url: "/clients/upload/nib",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#NibIsAdded').val('NibIsAdded');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$('#clientform').submit(function(e) {
    e.preventDefault();
    $('input:text[required]').parent().show();
    var izin = $('#IzinIsAdded').val();
    var nib = $('#NibIsAdded').val();
    if (izin.length == 0) {
        alert('Harap Upload Dokumen Izin!');
    } else if (nib.length == 0) {
        alert('Harap Upload Dokumen NIB!');
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    window.location.href = '/clients/waiting';
                }
            }
        });
    }
});

$("#wadah").dropzone({
    url: "/clients/upload/wadah",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#WadahIsAdded').val('WadahIsAdded');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#tps").dropzone({
    url: "/clients/upload/tps",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#TPSIsAdded').val('TPSIsAdded');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#pengolahan").dropzone({
    url: "/clients/upload/pengolahan",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#PengolahanIsAdded').val('PengolahanIsAdded');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});
$('#clientform2').submit(function(e) {
    e.preventDefault();
    $('input:text[required]').parent().show();
    var wadah = $('#WadahIsAdded').val();
    var tps = $('#TPSIsAdded').val();
    var olah = $('#PengolahanIsAdded').val();
    if (wadah.length == 0) {
        alert('Harap Upload Dokumen Izin!');
    } else if (tps.length == 0) {
        alert('Harap Upload Dokumen NIB!');
    } else if (olah.length == 0) {
        alert('Harap Upload Dokumen NIB!');
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    window.location.href = '/clients/waiting';
                }
            }
        });
    }
});









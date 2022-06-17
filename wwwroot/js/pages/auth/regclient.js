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

    // PopulateKota();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

$("#fileIzin").dropzone({
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/izin",    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/izin').done(function (data) {
            //Call the action method to load the images from the server

            if (data!== null && data.length > 0) {

                $.each(data, function (index, item) {
                    //// Create the mock file:
                    var mockFile = {
                        name: item.name,
                        size: item.fileSize,
                        filePath: item.filePath
                    };

                    // Call the default addedfile event handler
                    myDropzone.emit("addedfile", mockFile);

                    // And optionally show the thumbnail of the file:
                    myDropzone.emit("thumbnail", mockFile, item.filePath);

                    // Make sure there is no progress bar ober tha image
                    myDropzone.emit("complete", mockFile);

                    // subtract loaded files from max files count to keep upload limit
                    //myDropzone.options.maxFiles -= 1;
                });
            }
        });
    },
    removedfile: function removedfile(file) {
        $.getJSON("/clients/dokumen/izin/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    }
});

$("#fileNIB").dropzone({
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/nib",    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/nib').done(function (data) {
            //Call the action method to load the images from the server

            if (data!== null && data.length > 0) {

                $.each(data, function (index, item) {
                    //// Create the mock file:
                    var mockFile = {
                        name: item.name,
                        size: item.fileSize,
                        filePath: item.filePath
                    };

                    // Call the default addedfile event handler
                    myDropzone.emit("addedfile", mockFile);

                    // And optionally show the thumbnail of the file:
                    myDropzone.emit("thumbnail", mockFile, item.filePath);

                    // Make sure there is no progress bar ober tha image
                    myDropzone.emit("complete", mockFile);

                    // subtract loaded files from max files count to keep upload limit
                    //myDropzone.options.maxFiles -= 1;
                });
            }
        });
    },
    removedfile: function removedfile(file) {
        $.getJSON("/clients/dokumen/nib/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
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









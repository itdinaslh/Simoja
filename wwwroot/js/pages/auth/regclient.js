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
        placeholder: 'Pilih jenis Kegiatan...',
            ajax: {
                url: '/api/master/kawasan/jenis/search',
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
                                text: item.namaKegiatan,
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
                url: '/api/master/kawasan/status/search',
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
                                text: item.namaStatus,
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
                url: '/api/master/kawasan/pihak-angkut/search',
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
                                text: item.namaPihak,
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
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/wadah",    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/wadah').done(function (data) {
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
        $.getJSON("/clients/dokumen/wadah/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    }
});

$("#tps").dropzone({
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/tps",    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/tps').done(function (data) {
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
        $.getJSON("/clients/dokumen/tps/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    }
});

$("#pengolahan").dropzone({
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/pengolahan",    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/pengolahan').done(function (data) {
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
        $.getJSON("/clients/dokumen/pengolahan/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
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









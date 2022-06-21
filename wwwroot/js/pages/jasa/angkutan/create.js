$(document).ready(function() {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom',
        autoclose: true
    });

    PopulateJenisKendaraan();

});

function PopulateJenisKendaraan() {
    $('#vehicleType').select2({
        placeholder: 'Pilih Jenis Kendaraan...',
            ajax: {
                url: '/api/master/kendaraan/jenis/search',
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
                                text: item.namaJenis,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
}

$(document).on('load', function() {
    $('#stnkadded').val('');
    $('#kiradded').val('');
    $('#fotoadded').val('');
});

$(document).on('submit', '#clientform', function(e) {
    e.preventDefault();
    // var stnkdata = $('#stnkadded').val();
    // var kirdata = $('#kiradded').val();
    // var fotodata = $('#fotoadded').val();

    // $('input:text[required]').parent().show();

    // if (stnkdata = '') {
    //     alert('Harap Upload Dokumen STNK!');
    // } else if (kirdata == '') {
    //     alert('Harap Upload Dokumen KIR!');
    // } else if (fotodata == '') {
    //     alert('Harap Upload Foto Kendaraan!');
    // } else {
    //     $.ajax({
    //         url: this.action,
    //         method: this.method,
    //         data: $(this).serialize(),
    //         success: function(result) {
    //             if (result.success) {
    //                 window.location.href = '/clients/jasa/angkutan/kendaraan';
    //             }
    //         }
    //     });
    // }

    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function(result) {
            if (result.success) {
                window.location.href = '/clients/jasa/pengangkutan/kendaraan';
            }
        }
    });
});

$("#stnk").dropzone({    
    paramName: "files",
    url: "/clients/pengangkutan/upload/stnk?id=" + $('#UID').val(),    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/stnk').done(function (data) {
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
        $.getJSON("/clients/dokumen/stnk/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    },
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#stnkadded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#kir").dropzone({    
    paramName: "files",
    url: "/clients/pengangkutan/upload/kir?id=" + $('#UID').val(),    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/kir').done(function (data) {
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
        $.getJSON("/clients/dokumen/kir/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    },
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#kiradded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#foto").dropzone({    
    paramName: "files",
    url: "/clients/pengangkutan/upload/foto-kendaraan?id=" + $('#UID').val(),    
    init: function() {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/foto-kendaraan').done(function (data) {
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
        $.getJSON("/clients/dokumen/foto-kendaraan/delete/?file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    },
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#fotoadded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});



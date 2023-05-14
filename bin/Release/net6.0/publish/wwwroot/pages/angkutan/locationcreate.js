$(document).ready(function () {
    PopulateKotaDefault();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

$(document).on('load', function () {
    $('#imgadded').val('');
});

$('#vehicleform').submit(function (e) {
    e.preventDefault();
    var data = $('#imgadded').val();

    if (data.length == 0) {
        alert('Harap Upload Dokumen Kontrak Kerjasama!');
    }
    else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    window.location.href = '/clients/jasa/angkutan/lokasi';
                }
            }
        });
    }
});

$("#upLokasi").dropzone({
    paramName: "files",
    url: "/clients/pengangkutan/upload/lokasi-angkut?id=" + $('#UID').val(),
    init: function () {
        var myDropzone = this;
        $.getJSON('/clients/dokumen/lokasi-angkut').done(function (data) {
            //Call the action method to load the images from the server

            if (data !== null && data.length > 0) {

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
        $.getJSON("/clients/dokumen/lokasi/delete/?file=" + file.name).done(function (result) {
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
        $('#imgadded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

﻿$(document).ready(function () {
    loadTable();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });    
});

$(document).on('click', '#nextBtn', function () {
    NewUID();
});

$("#fileIzin").dropzone({
    addRemoveLinks: true,
    paramName: "files",
    url: "/clients/upload/izin/?id=" + $('.myUID').val(),
    init: function () {
        //var myDropzone = this;
        //$.getJSON('/clients/dokumen/izin/?id=' + $('.myUID').val()).done(function (data) {
        //    //Call the action method to load the images from the server

        //    if (data !== null && data.length > 0) {

        //        $.each(data, function (index, item) {
        //            //// Create the mock file:
        //            var mockFile = {
        //                name: item.name,
        //                size: item.fileSize,
        //                filePath: item.filePath
        //            };

        //            // Call the default addedfile event handler
        //            myDropzone.emit("addedfile", mockFile);

        //            // And optionally show the thumbnail of the file:
        //            myDropzone.emit("thumbnail", mockFile, item.filePath);

        //            // Make sure there is no progress bar ober tha image
        //            myDropzone.emit("complete", mockFile);

        //            // subtract loaded files from max files count to keep upload limit
        //            //myDropzone.options.maxFiles -= 1;
        //        });
        //    }
        //});
    },
    removedfile: function removedfile(file) {
        $.getJSON("/clients/dokumen/izin/delete/?id=" + $('.myUID').val() + "&file=" + file.name).done(function (result) {
            console.log("delete: " + result);
            if (result === true) {
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
    }
});

$('#clientform').submit(function (e) {
    e.preventDefault();
    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function (result) {
            if (result.success) {
                loadTable();
                ClearField();
                NewUID();
                $('.dz-preview').empty();
                $('.dz-message').show();
            }
        }
    });
});

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        stateSave: true,
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/jasa/pengangkutan/izin/list',
            method: 'POST'
        },
        columns: [
            { data: 'noIzinUsaha', name: 'noIzinUsaha' },
            { data: 'jmlAngkutan', name: 'jmlAngkutan' },
            { data: 'tglAkhirIzin', name: 'tglAkhirIzin' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/jenis/edit?jenisID="
                        + row.izinAngkutId + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function ClearField() {
    $('.datainput').val('');
    $('#txtJmlAngkut').val(0);
}

function NewUID() {
    var uid = UUID.generate();

    $('.myUID').val(uid);
}
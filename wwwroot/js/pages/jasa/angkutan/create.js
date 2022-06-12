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
                url: '/kendaraan/jenis/search',
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
}

$(document).on('load', function() {
    $('#stnkadded').val('');
    $('#kiradded').val('');
    $('#fotoadded').val('');
});

// $('#clientform').submit(function(e) {
//     e.preventDefault();
//     var stnkdata = $('#docAdded').val();
//     var kirdata = $('#locAdded').val();
//     var fotodata = $('#techAdded').val();

//     // $('input:text[required]').parent().show();

//     if (stnkdata.length == 0) {
//         alert('Harap Upload Dokumen STNK!');
//     } else if (kirdata.length == 0) {
//         alert('Harap Upload Dokumen KIR!');
//     } else if (fotodata.length == 0) {
//         alert('Harap Upload Foto Kendaraan!');
//     } else {
//         $.ajax({
//             url: this.action,
//             method: this.method,
//             data: $(this).serialize(),
//             success: function(result) {
//                 if (result.success) {
//                     window.location.href = '/clients/jasa/angkutan/kendaraan';
//                 }
//             }
//         });
//     }
// });

$(document).on('submit', '#clientform', function(e) {
    e.preventDefault();
    var stnkdata = $('#stnkadded').val();
    var kirdata = $('#kiradded').val();
    var fotodata = $('#fotoadded').val();

    // $('input:text[required]').parent().show();

    if (stnkdata = '') {
        alert('Harap Upload Dokumen STNK!');
    } else if (kirdata == '') {
        alert('Harap Upload Dokumen KIR!');
    } else if (fotodata == '') {
        alert('Harap Upload Foto Kendaraan!');
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    window.location.href = '/clients/jasa/angkutan/kendaraan';
                }
            }
        });
    }
});

$("#stnk").dropzone({
    url: "/clients/jasa/angkutan/upload/stnk",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    init: function() {
        this.on("sending", function(file, xhr, formData) {
          formData.append("pathuid", $('#theUID').val());
          console.log(formData)
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
    url: "/clients/jasa/angkutan/upload/kir",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    init: function() {
        this.on("sending", function(file, xhr, formData) {
          formData.append("pathuid", $('#theUID').val());
          console.log(formData)
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
    url: "/clients/jasa/angkutan/upload/fotokendaraan",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    init: function() {
        this.on("sending", function(file, xhr, formData) {
          formData.append("pathuid", $('#theUID').val());
          console.log(formData)
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



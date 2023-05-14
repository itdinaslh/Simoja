$(document).ready(function() {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom',
        autoclose: true
    });

    $('#docAdded').val('');
    $('#techAdded').val('');

    $('#TechUsed').select2();
});

$(document).on('load', function() {
    $('#docAdded').val('');
    $('#techAdded').val('');
});

$('#clientform').submit(function(e) {
    e.preventDefault();
    var docdata = $('#docAdded').val();
    var techdata = $('#techAdded').val();

    // $('input:text[required]').parent().show();

    if (docdata.length == 0) {
        alert('Harap Upload Dokumen Izin!');
    } else if (techdata.length == 0) {
        alert('Harap Upload Foto Teknologi Yang Digunakan!');
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    window.location.href = '/clients/jasa/olah/perizinan/index';
                }
            }
        });
    }
});

$("#upDocument").dropzone({
    url: "/clients/jasa/olah/upload/perizinan/dokumen",
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
        $('#docAdded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

$("#upTech").dropzone({
    url: "/clients/jasa/olah/upload/perizinan/teknologi",
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
        $('#techAdded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

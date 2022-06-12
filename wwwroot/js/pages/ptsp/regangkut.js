$(document).ready(function() {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom',
        autoclose: true
    });

    $('#IzinIsAdded').val('');
});

$(document).on('load', function() {
    $('#IzinIsAdded').val('');
});

$(document).on('submit', '#clientform', function(e) {
    e.preventDefault();

    var izin = $('#IzinIsAdded').val();

    $('input:text[required]').parent().show();

    if (izin == '') {
        alert('Harap upload dokumen izin!');
    } else {
        $.ajax({
            url: this.action,
            method: this.method,
            data: $(this).serialize(),
            success: function(result) {
                if (result.success) {
                    window.location.href = '/ptsp/kendaraan/' + result.client;
                }
            }
        });
    }
});

$("#fileIzin").dropzone({
    url: "/ptsp/upload/izin/angkutan",
    headers: {'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')},
    init: function() {
        this.on("sending", function(file, xhr, formData) {
          formData.append("pathuid", $('#pathuid').val());
          console.log(formData)
        });
    },
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
        $('#IzinIsAdded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

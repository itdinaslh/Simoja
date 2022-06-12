$(document).ready(function() {
    PopulateKota();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

$(document).on('load', function() {
    $('#imgadded').val('');
});

$('#vehicleform').submit(function(e) {
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
            success: function(result) {
                if (result.success) {
                    window.location.href = '/clients/jasa/angkutan/lokasi';
                }
            }
        });
    }
});

$("#upLokasi").dropzone({
    url: "/clients/jasa/angkutan/upload/lokasi",
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
        $('#imgadded').val('added');
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    }
});

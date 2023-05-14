$('.datepicker').datepicker({
    format: 'dd/mm/yyyy',
    orientation: 'bottom'
});

$(document).ready(function() {
    $('.angka').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'', decimalCharacter: ','});
    $('#txtTotalMasuk').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'.', decimalCharacter: ','});
    $('#Pengurangan').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'.', decimalCharacter: ','});
    $('#Penanganan').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'.', decimalCharacter: ','});

    PopKerjasama();
});

$(document).on('keyup', '.InCall', function() {
    var totalMasuk = 0;
    $('.InCall').each(function() {
        totalMasuk += +$(this).val();
    });

    $('#txtTotalMasuk').autoNumeric('set', totalMasuk);
});

$(document).on('keyup', '.proc', function() {
    var timbulan =0;
    var total = 0;
    $('.proc').each(function() {
        total += +$(this).val();
    });
    $('.tim').each(function() {
        timbulan += +$(this).val();
    });


    $('#Pengurangan').autoNumeric('set', total/timbulan*100);
});

$(document).on('keyup', '.pen', function() {
    var timbulan =0;
    var total = 0;
    $('.pen').each(function() {
        total += +$(this).val();
    });
    $('.tim').each(function() {
        timbulan += +$(this).val();
    });


    $('#Penanganan').autoNumeric('set', total/timbulan*100);
});

$('#RepForm').submit(function(e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function(result) {
            if (result.success) {
                showSuccessMessage();
            }
        }
    })
});

function showSuccessMessage() {
    Swal.fire(
        'Sukses',
        'Berhasil Simpan Data',
        'success'
    ).then(function() {
        window.location.href = '/clients/dashboard';
    });
}


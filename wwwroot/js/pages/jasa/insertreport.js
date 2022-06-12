$('.datepicker').datepicker({
    format: 'dd/mm/yyyy',
    orientation: 'bottom'
});

$('#Terolah').find('input').attr('disabled', 'disabled');
$('#MyResidu').find('input').attr('disabled', 'disabled');

$(document).ready(function() {
    $('.angka').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'', decimalCharacter: ','});
    $('#txtTotalMasuk').autoNumeric('init', { currencySymbol:'', allowDecimalPadding: false, digitGroupSeparator:'.', decimalCharacter: ','});

    PopKerjasama();
});

$('#chkTerolah').change(function() {
    if(this.checked) {
        $('#Terolah').find('input').removeAttr('disabled');
        $('.reqolah').attr('required', 'required');
    } else {
        $('#Terolah').find('input').attr('disabled', 'disabled');
        $('.reqolah').removeAttr('required');
    }
});

$('#chkResidu').change(function() {
    if(this.checked) {
        $('#MyResidu').find('input').removeAttr('disabled');
    } else {
        $('#MyResidu').find('input').attr('disabled', 'disabled');
    }
});

$('#chkMasuk').change(function() {
    if(this.checked) {
        $('#Masuk').find('input, select').removeAttr('disabled');
        $('.reqmasuk').attr('required', 'required');
    } else {
        $('#Masuk').find('input, select').attr('disabled', 'disabled');
        $('.reqmasuk').removeAttr('required');
    }
});

$(document).on('keyup', '.InCall', function() {
    var totalMasuk = 0;
    $('.InCall').each(function() {
        totalMasuk += +$(this).val();
    });

    $('#txtTotalMasuk').autoNumeric('set', totalMasuk);
});

$(document).on('keyup', '.proc', function() {
    var total = 0;
    $('.proc').each(function() {
        total += +$(this).val();
    });

    $('#txtTotalOlah').autoNumeric('set', total);
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

function PopKerjasama() {
    $('#PartnerID').select2({
        placeholder: 'Pilih Sumber Sampah...',
            ajax: {
                url: '/clients/jasa/olah/kerjasama/populate',
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
                                text: item.NamaPerusahaan,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
}

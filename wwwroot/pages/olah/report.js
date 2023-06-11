var terurai1 = 0; ulang1 = 0; b31 = 0; residu1 = 0;
var terurai2 = 0; ulang2 = 0; residu2 = 0;


function CalculateMasuk() {
    var totalMasuk = parseInt(terurai1) + parseInt(ulang1) + parseInt(b31) + parseInt(residu1);
    var strTotal = totalMasuk.toLocaleString('id-ID');

    $('#totalMasuk').text(strTotal);
}

function CalculateOlah() {
    var residu = (parseInt(terurai1) - parseInt(terurai2)) + (parseInt(ulang1) - parseInt(ulang2));

    var strResidu = residu.toLocaleString('id-ID');
    var totalResidu = parseInt(residu1) + parseInt(residu);
    var strTotal = totalResidu.toLocaleString('id-ID');

    $('#txtResidu2').val(strResidu);
    $('#totalOlah').text(strTotal);
}

$(document).ready(function () {
    loadTable();
});

$(document).on('keyup', '#txtTerurai1', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        terurai1 = getThis;
    } else {
        terurai1 = 0;
    }

    CalculateMasuk();
});

$(document).on('keyup', '#txtB31', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        b31 = getThis;
    } else {
        b31 = 0;
    }

    CalculateMasuk();
});

$(document).on('keyup', '#txtResidu1', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        residu1 = getThis;
    } else {
        residu1 = 0;
    }

    CalculateMasuk();
});

$(document).on('keyup', '#txtUlang1', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        ulang1 = getThis;
    } else {
        ulang1 = 0;
    }

    CalculateMasuk();
});

$(document).on('keyup', '#txtTerurai2', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        terurai2 = getThis;
    } else {
        terurai2 = 0;
    }

    CalculateOlah();
});

$(document).on('keyup', '#txtUlang2', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        ulang2 = getThis;
    } else {
        ulang2 = 0;
    }

    CalculateOlah();
});

$(document).on('keyup', '#txtResidu2', function () {
    var getThis = $(this).autoNumeric('get');

    if (getThis != '') {
        residu2 = getThis;
    } else {
        residu2 = 0;
    }

    CalculateOlah();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    $('.autonumber').autoNumeric('init', { currencySymbol: '', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });

    PopulateSumber();
    PopulatePenyedia();
    /*PopulateKendaraan();*/
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblReport').DataTable({
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",

        order: [[0, "desc"]]
    });
}

function PopulateSumber() {
    $('#sSumber').select2({
        placeholder: 'Pilih Sumber Sampah...',
        dropdownParent: $('#myModal'),
    });
}
function PopulatePenyedia() {
    $('#Teknologi').select2({
        placeholder: 'Pilih Teknologi Persampahan...',
        dropdownParent: $('#myModal'),
    });
}

function ValidateKendaraan() {
    $('.FormCreate').validate({
        rules: {
            NoPolisi: "required"
        },
        messages: {
            NoPolisi: 'Isi No Polisi...'
        }
    });
}

//tambahan
$(document).on('click', '#btnAddSPJ', function () {
    var myURL = '/clients/pengolahan/report/create/'
    $('#myModalContent').load(myURL, function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});

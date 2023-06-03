$(document).ready(function () {
    loadTable();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
    PopulateSumber();
    PopulatePenyedia();
    PopulateKendaraan();

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
    $('#penyedia').select2({
        placeholder: 'Pilih Nama Penyedia...',
        dropdownParent: $('#myModal'),
    });
}
function PopulateKendaraan() {
    $('.vehicle').select2({
        placeholder: 'Pilih Kendaraan...',
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
    var myURL = '/clients/usaha-kegiatan/report/create/'
    $('#myModalContent').load(myURL, function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});

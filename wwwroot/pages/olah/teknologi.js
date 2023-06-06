$(document).ready(function () {
    loadTable();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    PopulateTeknologi();
    PopulateAlat();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    //var myID = $('#izin').val();

    $('#tblTeknologi').DataTable().destroy();
    $('#tblTeknologi').DataTable({
        responsive: true,        
        lengthMenu: [5, 10, 20],        
        pagingType: "simple_numbers",
    });
}

function PopulateTeknologi() {
    $('.teknologi').select2({
        placeholder: 'Pilih Teknologi...',
        dropdownParent: $('#myModal')
    });
}

function PopulateAlat() {
    $('.alat').select2({
        placeholder: 'Pilih Alat yang Digunakan...',
        dropdownParent: $('#myModal')
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
$(document).on('click', '#btnAddVehicle', function () {
    var myURL = '/clients/pengolahan/teknologi/create/?izin=8ed70b14-5f31-4e11-bf16-28db'
    $('#myModalContent').load(myURL, function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});

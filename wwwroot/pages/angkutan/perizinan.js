var vehicle = '';
var currentIzinID = '';
var currentIzinVal = '';

$(document).ready(function () {
    loadTable();    

    $('#panel-3').hide();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    PopulateLokasiIzin();
    PopulateLokasiBuang();
    
});

function loadContent() {   
    $('#searchVehicle').val('');
    PopulateKendaraan(currentIzinID, '');
}

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    PopulateJenisKendaraan();
});

$(document).on('click', '#btnAddVehicle', function () {
    var myURL = '/clients/pengangkutan/kendaraan/create/?izin=' + currentIzinID
    $('#myModalContent').load(myURL, function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});

$('#clientform').submit(function (e) {
    e.preventDefault();

    var formdata = new FormData($('#clientform')[0]);

    $.ajax({
        url: this.action,
        method: this.method,
        data: formdata,
        processData: false,
        contentType: false,
        success: function (result) {
            if (result.success) {
                loadTable();
                ClearField();               
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
            url: '/api/clients/pengangkutan/izin/list',
            method: 'POST'
        },
        columns: [
            { data: 'noIzinUsaha', name: 'noIzinUsaha' },
            { data: 'jmlAngkutan', name: 'jmlAngkutan' },
            { data: 'tglTerbitIzin', name: 'tglTerbitIzin' },
            { data: 'tglAkhirIzin', name: 'tglAkhirIzin' },
            {
                "render": function (data, type, row) {
                    return `<div class='btn-group' role='group'>
                                <button type="button" class="btn btn-success btn-sm showVehicle dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Action
                                </button>
                                <div class="dropdown-menu">
                                    <button class="dropdown-item" href="#">Perpanjang</button>
                                    <button class="dropdown-item btnVehicle" data-id="` + row.izinAngkutID +  `" data-val="` + row.noIzinUsaha + `">Data Kendaraan</button>
                                </div>
                            </div>`;
                }
            }
        ],
        columnDefs: [            
            { className: 'text-center', targets: [1,2,3,4] }            
        ],
        order: [[3, "desc"]]
    });
}

$(document).on('click', '.btnVehicle', function () {
    $('#NoIzin').text('loading...');
    var myID = $(this).attr('data-id');
    var izin = $(this).attr('data-val');

    currentIzinID = myID;
    currentIzinVal = izin;

    PopulateKendaraan(myID, '');

    $('#panel-3').show('fast');    
    $('.showVehicle').dropdown('toggle');
});

$(document).on('keyup', '#searchVehicle', function () {
    var str = $(this).val();    

    PopulateKendaraan(currentIzinID, str);
})

function ClearField() {
    $('.datainput').val('');
    $('#txtJmlAngkut').val(0);
    $('.s2').val(null).trigger('change');
    $(".dokumen").val(null);
    $(".jmlAngkut").val(0);
}

function PopulateJenisKendaraan() {
    $('.vehicleType').select2({
        placeholder: 'Pilih Jenis Kendaraan...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/api/master/kendaraan/jenis/search',
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            dataType: 'json',
            delay: 100,
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.namaJenis,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function PopulateLokasiIzin() {
    $('.sTerbitIzin').select2({
        placeholder: 'Pilih Lokasi Izin...',
        allowClear: true,
        ajax: {
            url: "/api/master/lokasi-izin/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.data,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function PopulateLokasiBuang() {
    $('.sLokasiBuang').select2({
        placeholder: 'Pilih Lokasi Pembuangan...',
        allowClear: true,
        ajax: {
            url: "/api/master/lokasi-buang/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.data,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function PopulateKendaraan(izinID, term) {
    vehicle = '';    
    $('#NoIzin').text('loading...');
    $.ajax({
        type: 'GET',
        url: '/api/clients/pengangkutan/kendaraan/data/?id=' + izinID + '&search=' + term,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            vehicle = data;
            drawVehicle(vehicle);
            $('#NoIzin').text(currentIzinVal);
        }
    });
}

function drawVehicle(data) {
    $("#tblVehicle tr:has(td)").remove();

    var tblNum = 0;
    var trHTML = '';

    if (data.length === 0) {
        trHTML += '<tr><td class="text-center" colspan="7">Tidak ada data...</td><tr>';
    } else {
        $.each(data, function (i, item) {
            trHTML += '<tr><td class="text-center">' + (tblNum + 1) + '</td><td class="text-center">'
                + item.noPolisi + '</td><td class="text-center">' + item.noPintu + '</td><td class="text-center">'
                + item.jenis + '</td><td class="text-center">' + item.tahunPembuatan
                + '</td><td class="text-center">' + item.tglSTNK
                + '</td><td class="text-center">' + item.tglKIR
                + '</td></tr>';

            tblNum += 1;
        });
    }    

    $('#tblVehicle').append(trHTML);
}
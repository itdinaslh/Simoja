var vehicle = '';

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

    PopulateKendaraan(myID);
    $('#panel-3').show('fast');
    $('#NoIzin').text(izin);
    $('.showVehicle').dropdown('toggle');
});

function ClearField() {
    $('.datainput').val('');
    $('#txtJmlAngkut').val(0);
    $('.s2').val(null).trigger('change');
    $(".dokumen").val(null);
    $(".jmlAngkut").val(0);
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

function PopulateKendaraan(izinID) {
    $('#NoIzin').text('loading...');
    $.ajax({
        type: 'GET',
        url: '/api/clients/pengangkutan/kendaraan/data/?id=' + izinID,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            vehicle = data;
            drawVehicle(vehicle);
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
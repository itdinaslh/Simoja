var vehicle = '';
var currentIzinID = '';
var currentIzinVal = '';

$(document).ready(function () {
    /*loadTable();*/

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    loadTable();

    PopulateLokasiIzin();
    PopulateJenisKegiatan();
    PopulateJenisIzin();
    
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
                showSuccess();          
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
            url: '/api/clients/usaha-kegiatan/kawasan/list',
            method: 'POST'
        },
        columns: [
            { data: 'noIzinUsaha', name: 'noIzinUsaha' },
            { data: 'namaKawasan', name: 'namaKawasan' },
            { data: 'lokasiIzin', name: 'lokasiIzin' },
            { data: 'tglTerbitIzin', name: 'tglTerbitIzin' },
            {
                "render": function (data, type, row) {
                    return `<div class='btn-group' role='group'>
                                <button type="button" class="btn btn-success btn-sm showVehicle dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Action
                                </button>
                                <div class="dropdown-menu">
                                    <button class="dropdown-item" href="#">Perpanjang</button>                                    
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

function ClearField() {
    $('.datainput').val('');    
    $('.s2').val(null).trigger('change');
    $(".dokumen").val(null)
    
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

function PopulateJenisKegiatan() {
    $('.sJenisKegiatan').select2({
        placeholder: 'Pilih Jenis Kegiatan...',
        allowClear: true,
        ajax: {
            url: "/api/master/kawasan/jenis/search",
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

function PopulateJenisIzin() {
    $('.sJenisIzin').select2({
        placeholder: 'Pilih Jenis Izin Lingkungan...',
        allowClear: true,
        ajax: {
            url: "/api/master/kawasan/jenis-izin/search",
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

function showSuccess() {
    Swal.fire(
        {
            position: 'top-end',
            type: 'success',
            title: 'Data berhasil disimpan!',
            showConfirmButton: false,
            timer: 1000
        }).then(function () {
            loadTable();
            ClearField();  
        });
}


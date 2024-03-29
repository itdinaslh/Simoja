$(document).ready(function () {
    loadTable();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    PopulateJenisKendaraan();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    var myID = $('#izin').val();

    $('#tblKendaraan').DataTable().destroy();
    $('#tblKendaraan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,        
        lengthMenu: [5, 10, 20],        
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/pengangkutan/kendaraan/list/?id=' + myID,
            method: 'POST'
        },
        columns: [
            {data:'kendaraanId', name:'kendaraanId'},            
            {data:'noPolisi', name:'noPolisi'},            
            {data:'noPintu', name:'noPintu'},
            {data:'jenis', name:'jenis', searchable: false},
            {data:'tahunPembuatan', name:'tahunPembuatan'},
            {data:'tglSTNK', name:'tglSTNK', searchable: false, orderable: false},
            {data:'tglKIR', name:'tglKIR'}
            //{
            //    "render": function (data, type, row)
            //    {
            //        return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/kendaraan/details/?id="
            //        + row.uniqueId + "'><i class='fal fa-edit'></i> Data Kendaraan</a>";
            //    }
            //}
        ],
        order: [[0, "desc"]]
    });
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

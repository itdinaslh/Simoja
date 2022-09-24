$(document).ready(function() {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    var client = $('#ClientID').val();
    $('#tblUser').DataTable().destroy();
    $('#tblUser').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/ptsp/kendaraan/' + client + '/ajax',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'kendptsp.id'},
            {data:'NoPolisi', name:'kendptsp.NoPolisi'},
            {data:'NoPintu', name:'kendptsp.NoPintu'},
            {data:'Merk', name:'kendptsp.Merk'},
            {data:'NamaJenis', name:'jeniskendaraan.NamaJenis'},
            {data:'Tahun', name:'kendptsp.Tahun'},
            {data:'Keterangan', name:'kendptsp.Keterangan'},

            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href=''"
                    + row.id + "'><i class='fal fa-edit'></i> Edit</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', '#myModal', function() {
    $('#idjenis').select2({
        placeholder: 'Pilih Jenis Kendaraan...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/kendaraan/jenis/search',
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
                            text: item.NamaJenis,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});

$(document).ready(function() {
    loadTable();
})

function loadTable() {
    $('#tblKendaraan').DataTable().destroy();
    $('#tblKendaraan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,        
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/jasa/pengangkutan/kendaraan/list',
            method: 'POST'
        },
        columns: [
            {data:'kendaraanId', name:'kendaraanId'},            
            {data:'noPolisi', name:'noPolisi'},            
            {data:'noPintu', name:'noPintu'},
            {data:'jenis', name:'jenis', searchable: false},
            {data:'tahunPembuatan', name:'tahunPembuatan'},
            {data:'tglSTNK', name:'tglSTNK', searchable: false, orderable: false},
            {data:'tglKIR', name:'tglKIR'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/kendaraan/details/?id="
                    + row.uniqueId + "'><i class='fal fa-edit'></i> Data Kendaraan</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

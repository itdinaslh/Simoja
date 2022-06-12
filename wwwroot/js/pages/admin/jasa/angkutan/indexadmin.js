$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#tblJasa').DataTable().destroy();
    $('#tblJasa').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/data/jasa/angkutan/indexajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable:false},
            {data:'NamaUsaha', name:'clients.NamaUsaha'},
            {data:'NamaJenis', name:'jenisjasa.NamaJenis'},
            {data:'email', name:'users.email'},
            {data:'Telp', name:'clients.Telp'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/data/jasa/angkutan/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Cek Data</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

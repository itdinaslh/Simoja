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
            url: '/ptsp/olah/ajax',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'id', searchable:false},
            {data:'NamaUsaha', name:'NamaUsaha'},
            {data:'Alamat', name:'Alamat'},
            {data:'NoIzinUsaha', name:'NoIzinUsaha'},
            {data:'TglAkhirIzin', name:'TglAkhirIzin'},
            // {
            //     "render": function (data, type, row)
            //     {
            //         return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/data/jasa/pengolahan/details/"
            //         + row.id + "'><i class='fal fa-edit'></i> Cek Data</a>";
            //     }
            // }
        ],
        order: [[0, "desc"]]
    });
}

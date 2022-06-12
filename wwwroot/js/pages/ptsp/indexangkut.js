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
            url: '/ptsp/angkut/ajax',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'clientptsp.id', searchable:false},
            {data:'NamaUsaha', name:'clientptsp.NamaUsaha'},
            {data:'Alamat', name:'clientptsp.Alamat'},
            {data:'NoIzinUsaha', name:'clientptsp.NoIzinUsaha'},
            {data:'JmlAngkutan', name:'daptsp.JmlAngkutan'},
            {data:'TglAwalIzin', name:'clientptsp.TglAwalIzin'},
            {data:'TglAkhirIzin', name:'clientptsp.TglAkhirIzin'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='#"
                    + row.id + "'><i class='fal fa-edit'></i> Cek Data</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

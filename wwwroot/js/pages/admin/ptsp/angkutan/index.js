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
            url: '/admin/ptsp/angkutan/index/ajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable:false},
            {data:'NamaUsaha', name:'clientptsp.NamaUsaha'},
            {data:'NoIzinUsaha', name:'clientptsp.NoIzinUsaha'},
            {data:'Alamat', name:'clientptsp.Alamat'},
            {data:'TglAwalIzin', name:'clientptsp.TglAwalIzin'},
            {data:'TglAkhirIzin', name:'clientptsp.TglAkhirIzin'},
            {data:'JmlAngkutan', name:'daptsp.JmlAngkutan'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/ptsp/angkutan/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Data</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

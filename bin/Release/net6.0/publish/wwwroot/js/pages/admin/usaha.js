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
            url: '/admin/usaha/unverified',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'clientskawasan.id'},
            {data:'NamaPerusahaan', name:'cliclientskawasanents.NamaPerusahaan'},
            {data:'NamaKeg', name:'clientskawasan.NamaKeg'},
            {data:'email', name:'users.email'},
            {data:'Telp', name:'clientskawasan.Telp'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/usaha/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Cek Data</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}


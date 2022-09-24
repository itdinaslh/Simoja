$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/admin/jasa/unverified',
            method: 'POST'
        },
        columns: [
            {data:'clientId', name:'clientId'},
            {data:'clientName', name:'clientName'},
            {data:'jenisUsaha', name:'jenisUsaha'},
            {data:'email', name:'email'},
            {data:'telp', name:'telp'},            
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/jasa/details/?theID="
                    + row.clientGuid + "'><i class='fal fa-edit'></i> Cek Data</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}


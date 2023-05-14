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
            url: '/api/admin/jasa/angkutan',
            method: 'POST'
        },
        columns: [            
            { data: 'clientName', name:'clientName', autowidth: true },            
            { data: 'email', name: 'email', autowidth: true },
            { data: 'telp', name: 'telp', autowidth: true },
            { data: 'namaKabupaten', name: 'namaKabupaten', autowidth: true },
            { data: 'createdAt', name: 'createdAt', autowidth: true },
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/data/jasa/angkutan/details/?theID="
                    + row.clientID + "'><i class='fal fa-edit'></i></a>";
                }
            }
        ],
        columnDefs: [
            {
                targets: 5,
                className: 'dt-body-center'
            }
        ],
        order: [[4, "desc"]]
    });
}

$(document).ready(function() {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblUser').DataTable().destroy();
    $('#tblUser').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/ptsp/users/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'u.id'},
            {data:'name', name:'u.name'},
            {data:'email', name:'u.email'},
            {data:'NamaKota', name:'k.NamaKota'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/admin/ptsp/users/edit/"
                    + row.id + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

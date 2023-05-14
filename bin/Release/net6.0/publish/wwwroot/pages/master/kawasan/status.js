$(document).ready(function() {
    loadContent();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        stateSave: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/master/kawasan/status',
            method: 'POST'
        },
        columns: [
            {data:'statusKelolaID', name:'statusKelolaID'},            
            {data:'namaStatus', name:'namaStatus'},            
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kawasan/status/edit?statusID="
                    + row.statusKelolaID + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}
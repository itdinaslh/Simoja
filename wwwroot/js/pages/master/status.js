$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#tblstatus').DataTable().destroy();
    $('#tblstatus').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/master/kawasan/status/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'id'},
            {data:'NamaStatus', name:'NamaStatus'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kawasan/status/edit/"
                    + row.id + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Data berhasil disimpan!',
        showConfirmButton: false,
        timer: 1000
    }).then(function () {
        loadTable();
    });
}

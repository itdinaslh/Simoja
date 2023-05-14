$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#tbljenis').DataTable().destroy();
    $('#tbljenis').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/master/kawasan/jenis/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'id'},
            {data:'Prefix', name:'Prefix', searchable: false, orderable: false},
            {data:'NamaJenis', name:'NamaJenis'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kawasan/jenis/edit/"
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

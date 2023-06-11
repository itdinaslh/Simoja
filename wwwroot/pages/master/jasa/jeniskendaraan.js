$(document).ready(function() {
    loadTable();
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
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/master/kendaraan/jenis',
            method: 'POST'
        },
        columns: [
            { data: 'tipeKendaraanID', name:'tipeKendaraanID'},
            { data: 'kode', name:'kode'},
            { data: 'namaTipe', name:'namaTipe'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kendaraan/jenis/edit/?jenisId="
                        + row.tipeKendaraanID + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).ready(function () {
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
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/master/kawasan/jenis-izin',
            method: 'POST'
        },
        columns: [
            { data: 'jenisIzinLingkunganID', name: 'jenisIzinLingkunganID' },            
            { data: 'namaJenisIzin', name: 'namaJenisIzin' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kawasan/jenis-izin-lingkungan/edit?jenisID="
                        + row.jenisIzinLingkunganID + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}
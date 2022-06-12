$(document).ready(function() {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tbJenis').DataTable().destroy();
    $('#tbJenis').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/master/jasa/jeniskendaraan/ajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum'},
            {data:'NamaJenis', name:'NamaJenis'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' data-href='/master/jasa/jeniskendaraan/edit/"
                    + row.id + "'><i class='fal fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

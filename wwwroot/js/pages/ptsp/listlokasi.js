$(document).ready(function() {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    var client = $('#ClientID').val();
    $('#tblUser').DataTable().destroy();
    $('#tblUser').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/ptsp/sumber/' + client + '/ajax',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'id'},
            {data:'NamaPerusahaan', name:'NamaPerusahaan'},
            {data:'Alamat', name:'Alamat'},
            {data:'Teknologi', name:'Teknologi'},
            {data:'Kapasitas', name:'Kapasitas'},

            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href=''"
                    + row.id + "'><i class='fal fa-edit'></i> Edit</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

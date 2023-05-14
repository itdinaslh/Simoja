$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#izin').DataTable().destroy();
    $('#izin').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/olah/perizinan/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NoIzinUsaha', name:'NoIzinUsaha'},
            {data:'TglAwalIzin', name:'TglAwalIzin'},
            {data:'TglAkhirIzin', name:'TglAkhirIzin'},
            {data:'Teknologi', name:'Teknologi'},
            {data:'Kapasitas', name:'Kapasitas'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-primary mr-2' href='/clients/jasa/olah/perizinan/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Detail</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

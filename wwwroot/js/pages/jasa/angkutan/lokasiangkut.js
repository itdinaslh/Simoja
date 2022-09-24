$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#lokasiAngkut').DataTable().destroy();
    $('#lokasiAngkut').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/jasa/pengangkutan/lokasi-angkut/list',
            method: 'POST'
        },
        columns: [
            {data:'lokasiAngkutId', name:'lokasiAngkutId', searchable: false},
            {data:'namaLokasi', name:'namaLokasi'},
            {data:'kabupaten', name:'kabupaten', searchable: false, orderable: false},
            {data:'kecamatan', name:'kecamatan', searchable: false, orderable: false},
            {data:'kelurahan', name:'kelurahan', searchable: false, orderable: false},
            {data:'tglAwalKontrak', name:'tglAwalKontrak', searchable: false, orderable: false},
            {data:'tglAkhirKontrak', name:'tglAkhirKontrak', searchable: false, orderable: false},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/angkutan/lokasi/details/?id="
                    + row.uniqueId + "'><i class='fal fa-edit'></i> Data Lokasi</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

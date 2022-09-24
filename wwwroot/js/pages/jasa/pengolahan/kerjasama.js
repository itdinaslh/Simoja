$(document).ready(function() {
    loadTable();
});

function loadTable() {
    $('#kerjasama').DataTable().destroy();
    $('#kerjasama').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/olah/kerjasama/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaPerusahaan', name:'partnerolah.NamaPerusahaan'},
            {data:'NamaKota', name:'kot.NamaKota'},
            {data:'NamaKecamatan', name:'kec.NamaKecamatan'},
            {data:'NamaKelurahan', name:'kec.NamaKecamatan'},
            {data:'Alamat', name:'partnerolah.Alamat'},
            {data:'TglAwalKontrak', name:'partnerolah.TglAwalKontrak'},
            {data:'TglAkhirKontrak', name:'partnerolah.TglAkhirKontrak'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/olah/kerjasama/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Data Lokasi</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

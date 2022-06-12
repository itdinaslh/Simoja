$(document).ready(function() {
    loadAngkutan();
    loadPengolahan();
});

function loadAngkutan() {
    $('#tblKendaraan').DataTable().destroy();
    $('#tblKendaraan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/angkutan/kendaraan/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'id', name:'kendaraan.id'},
            {data:'NoPolisi', name:'kendaraan.NoPolisi'},
            {data:'NoPintu', name:'kendaraan.NoPintu'},
            {data:'NamaJenis', name:'jeniskendaraan.NamaJenis'},
            {data:'TahunPembuatan', name:'kendaraan.TahunPembuatan'},
            {data:'TglBerlakuSTNK', name:'kendaraan.TglBerlakuSTNK'},
            {data:'TglBerlakuKIR', name:'kendaraan.TglBerlakuKIR'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/angkutan/kendaraan/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Data Kendaraan</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function loadPengolahan() {
    $('#lokasiAngkut').DataTable().destroy();
    $('#lokasiAngkut').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/angkutan/lokasi/ajaxindex',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaLokasi', name:'lokasiangkutan.NamaLokasi'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
            {data:'NamaKelurahan', name:'kelurahan.NamaKelurahan'},
            {data:'TglAwalKontrak', name:'lokasiangkutan.TglAwalKontrak'},
            {data:'TglAkhirKontrak', name:'lokasiangkutan.TglAkhirKontrak'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/angkutan/lokasi/details/"
                    + row.id + "'><i class='fal fa-edit'></i> Data Lokasi</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

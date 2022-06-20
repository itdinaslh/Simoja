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
            url: '/api/clients/jasa/pengangkutan/kendaraan/list',
            method: 'POST'
        },
        columns: [
            {data:'kendaraanId', name:'kendaraanId'},            
            {data:'noPolisi', name:'noPolisi'},            
            {data:'noPintu', name:'noPintu'},
            {data:'jenis', name:'jenis', searchable: false},
            {data:'tahunPembuatan', name:'tahunPembuatan'},
            {data:'tglSTNK', name:'tglSTNK'},
            {data:'tglKIR', name:'tglKIR'},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/kendaraan/details/?id="
                    + row.uniqueId + "'><i class='fal fa-edit'></i> Data Kendaraan</a>";
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
            url: '/api/clients/jasa/pengangkutan/lokasi-angkut/list',
            method: 'POST'
        },
        columns: [
            {data:'LokasiAngkutId', name:'LokasiAngkutId', searchable: false},
            {data:'namaLokasi', name:'namaLokasi'},
            {data:'Kabupaten', name:'Kabupaten', searchable: false, orderable: false},
            {data:'Kecamatan', name:'Kecamatan', searchable: false, orderable: false},
            {data:'Kelurahan', name:'Kelurahan', searchable: false, orderable: false},
            {data:'tglAwalKontrak', name:'tglAwalKontrak', searchable: false, orderable: false},
            {data:'tglAkhirKontrak', name:'tglAkhirKontrak', searchable: false, orderable: false},
            {
                "render": function (data, type, row)
                {
                    return "<a class='btn btn-sm btn-outline-success mr-2' href='/clients/jasa/angkutan/lokasi-angkut/details/?id="
                    + row.uniqueId + "'><i class='fal fa-edit'></i> Data Lokasi</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

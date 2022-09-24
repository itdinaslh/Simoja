$(document).ready(function() {
    loadAngkutan();
    loadPengolahan();
});

function loadAngkutan() {
    $('#tblAngkut').DataTable().destroy();
    $('#tblAngkut').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/listangkutanajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaUsaha', name:'clients.NamaUsaha'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
            {data:'NamaKelurahan', name:'kelurahan.NamaKelurahan'},
            {data:'Alamat', name:'clients.Alamat'},
            {data:'Telp', name:'clients.Telp'},
            {data:'NoIzinUsaha', name:'clients.NoIzinUsaha'},
            {data:'TglAkhirIzin', name:'clients.TglAkhirIzin'}
        ],
        order: [[0, "desc"]]
    });
}

function loadPengolahan() {
    $('#tblOlah').DataTable().destroy();
    $('#tblOlah').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/listpengolahanajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaUsaha', name:'clients.NamaUsaha'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
            {data:'NamaKelurahan', name:'kelurahan.NamaKelurahan'},
            {data:'Alamat', name:'clients.Alamat'},
            {data:'Telp', name:'clients.Telp'},
            {data:'NoIzinUsaha', name:'clients.NoIzinUsaha'},
            {data:'TglAkhirIzin', name:'clients.TglAkhirIzin'}
        ],
        order: [[0, "desc"]]
    });
}

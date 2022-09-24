$(document).ready(function() {
    LoadReport();
    LoadReport2();
});



function LoadReport(tglAwal, tglAkhir) {
    $('#rptBulanan').DataTable().destroy();
    $('#rptBulanan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/jasa/angkutan/laporan/bulanan/',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum'},
            {data:'TglAngkut', name:'reportangkutan.TglAngkut'},
            {data:'JmlSampah', name:'reportangkutan.JmlSampah', searchable: false, orderable: false},
            {data:'JmlReduksi', name:'reportangkutan.JmlReduksi', searchable: false, orderable: false},
            {data:'JmlResidu', name:'reportangkutan.JmlResidu', searchable: false, orderable: false}
        ],
        order: [[0, "desc"]]
    });
}

function LoadReport2(tglAwal, tglAkhir) {
    $('#rptBulanan2').DataTable().destroy();
    $('#rptBulanan2').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/jasa/pengolahan/laporan/bulanan',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum'},
            // {data:'NamaUsaha', name:'clients.NamaUsaha'},
            // {data:'NamaKota', name:'kota.NamaKota'},
            // {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
            {data:'TglMasuk', name:'rpm.TglMasuk'},
            {data:'KKK', name:'rpm.KKK', searchable: false, orderable: false},
            {data:'Plastik', name:'rpm.Plastik', searchable: false, orderable: false},
            {data:'Kaca', name:'rpm.Kaca', searchable: false, orderable: false},
            {data:'Logam', name:'rpm.Logam', searchable: false, orderable: false},
            {data:'Lainnya', name:'rpm.Lainnya', searchable: false, orderable: false},
            {data:'Organik', name:'rpm.Organik', searchable: false, orderable: false},
            {data:'Total_Masuk', name:'Total_Masuk', searchable: false, orderable: false}
        ],
        order: [[0, "desc"]]
    });
}

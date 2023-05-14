
$(document).ready(function() {
    $('.datepicker').datepicker({
        format: 'yyyy-mm-dd',
        orientation: 'bottom'
    });
});

$('#frmNgawur').submit(function(e) {
    e.preventDefault();

    $('input:text[required]').parent().show();

    var tglAwal = $('#TglAwal').val();
    var tglAkhir = $('#TglAkhir').val();

    LoadReport(tglAwal, tglAkhir);
});

$('#btnExcel').click(function() {
    var tAwal = $('#TglAwal').val();
    var tAkhir = $('#TglAkhir').val();

    if (tAwal == '') {
        alert('Isi Tanggal Awal!');
    } else if (tAkhir == '') {
        alert('Isi Tanggal Akhir!')
    } else {
        var url = "/clients/jasa/pengolahan/laporan/bulanan/excel/" + tAwal + "/" + tAkhir;

        var win = window.open("", "_blank");

        win.location.href = url;

        win.focus;
    }
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
            url: '/clients/jasa/olah/laporan/bulanan/' + tglAwal + '/' + tglAkhir,
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum'},
            {data:'NamaUsaha', name:'clients.NamaUsaha'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
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



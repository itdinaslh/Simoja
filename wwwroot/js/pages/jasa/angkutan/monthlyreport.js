
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
        var url = "/clients/jasa/pengangkutan/laporan/bulanan/excel/" + tAwal + "/" + tAkhir;

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
            url: '/clients/jasa/angkutan/laporan/bulanan/' + tglAwal + '/' + tglAkhir,
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum'},
            {data:'NamaLokasi', name:'lokasiangkutan.NamaLokasi'},
            {data:'NoPolisi', name:'kendaraan.NoPolisi'},
            {data:'TglAngkut', name:'reportangkutan.TglAngkut'},
            {data:'JnsSampah', name:'reportangkutan.JnsSampah'},
            {data:'LokasiTujuan', name:'reportangkutan.LokasiTujuan'},
            {data:'JmlSampah', name:'reportangkutan.JmlSampah', searchable: false, orderable: false},
            {data:'JmlReduksi', name:'reportangkutan.JmlReduksi', searchable: false, orderable: false},
            {data:'JmlResidu', name:'reportangkutan.JmlResidu', searchable: false, orderable: false}
        ],
        order: [[0, "desc"]]
    });
}



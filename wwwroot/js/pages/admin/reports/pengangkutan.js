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

function LoadReport(tglAwal, tglAkhir) {
    var sum = $.pivotUtilities.aggregatorTemplates.sum;
    var numberFormat = $.pivotUtilities.numberFormat;
    var idFormat = numberFormat({thousandsSep:".", decimalSep:","});
    var derivers = $.pivotUtilities.derivers;
    var renderers = $.extend($.pivotUtilities.renderers,
            $.pivotUtilities.c3_renderers);

    $.getJSON("/admin/data/report/pengangkutan/pivotmasuk/" + tglAwal + "/" + tglAkhir, function(data) {
        $("#pivotMasuk").pivotUI(data, {
            renderers: renderers,
            rendererOptions: { c3: { size: {width: 800, height: 600} } },
            rows: ['Tujuan'],
            vals: ["Jumlah Sampah"],
            aggregatorName: "Sum",
            rendererName: "Bar Chart",
            rowOrder: "value_z_to_a", colOrder: "value_z_to_a"
        });
    });
}

$('#btnExcel').click(function() {
    var tAwal = $('#TglAwal').val();
    var tAkhir = $('#TglAkhir').val();

    if (tAwal == '') {
        alert('Isi Tanggal Awal!');
    } else if (tAkhir == '') {
        alert('Isi Tanggal Akhir!')
    } else {
        var url = "/admin/data/report/pengangkutan/excel/" + tAwal + "/" + tAkhir;

        var win = window.open("", "_blank");

        win.location.href = url;

        win.focus;
    }
});

$(document).ready(function() {
    PopulateJenis();
    PopulateKota();
    LoadKerjasama();
    LoadIzin();

    var idkota = $('#cbIdKota option:selected').val();
    var idkecamatan = $('#cbIdKecamatan option:selected').val();

    loadKecamatan(idkota);
    loadKelurahan(idkecamatan);

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

$('#frmUpdateData').submit(function(e) {
    e.preventDefault();
    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function(result) {
            if (result.success) {
                showSuccessMessage();
            }
        }
    });
});


function PopulateJenis() {
    $('#comtype').select2({
        placeholder: 'Pilih jenis usaha...',
            ajax: {
                url: '/master/jasa/findjenis',
                data: function(params) {
                    return {
                        q: params.term
                    }
                },
                dataType: 'json',
                delay: 100,
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.NamaJenis,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
}

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'center',
        type: 'success',
        title: 'Data Berhasil Diupdate',
        showConfirmButton: false,
        timer: 1000
    });
}

function LoadKerjasama() {
    var theid = $('#clientid').val();
    $('#tblKerjasama').DataTable().destroy();
    $('#tblKerjasama').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/data/jasa/pengolahan/details/' + theid + '/ajaxkerjasama',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaPerusahaan', name:'partnerolah.NamaPerusahaan'},
            {data:'NamaKota', name:'kota.NamaKota'},
            {data:'NamaKecamatan', name:'kecamatan.NamaKecamatan'},
            {data:'NamaKelurahan', name:'kelurahan.NamaKelurahan'},
            {data:'TglAwalKontrak', name:'partnerolah.TglAwalKontrak'},
            {data:'TglAkhirKontrak', name:'partnerolah.TglAkhirKontrak'},
            // {
            //     "render": function (data, type, row)
            //     {
            //         return "<a class='btn btn-sm btn-outline-success mr-2 verify' href='/admin/data/jasa/pengolahan/kerjasama/"
            //         + row.id + "'><i class='fal fa-edit'></i> Details</a>";
            //     }
            // }
        ],
        order: [[0, "desc"]]
    });
}

function LoadIzin() {
    var theid = $('#clientid').val();
    $('#tblIzin').DataTable().destroy();
    $('#tblIzin').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/data/jasa/pengolahan/details/' + theid + '/ajaxizin',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NoIzinUsaha', name:'NoIzinUsaha'},
            {data:'TglAwalIzin', name:'TglAwalIzin'},
            {data:'TglAkhirIzin', name:'TglAkhirIzin'},
            {data:'Teknologi', name:'Teknologi'},
            {data:'Kapasitas', name:'Kapasitas'},
            // {
            //     "render": function (data, type, row)
            //     {
            //         return "<a class='btn btn-sm btn-outline-primary mr-2 verify' href='/admin/data/jasa/pengolahan/izin/"
            //         + row.id + "'><i class='fal fa-edit'></i> Details</a>";
            //     }
            // }
        ],
        order: [[0, "desc"]]
    });
}

$(document).ready(function() {
    PopulateJenis();
    PopulateKota();
    loadTable();
    LoadLokasi();

    var idkota = $('#cbIdKota option:selected').val();
    var idkecamatan = $('#cbIdKecamatan option:selected').val();

    loadKecamatan(idkota);
    loadKelurahan(idkecamatan);

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

var lokasi = [];

$('#frmUpdateData').submit(function(e) {
    e.preventDefault();
    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function(result) {
            if (result.success) {
                showBerhasil();
            }
        }
    });
});

function loadContent() {
    loadTable();
    LoadLokasi();
}

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

function showBerhasil() {
    Swal.fire(
    {
        position: 'center',
        type: 'success',
        title: 'Data Berhasil Diupdate',
        showConfirmButton: false,
        timer: 1000
    });
}

function loadTable() {
    var theid = $('#clientid').val();
    $('#tblKendaraan').DataTable().destroy();
    $('#tblKendaraan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/data/jasa/angkutan/kendaraan/' + theid + '/ajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NoPolisi', name:'kendaraan.NoPolisi'},
            {data:'NoPintu', name:'kendaraan.NoPintu'},
            {data:'NamaJenis', name:'jeniskendaraan.NamaJenis'},
            {data:'TahunPembuatan', name:'kendaraan.TahunPembuatan'},
            {data:'TglBerlakuSTNK', name:'kendaraan.TglBerlakuSTNK'},
            {data:'TglBerlakuKIR', name:'kendaraan.TglBerlakuKIR'},
            {
                "render": function (data, type, row)
                {
                    return "<button class='btn btn-sm btn-outline-success mr-2 verify showMe' data-href='/admin/data/jasa/angkutan/kendaraan/"
                    + row.id + "'><i class='fal fa-edit'></i> Details</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function LoadLokasi() {
    var theid = $('#clientid').val();
    $('#tblKerjasama').DataTable().destroy();
    $('#tblKerjasama').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/data/jasa/angkutan/lokasi/' + theid + '/ajax',
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
            // {
            //     "render": function (data, type, row)
            //     {
            //         return "<button class='btn btn-sm btn-outline-success mr-2 verify showMe' data-href='/admin/data/jasa/angkutan/lokasi/"
            //         + row.id + "'><i class='fal fa-edit'></i> Data</button>";
            //     }
            // }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', '#myModal', function() {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    $('#vehicleType').select2({
        placeholder: 'Pilih Jenis Kendaraan...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/kendaraan/jenis/search',
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
});

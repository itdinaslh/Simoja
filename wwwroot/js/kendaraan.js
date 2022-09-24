$(document).ready(function() {
    $('.datepicker').datepicker({
        format: 'dd-mm-yyyy',
        orientation: 'bottom'
    });

    $('#NoPolisi').select2({
        placeholder: 'Pilih No Polisi...',
            ajax: {
                url: '/kendaraan/api',
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
                                text: item.NoPolisi,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });

    $('#PartnerID').select2({
        placeholder: 'Pilih Kerjasama...',
            ajax: {
                url: '/lokasi/api',
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
                                text: item.NamaLokasi,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });

    $('#tblLaporan').DataTable();
});

function loadTable() {
    var tgl = $('#TglAngkut').val();

    $('#tblLaporan').DataTable().destroy();
    $('#tblLaporan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/clients/jasa/angkutan/report/' + tgl,
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable:false},
            {data:'TglAngkut', name:'reportangkutan.TglAngkut'},
            {data:'NoPolisi', name:'kendaraan.NoPolisi'},
            {data:'NamaLokasi', name:'lokasiangkutan.NamaLokasi'},
            {data:'JmlSampah', name:'reportangkutan.JmlSampah'},
            {data:'JnsSampah', name:'reportangkutan.JnsSampah'},
            {data:'LokasiTujuan', name:'reportangkutan.LokasiTujuan'},
            {data:'JmlReduksi', name:'reportangkutan.JmlReduksi'},
            {data:'JmlResidu', name:'reportangkutan.JmlResidu'},
            {
                "render": function (data, type, row)
                {
                    return "<a href='/report/angkutan/harian/delete/"
                    + row.id + " class='btn btn-sm btn-outline-danger mr-2 verify' '><i class='fal fa-edit'></i> Hapus</a>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function clearinput() {
    $('.toClear').val('');
}

$('#angkutform').submit(function(e) {
    e.preventDefault();
    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function(result) {
            if (result.success) {
                loadTable();
                showSuccessMessage();
                clearinput();
            }
        }
    })
});

function showSuccessMessage() {
    Swal.fire(
    {
        position: 'top-end',
        type: 'success',
        title: 'Sukses!',
        showConfirmButton: false,
        timer: 1000
    });
}

$(document).on('change', '#TglAngkut', function() {
    loadTable();
});


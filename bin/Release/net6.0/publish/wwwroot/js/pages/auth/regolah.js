$(document).ready(function () {
    loadTable();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });

    $('.sTerbitIzin').select2({
        placeholder: 'Pilih Lokasi Izin...',
        allowClear: true,
        ajax: {
            url: "/api/master/lokasi-izin/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.data,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});

$('#ClientForm').submit(function (e) {
    e.preventDefault();
    $.ajax({
        url: this.action,
        method: this.method,
        data: $(this).serialize(),
        success: function (result) {
            if (result.success) {
                loadTable();
                ClearField();
            }
        }
    });
});

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        stateSave: true,
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/jasa/pengolahan/izin/list',
            method: 'POST'
        },
        columns: [
            { data: 'noIzinUsaha', name: 'noIzinUsaha' },            
            { data: 'tglAkhirIzin', name: 'tglAkhirIzin' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' data-href='/jenis/edit?jenisID="
                        + row.izinOlahId + "'><i class='fal fa-edit'></i> Edit</button><button class='btn btn-sm btn-danger' data-href='/register/olah/izin/delete/?id=>"
                        + row.izinOlahId + "'><i class='fal fa-trash'></i> Delete</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

function ClearField() {
    $('.datainput').val('');
    $(".dokumen").val(null);
    $('.jmltek').val(0);
    $('.s2').val(null).trigger('change');
}
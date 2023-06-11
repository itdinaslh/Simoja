$(document).ready(function () {
    loadTable();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
    PopulateKendaraan();

    inputRepeater();
    PopulateLokasi();
    PopulateTujuan();     
        
});    

function inputRepeater() {
    var i = 0;
    $("#tambahEl").on("click", () => {
        ++i;
        $("#details").append(
            `
                <div class="row align-items-end mb-3 row${i}">
                    <div class="col-3">
                        <label>Lokasi Pengangkutan</label>
                        <select name="DetailSpjVMs[${i}].LokasiAngkutID" class="form-control cSelect sLokasi" required>
                        </select>
                    </div>
                    <div class="col-3">
                        <label>Tujuan</label>
                        <select name="DetailSpjVMs[${i}].LokasiBuangID" class="form-control cSelect sTujuan" required>
                        </select>
                    </div>
                    <div class="col-2">
                        <label>Berat Sampah</label>
                        <input type="text" name="DetailSpjVMs[${i}].Berat" class="form-control" required />
                    </div>
                    <div class="col-3">
                        <label>Tanggal Pengangkutan</label>
                        <input type="text" name="DetailSpjVMs[${i}].TglAngkut" class="form-control datepicker"
                            required />
                    </div>
                    <div class="col-1 px-0">
                        <button type="button" class="btn btn-sm btn-danger text-light mb-1 deleteEl" data-item-id="${i}"><i class="fal fa-trash"></i></button>
                    </div>
                </div>
                `
        );

        PopulateLokasi();
        PopulateTujuan();
    });
}

$(document).on('click', '.deleteEl', function (e) {
    var id = $(this).attr('data-item-id');    

    $('.row' + id).remove();
});

function PopulateLokasi() {
    $(`.sLokasi`).select2({
        placeholder: 'Pilih Lokasi...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/api/clients/pengangkutan/lokasi-angkut/search',
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            dataType: 'json',
            delay: 100,
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
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
}

function PopulateTujuan(i) {
    $(`.sTujuan`).select2({
        placeholder: 'Pilih Tujuan...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/api/master/lokasi-buang/search',
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            dataType: 'json',
            delay: 100,
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
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
}

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblReport').DataTable().destroy();
    $('#tblReport').DataTable({        
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/api/clients/pengangkutan/spj',
            method: 'POST'
        },
        columns: [
            { data: 'noSPJ', name: 'noSPJ' },
            { data: 'noPolisi', name: 'noPolisi' },
            { data: 'noPintu', name: 'noPintu' },
            { data: 'noStruk', name: 'noStruk' },
            { data: 'tonase', name: 'tonase' },
            { data: 'tglSPJ', name: 'tglSPJ' },
            { data: 'tonase', name: 'tonase' }            
        ],
        columnDefs: [
            { className: 'text-center', targets: [0, 4, 5] }
        ],
        order: [[0, "desc"]]
    });
}

function PopulateKendaraan() {
    $('.vehicle').select2({
        placeholder: 'Pilih Kendaraan...',
        dropdownParent: $('#myModal'),
        ajax: {
            url: '/api/clients/pengangkutan/kendaraan/nopol/search',
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            dataType: 'json',
            delay: 100,
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
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
}

function ValidateKendaraan() {
    $('.FormCreate').validate({
        rules: {
            NoPolisi: "required"
        },
        messages: {
            NoPolisi: 'Isi No Polisi...'
        }
    });
}

//tambahan
$(document).on('click', '#btnAddSPJ', function () {
    var myURL = '/clients/pengangkutan/report/create/'
    $('#myModalContent').load(myURL, function () {

        $('#myModal').modal();

        bindForm(this);
    });

    return false;
});
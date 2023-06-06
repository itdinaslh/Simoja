$(document).ready(function () {
    loadTable();
});

$(document).on('shown.bs.modal', '#myModal', function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
    PopulateKendaraan();

    $(document).ready(() => {
        inputRepeater()
        deleteElement()
        PopulateLokasi(0)
        PopulateTujuan(0)
});

    function inputRepeater() {
        var i = 0;
        $("#tambahEl").on("click", () => {
            ++i;
            $("#details").append(
                `
                <div class="row align-items-end mb-3">
                    <div class="col-3">
                        <label>Lokasi Pengangkutan</label>
                        <select name="addmore[${i}][BarangID]" class="form-control cSelect sLokasi" id="sLokasi${i}" required>
                        </select>
                    </div>
                    <div class="col-3">
                        <label>Tujuan</label>
                        <select name="addmore[${i}][BarangID]" class="form-control cSelect sTujuan" id="sTujuan${i}" required>
                        </select>
                    </div>
                    <div class="col-2">
                        <label>Berat Sampah</label>
                        <input type="text" id="vol${i}" name="addmore[${i}][Vol]" class="form-control jumlah${i}" required />
                    </div>
                    <div class="col-3">
                        <label>Tanggal Pengangkutan</label>
                        <input type="text" id="rharga${i}" name="addmore[${i}][Harga]" class="form-control datepicker"
                            required />
                    </div>
                    <div class="col-1 px-0">
                        <a class="btn btn-sm btn-danger text-light mb-1 deleteEl">Delete</a>
                    </div>
                </div>
                `
            )
            deleteElement()
            PopulateLokasi(i)
            PopulateTujuan(i)
        })
    }

    function deleteElement() {
        $.each($(".deleteEl"), function (i, del) {
            $(del).on("click", function (e) {
                // remove row element
                $(e.target).parent().parent().remove()
            })
        })
    }
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

    
});

function loadContent() {
    loadTable();
}

function loadTable() {
    var myID = $('#izin').val();

    $('#tblReport').DataTable().destroy();
    $('#tblReport').DataTable({
        lengthMenu: [5, 10, 20],
        pagingType: "simple_numbers",

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

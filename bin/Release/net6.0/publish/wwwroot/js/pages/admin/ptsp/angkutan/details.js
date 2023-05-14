$(document).ready(function() {
    loadTable();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

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
            url: '/admin/ptsp/angkutan/kendaraan/' + theid + '/ajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NoPolisi', name:'kendptsp.NoPolisi'},
            {data:'Merk', name:'kendptsp.Merk'},
            {data:'NamaJenis', name:'jeniskendaraan.NamaJenis'},
            {data:'Tahun', name:'kendptsp.Tahun'},
            {data:'Keterangan', name:'kendptsp.Keterangan'}
        ]
    });
}

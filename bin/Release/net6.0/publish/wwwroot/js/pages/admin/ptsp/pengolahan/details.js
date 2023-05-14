$(document).ready(function() {
    loadTable();

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        orientation: 'bottom'
    });
});

function loadTable() {
    var theid = $('#clientid').val();

    $('#tblSumber').DataTable().destroy();
    $('#tblSumber').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        ajax: {
            url: '/admin/ptsp/pengolahan/sumber/' + theid + '/ajax',
            method: 'GET'
        },
        columns: [
            {data:'rownum', name:'rownum', searchable: false},
            {data:'NamaPerusahaan', name:'NamaPerusahaan'},
            {data:'Alamat', name:'Alamat'},
            {data:'Teknologi', name:'Teknologi'},
            {data:'Kapasitas', name:'Kapasitas'}
        ]
    });
}

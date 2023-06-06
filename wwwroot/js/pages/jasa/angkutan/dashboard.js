$(document).ready(function() {
    loadAngkutan();
    loadPengolahan();
});

function loadAngkutan() {
    $('#tblKendaraan').DataTable().destroy();
    $('#tblKendaraan').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,        
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
       
        order: [[0, "desc"]]
    });
}

function loadPengolahan() {
    $('#lokasiAngkut').DataTable().destroy();
    $('#lokasiAngkut').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        lengthMenu:[5,10,20],
        pagingType: "simple_numbers",
        
        order: [[0, "desc"]]
    });
}

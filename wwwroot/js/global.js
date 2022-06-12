$.ajaxSetup({
    headers: {
        'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
    }
});

$(document).on('shown.bs.modal', function () {
    $(this).find('[autofocus]').focus();
});


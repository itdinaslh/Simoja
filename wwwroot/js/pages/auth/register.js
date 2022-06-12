$(document).ready(function() {
    $('#RoleID').select2({
        placeholder: 'Pilih Jenis Jasa/Usaha...',
            ajax: {
                url: '/roles/populatereg',
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
                                text: item.RoleName,
                                id: item.id
                            }
                        })
                    }
                },
                cache: true
            }
    });
});

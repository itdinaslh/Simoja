var count = 0;

var notif = '';

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/notification")
    .build();

Object.defineProperty(WebSocket, 'OPEN', { value: 1, });

connection.start();

connection.on("ChangeNotif", function () {
    GetNotifications();
});

$(document).ready(function () {
    GetNotifications();
});

$(document).on('click', '#AllNotification', function () {
    $('.userNotif').empty();
    GetNotifications();
});

function GetNotifications() {
    $('.userNotif').empty();
    $.ajax({
        url: '/service/notifications',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            count = data.count;
            notif = data.notifications;
            $('.notifCount').text(count);
            drawNotifications();
        }
    });
}

function drawNotifications() {
    var divHTML = '';

    if (count == 0) {
        divHTML += `<div class="tab-pane active p-3 text-center">
                <h5 class="mt-4 pt-4 fw-500">
                    <span class="d-block fa-3x pb-4 text-muted">
                        <i class="ni ni-arrow-up text-gradient opacity-70"></i>
                    </span> Tidak ada pesan
                    <small class="mt-3 fs-b fw-400 text-muted">
                        Belum ada notifikasi untuk ditampilkan                        
                    </small>
                </h5>
            </div>`;

        $('.userNotif').append(divHTML);
    } else {
        divHTML += `<div class="tab-pane active" id="tab-messages" role="tabpanel">
                        <div class="custom-scroll h-100">
                            <ul class="notification">`;
        $.each(notif, function (i, item) {
            if (item.isRead) {
                divHTML += `<li>
                            <a href="${item.href}" class="d-flex align-items-center">
                                <span class="status status-danger mr-2">
                                    <span class="profile-image rounded-circle d-inline-block" style="background-image:url('/img/truck.png')"></span>
                                </span>
                                <span class="d-flex flex-column flex-1 ml-1">
                                    <span class="name">${item.title}</span>
                                    <span class="msg-a fs-sm">${item.subTitle}</span>
                                    <span class="msg-b fs-xs">${item.content}</span>                                    
                                </span>
                            </a>
                        </li>`;                
            } else {
                divHTML += `<li class="unread">
                            <a href="${item.href}" class="d-flex align-items-center">
                                <span class="status status-danger mr-2">
                                    <span class="profile-image rounded-circle d-inline-block" style="background-image:url('/img/truck.png')"></span>
                                </span>
                                <span class="d-flex flex-column flex-1 ml-1">
                                    <span class="name">${item.title}<span class="badge badge-primary fw-n position-absolute pos-top pos-right mt-1">Unread</span></span>
                                    <span class="msg-a fs-sm">${item.subTitle}</span>
                                    <span class="msg-b fs-xs">${item.content}</span>                                    
                                </span>
                            </a>
                        </li>`;
            }
                      
        });

        divHTML += `</ul>
                    </div>
                    </div>`

        $('.userNotif').append(divHTML);
    }
}
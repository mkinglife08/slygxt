$(function () {
    //Msg Init
    var proxy = $.connection.msgHub;
    $.connection.hub.qs = { "UserId": cookie.GetEMRUserCookie("api_token", "UserId"), "DpetId": cookie.GetEMRUserCookie("api_token", "DpetId") };
    proxy.client.getMsg = function (mType, id, msg) {
        openMsgPop()
    };
    $.connection.hub.start();
});
//打开消息弹窗
function openMsgPop() {
    if (parseInt($('#msg_count').html()) > 0) {
        layer.open({
            type: 2,
            shade: [0],
            shadeClose: true,
            anim: 2,
            resize: false,
            title: '消息提醒',
            content: __curHostAddress + 'page/DoctorPages/ConsultationPop',
            btn: [],
            area: ['800px', '380px'],
            offset: 'rb', //右下角弹出
            success: function (layero, index) {
                var t = setTimeout(function () {
                    layer.close(index);
                }, 5000);
                layero.on('mouseenter', function () {
                    clearTimeout(t);
                }).on('mouseleave', function () {
                    t = setTimeout(function () {
                        layer.close(index);
                    }, 5000);
                });
            }
        });
    } else {
        layer.msg("当前没有可读消息", { icon: 5 });
    }
}
//parameter - 'add' - when plus 1:true; when minus 1:false
function MsgCount(add) {
    var mIcon = $('#msgs i');
    var mc = $('#msg_count');
    var cnt = mc.html();
    if (cnt == "") cnt = "0";
    if (add) {
        cnt = (parseInt(cnt) + 1) + "";
    }
    else {
        if (parseInt(cnt) - 1 < 1) {
            cnt = "0";
        }
        else {
            cnt = (parseInt(cnt) - 1) + "";
        }
    }
    mc.html(cnt);
    if (cnt == "0") {
        mIcon.removeClass('m-animate-shake');
        mc.hide();
    }
    else {
        if (!mIcon.hasClass('m-animate-shake')) mIcon.addClass('m-animate-shake');
        mc.show();
    }
}
//display new message number
function MsgRecount(msgCount) {
    $('#msg_count').html(msgCount + '');
    if (msgCount > 0) {
        $('#msgs i').addClass('m-animate-shake');
        $('#msg_count').fadeIn();
        openMsgPop();
    }
    else {
        $('#msgs i').removeClass('m-animate-shake');
        $('#msg_count').fadeOut();
    }
}
//get new msg count from db
function getNewMsgCnt() {
    EWinsBase.json("api/Doctor/Consultation/GetConsulationCountByUser", {
        type: "POST",
        dataType: "json",
        success: function (config, data) {
            MsgRecount(data.data);
        }
    });
}

var Common = {};
//操作提示方法,不建议由AjaxHelper直接调用
Common.Tips = function (result,callback) {
    var show_time = 3;
    var icon = result.Res ? 'succeed' : 'warning';
    $.dialog({ icon: icon, content: result.Msg, time: show_time, cancel: callback });
}
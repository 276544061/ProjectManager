var App = {};
App.SaveSuccess=function(data) {
    Common.SuccessTip(data.Msg);
}
App.CreateModule=function() {
    $.dialog.open('/Module/SimpleAdd', {
        title: '添加模块', width: 470, height: 140,
        close: function () {
            App.LoadModules();
        }
    });
}
App.CreateArea = function () {
    $.dialog.open('/Area/Add', {
        title: '添加区域', width: 470, height: 140,
        close: function () {
            App.LoadAreas();
        }
    });
}
App.LoadModules = function () {
    var tip = $('#ModuleName');
    var tmp = tip.val();
    $.ajax({
        url: '/Module/load',
        type: 'post',
        cache: false,
        dataType: 'json',
        async:false,
        success:function(d) {
            tip.empty();
            for (var i = 0; i < d.Data.length; i++) {
                tip.append("<option value=\"" + d.Data[i].ID + "\">" + d.Data[i].Name + "</option>");
            }
            tip.val(tmp);
        }
    });
}
App.LoadAreas = function () {
    var tip = $('#AreaName');
    var tmp = tip.val();
    $.ajax({
        url: '/Area/load',
        type: 'post',
        cache: false,
        dataType: 'json',
        async: false,
        success: function (d) {
            tip.empty();
            for (var i = 0; i < d.Data.length; i++) {
                tip.append("<option value=\"" + d.Data[i].ID + "\">" + d.Data[i].Name + "</option>");
            }
            tip.val(tmp);
        }
    });
}
App.UM = UM.getEditor('container', {
    initialFrameWidth: 539,
    initialFrameHeight: 300,
    toolbar: [
        'bold italic underline strikethrough | superscript subscript | forecolor backcolor | removeformat |',
        'insertorderedlist insertunorderedlist',
        '| justifyleft justifycenter justifyright justifyjustify |',
        'link unlink ']
});
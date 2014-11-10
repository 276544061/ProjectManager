var App = {};
App.SaveSuccess = function (data) {
    Common.Tips(data);
}
App.Delete = function (data) {
    //删除成功
    if (data.Res) {
        Common.Tips(data, function() {
            location.reload();
        });
    }else if (!data.Res) {
        Common.Tips(data);
    }
}
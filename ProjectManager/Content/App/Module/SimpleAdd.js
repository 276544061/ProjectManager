var App = {};
App.SaveSuccess = function (data) {
    Common.Tips(data, function () { $.dialog.close(); });
}
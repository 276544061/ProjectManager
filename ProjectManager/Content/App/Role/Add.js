var App = {};
App.SaveSuccess = function (data) {
    if (data.Res) {
        document.forms[0].reset();
    }
    Common.Tips(data);
}

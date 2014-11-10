var App = {};
var setting = {
    data: {
        key: {
            name: "Name"
        },
        simpleData: {
            enable: true,
            idKey: 'ID',
            pIdKey: 'Pid'
        }
    },
    callback: {
        onClick: function (event, treeId, treeNode, clickFlag) {
            $("#ID").val(treeNode['ID']);
            $('#Pid').val(treeNode['Pid'] == null ? 0 : treeNode['Pid']);
            $('#Name').val(treeNode['Name']);
            $('#GroupID').val(treeNode['GroupID']);
            $('#Link').val(treeNode['Link']);
            $('#SortNo').val(treeNode['SortNo']);
        }
    }
};
App.Delete = function () {
    $.post("/Node/Delete", { id: $('#ID').val() }, function (data) {
        App.InitTree();
        document.forms['form1'].reset();
        Common.Tips(data);
    });
}
App.SaveSuccess = function (data) {
    App.InitTree();
    document.forms['form1'].reset();
    Common.Tips(data);
}
App.InitTree = function () {
    $.getJSON('/Node/GetNode', function (data) {
        for (var i = 0; i < data.length; i++) {
            data[i].open = true;
        }
        var tree = $.fn.zTree.getZTreeObj("ztree");
        if (null != tree) {
            tree.destroy();
        }
        $.fn.zTree.init($("#ztree"), setting, data);
    });
}

$(document).ready(function () {
    App.InitTree();
})

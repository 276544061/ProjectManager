var App = {};
var setting = {
    check: {
        enable: true
    },
    data: {
        key: {
            name: "Name"
        },
        simpleData: {
            enable: true,
            idKey: 'ID',
            pIdKey: 'Pid'
        }
    }
};
App.Save = function () {
    var tree = $.fn.zTree.getZTreeObj("ztree");
    var nodes = tree.getCheckedNodes(true);
    var ns = '';
    for (var i = 0; i < nodes.length; i++) {
        ns += nodes[i]['ID'] + ',';
    }
    $.post('/Role/SaveAccess', {role_id:$("#ID").val(),node:ns},function(data) {
        Common.Tips(data);
    })
    //App.InitTree();
    //document.forms['form1'].reset();
    //Common.Tips(data);
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
        App.InitAccess();
    });
}
App.InitAccess = function () {
    var tree = $.fn.zTree.getZTreeObj("ztree");
    $.getJSON('/Role/GetAccess', { id: $("#ID").val() }, function (data) {
        tree.cancelSelectedNode();
        for (var i = 0; i < data.length; i++) {
            var node = tree.getNodeByParam('ID', data[i].NodeID, null);
            tree.checkNode(node, true, true);
        }
    });
}

$(document).ready(function () {
    App.InitTree();
})

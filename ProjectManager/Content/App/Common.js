var Common = {};
Common.Init=function() {
    Common.Menu();
}
//操作提示方法,不建议由AjaxHelper直接调用
Common.Tips = function (result,callback) {
    var show_time = 2;
    var icon = result.Res ? 'succeed' : 'warning';
    $.dialog({ icon: icon, content: result.Msg, time: show_time, cancel: callback });
}

Common.Menu=function() {
    /* 一级导航 */
    var topMenu = $(".m-menu ul li");
    topMenu.click(function () {
        var aSel = $(this).attr('selected');
        if (aSel != 'selected') {
            topMenu.removeAttr('selected').removeClass('z-crt');
            $(this).addClass("z-crt").attr("selected", "selected");
        } else {
            topMenu.removeAttr('selected').removeClass('z-crt');
        }
        var dataGroup = $(this).children('a').first().attr('data-group');
        $('.scdli').removeClass('z-hide').addClass('z-hide');
        $('.scdli[data-group="' + dataGroup + '"]').removeClass('z-hide');
    });
    /* /一级导航 */

    /* 左侧导航 */
    var firstMenu = $(".fst");
    var secondMenu = $('.scd');
    var secondMenuli = $('.scd li a');
    firstMenu.click(function () {
        var aSel = $(this).attr('selected');
        if (aSel != 'selected') {
            secondMenu.slideUp();
            $(this).siblings(".scd").slideToggle();
            firstMenu.removeAttr('selected').removeClass('z-crt');
            $(this).addClass("z-crt").attr("selected", "selected");
        } else {
            $(this).siblings(".scd").slideUp(function () {
                firstMenu.removeAttr('selected').removeClass('z-crt');
            });
        }
    });
    secondMenuli.click(function () {
        var aSel = $(this).attr('selected');
        if (aSel != 'selected') {
            secondMenuli.removeAttr('selected').removeClass('z-crt');
            $(this).addClass("z-crt").attr("selected", "selected");
        } else {
            $(this).siblings(".scd").slideUp(function () {
                secondMenuli.removeAttr('selected').removeClass('z-crt');
            });
        }
    });
    /* /左侧导航 */
}

$(document).ready(function() {
    Common.Init();
});

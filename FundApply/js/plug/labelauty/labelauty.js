
; (function ($) {
    /**
     * 扩展复选框，注入easyui datatable组件，
     * 扩展datatable组件列的自定义显示隐藏功能。
     * By： 李科笠 2016年4月28日 17:29:52
     * @param {} tag 目标容器
     * @param {} tag2 单选或者多选 【check，rdo】
     * @param {} func1 取消选中 执行的方法
     * @param {} func2 选中 执行的方法
     * @returns {} 
     */
    $.fn.labelauty = function (tag, tag2, func1,func2) {
        //判断是否选中
        rdochecked(tag);
        //单选or多选
        if (tag2 == "rdo") {
            //单选
            $(".rdobox").click(function () {
                $(this).prev().prop("checked", "checked");
                rdochecked(tag);
            });
        } else {
            //多选
            $(".chkbox").click(function () {
                //禁止按钮
                if ($(this).attr("class").indexOf("disabled")>=0) {
                    return;
                }
                if ($(this).prev().prop("checked") == true) {
                    $(this).prev().removeAttr("checked");
                }
                else {
                    $(this).prev().prop("checked", "checked");
                }
                rdochecked(tag);
            });
        }

        //判断是否选中
        function rdochecked(tag) {
            $('.' + tag).each(function (i) {
                var rdobox = $('.' + tag).eq(i).next();
                if ($('.' + tag).eq(i).prop("checked") == false) {
                    rdobox.removeClass("checked");
                    rdobox.addClass("unchecked");
                    rdobox.find(".check-image").css("background", "url(/js/plug/labelauty/images/input-unchecked.png)");
                }
                else {
                    rdobox.removeClass("unchecked");
                    rdobox.addClass("checked");
                    rdobox.find(".check-image").css("background", "url(/js/plug/labelauty/images/input-checked.png)");
                }
            });
        }

        //单击按钮事件
        $(".chkbox").click(function () {
            if ($(this).prev().attr("class").indexOf("disabled") >= 0) {
                return;
            }
            if ($(this).prev().prop('checked')) {
                if ($(this).attr("class").indexOf("disabled") >= 0) { return; }//禁止按钮
                func1($(this));
            } else {
                if ($(this).attr("class").indexOf("disabled") >= 0) { return; }//禁止按钮
                func2($(this));
            }
        });
    }

}(jQuery));


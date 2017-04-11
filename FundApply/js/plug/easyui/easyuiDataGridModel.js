;(function($) {
    var taget = $.CBD.EasyUI.DataTable;
    var defaultOption = {
        targetTale: "",
        data: [],
        columns: []
    };

    taget.NormalTable = function (option) {
        defaultOption.targetTale.datagrid({
            data: defaultOption.data,
            remoteSort: false,
            singleSelect: true,
            onLoadSuccess: function(data) {
                var thisfield = $(this).datagrid('options').columns[0][0].field;
                console.debug(thisfield);
                if (data.total === 0) {
                    $(this).datagrid('appendRow',
                        { INDUSTRY_MTYPE_NAME: '<div style="text-align:center;color:red">没有符合条件的相关记录！</div>' })
                        .datagrid('mergeCells', { index: 0, field: 'INDUSTRY_MTYPE_NAME', colspan: 3 });
                    $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').hide();
                } else {
                    $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').show();
                };
            },
            columns: defaultOption.columns
        });
    };
})(jQuery);
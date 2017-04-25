<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseList.aspx.cs" Inherits="FundApply.Project_FGW.Statistics.Checked.EnterpriseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../../css/style.css" rel="stylesheet" />
    <link href="../../../../css/buttons.css" rel="stylesheet" />
    <link href="../../../../easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../../../easyui/themes/icon.css" rel="stylesheet" />
    <script src="../../../../easyui/jquery.min.js"></script>
    <script src="../../../../easyui/jquery.easyui.min.js"></script>
    <script src="../../../../js/plug/layer/Jquery.CBD.js"></script>
    <style>
        .datagrid-header .datagrid-cell span {
            font-size: 14pX;
            font-weight: bold;
        }

        .datagrid-cell {
            font-size: 14pX;
        }

        label {
            font-size: 16px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left;">
            <div style="margin-bottom: 10px; font-size: 14px;">
                单位名称：<input />
                <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">查询</button>
                <div style="margin-bottom: 10px; margin-right: 15px; font-size: 14px; float: right;">
                    <button class="button button-primary button-pill button-tiny" type="button" onclick="Close();">返回</button>
                </div>
            </div>
        </div>
        <div>
            <table id="dg1" style="width: 98%;"></table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function Close() {
        $("body", window.parent.document).css("overflow-y", "scroll");
        parent.layer.closeAll();
    }

    $(function () {
        $("body", window.parent.document).css("overflow-y", "hidden")
        $('#dg1').datagrid({
            rownumbers: true,
            //url: '/SysUser/GetList',
            methord: 'post',
            sortName: 'Id',
            sortOrder: 'desc',
            idField: 'Id',
            pageSize: 15,
            pageList: [15, 20, 30, 40, 50],
            pagination: true,
            striped: true, //奇偶行是否区分
            singleSelect: true,//单选模式
            frozenColumns:
            [
                [
                    {
                        field: 'applytype',
                        title: '申报类型',
                        width: 110,
                        align: 'left'
                    },
                    {
                        field: 'natorgcode',
                        title: '组织机构代码',
                        width: 110,
                        align: 'left'
                    },
                    {
                        field: 'orgname',
                        title: '单位名称',
                        width: 290,
                        align: 'center',
                        formatter: function (value, row, index) {
                            return "<div class='tXtleft'>" + row.orgname + "</div>";
                        }
                    }
                ]
            ],
            columns: [[
                        { field: 'captialok', title: '已申请资金', align: 'right', width: 80 },
                        { field: 'status', title: '审核状态', align: 'left', width: 80 },
                        { field: 'captial', title: '支持资金', align: 'right', width: 80 },
                        { field: 'applytime', title: '审核时间', align: 'left', width: 80 },
                        { field: 'yysr', title: '上年营业收入', align: 'right', width: 80 },
                        { field: 'tax', title: '上年税收数额', align: 'right', width: 80 },
                        { field: 'industry', title: '所属行业', align: 'left', width: 80 },
                        { field: 'yuangong', title: '员工数量', align: 'right', width: 80 },
                        { field: 'address', title: '注册地址', align: 'left', width: 80 }
            ]],
            data: {
                "total": 10, "rows":
                [
                    { "applytype": "金融资金", "natorgcode": "MA0014BR4", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    //{ "applytype": "金融资金", "natorgcode": "MA001DEU2", "orgname": "", "captialok": 200.00, "status": "待审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    //{ "applytype": "金融资金<label style='color:red;'>*</label>", "natorgcode": "556849245", "orgname": "", "captialok": 200.00, "status": "退回修改", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "MA001DEU2", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "761449531", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "MA0014BR4", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "MA001DEU2", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "556849245", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "MA001DEU2", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" },
                    { "applytype": "金融资金", "natorgcode": "761449531", "orgname": "", "captialok": 200.00, "status": "已审核", "yysr": 1000, "tax": 500, "industry": "金融业" }
                ]
            },
            onClickRow: function (index, row) {
                CBD.openNewPage('ApplyProject.aspx', { orgCode: row.NAT_ORG_CODE });
            }
        });
    });
</script>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProjectList.aspx.cs" Inherits="FundApply.Project_CYB.Index.ApplyProjectList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" />
    <link href="../../../css/buttons.css" rel="stylesheet" />
    <link href="../../../easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../../easyui/themes/icon.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../easyui/jquery.min.js"></script>
    <script src="../../../easyui/jquery.easyui.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <script src="../../../js/plug/layer/Jquery.CBD.js"></script>
    <script src="../../js/plug/layer/Jquery.CBD.js"></script>
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
                单位名称：<input  id="txtCompany"/>
                <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">查询</button>
                <div style="margin-bottom: 10px; margin-right: 15px; font-size: 14px; float: right;">
                    <button class="button button-primary button-pill button-tiny" type="button" onclick="javascript:parent.layer.closeAll();">返回</button>
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
    //var time1 = new Date().Format("yyyy-MM-dd");
    //alert("2016-15-05 11:21:25".Format("yyyy-MM-dd"));
    $(function () {
        var $data = { company: $('#txtCompany').val() };
        CBD.ajaxData($data, '<%=Request.Path%>/GetApplyProjectList', function (jsondata) {
            $('#dg1').datagrid({
                rownumbers: true,
                data: jsondata,
                rownumbers: true,
                remoteSort: false,
                singleSelect: true, fitColumns: true,
                ////methord: 'post',
                ////sortName: 'Id',
                ////sortOrder: 'desc',
                ////idField: 'Id',
                ////pageSize: 15,
                ////pageList: [15, 20, 30, 40, 50],
                ////pagination: true,
                striped: true, //奇偶行是否区分
                ////singleSelect: true,//单选模式
                frozenColumns:
                 [
                     [
                         {
                             field: 'ApplyTypeId_BigName',
                             title: '申报类型',
                             width: 110,
                             align: 'left'
                         },
                         {
                             field: 'Nat_Org_Code',
                             title: '组织机构代码',
                             width: 110,
                             align: 'left'
                         },
                         {
                             field: 'Company',
                             title: '单位名称',
                             width: 290,
                             align: 'left'
                         }
                     ]
                 ],
                columns: [[
                            { field: 'ApplyFund', title: '已申请资金', align: 'right', width: 80 },
                            { field: 'ProjectState', title: '审核状态', align: 'left', width: 80 },
                            { field: 'ApprovalFund', title: '支持资金', align: 'right', width: 80 },
                            {
                                field: 'UpdateTime', title: '审核时间', align: 'left', width: 80,
                                formatter: function (value, row, index) {
                                    return value.substring(0, 10);
                                }
                            },
                            { field: 'YYSR', title: '上年营业收入', align: 'right', width: 80 },
                            { field: 'TAX', title: '上年税收数额', align: 'right', width: 80 },
                            { field: 'IndustryName', title: '所属行业', align: 'left', width: 80 },
                            { field: 'Employee', title: '员工数量', align: 'right', width: 80 },
                            { field: 'RegAddress', title: '注册地址', align: 'left', width: 80 }
                ]],
                onClickRow: function (index, row) {
                    CBD.openNewPage('ApplyProject.aspx', { Nat_Org_Code: row.Nat_Org_Code });
                }
            });
        });       
    });    
</script>


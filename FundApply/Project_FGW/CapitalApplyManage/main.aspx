<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_FGW.CapitalApplyManage.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>历年资金申报情况</label>&nbsp;&nbsp;
            <button class="button button-primary button-pill button-tiny" type="button" onclick="AddCapitalApply()">添加</button>
        </div>
        <table class="gridtable">
            <tr>
                <th>序号</th>
                <th>产业资金申请</th>
                <th>申报开始时间</th>
                <th>申报结束时间</th>
                <th>审核单位数</th>
                <th>审核资金（万元）</th>
                <th>操作</th>
            </tr>
            <tr>
                <td>1</td>
                <td onclick="CapitalApplyHistory('2016上半年')" style="cursor: pointer;">2016上半年</td>
                <td>2017-03-01</td>
                <td>2017-06-01</td>
                <td>500</td>
                <td>2500</td>
                <td onclick="EditCapitalApply()" style="cursor: pointer;">修改</td>
            </tr>
            <tr>
                <td>2</td>
                <td onclick="CapitalApplyHistory('2016下半年')" style="cursor: pointer;">2016下半年</td>
                <td>2016-03-01</td>
                <td>2016-06-01</td>
                <td>500</td>
                <td>2500</td>
                <td onclick="EditCapitalApply()" style="cursor: pointer;">修改</td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript">
    function CapitalApplyHistory(date) {
        layer.open({
            type: 2,
            closeBtn: 0,
            title: false,
            maxmin: false, shadeClose: false,
            shade: false, maxmin: false,
            area: ['100%', '100%'],
            content: '../Index/main.aspx'
        });
    }

    //添加资金申请管理信息
    function AddCapitalApply() {
        layer.open({
            type: 2,
            title: '添加资金申请信息',
            shadeClose: true,
            shade: false,
            area: ['360px', '200px'],
            content: 'AddCapitalApply.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }
    //修改资金申请管理信息
    function EditCapitalApply() {
        layer.open({
            type: 2,
            title: '编辑资金申请信息',
            shadeClose: true,
            shade: false,
            area: ['360px', '200px'],
            content: 'EditCapitalApply.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }

    //查看资金申请管理信息
    function SearchCapitalApply() {
        layer.open({
            type: 2,
            title: '资金申请信息',
            shadeClose: true,
            shade: false,
            area: ['360px', '200px'],
            content: 'CapitalApplyDetails.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }
</script>

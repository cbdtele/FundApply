<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditApplyTime.aspx.cs" Inherits="FundApply.Project_CYB.Index.EditApplyTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../css/style.css" rel="stylesheet" />--%>
    <link href="../../css/buttons.css" rel="stylesheet" />
    <link href="../../easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../easyui/themes/icon.css" rel="stylesheet" />
    <script src="../../easyui/jquery.min.js"></script>
    <script src="../../easyui/jquery.easyui.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/layui.js"></script>
    <script src="../../js/plug/My97DatePicker/WdatePicker.js"></script>

    <style>
        body {
            overflow-x: hidden;
            overflow-y: hidden;
        }

        table tr td {
            height: 30px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form>
        <div style="margin:20px 40px 20px 40px">
        <table>
            <tr>
                <td>申报开始时间：</td>
                <td>
                    <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true})" /></td>
            </tr>
            <tr>
                <td>申报结束时间</td>
                <td>
                    <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true})" /></td>
            </tr>
            <tr style="height: 60px; width: 300px;">
                <td colspan="2" style="text-align: center;">
                    <button class="button button-primary button-pill button-tiny" type="button" onclick="Submit()">修改</button>
                    <button class="button button-primary button-pill button-tiny" type="button" onclick="Close()">取消</button>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">

    function Close() {
        parent.layer.closeAll();
    }
    //提交
    function Submit(name, type) {
        layer.confirm('您是确定要提交吗？', {
            btn: ['确定', '取消']
        }, function () {
            layer.msg('已提交！', { icon: 1 }, function () {
                parent.layer.closeAll();
                //location.href = "/Project_Entprise/main.aspx";
            });
        });
    }
</script>

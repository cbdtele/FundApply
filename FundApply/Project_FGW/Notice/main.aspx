<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_FGW.Notice.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
        <style>
        a {
            color:blue;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>历年公告情况</label>&nbsp;&nbsp;
            <button class="button button-primary button-pill button-tiny" type="button" onclick="AddNotice()">添加</button>
        </div>
        <table class=" gridtable">
            <tr>
                <th>序号</th>
                <th>标题</th>
                <th>发布时间</th>
                <th>发布状态</th>
                <th>操作</th>
            </tr>
            <tr>
                <td>1</td>
                <td>测试标题test1</td>
                <td>2017-03-29</td>
                <td>已发布</td>
                <td><a href="javascript:void(0);" onclick="SearchNotice();">查看</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>测试标题test2</td>
                <td>2017-03-30</td>
                <td>未发布</td>
                 <td><a href="javascript:void(0);" onclick="EditNotice();">编辑</a></td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript">
    //添加公示信息
    function AddNotice() {
        layer.open({
            type: 2,
            closeBtn: 0,
            title: false,
            maxmin: false, shadeClose: false,
            shade: false, maxmin: false,
            area: ['100%', '100%'],
            content: 'AddNotice.aspx'
        });
    }
    //修改公示信息
    function EditNotice() {
        layer.open({
            type: 2,
            closeBtn: 0,
            title: false,
            maxmin: false, shadeClose: false,
            shade: false, maxmin: false,
            area: ['100%', '100%'],
            content: 'EditNotice.aspx'
        });
    }
    //查看公示信息
    function SearchNotice() {
        layer.open({
            type: 2,
            closeBtn: 0,
            title: false,
            maxmin: false, shadeClose: false,            
            shade: false,maxmin: false, 
            area: ['100%', '100%'],
            content: 'NoticeDetails.aspx'
        });
    }
</script>

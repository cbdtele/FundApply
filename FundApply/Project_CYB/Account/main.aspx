<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_CYB.Account.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/buttons.css" rel="stylesheet" />
    <link href="../../css/style.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/layui.js"></script>
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
    <style>
        .layui-input {
            width: 95% !important;
        }

        .dvlayui label {
            font-size: 14px;
        }

        .layui-form-label {
            width: 100px !important;
        }

        .layui-input-block {
            margin-left: 130px !important;
            min-height: 45px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>
                修改账户信息                                
            </label>
        </div>
        <div style="text-align: center;">
            <label class="layui-form-label">用户名 </label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入用户名" class="layui-input" />
            </div>
            <label class="layui-form-label">密码</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入密码" class="layui-input" />
            </div>
            <label class="layui-form-label">邮箱</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input" />
            </div>
            <div style="text-align: center; margin-top: 10px;">
                <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">修改</button>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    //配置layui
    $(function () {
        var from = layui.form(), layer = layui.layer;
    });
</script>

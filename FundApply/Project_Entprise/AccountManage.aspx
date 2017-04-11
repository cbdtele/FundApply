<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountManage.aspx.cs" Inherits="FundApply.Project_Entprise.AccountManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../css/style.css" rel="stylesheet" />--%>
    <link href="../css/buttons.css" rel="stylesheet" />
    <link href="../easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../easyui/themes/icon.css" rel="stylesheet" />
    <script src="../easyui/jquery.min.js"></script>
    <script src="../easyui/jquery.easyui.min.js"></script>
    <script src="../js/plug/layer/layer.js"></script>
    <link href="../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../css/plug/layui/layui.js"></script>
    <script src="../css/plug/layui/lay/dest/layui.all.js"></script>
    <style>
        body {
            font-size:9pt;
        }
        /*body {
            width:400px;
            overflow-x: hidden;
            overflow-y: hidden;
        }*/

        /*table tr td {
            font-size: 9pt;
        }*/
    </style>
</head>
<body>
    <%--    <div class="rightinfo" id="div_content">--%>
    <form id="form1" runat="server">
        <div class="layui-tab">
            <ul class="layui-tab-title">
                <li class="layui-this">修改账户信息</li>
                <li>修改密码</li>
            </ul>
            <div class="layui-tab-content">
                <div class="layui-tab-item layui-show">
                    <label class="layui-form-label">组织机构代码 </label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input">
                    </div>
                    <label class="layui-form-label">单位名称</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入单位名称" class="layui-input">
                    </div>
                    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                        <legend>联系方式一</legend>
                    </fieldset>
                    <label class="layui-form-label">联系人</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入联系人" class="layui-input">
                    </div>
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入手机" class="layui-input">
                    </div>
                    <label class="layui-form-label">固定电话</label>
                    <div class="layui-input-block">
                        <input id="phone" type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入固定电话" class="layui-input">
                    </div>
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input">
                    </div>

                    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                        <legend>联系方式二</legend>
                    </fieldset>
                    <label class="layui-form-label">联系人</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入联系人" class="layui-input">
                    </div>
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入手机" class="layui-input">
                    </div>
                    <label class="layui-form-label">固定电话</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入固定电话" class="layui-input">
                    </div>
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-block">
                        <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input">
                    </div>

                    <label class="layui-form-label">账号密码</label>
                    <div class="layui-input-block">
                        <input id="password" type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入账号密码" class="layui-input">
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">修改</button>
                        <button class="button button-primary button-pill button-tiny" type="button" onclick="Close()">取消</button>
                    </div>
                </div>
                <div class="layui-tab-item">
                    <div style="text-align: center;">
                        <label class="layui-form-label">用户名 </label>
                        <div class="layui-input-block">
                            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入用户名" class="layui-input">
                        </div>
                        <label class="layui-form-label">密码</label>
                        <div class="layui-input-block">
                            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入密码" class="layui-input">
                        </div>
                        <label class="layui-form-label">邮箱</label>
                        <div class="layui-input-block">
                            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input">
                        </div>
                        <div style="text-align: center; margin-top: 10px;">
                            <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">修改</button>
                            <button class="button button-primary button-pill button-tiny" type="button" onclick="Close()">取消</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%--</div>--%>
</body>
</html>
<script type="text/javascript">
    //配置layui
    $(function () {
        var from = layui.form(), layer = layui.layer;
    });

    function Close() {
        parent.layer.closeAll();
    }
    $(function () {

        $("#phone").keyup(function () {
            var phone = $("#phone").val();
            console.log(phone);
            $("#password").val(phone);
        });

    });
</script>

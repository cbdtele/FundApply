<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_Entprise.UserInfo.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/plug/layer/layer.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/layui.js"></script>
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
    <style type="text/css">
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
                修改用户信息                                
            </label>
        </div>
        <label class="layui-form-label">组织机构代码 </label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input" id="Nat_Org_Code" runat="server" readonly="readonly"/>
        </div>
        <label class="layui-form-label">单位名称</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="Company" runat="server"  readonly="readonly"/>
        </div>
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            <legend>联系方式一</legend>
        </fieldset>
        <label class="layui-form-label">联系人</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入联系人" class="layui-input" id="LinkMan1" runat="server"/>
        </div>
        <label class="layui-form-label">手机</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入手机" class="layui-input" id="MobilePhone1" runat="server"/>
        </div>
        <label class="layui-form-label">固定电话</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入固定电话" class="layui-input" id="Telephone1" runat="server"/>
        </div>
        <label class="layui-form-label">邮箱</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input" id="Email1" runat="server"/>
        </div>

        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            <legend>联系方式二</legend>
        </fieldset>
        <label class="layui-form-label">联系人</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入联系人" class="layui-input" id="LinkMan2" runat="server"/>
        </div>
        <label class="layui-form-label">手机</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入手机" class="layui-input" id="MobilePhone2" runat="server"/>
        </div>
        <label class="layui-form-label">固定电话</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入固定电话" class="layui-input" id="Telephone2" runat="server"/>
        </div>
        <label class="layui-form-label">邮箱</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入邮箱" class="layui-input" id="Email2" runat="server"/>
        </div>

        <label class="layui-form-label">账号密码</label>
        <div class="layui-input-block">
            <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入账号密码" class="layui-input" id="Password" runat="server"/>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <asp:Button  CssClass="button button-primary button-pill button-tiny" Text="修改" runat="server"  ID="Modify" OnClick="Modify_Click"/>
            <%--<button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()" id="Modify" runat="server">修改</button>--%>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        var from = layui.form(), layer = layui.layer;
    });
</script>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="FundApply.Project_Entprise.ProjectDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <script src="../../css/plug/layui/layui.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <style>
        label {
            font-size: 14px;
        }

        .layui-form-label {
            padding: 3px 0px;
            width: 100px;
        }

        .layui-input-block {
            margin-left: 100px;
            min-height: 26px;
        }

        .layui-form-item {
            margin-bottom: 0px;
            /*clear: both;*/
        }

        .layui-input {
            height: 28px;
            border-width: 0px;
        }
    </style>
</head>
<body>
    <div style="padding: 2px 100px 5px 100px">
        <form class="layui-form" runat="server">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>基本信息</legend>
            </fieldset>
            <label class="layui-form-label">组织机构代码 </label>
            <div class="layui-input-block">
                <input type="text" name="Nat_Org_Code" lay-verify="Nat_Org_Code" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input" id="txtNat_Org_Code" runat="server" readonly="readonly" />
            </div>
            <label class="layui-form-label">单位名称</label>
            <div class="layui-input-block">
                <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="txtCompany" runat="server" readonly="readonly" />
            </div>
            <label class="layui-form-label">所属行业</label>
            <div class="layui-input-block">
                <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="drpIndustryId" runat="server" />
            </div>
            <label class="layui-form-label">上年营业收入</label>
            <div class="layui-input-block">
                <input type="text" name="YYSR" lay-verify="YYSR" autocomplete="off" placeholder="请输入上年营业收入" class="layui-input" id="txtYYSR" runat="server" />
            </div>
            <label class="layui-form-label">上年税收总额</label>
            <div class="layui-input-block">
                <input type="text" name="TAX" lay-verify="TAX" autocomplete="off" placeholder="请输入上年税收总额" class="layui-input" id="txtTAX" runat="server" />
            </div>
            <label class="layui-form-label">员工人数</label>
            <div class="layui-input-block">
                <input type="text" name="Employee" lay-verify="Employee" autocomplete="off" placeholder="请输入员工人数" class="layui-input" id="txtEmployee" runat="server" />
            </div>
            <label class="layui-form-label">注册地址</label>
            <div class="layui-input-block">
                <input type="text" name="RegAddress" lay-verify="RegAddress" autocomplete="off" placeholder="请输入注册地址" class="layui-input" id="txtRegAddress" runat="server" />
            </div>
            <label class="layui-form-label">经营地址</label>
            <div class="layui-input-block">
                <input type="text" name="BusinessAddress" lay-verify="BusinessAddress" autocomplete="off" placeholder="请输入经营地址" class="layui-input" id="txtBusinessAddress" runat="server" />
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">申请类型</label>
                <div class="layui-input-inline">
                    <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="drpApplyTypeBig" runat="server" />
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="drpApplyTypeSmall" runat="server" />
                </div>
            </div>
            <label class="layui-form-label">申请资金</label>
            <div class="layui-input-block">
                <input type="text" name="ApplyFund" lay-verify="ApplyFund" autocomplete="off" placeholder="请输入申请资金" class="layui-input" id="txtApplyFund" runat="server" />
            </div>
            <label class="layui-form-label">申报材料</label>
            <div class="layui-input-block">
                <%--class="layui-upload-file" --%>
                <input type="text" name="Attachment" lay-verify="Attachment" class="layui-input" lay-title="上传文件" id="txtAttachment" runat="server" />
            </div>

            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>项目联系人</legend>
            </fieldset>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">姓名</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectLinkMan" lay-verify="ProjectLinkMan" autocomplete="off" placeholder="请输入姓名" class="layui-input" id="txtProjectLinkMan" runat="server" />
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">职位</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectPosition" lay-verify="ProjectPosition" autocomplete="off" placeholder="请输入职位" class="layui-input" id="txtProjectPosition" runat="server" />
                    </div>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectMobilPhone" lay-verify="phone" autocomplete="off" placeholder="请输入手机" class="layui-input" id="txtProjectMobilPhone" runat="server" />
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectEmail" lay-verify="email" autocomplete="off" placeholder="请输入邮箱" class="layui-input" id="txtProjectEmail" runat="server" />
                    </div>
                </div>
            </div>

            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>审核信息</legend>
            </fieldset>

            <div class="layui-form-item">
                <label class="layui-form-label">审核状态</label>
                <div class="layui-input-inline">
                    <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="通过" class="layui-input" />
                </div>
                <label class="layui-form-label">支持资金</label>
                <div class="layui-input-inline">
                    <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="100万" class="layui-input" />
                </div>
            </div>
            <label class="layui-form-label">审核时间</label>
            <div class="layui-input-inline">
                <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="2017-04-21" class="layui-input" />
            </div>
        </form>
        <div style="margin-top: 80px;"></div>
        <div style="text-align: center; padding: 5px">
            <button class="button button-primary button-pill button-tiny" type="button" onclick="javascript:parent.layer.closeAll();">取消</button>
        </div>
    </div>
</body>
</html>


<script type="text/javascript">
    $("input").attr("readonly", "readonly");
</script>

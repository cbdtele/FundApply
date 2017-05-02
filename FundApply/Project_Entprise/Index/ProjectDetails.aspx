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
    <form class="layui-fo0rm">
        <div style="padding: 2px 100px 5px 100px">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>基本信息</legend>
            </fieldset>
            <label class="layui-form-label">组织机构代码 </label>
            <div class="layui-input-block">
                <input type="text" name="Nat_Org_Code" lay-verify="Nat_Org_Code" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input" id="txtNat_Org_Code" readonly="readonly" />
            </div>
            <label class="layui-form-label">单位名称</label>
            <div class="layui-input-block">
                <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="txtCompany" readonly="readonly" />
            </div>
            <label class="layui-form-label">所属行业</label>
            <div class="layui-input-block">
                <input type="text" name="IndustryId" lay-verify="IndustryId" autocomplete="off" class="layui-input" id="txtIndustryId" readonly="readonly" />
<%--                <select id="txtIndustryId">
                </select>--%>
                <%--            <asp:DropDownList name="IndustryId" lay-verify="IndustryId" ID="drpIndustryId">
            </asp:DropDownList>--%>
            </div>
            <label class="layui-form-label">上年营业收入</label>
            <div class="layui-input-block">
                <input type="text" name="YYSR" lay-verify="YYSR" autocomplete="off" placeholder="请输入上年营业收入" class="layui-input" id="txtYYSR" />
            </div>
            <label class="layui-form-label">上年税收总额</label>
            <div class="layui-input-block">
                <input type="text" name="TAX" lay-verify="TAX" autocomplete="off" placeholder="请输入上年税收总额" class="layui-input" id="txtTAX" />
            </div>
            <label class="layui-form-label">员工人数</label>
            <div class="layui-input-block">
                <input type="text" name="Employee" lay-verify="Employee" autocomplete="off" placeholder="请输入员工人数" class="layui-input" id="txtEmployee" />
            </div>
            <label class="layui-form-label">注册地址</label>
            <div class="layui-input-block">
                <input type="text" name="RegAddress" lay-verify="RegAddress" autocomplete="off" placeholder="请输入注册地址" class="layui-input" id="txtRegAddress" />
            </div>
            <label class="layui-form-label">经营地址</label>
            <div class="layui-input-block">
                <input type="text" name="BusinessAddress" lay-verify="BusinessAddress" autocomplete="off" placeholder="请输入经营地址" class="layui-input" id="txtBusinessAddress" />
            </div>
            <label class="layui-form-label">纳税地址</label>
            <div class="layui-input-block">
                <input type="text" name="txtTaxAddress" lay-verify="txtTaxAddress" autocomplete="off" placeholder="请输入纳税地址" class="layui-input" id="txtTaxAddress" />
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">申请类型</label>
                <div class="layui-input-inline">
                    <input type="text" name="dl1" lay-verify="dl1" autocomplete="off" placeholder="请输入纳税地址" class="layui-input" id="dl1" />
   <%--                 <select id="dl1" onchange="GetCity(this.value)">
                    </select>--%>
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="ApplyTypeId" class="layui-input" id="txtApplyTypeId" />
<%--                    <select id="txtApplyTypeId" onchange="GetTable($(this).find('option:selected').attr('href'))">
                    </select>--%>
                </div>
                <div class="layui-input-inline">
                </div>
            </div>
            <label class="layui-form-label">申请资金</label>
            <div class="layui-input-block">
                <input type="text" name="ApplyFund" lay-verify="ApplyFund" autocomplete="off" placeholder="请输入申请资金" class="layui-input" id="txtApplyFund" />
            </div>

            <label class="layui-form-label">申报表</label>
            <div class="layui-input-block">
                <input type="file" name="txtApplyTable" id="txtApplyTable" />
                <button type="button" onclick="$('#txtApplyTable').uploadify('upload')">上传申报表</button>
                <button type="button"><a href="../../file/ApplyTable/cyb_1.docx" id="applyTable">下载申报表模板</a></button>
            </div>
            <label class="layui-form-label">其他申报材料</label>
            <div class="layui-input-block">
                <input type="file" name="txtAttachment" id="txtAttachment" />
                <button type="button" onclick="$('#txtAttachment').uploadify('upload')">上传申报材料</button>
            </div>
            <div class="layui-form-item layui-form-text">
                <label class="layui-form-label">备注</label>
                <div class="layui-input-block">
                    <textarea placeholder="请输入内容" class="layui-textarea" id="txtRemarks"></textarea>
                </div>
            </div>
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>项目联系人</legend>
            </fieldset>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">姓名</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectLinkMan" lay-verify="ProjectLinkMan" autocomplete="off" placeholder="请输入姓名" class="layui-input" id="txtProjectLinkMan" />
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">职位</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectPosition" lay-verify="ProjectPosition" autocomplete="off" placeholder="请输入职位" class="layui-input" id="txtProjectPosition" />
                    </div>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectMobilPhone" lay-verify="phone" autocomplete="off" placeholder="请输入手机" class="layui-input" id="txtProjectMobilPhone" />
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-inline">
                        <input type="text" name="ProjectEmail" lay-verify="email" autocomplete="off" placeholder="请输入邮箱" class="layui-input" id="txtProjectEmail" />
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

            <div style="margin-top: 80px;"></div>
            <div style="text-align: center; padding: 5px">
                <button class="button button-primary button-pill button-tiny" type="button" onclick="javascript:parent.layer.closeAll();">取消</button>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $("input").attr("readonly", "readonly");

    //初始化数据
    $(function () {
        initData();
    });

    //获取值，填充
    function initData() {
        var $data = { id: '<%=Request.Params["id"]%>' };
        $data = JSON.stringify($data);
        $.ajax({
            type: "POST",
            url: "<%=Request.Path%>/InitData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: $data,
            success: function (r) {
                r = JSON.parse(r.d);
                $('#txtNat_Org_Code').val('<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Nat_Org_Code%>');
                $('#txtCompany').val('<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Company%>');
                if (r == null) {
                    Industry(0);
                    ApplyType(0);
                    GetCity(0);
                } else {
                    //$('#txtIndustryId').val(r.IndustryId);
                    $('#txtApplyFund').val(r.ApplyFund);
                    $('#txtYYSR').val(r.YYSR);
                    $('#txtTAX').val(r.TAX);
                    $('#txtEmployee').val(r.Employee);
                    $('#txtRegAddress').val(r.RegAddress);
                    $('#txtBusinessAddress').val(r.BusinessAddress);
                    $('#txtTaxAddress').val(r.TaxAddress);
                    $('#txtApplyTable').val(r.ApplyTable);
                    $('#txtAttachment').val(r.Attachment);
                    $('#txtRemarks').val(r.Remarks);
                    $('#txtProjectLinkMan').val(r.ProjectLinkMan);
                    $('#txtProjectPosition').val(r.ProjectPosition);
                    $('#txtProjectMobilPhone').val(r.ProjectMobilPhone);
                    $('#txtProjectEmail').val(r.ProjectEmail);
                    Industry(0, r.IndustryId);
                    ApplyType(0, r.ApplyTypeId);
                    GetCity(1, r.ApplyTypeId);
                }
            }
        });
    }

    // 行业类型
    function Industry(n, industryId) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "../../ashx/IndustryDrp.ashx",
            data: { "n": n, "industryId": industryId },
            success: function (json) {
                var pro = $("#txtIndustryId");
                pro.val(json[0].IndustryName);
            }
        });
    }

    // 申请类型二级联动
    function ApplyType(n, ApplyTypeId) {

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "../../ashx/ApplyProjectDrp.ashx",
            data: { "n": n, "applyTypeId": ApplyTypeId },
            success: function (json) {
                console.log(json);
                var pro = $("#dl1");
                pro.val(json[0].ApplyTypeId_BigName);
            }
        });
    }
    function GetCity(n, ApplyTypeId) {
        var city = $("#txtApplyTypeId");
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "../../ashx/ApplyProjectDrp.ashx",
                data: { "n": n, "applyTypeId": ApplyTypeId },
                success: function (json) {
                    city.val(json[0].ApplyTypeId_SmallName);
                }
            });
        }
</script>

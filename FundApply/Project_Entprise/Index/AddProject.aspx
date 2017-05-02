<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="FundApply.Project_Entprise.AddProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
    <script src="../../css/plug/layui/layui.js"></script>
    <link href="../../js/plug/uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../js/plug/uploadify/jquery.uploadify.js"></script>
    <style>
        label {
            font-size: 14px;
        }

        .layui-form-label {
            width: 150px;
        }

        .layui-input-block {
            margin-left: 130px;
            min-height: 45px;
        }

        .layui-form-item {
            margin-bottom: 0px;
        }

        .layui-input, .layui-textarea {
            width: 80%;
        }
    </style>
</head>
<body>

    <form class="layui-feorm">
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
            <select id="txtIndustryId">
            </select>
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
                <select id="dl1" onchange="GetCity(this.value)">
                </select>
            </div>
            <div class="layui-input-inline">
                <select id="txtApplyTypeId" onchange="GetTable($(this).find('option:selected').attr('href'))">
                    <option value="00">请选择</option>
                </select>
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
        <div style="text-align: center; padding: 5px">
            <%--<asp:Button class="button button-primary button-pill button-tiny" lay-submit="" lay-filter="demo1" Text="申报" ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="Submit();" />--%>
            <button class="button button-primary button-pill button-tiny" id="btnSubmit" lay-submit="" lay-filter="demo1" type="button">申报</button>
            <button class="button button-primary button-pill button-tiny" type="button" onclick="javascript:parent.layer.closeAll();">取消</button>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">

    $(function () {
        //申报表
        $("#txtApplyTable").uploadify({
            //指定swf文件
            'swf': '../../js/plug/uploadify/uploadify.swf',
            //后台处理的页面
            'uploader': '../../../ashx/UploadHandler.ashx',
            //按钮显示的文字
            'buttonText': '上传文件',
            //显示的高度和宽度，默认 height 30；width 120
            'height': 15,
            'width': 80,
            //上传文件的类型  默认为所有文件    'All Files'  ;  '*.*'
            //在浏览窗口底部的文件类型下拉菜单中显示的文本
            'fileTypeDesc': 'Image Files',
            //允许上传的文件后缀
            //'fileTypeExts': '*.gif; *.jpg; *.png',
            //发送给后台的其他参数通过formData指定
            //'formData': { 'someKey': 'someValue', 'someOtherKey': 1 },
            //上传文件页面中，你想要用来作为文件队列的元素的id, 默认为false  自动生成,  不带#
            //'queueID': 'fileQueue',
            //选择文件后自动上传
            'auto': false,
            //设置为true将允许多文件上传
            'multi': true,
            'onUploadSuccess': function (file, data, response) {
                $('#txtApplyTable').val(data);//把url传过来
            }
        });
        //其他材料
        $("#txtAttachment").uploadify({
            'swf': '../../js/plug/uploadify/uploadify.swf',
            'uploader': '../../../ashx/UploadHandler.ashx',
            'buttonText': '上传文件',
            'height': 15,
            'width': 80,
            'fileTypeDesc': 'Image Files',
            'auto': false,
            'multi': true,
            'onUploadSuccess': function (file, data, response) {
                $('#txtApplyTable').val(data);//把url传过来
            }
        });
    });



    $(function () {
        //初始化数据
        initData();
        //下拉框
        
        


    });
    //验证规则
    layui.use(['form'], function () {
        var form = layui.form()
        , layer = layui.layer
        , layedit = layui.layedit
        , laydate = layui.laydate;
        form.verify({
            Nat_Org_Code: function (value) {
                if (value.length <= 0) {
                    return '请输入组织机构代码';
                }
            },
            Company: function (value) {
                if (value.length <= 0) {
                    return '请输入单位名称';
                }
            },
            YYSR: [/^[1-9]{0,7}.\d{0,2}$/, '请输入上年营业收入'],
            TAX: [/^[1-9]{0,7}.\d{0,2}$/, '请输入上年税收总额'],
            Employee: [/^\d+$/, '请输入员工人数'],
            RegAddress: function (value) {
                if (value.length <= 0) {
                    return '请输入注册地址';
                }
            },
            BusinessAddress: function (value) {
                if (value.length <= 0) {
                    return '请输入经营地址';
                }
            },
            ApplyFund: [/^[1-9]{0,7}.\d{0,2}$/, '请输入申请资金'],
            ProjectLinkMan: function (value) {
                if (value.length <= 0) {
                    return '请输入姓名';
                }
            },
            ProjectPosition: function (value) {
                if (value.length <= 0) {
                    return '请输入职位';
                }
            }
        });
    });

    //获取值，填充
    function initData() {
        var $data = { userId: '<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Id%>' };
        $data = JSON.stringify($data);
        $.ajax({
            type: "POST",
            url: "<%=Request.Path%>/InitData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: $data,
            success: function (r) {
                r = JSON.parse(r.d)
                 $('#txtNat_Org_Code').val('<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Nat_Org_Code%>');
                $('#txtCompany').val('<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Company%>');
                if (r==null) {
                    Industry(0);
                    ApplyType(0);
                } else {
                $('#txtIndustryId').val(r.IndustryId);
                //$('#txtApplyFund').val(r.ApplyFund);
                $('#txtYYSR').val(r.YYSR);
                $('#txtTAX').val(r.TAX);
                $('#txtEmployee').val(r.Employee);
                $('#txtRegAddress').val(r.RegAddress);
                $('#txtBusinessAddress').val(r.BusinessAddress);
                $('#txtTaxAddress').val(r.TaxAddress);
                alert(r.IndustryId);
                Industry(0, r.IndustryId);
                ApplyType(0, r.ApplyTypeId);
                }
            }
        });
    }

    //申报
    $("#btnSubmit").click(function () {
        var $data = {
            UserId:'<%=(Session["UsersModel"] as FundApply.Model.UsersModel).Id%>',
            Nat_Org_Code: $('#txtNat_Org_Code').val(),
            Company: $('#txtCompany').val(),
            IndustryId: $('#txtIndustryId').val(),
            YYSR: $('#txtYYSR').val(),
            TAX: $('#txtTAX').val(),
            Employee: $('#txtEmployee').val(),
            RegAddress: $('#txtRegAddress').val(),
            BusinessAddress: $('#txtBusinessAddress').val(),
            TaxAddress: $('#txtTaxAddress').val(),
            ApplyTypeId: $('#txtApplyTypeId').val(),
            ApplyFund: $('#txtApplyFund').val(),
            ApplyTable: $('#txtApplyTable').val(),
            Attachment: $('#txtAttachment').val(),
            Remarks: $('#txtRemarks').val(),
            ProjectLinkMan: $('#txtProjectLinkMan').val(),
            ProjectPosition: $('#txtProjectPosition').val(),
            ProjectMobilPhone: $('#txtProjectMobilPhone').val(),
            ProjectEmail: $('#txtProjectEmail').val()
        }
        $data = JSON.stringify($data);

        $.ajax({
            type: "POST",
            url: "<%=Request.Path%>/AddApplyProject",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: $data,
            success: function (r) {
                if (r.d == "ok") {
                    layer.alert("申报成功");
                }
            }
        });
    });

    // 行业类型
    function Industry(n, IndustryId) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "../../ashx/IndustryDrp.ashx",
            data: { "n": n, "industryId": IndustryId },
            success: function (json) {
                var pro = $("#txtIndustryId");
                pro.append('<option value="00">请选择</option>');
                $.each(json, function (i, n) {
                    $(pro).append(" <option value='" + n.IndustryId + "'>" + n.IndustryName + "</option>");
                });
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
                var pro = $("#dl1");
                pro.append('<option value="00">请选择</option>');
                $.each(json, function (i, n) {
                    $(pro).append(" <option value='" + n.ApplyTypeId_BigId + "'>" + n.ApplyTypeId_BigName + "</option>");
                });
            }
        });
    }
    function GetCity(n) {
        var city = $("#txtApplyTypeId");
        city.html("");
        if (n == "00") {
            city.append('<option value="00">请选择</option>');
        } else {
            city.append('<option value="00">请选择</option>');
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "../../ashx/ApplyProjectDrp.ashx",
                data: { "n": n },
                success: function (json) {
                    $.each(json, function (i, n) {
                        $(city).append(" <option href='" + n.ApplyTableUrl + "' value='" + n.ApplyTypeId_SmallId + "'>" + n.ApplyTypeId_SmallName + "</option>");
                    });
                }
            });
        }
    }
    //更改申报表模板的链接
    function GetTable(href) {
        var table = $("#applyTable");
        table.attr("href", href);

    }

    //询问框
    function Submit() {
        layer.confirm('您是确定要提交吗？', {
            btn: ['确定', '取消'] //按钮
        }, function () {
            layer.msg('已提交！', { icon: 1 }, function () {
                parent.layer.closeAll();
            });
        }, function () {
        });
    }
</script>

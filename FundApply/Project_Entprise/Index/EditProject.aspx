<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="FundApply.Project_Entprise.EditProject" %>

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
    <script src="../../js/login.js"></script>
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
            /*clear: both;*/
        }

        .layui-input, .layui-textarea {
            /*display: block;*/
            width: 80%;
            /*padding-left: 10px;*/
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
                <input type="text" name="Nat_Org_Code" lay-verify="Nat_Org_Code" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input" id="txtNat_Org_Code" runat="server" readonly="readonly"/>
            </div>
            <label class="layui-form-label">单位名称</label>
            <div class="layui-input-block">
                <input type="text" name="Company" lay-verify="Company" autocomplete="off" placeholder="请输入单位名称" class="layui-input" id="txtCompany" runat="server" readonly="readonly"/>
            </div>
            <label class="layui-form-label">所属行业</label>
            <div class="layui-input-block">
                <asp:DropDownList name="IndustryId" lay-verify="IndustryId" ID="drpIndustryId" runat="server">
                </asp:DropDownList>
            </div>
            <label class="layui-form-label">上年营业收入(元)</label>
            <div class="layui-input-block">
                <input type="text" name="YYSR" lay-verify="YYSR" autocomplete="off" placeholder="请输入上年营业收入" class="layui-input" id="txtYYSR" runat="server" />
            </div>
            <label class="layui-form-label">上年税收总额(元)</label>
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
                    <select name="quiz1">
                        <option value="1" selected="">金融业</option>
                        <option value="2">文化创意产业</option>
                        <option value="3">高新技术产业</option>
                        <option value="4">高新技术产业（信息服务业）</option>
                        <option value="5">总部经济及服务业</option>
                        <option value="6">中小企业发展</option>
                        <option value="7">企业上市</option>
                    </select>
                </div>
                <div class="layui-input-inline">
                    <select name="ApplyTypeId" lay-verify="ApplyTypeId" id="txtApplyTypeId" runat="server">
                        <option value="1" selected="">房屋补贴</option>
                        <option value="2">一次性入住</option>
                        <option value="3">区级收入贡献</option>
                    </select>
                </div>
            </div>
            <label class="layui-form-label">申请资金(元)</label>
            <div class="layui-input-block">
                <input type="text" name="ApplyFund" lay-verify="ApplyFund" autocomplete="off" placeholder="请输入申请资金" class="layui-input" id="txtApplyFund" runat="server" />
            </div>
            <label class="layui-form-label">申报材料</label>
            <div class="layui-input-block"> <%--class="layui-upload-file" --%>
                                <%--<asp:FileUpload runat="server" />--%>
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

            <div style="margin-top: 80px;"></div>
            <div style="text-align: center; padding: 5px">
                <asp:Button class="button button-primary button-pill button-tiny" lay-submit="" lay-filter="demo1" Text="编辑提交" runat="server" ID="btnSubmit"  OnClick="btnSubmit_Click"/>
                <%--<button class="button button-primary button-pill button-tiny" type="button" onclick="Submit();">编辑提交</button>--%>
                <button class="button button-primary button-pill button-tiny" type="button" onclick="javascript:parent.layer.closeAll();">取消</button>
            </div>
        </form>
    </div>
</body>
</html>


<script type="text/javascript">

    layui.use(['form', 'layedit', 'laydate'], function () {
        var form = layui.form()
        , layer = layui.layer
        , layedit = layui.layedit
        , laydate = layui.laydate;

        //创建一个编辑器
        var editIndex = layedit.build('LAY_demo_editor');
        //自定义验证规则
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
            //Attachment: function (value) {},
            ProjectLinkMan: function (value) {
                if (value.length <= 0) {
                    return '请输入姓名';
                }
            },
            ProjectPosition: function (value) {
                if (value.length <= 0) {
                    return '请输入职位';
                }            }
        });    
    });

    function Submit() {
        //询问框
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

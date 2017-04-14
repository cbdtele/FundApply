<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProject.aspx.cs" Inherits="FundApply.Project_CYB.Index.SBQK.Project" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" />
    <link href="../../../css/buttons.css" rel="stylesheet" />
    <link href="../../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../../css/plug/layui/lay/dest/layui.all.js"></script>
    <script src="../../../js/plug/layer/layer.js"></script>
    <script src="../../../css/plug/layui/layui.js"></script>
    <script src="../../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../css/plug/layui/layui.js"></script>
    <link href="../../../css/plug/layui/css/layui.css" rel="stylesheet" />
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
        <form class="layui-form" action="">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>基本信息</legend>
            </fieldset>
            <label class="layui-form-label">组织机构代码 </label>
            <div class="layui-input-block">
                <input name="title" lay-verify="title" autocomplete="off" class="layui-input" value="694968736" />
                <%--<input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input">--%>
            </div>
            <label class="layui-form-label">单位名称</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" class="layui-input" value="北京测试test有限公司">
            </div>
            <label class="layui-form-label">所属行业</label>
            <div class="layui-input-block">
                <select name="interest" lay-filter="aihao">
                    <option value="4">请选择行业</option>
                    <option value="0" selected="">金融业</option>
                    <option value="1">批发和零售业</option>
                    <option value="2">房地产业</option>
                </select>
            </div>
            <label class="layui-form-label">上年营业收入</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" class="layui-input" value="500万">
            </div>
            <label class="layui-form-label">上年税收总额</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" class="layui-input" value="30万">
            </div>
            <label class="layui-form-label">员工人数</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入员工人数" class="layui-input" value="20">
            </div>
            <label class="layui-form-label">注册地址</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入注册地址" class="layui-input" value="北京市朝阳区柳芳南里甲５号１号楼１至５层１－１一层１２０９">
            </div>
            <label class="layui-form-label">经营地址</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入经营地址" class="layui-input" value="北京市朝阳区柳芳南里甲５号１号楼１至５层１－１一层１２０９">
            </div>


            <div class="layui-form-item">
                <label class="layui-form-label">申请类型</label>
                <div class="layui-input-inline">
                    <select name="quiz1">
                        <option value="0">请选择产业</option>
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
                    <select name="quiz2">
                        <option value="0" selected="">请选择</option>
                        <option value="1" selected="">房屋补贴</option>
                        <option value="2">一次性入住</option>
                        <option value="3">区级收入贡献</option>
                    </select>
                </div>
            </div>
            <label class="layui-form-label">申请资金</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input" value="200万">
            </div>
            <label class="layui-form-label">申报材料</label>
            <div class="layui-input-block">
                <div style="height: 38px; padding-top: 5px;"><a href="../file/我是一个测试文件.docx">1.相关资料</a></div>
            </div>


            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>项目联系人</legend>
            </fieldset>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">姓名</label>
                    <div class="layui-input-inline">
                        <input type="tel" name="phone" lay-verify="phone" autocomplete="off" placeholder="请输入姓名" class="layui-input" value="张三">
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">职位</label>
                    <div class="layui-input-inline">
                        <input type="text" name="email" lay-verify="email" autocomplete="off" placeholder="请输入职位" class="layui-input" value="CEO">
                    </div>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-inline">
                        <input type="tel" name="phone" lay-verify="phone" autocomplete="off" placeholder="请输入手机" class="layui-input" value="18612345678">
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-inline">
                        <input type="text" name="email" lay-verify="email" autocomplete="off" placeholder="请输入邮箱" class="layui-input" value="123456789@163.com">
                    </div>
                </div>
            </div>

            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>审核信息</legend>
            </fieldset>

            <div class="layui-form-item">
                <label class="layui-form-label">审核意见</label>
                <div class="layui-input-inline">
                    <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="没有意见" class="layui-input">
                </div>
                <label class="layui-form-label">审核资金</label>
                <div class="layui-input-inline">
                    <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="100万" class="layui-input">
                </div>
            </div>
            <label class="layui-form-label">审核时间</label>
            <div class="layui-input-inline">
                <input readonly="readonly" type="text" name="email" lay-verify="email" autocomplete="off" value="2017-03-03" class="layui-input">
            </div>
        </form>
        <div style="margin-top: 80px;"></div>
        <div style="text-align: center; padding: 5px">
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Close();">取消</button>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
    $("input").attr("readonly", "readonly");

    function Close() {
        parent.layer.closeAll();
    }

    layui.use(['form', 'layedit', 'laydate'], function () {
        var form = layui.form()
        , layer = layui.layer
        , layedit = layui.layedit
        , laydate = layui.laydate;

        //创建一个编辑器
        var editIndex = layedit.build('LAY_demo_editor');

        //自定义验证规则
        form.verify({
            title: function (value) {
                if (value.length < 5) {
                    return '标题至少得5个字符啊';
                }
            }
          , pass: [/(.+){6,12}$/, '密码必须6到12位']
          , content: function (value) {
              layedit.sync(editIndex);
          }
        });

        //监听指定开关
        form.on('switch(switchTest)', function (data) {
            layer.msg('开关checked：' + (this.checked ? 'true' : 'false'), {
                offset: '6px'
            });
            layer.tips('温馨提示：请注意开关状态的文字可以随意定义，而不仅仅是ON|OFF', data.othis)
        });

        //监听提交
        form.on('submit(demo1)', function (data) {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            })
            return false;
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


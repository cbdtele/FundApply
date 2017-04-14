<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProject.aspx.cs" Inherits="FundApply.Project_CYB.ZJPS.Checked.ApplyProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../../css/style.css" rel="stylesheet" />
    <link href="../../../../css/buttons.css" rel="stylesheet" />
    <link href="../../../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../../css/plug/layui/lay/dest/layui.all.js"></script>
    <script src="../../../../js/plug/layer/layer.js"></script>
    <script src="../../../../css/plug/layui/layui.js"></script>
    <script src="../../../../css/plug/layui/layui.js"></script>
    <link href="../../../../css/plug/layui/css/layui.css" rel="stylesheet" />
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

        textarea {
            margin-left: 10px;
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
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input" value="金融业">
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">申请类型</label>
                 <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input" value="金融业-房屋补贴">
            </div>                
            </div>
            <label class="layui-form-label">申请资金</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input" value="200万">
            </div>
            <label class="layui-form-label" >审核资金</label>
            <div class="layui-input-block">
                <input <%--id="shzj" style="border-width:1px;margin-left:10px;" --%> type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input" value="200万">
            </div>
        </form>
        <div style="text-align: center; padding: 5px">
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Close();">取消</button>
        </div>
    </div>
</body>
</html>


<script type="text/javascript">
    $("input").attr("readonly", "readonly");
    $("#shzj").removeAttr("readonly");
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
                //location.href = "/Project_Entprise/main.aspx";
            });

        }, function () {


            //layer.msg('也可以这样', {
            //    time: 20000, //20s后自动关闭
            //    btn: ['明白了', '知道了']
            //});
        });

    }

    $(function () {

    });

</script>

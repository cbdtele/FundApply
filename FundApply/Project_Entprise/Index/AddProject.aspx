<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="FundApply.Project_Entprise.AddProject" %>

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
            width: 100px;
        }

        .layui-input-block {
            margin-left: 130px;
            min-height: 45px;
        }

        .layui-form-item {
            margin-bottom: 0px;
            /*clear: both;*/
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
                <input type="text" name="title"  lay-verify="required" lay-verify="title" autocomplete="off" placeholder="请输入组织机构代码/统一社会信用代码" class="layui-input">
            </div>

            <label class="layui-form-label">单位名称</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入单位名称" class="layui-input">
            </div>
            <label class="layui-form-label">所属行业</label>
            <div class="layui-input-block">
                <select name="interest" lay-filter="aihao">
                    <option value="3" selected="">请选择行业</option>
                    <option value="0">金融业</option>
                    <option value="1">批发和零售业</option>
                    <option value="2">房地产业</option>
                </select>
            </div>
            <label class="layui-form-label">上年营业收入</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入上年营业收入" class="layui-input">
            </div>
            <label class="layui-form-label">上年税收总额</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入上年税收总额" class="layui-input">
            </div>
            <label class="layui-form-label">员工人数</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入员工人数" class="layui-input">
            </div>
            <label class="layui-form-label">注册地址</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入注册地址" class="layui-input">
            </div>
            <label class="layui-form-label">经营地址</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入经营地址" class="layui-input">
            </div>


            <div class="layui-form-item">
                <label class="layui-form-label">申请类型</label>
                <div class="layui-input-inline">
                    <select name="quiz1">
                        <option value="0" selected="">请选择产业</option>
                        <option value="1">金融业</option>
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
                        <option value="1">房屋补贴</option>
                        <option value="2">一次性入住</option>
                        <option value="3">区级收入贡献</option>
                    </select>
                </div>
            </div>
            <label class="layui-form-label">申请资金</label>
            <div class="layui-input-block">
                <input type="text" name="title" lay-verify="title" autocomplete="off" placeholder="请输入申请资金" class="layui-input">
            </div>
            <label class="layui-form-label">申报材料</label>
            <div class="layui-input-block">
                <input type="file" name="file" class="layui-upload-file" lay-title="上传文件">
            </div>

            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>项目联系人</legend>
            </fieldset>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">姓名</label>
                    <div class="layui-input-inline">
                        <input type="tel" name="phone" lay-verify="phone" autocomplete="off" placeholder="请输入姓名" class="layui-input">
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">职位</label>
                    <div class="layui-input-inline">
                        <input type="text" name="email" lay-verify="email" autocomplete="off" placeholder="请输入职位" class="layui-input">
                    </div>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label">手机</label>
                    <div class="layui-input-inline">
                        <input type="tel" name="phone" lay-verify="phone" autocomplete="off" placeholder="请输入手机" class="layui-input">
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label">邮箱</label>
                    <div class="layui-input-inline">
                        <input type="text" name="email" lay-verify="email" autocomplete="off" placeholder="请输入邮箱" class="layui-input">
                    </div>
                </div>
            </div>
        </form>

        <div style="text-align: center; padding: 5px">
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Submit()">申报</button>
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Close();">取消</button>
        </div>
    </div>
</body>
</html>
<script type="text/javascript">

    layui.use('upload', function () {
        layui.upload({
            url: '' //上传接口
          , success: function (res) { //上传成功后的回调
              console.log(res)
          }
        });

        layui.upload({
            url: '/test/upload.json'
          , elem: '#test' //指定原始元素，默认直接查找class="layui-upload-file"
          , method: 'get' //上传接口的http类型
          , success: function (res) {
              LAY_demo_upload.src = res.url;
          }
        });
    });


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
        alert(2);
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

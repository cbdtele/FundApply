<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_CYB.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/plug/layer/layer.js"></script>
    <link href="../css/plug/layui/css/layui.css" rel="stylesheet" /> 
    <script src="../css/plug/layui/lay/dest/layui.all.js"></script> 
    <style type="text/css">
        body {
            overflow-x: hidden; overflow-y: hidden;
            text-align: center;
        }

        * {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-tab">
            <div style="position:fixed; width:100%;height:40px;background-color:#e8ecf4;">
            <ul class="layui-tab-title" style="padding-right:20px;">
                <li style="background-color:#fff">首页</li>
                <li>数据导入</li>
                <li>修改密码</li>
            </ul>
            </div>
            <div class="layui-tab-content">
                <%--内容一--%>
                <div class="layui-tab-item layui-show">
                     <iframe src="Index/main.aspx" style=" border: none; width: 100%; height: 500px;margin:40px 10px 10px 10px;"></iframe>
                </div>
                <%--内容2--%>
                <div class="layui-tab-item dvlayui">
                     <iframe src="DataReport/main.aspx" style=" border: none; width: 100%; height: 500px;margin:40px 10px 10px 10px;"></iframe>
                </div>
                <%--内容3--%>
                <div class="layui-tab-item dvlayui">
                     <iframe src="Account/main.aspx" style=" border: none; width: 100%; height: 500px;margin:40px 10px 10px 10px;"></iframe>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript"> 
    $(function () {
        $('li').click(function () {
            $(this).css("backgroundColor", "#fff").siblings("li").css("backgroundColor", "#e8ecf4");
        });
    });

</script>
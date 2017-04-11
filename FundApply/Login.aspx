<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE>
<html>
<head>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,Chrome=1" />
    <title>朝阳区发改委产业资金申请平台</title>
    <link rel="shortcut icon" href="logo.png" />
    <style>
        body {
            padding: 0px;
            margin: 0px;
        }

        .btnLogin {
            width: 61px;
            height: 33px;
            background-image: url(images/img-02.jpg);
            border: none;
            position: absolute;
            top: 370px;
            left: 683px;
        }
    </style>
    <script>
        function go() {
            location.href = 'main.aspx';
        }
    </script>
</head>
<body>
    <form runat="server">
        <div style="background-image: url(images/img-01.jpg); width: 1000px; height: 600px; margin: 0 auto; position: relative;">
            <div>
                <input type="text" name="username" id="username" style="border: none; height: 26px; position: absolute; top: 270px; left: 535px; background-color: #e5e3e8; outline: none; border-radius: 4px;" />
            </div>
            <div>
                <input type="password" name="password" id="password" style="border: none; height: 26px; position: absolute; top: 321px; left: 535px; background-color: #e5e3e8; outline: none; border-radius: 4px;" />
            </div>
            <button type="button" class="btnLogin"></button>
            <%--<asp:Button ID="btnSubmit" runat="server" CssClass="btnLogin" OnClick="btnSubmit_Click" />--%>
        </div>
    </form>

    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/plug/layer/Jquery.CBD.js"></script>
    <script type="text/javascript">
        var Login = function () {
            var $username = $("input#username").val();
            var $password = $("input#password").val();

            if ($username == "" || $username == null) {
                layer.msg("请输入登录名", { icon: 0, shadeClose: true, shade: [0.4, '#393D49'] });
                return;
            }
            if ($password == "" || $password == null) {
                layer.msg("请输入密码", { icon: 4, shadeClose: true, shade: [0.4, '#393D49'] });
                return;
            }

            layer.msg('登陆中...', { icon: 16, shade: [0.5, '#393D49'], time: 100000 });
            CBD.ajaxData({
                name: $('input#username').val(),
                password: $('input#password').val(),
                verification: '<%=Verification%>'
            }, '<%=Request.Path%>/LoginCheck', function (result) {
                if (result.state) {
                    layer.msg('登陆成功', { icon: 1, shade: [0.5, '#393D49'] });
                    window.location.href = '/main.aspx';
                } else {
                    CBD.showAlertBox(result.message);
                }
            });
        };

        $('button.btnLogin').click(function () { Login(); });
        $("body").bind("keydown", function (e) {
            var theEvent = e || window.event;
            var code = theEvent.keyCode || theEvent.which || theEvent.charCode;
            if (code == 13) {
                Login();
            }
        });
    </script>
</body>
</html>

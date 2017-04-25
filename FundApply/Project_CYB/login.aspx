<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FundApply.Project_CYB.login" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="../images/logo.png" />
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="css/login2style.css">
    <script type="text/javascript" src="js/jquery-1.9.1.js"></script>
    <script src="../js/login.js"></script>
    <style type="text/css">
        body {
            height: 100%;
            overflow-y: hidden;
        }

        html {
            height: 100%;
        }
    </style>
</head>
<body>
    <div id="wrap">
        <img class="bg" src="images/bg.jpg">
        <div id="topwrap">
            <div id="top"></div>
        </div>

        <div id="contwrap">
            <div id="cont">
                <div class="left">
                    <div class="leftmain">
                        <div class="tts">
                            <img src="images/loginimg.png"></div>
                        <div class="inputs">
                            <form id="form1" method="" action="#">
                                <p class="commen">
                                    <label for="logname">账号</label>
                                    <input id="logname" name="logname" required minlength="" placeholder="请输入账号">
                                </p>
                                <p class="commen">
                                    <label for="password">密码</label>
                                    <input id="logpassword" name="logpassword" required minlength="" placeholder="请输入密码">
                                </p>
                                <p class="">
                                    <label for="yzm">验证码</label>
                                    <input class="yzm" id="Image" name="Image" style="width: 100px;">
                                    <img style="height: 24px;" id="imgRandom" src="../Randomimage_CN.aspx" onclick="javascript:imgSrc();" alt="验证码" />
                                    <a href="javascript:imgSrc();" style="font-size: 12px; color: #789ccf;">换一张</a>
                                </p>
                                <p class="ff"><a class="forgot" href="##"><i>忘记密码？</i></a></p>
                                <p>
                                    <input class="submit" id="submit" type="submit" onclick="login();" value="登&nbsp;&nbsp;录">
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
    <script type="text/javascript">
        function login() {
            location.href = "parentmain.aspx";
        }
    </script>
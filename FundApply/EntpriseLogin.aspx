<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntpriseLogin.aspx.cs" Inherits="FundApply.EntpriseLogin" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>朝阳区重点产业发展引导资金信息管理平台</title>
    <link rel="stylesheet" type="text/css" href="css/loginstyle.css">
    <link rel="shortcut icon" href="../images/logo.png" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="js/plug/jquery-validation-1.14.0/dist/localization/messages_zh.min.js"></script>
    <script src="../js/plug/layer/Jquery.CBD.js"></script>
    <script src="../js/plug/layer/layer.js"></script>
    <script src="../js/login.js"></script>
    <style type="text/css">
	
	</style>
</head>
<body>
    <div id="wrap">
        <div id="topwrap">
            <div id="top"></div>
        </div>
        <div id="bannerwrap">
            <div id="banner">
                <div class="show">
                    <img src="images/img1.jpg">
                </div>
                <div class="blueline"></div>
            </div>
        </div>
        <div id="contwrap">
            <div id="cont">
                <div class="left">
                    <div class="leftmain">
                        <div class="tts">
                            <img src="images/loginimg.png">
                        </div>
                        <div class="inputs">
                            <form id="login" name="login">
                                <input type="hidden" name="type" value="login" />
                                <p class="commen">
                                    <label for="name">账号</label>
                                    <input id="logname" name="logname" required minlength=""placeholder="请填写组织机构代码/统一社会信用代码">
                                </p>
                                <p class="commen">
                                    <label for="password">密码</label>
                                    <input id="logpassword" name="logpassword" required minlength="">
                                </p>
                                <p class="">
                                    <label for="yzm">验证码</label>
                                    <input class="yzm" id="Image" name="Image" style="width: 100px;">
                                    <img style="height: 24px;" id="imgRandom" src="../Randomimage_CN.aspx" onclick="javascript:imgSrc();" alt="验证码" />
                                    <a href="javascript:imgSrc();" style="font-size: 12px; color: #789ccf;">换一张</a>
                                </p>
                                <p class="ff"><a class="forgot" href="##"><i>忘记密码？</i></a></p>
                                <p>
                                    <input type="submit" class="submit" value="登&nbsp;&nbsp;录" />
                                    <%--<asp:Button ID="btnLogin" runat="server" Text="登&nbsp;&nbsp;录" OnClick="btnLogin_Click" class="submit"  OnClientClick="login();"/>--%>
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
                <div class="mid"></div>
                <div class="right">
                    <div class="rightmain">
                        <div class="tts">
                            <img src="images/regimg.png">
                        </div>
                        <div class="inputs">
                            <form id="register" name="register">
                                <input type="hidden" name="type" value="register" />
                                <p class="commen">
                                    <label for="Nat_Org_Code">组织机构代码</label><span class="star" id="spantip">*</span>
                                    <input id="Nat_Org_Code" name="Nat_Org_Code" required minlength="" placeholder="请填写组织机构代码/统一社会信用代码">
                                </p>
                                <p class="commen">
                                    <label for="Company">企业单位名称</label><span class="star">*</span>
                                    <input id="Company" name="Company" required minlength="">
                                </p>
                                <p class="commen">
                                    <label class="tel-tt">联系方式一</label>
                                </p>
                                <div class="contact">
                                    <p class="commen">
                                        <label for="LinkMan1">联系人</label><span class="star">*</span>
                                        <input id="LinkMan1" name="LinkMan1" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="MobilePhone1">手机</label><span class="star">*</span>
                                        <input id="MobilePhone1" name="MobilePhone1" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="Telephone1">固定电话</label><span class="star">*</span>
                                        <input id="Telephone1" name="Telephone1" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="Email1">邮箱</label><span class="star">*</span>
                                        <input id="Email1" name="Email1">
                                    </p>
                                </div>
                                <p class="commen">
                                    <label class="tel-tt">联系方式二</label>
                                </p>
                                <div class="contact contact2">
                                    <p class="commen">
                                        <label for="LinkMan2">联系人</label><span class="star">*</span>
                                        <input id="LinkMan2" name="LinkMan2" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="MobilePhone2">手机</label><span class="star">*</span>
                                        <input id="MobilePhone2" name="MobilePhone2" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="Telephone2">固定电话</label><span class="star">*</span>
                                        <input id="Telephone2" name="Telephone2" required minlength="">
                                    </p>
                                    <p class="commen">
                                        <label for="Email2">邮箱</label><span class="star">*</span>
                                        <input id="Email2" name="Email2" required minlength="">
                                    </p>
                                </div>
                                <p class="commen">
                                    <label for="password">密码</label><span class="star">*</span>
                                    <input id="password" name="password1" required minlength="">
                                </p>
                                <p class="commen">
                                    <label for="Password">确认密码</label><span class="star">*</span>
                                    <input id="Password" name="Password" required minlength="">
                                </p>
                                <p style="margin-top: 30px;">
                                    <input type="submit" class="submit" value="注&nbsp;&nbsp;册" />
                                    <%--<asp:Button ID="btnRegister" runat="server" Text="注&nbsp;&nbsp;册" class="submit" OnClick="btnRegister_Click"  OnClientClick="register();"/>--%>
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

    //$.validator.setDefaults({
    //    submitHandler: function () {
    //        alert("提交事件!");
    //    }
    //});
    //$().ready(function () {
    //    $("#login").validate();
    //});
    //function login() {
    //    return false;
    //}
    //function register() {
    //    return false;
    //}


    $('#login').submit(function () {
        return submitCheck();
        var data = $('#login').serialize();
    });

    $('#register').submit(function () {
        //return false;
        //console.log(checkexists());
        //return checkexists();
        //return false;
        var data = $('#register').serialize();
    });


    $("#Nat_Org_Code").blur(function () {
        checkexists();
    });

    function checkexists() {
        $data = { nat_Org_Code: $("#Nat_Org_Code").val() };
        $.CBD.ajaxData($data, "<%=Request.Path%>/CheckExists", function (json) {
            if (json == true) {
                 layer.alert("组织机构代码已注册");
                 return false;
            } else {
                return true;
            }
         });
     }
</script>

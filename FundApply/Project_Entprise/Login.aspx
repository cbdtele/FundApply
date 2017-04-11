<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FundApply.Project_Entprise.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            background-color:#eee;
            text-align:center;
            height:100%;
            overflow:hidden;
        }
        * {
            margin:0 auto;
        }
       html {
            height:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height:100%;">
    <div style="width:1024px;height:100%;">
        <img style="width:100%;height:100%;" src="../images/login.jpg" onclick="goLogin();">
    </div>
    </form>
</body>
</html>
<script>
    function goLogin() {
        location.href = "parentmain.aspx";
    }
</script>

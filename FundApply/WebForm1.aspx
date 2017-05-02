<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FundApply.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人会员密码找回</title>
    <link href="/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        // 检查 E-mail 是否已被注册  
        function CheckEmail() {
            var e = document.getElementById("email").value;
            if (e != "") {
                if (!/(\S)+[@]{1}(\S)+[.]{1}(\w)+/.test(e)) {
                    alert("请输入格式正确的E-mail 地址！");
                    var email = document.getElementById("email");
                    email.value = "";
                    email.focus();
                }
            }
        }

        function checkAll() {
            var ee = document.getElementById("username").value;
            if (ee == "") {
                alert('登录名称不能为空');
                return false;
            }

            var e = document.getElementById("email").value;
            if (e == "") {
                alert('Emial不能为空');
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="778" border="0" align="center" cellpadding="5" cellspacing="0" class="table_huang">
                <tr>
                    <td colspan="2" class="TD_huang_14_write"><span style="font-size: 11pt">>> 获取密码</span></td>
                </tr>
                <tr>
                    <td width="26"></td>
                    <td width="724">
                        <table width="90%" border="0" cellspacing="2" cellpadding="5">
                            <tr>
                                <td width="23%">
                                    <div align="right">用户名：</div>
                                </td>
                                <td width="77%">
                                    <asp:TextBox ID="username" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">注册时填写的Email：</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="email" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>                          
                            <tr>

                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text=" 找回密码 " /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

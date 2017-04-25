<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FundApply.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/plug/layer/Jquery.CBD.js"></script>
</head>
<body>
    <form id="form1">
    <div>
        <input  name="a"/>
        <input  name="ab"/>
        <input  name="abc"/>
        <input  name="abcd"/>
        <input type="button" name="name" value="myfunction"  onclick="myfunction();"/>
    </div>
    </form>
</body>
</html>
<script>
    function myfunction() {

        var $data = $('form').serialize();
        //$data = JSON.parse($data);
        //$data = JSON.stringify($data);

        console.log($data);
        $.CBD.ajaxData({time1:$data}, "<%=Request.Path%>/Add", function (json) {
            alert(json);
        });
        //data = { "id": "123" };
        ////data = JSON.stringify(data);
        ////data = JSON.parse(data);
        //$.ajax({
        //    type:'post',
        //    url: '/WebForm1.aspx/Add',
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    //data: data,
        //    success: function (r) {
        //        //r = JSON.stringify(r);
        //        alert(r.d);//返回的数据用data.d获取内容
        //    },
        //    error: function (err) {
        //        alert(err);
        //    }
        //});        
    }
</script>

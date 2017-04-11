<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeDetails.aspx.cs" Inherits="FundApply.Project_FGW.Notice.PolicyDetails" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <link href="../../easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../easyui/themes/icon.css" rel="stylesheet" />
    <script src="../../easyui/jquery.min.js"></script>
    <script src="../../easyui/jquery.easyui.min.js"></script>
    <script src="../../js/plug/UEditor/ueditor.config.js"></script>
    <script src="../../js/plug/UEditor/ueditor.all.min.js"></script>
    <script src="../../js/plug/UEditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../../js/plug/swfupload/swfupload.js"></script>
    <script src="../../js/plug/swfupload/swfupload.queue.js"></script>
    <script src="../../js/plug/swfupload/fileprogress.js"></script>
    <script src="../../js/plug/swfupload/filegroupprogress.js"></script>
    <script src="../../js/plug/swfupload/handlers.js"></script>

    <script src="../../js/plug/layer/Jquery.CBD.js"></script>
    <style>
        tr {
            margin: 100px 10px 10px 10px;
        }


        body {
            /*overflow:scroll;*/
            overflow-y: hidden;
            overflow-x: hidden;
        }
    </style>
</head>
<body>
    <div id="div_content" style="margin: 20px 20px 20px 20px;">
        <form id="ff" method="post" runat="server">
            <table>
                <tr>
                    <td style="width: 1%;">公示名称：</td>
                    <td style="width: 10%;">
                        <label>测试标题test1</label>
                    </td>
                </tr>
                <tr>
                    <td>公示简介：</td>
                    <td>
                        <label>
                            公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容
                            公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容
                            公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容公示测试内容
                        </label>
                        <%--<script id="editor" type="text/plain" style="width: 95%; height: 250px;"></script>--%>
                    </td>
                </tr>
                <tr>
                    <td>附件：</td>
                    <td>
                        <label>
                            1.附件1test<br />
                            2.附件2test
                        </label>
                    </td>
                </tr>
            </table>
        </form>
        <div style="text-align: center; padding: 5px">
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Close()">取消</button>
        </div>
    </div>
</body>
</html>
<script type="text/javascript">
    $(function () {
        var ue = UE.getEditor('editor');
    });
    function Close() {
        parent.layer.closeAll();
    }
</script>

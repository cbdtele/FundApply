<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_FGW.Index.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
        <style>
        a {
            color:blue;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>2017上半年产业资金申报情况</label>
        </div>
        <table class="gridtable">
            <tr>
                <th rowspan="2">序号</th>
                <th rowspan="2">产业办</th>
                <th colspan="3">申报情况</th>
                <th colspan="4">立项审核</th>
                <th colspan="3">资金评审</th>
                <th colspan="2">申报时间</th>
            </tr>
            <tr>
                <th>申报类型</th>
                <th>申报单位数</th>
                <th>申报资金</th>
                <th>待审核</th>
                <th>退回修改</th>
                <th>审核通过</th>
                <th>资金申报</th>
                <th>未核定</th>
                <th>已核定</th>
                <th>审批资金</th>
                <th>开始</th>
                <th>结束</th>
            </tr>
            <tr>
                <td>1</td>
                <td>金融办</td>
                <td style="text-align: left;">金融办-房屋补贴</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">400</a></td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('1');">100</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('2');">100</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('3');">200</a></td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('4');">100</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('5');">100</a></td>
                <td style="text-align: right;">1000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
            <tr>
                <td>2</td>
                <td>金融办</td>
                <td style="text-align: left;">金融办-一次性入驻</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">200</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">1000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
            <tr>
                <td>3</td>
                <td>金融办</td>
                <td style="text-align: left;">金融办-区级收入贡献</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">200</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">1000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
            <tr>
                <td>4</td>
                <td>文化创意产业管委会</td>
                <td style="text-align: left;">一次性入驻</td>
                <td style="text-align: right;">1200</td>
                <td style="text-align: right;">6000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">600</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">3000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
            <tr>
                <td>5</td>
                <td>中关村朝阳园</td>
                <td style="text-align: left;">区级收入贡献</td>
                <td style="text-align: right;">1200</td>
                <td style="text-align: right;">6000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">600</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">3000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
            <tr>
                <td>6</td>
                <td>商务委</td>
                <td style="text-align: left;">税收贡献</td>
                <td style="text-align: right;">1200</td>
                <td style="text-align: right;">6000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">600</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">300</td>
                <td style="text-align: right;">3000</td>
                <td>2017-03-01</td>
                <td>2017-06-30</td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript">
    function goEntprise(type) {
        var url = "";
        switch (type) {
            case "0":
                url = "SBQK/EnterpriseList.aspx";//申报单位数
                break;
            case "1":
                url = "LXSH/UnChecked/EnterpriseList.aspx";//待审核
                break;
            case "2":
                url = "LXSH/ReturnModification/EnterpriseList.aspx";//退回修改
                break;
            case "3":
                url = "LXSH/Checked/EnterpriseList.aspx";//审核通过
                break;
            case "4":
                url = "ZJPS/UnChecked/EnterpriseList.aspx";//未核定
                break;
            case "5":
                url = "ZJPS/Checked/EnterpriseList.aspx";//已核定
                break;
            default:
        }
        layer.open({
            type: 2,
            closeBtn: 0,
            title: false,
            maxmin: false, shadeClose: false,
            shade: false, maxmin: false,
            area: ['100%', '100%'],
            content: url
        });
    }
</script>

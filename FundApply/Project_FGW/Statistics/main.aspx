<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_FGW.Statistics.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/layui.js"></script>
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
    <script src="../../js/echarts.min.js"></script>
    <style type="text/css">
        body {
            text-align: center;
        }

        * {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>
                2017上半年资金申报统计                                
            </label>
        </div>
        <table class=" gridtable">
            <tr>
                <th>申报类型</th>
                <th>申报细类</th>
                <th>申报单位数</th>
                <th>审核通过</th>
                <th>审核金额（万元）</th>
            </tr>
            <tr>
                <td style="text-align: left;">金融业</td>
                <td style="text-align: left;">房屋补贴</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">400</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('1');">400</a></td>
                <td style="text-align: right;">2000</td>
            </tr>
            <tr>
                <td style="text-align: left;">金融业</td>
                <td style="text-align: left;">一次性入驻</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
            </tr>
            <tr>
                <td style="text-align: left;">金融业</td>
                <td style="text-align: left;">区级收入贡献</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; font-weight: 900;">合计</td>
                <td style="text-align: right;">1200</td>
                <td style="text-align: right;">1200</td>
                <td style="text-align: right;">6000</td>
            </tr>
        </table>
        <div style="text-align: center; margin: 25px 10px 10px 10px;">
            <div id="dv1" style="width: 440px; height: 320px; float: left;"></div>
            <div id="dv2" style="width: 440px; height: 320px; float: left;"></div>
            <div id="dv3" style="width: 440px; height: 320px; float: left; margin-top: 20px;"></div>
            <div id="dv4" style="width: 440px; height: 320px; float: left; margin-top: 20px;"></div>
            <div id="dv5" style="width: 440px; height: 320px; float: left; margin-top: 20px;"></div>
            <div id="dv6" style="width: 440px; height: 320px; float: left; margin-top: 20px;"></div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $("body", window.parent.document).css("overflow-y", "scorll")
    });
    //钻去到企业列表
    function goEntprise(type) {
        var url = ''; var title = '';
        switch (type) {
            case '0':
                url = 'EnterpriseList.aspx';//申报单位数
                title = '';
                break;
            case '1':
                url = 'Checked/EnterpriseList.aspx';//审核通过
                title = '待审核';
                break;          
            default:
        }
        //iframe层
        layer.open({
            type: 2,
            title: false,
            maxmin: false, shadeClose: false,
            closeBtn: 0, 
            shade: false,
            maxmin: false, 
            area: ['100%', '100%'],
            content: url,
            yes: function (index, layero) {
                layer.close(index); //如果设定了yes回调，需进行手工关闭
            }
        });
    }
</script>

<%--echart图表--%>
<script type="text/javascript">

    var myChart1 = echarts.init(document.getElementById('dv1'));
    var option1 = {
        title: {
            text: '历年申报单位数量',
            x: 'center'
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ['单位数量']
        },
        xAxis: {
            data: ["2016上半年", "2016下半年", "2017上半年", "2017下半年"]
        },
        yAxis: {},
        series: [{
            name: '单位数量',
            type: 'line',
            data: [1200, 1000, 1400, 1200]
        }]
    };
    myChart1.setOption(option1);

    var myChart2 = echarts.init(document.getElementById('dv2'));
    var option2 = {
        title: {
            text: '2017上半年各产业办申报单位数量',
            x: 'center'
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ['单位数量']
        },
        xAxis: {
            data: ["金融办", "文创办", "中关村朝阳园", "商务委"]
        },
        yAxis: {},
        series: [{
            name: '单位数量',
            type: 'bar',
            barWidth: 50,
            data: [300, 250, 150, 500]
        }]
    };
    myChart2.setOption(option2);

    var myChart3 = echarts.init(document.getElementById('dv3'));
    var option3 = {
        title: {
            text: '历年申报资金',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ["2016上半年", "2016下半年", "2017上半年", "2017下半年"]
        },
        series: [
         {
             name: '申报资金',
             type: 'pie',
             radius: '55%',
             center: ['50%', '60%'],
             data: [
                 { value: 1000, name: '2016上半年' },
                 { value: 1000, name: '2016下半年' },
                 { value: 1500, name: '2017上半年' },
                 { value: 2500, name: '2017下半年' }
             ],
             itemStyle: {
                 emphasis: {
                     shadowBlur: 10,
                     shadowOffsetX: 0,
                     shadowColor: 'rgba(0, 0, 0, 0.5)'
                 }
             }
         }
        ]
    };
    myChart3.setOption(option3);

    var myChart4 = echarts.init(document.getElementById('dv4'));
    var option4 = {
        title: {
            text: '2017上半年各产业办申报资金',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ["金融办", "文创办", "中关村朝阳园", "商务委"]
        },
        series: [
         {
             name: '申报资金',
             type: 'pie',
             radius: '55%',
             center: ['50%', '60%'],
             data: [
                 { value: 2000, name: '金融办' },
                 { value: 1000, name: '文创办' },
                 { value: 500, name: '中关村朝阳园' },
                 { value: 2500, name: '商务委' }
             ],
             itemStyle: {
                 emphasis: {
                     shadowBlur: 10,
                     shadowOffsetX: 0,
                     shadowColor: 'rgba(0, 0, 0, 0.5)'
                 }
             }
         }
        ]
    };
    myChart4.setOption(option4);

    var myChart5 = echarts.init(document.getElementById('dv5'));
    var option5 = {
        title: {
            text: '历年审批资金',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ["2016上半年", "2016下半年", "2017上半年", "2017下半年"]
        },
        series: [
         {
             name: '审批资金',
             type: 'pie',
             radius: '55%',
             center: ['50%', '60%'],
             data: [
                 { value: 800, name: '2016上半年' },
                 { value: 800, name: '2016下半年' },
                 { value: 1200, name: '2017上半年' },
                 { value: 2300, name: '2017下半年' }
             ],
             itemStyle: {
                 emphasis: {
                     shadowBlur: 10,
                     shadowOffsetX: 0,
                     shadowColor: 'rgba(0, 0, 0, 0.5)'
                 }
             }
         }
        ]
    };
    myChart5.setOption(option5);

    var myChart6 = echarts.init(document.getElementById('dv6'));
    var option6 = {
        title: {
            text: '2017上半年各产业办审批资金',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'horizontal',
            y: 'bottom',
            data: ["金融办", "文创办", "中关村朝阳园", "商务委"]
        },
        series: [
         {
             name: '审批资金',
             type: 'pie',
             radius: '55%',
             center: ['50%', '60%'],
             data: [
                 { value: 1800, name: '金融办' },
                 { value: 900, name: '文创办' },
                 { value: 450, name: '中关村朝阳园' },
                 { value: 2200, name: '商务委' }
             ],
             itemStyle: {
                 emphasis: {
                     shadowBlur: 10,
                     shadowOffsetX: 0,
                     shadowColor: 'rgba(0, 0, 0, 0.5)'
                 }
             }
         }
        ]
    };
    myChart6.setOption(option6);
</script>

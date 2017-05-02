<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_CYB.Index.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
     <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
    <script src="../../js/plug/layer/Jquery.CBD.js"></script>
    <style type="text/css">
        body {
            text-align: center;
        }

        * {
            margin: 0 auto;
        }
         a {
            color:blue;
            cursor: pointer;
        }
        label {
            font-size: 16px;
            text-align: left;
        }      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>
                2017上半年产业资金申报情况 &nbsp;&nbsp;
                申报时间：2017年4月8日--2017年6月30日  &nbsp;&nbsp;
                <button class="button button-primary button-pill button-tiny" type="button" onclick="EditCapitalApply();">修改申报时间</button>
            </label>
        </div>
        <table class=" gridtable">
            <tr>
                <th colspan="3">申报情况</th>
                <th colspan="4">立项审核</th>
                <th colspan="3">资金评审</th>
            </tr>
            <tr>
                <th>申报类型</th>
                <th>申报单位数</th>
                <th>申报资金（万元）</th>
                <th>待审核</th>
                <th>退回修改</th>
                <th>审核通过</th>
                <th>申报资金（万元）</th>
                <th>核定</th>
                <th>不予支持</th>
                <th>审批资金（万元）</th>
            </tr>
            <tr>
                <td style="text-align: left;">金融资金-房屋补贴</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">1</a></td>
                <td style="text-align: right;">50</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('1');">1</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('2');">1</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('3');">1</a></td>
                <td style="text-align: right;">50</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('4');">1</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('5');">0</a></td>
                <td style="text-align: right;">50</td>
            </tr>
<%--            <tr>
                <td style="text-align: left;">金融资金-一次性入驻</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">200</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">1000</td>
            </tr>
            <tr>
                <td style="text-align: left;">金融资金-区级收入贡献</td>
                <td style="text-align: right;">400</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">200</td>
                <td style="text-align: right;">2000</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">100</td>
                <td style="text-align: right;">1000</td>
            </tr>--%>
            <tr>
                <td style="text-align: left; font-weight: 900">合计</td>
                <td style="text-align: right;">1</td>
                <td style="text-align: right;">50</td>
                <td style="text-align: right;" id="dsh"><%=Session["num1"]==null?1:Session["num1"] %></td>
                <td style="text-align: right;">1</td>
                <td style="text-align: right;">1</td>
                <td style="text-align: right;">50</td>
                <td style="text-align: right;">1</td>
                <td style="text-align: right;">0</td>
                <td style="text-align: right;">50</td>
            </tr>
        </table>
        <div style="text-align: left; margin: 20px 0px 10px 0px;">
            <span class="span-line"></span>
            <label>历年产业资金申报情况</label>
        </div>
        <div style="margin-bottom: 10px; font-size: 14px;">
                申报项目类型：
            <select class="combo">
                <option value="1000">全部</option>
                <option value="value">房屋补贴</option>
                <option value="value">一次性入驻</option>
                <option value="value">区级收入贡献</option>
            </select>&nbsp;&nbsp;
                <button class="button button-primary button-pill button-tiny" type="button" onclick="search()">查询</button>
        </div>
        <table class="gridtable">
            <tr>
                <th>序号</th>
                <th>产业资金申请</th>
                <th>申报单位数</th>
                <th>审核通过</th>
                <th>支持资金（万元）</th>
            </tr>
            <tr>
                <td>1</td>
                <td>2016上半年</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">500</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">400</a></td>
                <td>2500</td>
            </tr>
            <tr>
                <td>2</td>
                <td>2016下半年</td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">500</a></td>
                <td style="text-align: right;"><a href="javascript:void(0);" onclick="goEntprise('0');">400</a></td>
                <td>2500</td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript">
    //钻去到企业列表
    function goEntprise(type) {
        var url = ''; var title = '';
        switch (type) {
            case '0':
                url = 'SBQK/EnterpriseList.aspx';//申报单位数
                break;
            case '1':
                url = 'LXSH/UnChecked/EnterpriseList.aspx';//待审核
                break;
            case '2':
                url = 'LXSH/ReturnModification/EnterpriseList.aspx';//退回修改
                break;
            case '3':
                url = 'LXSH/Checked/EnterpriseList.aspx';//已审核
                break;
            case '4':
                url = 'ZJPS/UnChecked/EnterpriseList.aspx';//未核定
                break;
            case '5':
                url = 'ZJPS/Checked/EnterpriseList.aspx';//已核定
                break;
            default:
        }
        //iframe层
        layer.open({
            type: 2,
            title: false,
            //title: '添加资金申请',
            maxmin: false, shadeClose: false,
            closeBtn: 0, //不显示关闭按钮
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: ['100%', '100%'],
            content: url,
            yes: function (index, layero) {
                layer.close(index); //如果设定了yes回调，需进行手工关闭
            }
        });
    }

    //修改申报时间
    function EditCapitalApply() {
        layer.open({
            type: 2,
            title: '编辑资金申请信息',
            shadeClose: true,
            shade: false,
            //maxmin: true, //开启最大化最小化按钮
            area: ['360px', '200px'],
            content: 'EditApplyTime.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }
</script>

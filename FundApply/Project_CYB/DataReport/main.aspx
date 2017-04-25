<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_CYB.DataReport.main" %>

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
    <script src="../../js/plug/layer/layer.js"></script>
    <script src="../../js/plug/layer/Jquery.CBD.js"></script>

    <link href="../../css/plug/layui/css/layui.css" rel="stylesheet" />
    <script src="../../css/plug/layui/layui.js"></script>
    <script src="../../css/plug/layui/lay/dest/layui.all.js"></script>
    <style type="text/css">
        body {
            text-align: center;
        }

        * {
            margin: 0 auto;
        }

        a {
            color: blue;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>
                2016年产业办导入历史数据 &nbsp;&nbsp;
                                <button class="button button-primary button-pill button-tiny" type="button" onclick="AddEnterprise();">添加</button>
            </label>
        </div>
        <table class=" gridtable">
            <tr>
                <th>序号</th>
                <th>产业申报</th>
                <th>组织机构代码</th>
                <th>单位名称</th>
                <th>申报类型</th>
                <th>核定资金（万元）</th>
                <th>操作</th>
            </tr>
            <tr>
                <td>1</td>
                <td>金融业</td>
                <td>MA001DEU2</td>
                <td>北京test科技有限公司</td>
                <td>房屋补贴</td>
                <td>100</td>
                <td><a href="javascript:void(0);" onclick="Del()">删除</a></td>
            </tr>
            <tr>
                <td>2</td>
                <td>金融业</td>
                <td>MA001DEU2</td>
                <td>北京test科技有限公司</td>
                <td>房屋补贴</td>
                <td>100</td>
                <td><a href="javascript:void(0);" onclick="Del()">删除</a></td>
            </tr>
            <tr>
                <td>3</td>
                <td>金融业</td>
                <td>MA001DEU2</td>
                <td>北京test科技有限公司</td>
                <td>房屋补贴</td>
                <td>100</td>
                <td><a href="javascript:void(0);" onclick="Del()">删除</a></td>
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
                url = 'EnterpriseList.aspx';
                title = '';
                break;
            case '1':
                url = 'UnChecked/EnterpriseList.aspx';//待审核
                title = '待审核';
                break;
            case '2':
                url = 'Checked/EnterpriseList.aspx';//已审核
                title = '已审核';
                break;
            case '3':
                url = 'ReturnModification/EnterpriseList.aspx';//退回修改
                title = '退回修改';
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

    //对行进行操作 编辑 
    function AddEnterprise() {
        layer.open({
            type: 2,
            title: false,
            //title: '添加资金申请',
            maxmin: false, shadeClose: false,
            closeBtn: 0, //不显示关闭按钮
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: ['100%', '100%'],
            content: 'ApplyProject.aspx' //iframe的url
        });
    }

    function Del() {
        layer.confirm('您是确定要删除吗？', {
            btn: ['确定', '取消'] //按钮
        }, function () {
            layer.msg('已删除！', { icon: 1 });
        }, function () {
            //layer.msg('也可以这样', {
            //    time: 20000, //20s后自动关闭
            //    btn: ['明白了', '知道了']
            //});
        });
    }

    //对行进行操作 查看 
    function searchRow(year) {
        layer.open({
            type: 2,
            //title: year + '资金申请详细信息',
            title: false,
            //title: '添加资金申请',
            maxmin: false, shadeClose: false,
            closeBtn: 0, //不显示关闭按钮
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: ['100%', '100%'],
            content: 'EnterpriseList.aspx' //iframe的url
        });
    }

    //添加
    function EditAccount(name) {
        //iframe层
        layer.open({
            type: 2,
            title: '修改账号信息',
            maxmin: true, shadeClose: true,
            shade: false,
            area: ['350px', '200px'],
            content: 'AccountManage.aspx'
        });
    }

    //修改账户
    function EditAccount(name, type) {
        layer.open({
            type: 2,
            title: '修改账户信息和密码',
            shadeClose: true,
            shade: false,
            area: ['370px', '220px'],
            content: 'AccountManage.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }

    //资金评审
    function goZJPS(type) {
        var url = ''; var title = '';
        switch (type) {
            case '0':
                url = 'ZJPS/UnChecked/EnterpriseList.aspx';
                title = '未核定';
                break;
            case '1':
                url = 'ZJPS/Checked/EnterpriseList.aspx';//待审核
                title = '已核定';
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



    //修改申报时间
    function EditCapitalApply() {
        console.log("sdf");
        layer.open({
            type: 2,
            title: '编辑资金申请信息',
            shadeClose: true,
            shade: false,
            //maxmin: true, //开启最大化最小化按钮
            area: ['360px', '180px'],
            content: 'EditApplyTime.aspx',
            yes: function (index, layero) {
                layer.close(index);
            }
        });
    }
</script>

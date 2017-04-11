<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="FundApply.Project_Entprise.ProjectList" %>

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
</head>
<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul" id="nav">
            <li><a href="#">项目申报</a></li>
            <li><a href="#">项目列表</a></li>
        </ul>
    </div>
    <div class="rightinfo" id="div_content">
        <form id="form1" runat="server">
            <div style="margin-bottom: 2px; margin-top: 5px;">
                年份：
            <select class=" combo">
                <option value="1000">全部</option>
                <option value="2017">2017年</option>
                <option value="2016">2016年</option>
                <option value="2015">2015年</option>
                <option value="2014">2014年</option>
            </select>
                申报项目类型：
            <select class="combo">
                <option value="1000">全部</option>
                <option value="value">金融业</option>
                <option value="value">文化创意产业</option>
                <option value="value">高新技术产业</option>
                <option value="value">高新技术产业（信息服务业）</option>
                <option value="value">总部经济及服务业</option>
                <option value="value">中小企业发展</option>
                <option value="value">企业上市</option>
            </select>
                申报状态：
            <select class="combo">
                <option value="1000">全部</option>
                <option value="value">待审批</option>
                <option value="value">已审批</option>
                <option value="value">退回</option>
            </select>
            <button class="button button-primary button-pill button-tiny" type="button" onclick="GoSearch()">查询</button>
            </div>
            <div>
                <table id="dg1"></table>
            </div>
            <div id="tb" style="height: auto">
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="Add();">添加</a>
<%--                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="removeit()">删除</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true" onclick="accept()">保存</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-undo',plain:true" onclick="reject()">取消</a>--%>
                <%--<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true" onclick="getChanges()">GetChanges</a>--%>
            </div>
            <div id="win"></div>
        </form>
    </div>
</body>
</html>
<script type="text/javascript">

    $(function () {
        $('#dg1').datagrid({
            //toolbar: [{
            //    iconCls: 'icon-search',
            //    handler: function(){alert('edit')}
            //},'-',{
            //    iconCls: 'icon-help',
            //    handler: function(){alert('help')}
            //}],
            rownumbers: true,
            //url: '/SysUser/GetList',
            //width: SetGridWidthSub(10),
            methord: 'post',
            //height: SetGridHeightSub(45),

            fitColumns: true,
            sortName: 'Id',
            sortOrder: 'desc',
            idField: 'Id',
            pageSize: 15,
            pageList: [15, 20, 30, 40, 50],
            pagination: true,
            striped: true, //奇偶行是否区分
            singleSelect: true,//单选模式
            toolbar: '#tb',
            columns: [[
                        { field: 'ApplyYear', title: '申报年份', align: 'center', width: 55 },
                        { field: 'TypeBig', title: '项目类型大类', align: 'center', width: 55 },
                         { field: 'TypeSmall', title: '项目类型小类', align: 'center', width: 55 },
                        { field: 'ApplyTime', title: '申报时间', align: 'center', width: 55 },
                        { field: 'ApplyName', title: '申报联系人', align: 'center', width: 55 },
                        { field: 'Approve', title: '审批时间', align: 'center', width: 55 },
                        { field: 'Apprdove', title: '申报状态', align: 'center', width: 55 },
                        {
                            field: 'Operation', title: '操作', align: 'center', width: 55,
                            formatter: function (value, row, index) {
                                var btn = '<a class="editcls" onclick="searchRow(\'' + row.TypeBig + '\')" href="javascript:void(0)">查看</a>';
                                btn = btn + '<a class="editcls2" onclick="EditRow(\'' + row.TypeBig + '\')" href="javascript:void(0)">编辑</a>';
                                btn = btn + '<a class="editcls3" onclick="deleteRow(\'' + row.TypeBig +  '\')" href="javascript:void(0)">删除</a>';
                                return btn;
                            }
                        }
            ]],
            onLoadSuccess: function (data) {
                $('.editcls').linkbutton({ text: '', plain: true, iconCls: 'icon-search' });
                $('.editcls2').linkbutton({ text: '', plain: true, iconCls: 'icon-edit' });
                $('.editcls3').linkbutton({ text: '', plain: true, iconCls: 'icon-remove' });
            },
            data: {
                "total": 4, "rows":
                [
                    { "ApplyYear": "2017年", "TypeBig": "Koi", "TypeSmall": 10.00, "status": "P", "listprice": 36.50, "attr1": "Large", "itemid": "EST-1" },
                    { "ApplyYear": "2016年", "TypeBig": "Dalmation", "TypeSmall": 12.00, "status": "P", "listprice": 18.50, "attr1": "Spotted ", "itemid": "EST-10" },
                    { "ApplyYear": "2015年", "TypeBig": "Rattlesnake", "TypeSmall": 12.00, "status": "P", "listprice": 38.50, "attr1": "Venomless", "itemid": "EST-11" },
                    { "ApplyYear": "2014年", "TypeBig": "Rattlesnake", "TypeSmall": 12.00, "status": "P", "listprice": 26.50, "attr1": "Rattleless", "itemid": "EST-12" }
                ]
            }

        });
    });

    //添加
    function Add(name) {
        //iframe层
        layer.open({
            type: 2,
            //title:false,
            title: '添加公示信息',
            maxmin: true, shadeClose: true,
            shade: false,
            area: ['100%', '100%'],
            content: 'AddProject.aspx' //iframe的url
            //content: ['AddPolicy.aspx', 'no'] //iframe的url
        });
    }

    //对行进行操作 编辑 
    function EditRow(name) {
        layer.open({
            type: 2,
            title: '编辑公示信息',
            maxmin: true, shadeClose: true,
            shade: false,
            area: ['100%', '100%'],
            content: 'EditProject.aspx' //iframe的url
        });
    }

    //对行进行操作 查看 
    function searchRow(name) {
        layer.open({
            type: 2,
            title: '公示信息',
            maxmin: true, shadeClose: true,
            shade: false,
            area: ['100%', '100%'],
            content: 'PolicyProject.aspx' //iframe的url
        });
    }

    //删除
    function deleteRow(name, type) {
        $.messager.confirm('删除', '您确定要删除吗？', function (r) {
            if (r) {
                $.messager.show({
                    title: '删除',
                    msg: '这条消息已经删除！',
                    //timeout: 3000,
                    showType: 'slide'
                });
            }
        });
    }
</script>


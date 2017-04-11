<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FundApply.Project_Entprise.Index.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/buttons.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/plug/layer/layer.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-bottom: 10px;">
            <span class="span-line"></span>
            <label>贵单位还未申请2017上半年产业资金</label>&nbsp;&nbsp;
                            <button class="button button-primary button-pill button-tiny" type="button" onclick="Add()">立即申请</button>
            <div style="margin-top: 10px;"></div>
            <span class="span-line"></span>
            <label>贵单位申请材料已提交</label>
        </div>
        <table class=" gridtable">
            <tr>
                <th>申请年份</th>
                <th>申报类型</th>
                <th>申请资金</th>
                <th>审核资金</th>
                <th>审核单位</th>
                <th>审核状态</th>
                <th>审核时间</th>
                <th>相关文档</th>
                <th>操作</th>
            </tr>
            <tr>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">2017</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">金融业</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">500</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">-</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">金融办</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">待审核</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">-</a></td>
                <td><a href="../file/我是一个测试文件.docx" style="cursor: pointer;">详情</a></td>
                <td><a href="javascript:void(0);" onclick="Edit();" style="cursor: pointer;">修改</a></td>
            </tr>
        </table>
        <div style="text-align: left; margin: 20px 0px 10px 0px;">
            <span class="span-line"></span>
            <label>历史申报情况</label>
        </div>
        <table class=" gridtable">
            <tr>
                <th>序号</th>
                <th>年份</th>
                <th>申报类型</th>
                <th>申请资金</th>
                <th>审核资金</th>
                <th>审核单位</th>
                <th>审核时间</th>
                <th>相关文档</th>
                <th>操作</th>
            </tr>
            <tr>
                <td onclick="search();" style="cursor: pointer;">1</td>
                <td onclick="search();" style="cursor: pointer;">2017</td>
                <td onclick="search();" style="cursor: pointer;">金融业</td>
                <td onclick="search();" style="cursor: pointer;">500</td>
                <td onclick="search();" style="cursor: pointer;">500</td>
                <td onclick="search();" style="cursor: pointer;">金融办</td>
                <td onclick="search();" style="cursor: pointer;">2017-03-28</td>
                <td><a href="../file/我是一个测试文件.docx" style="cursor: pointer;">详情</a></td>
                <td onclick="search();" style="cursor: pointer;">查看</td>
            </tr>
            <tr>
                <td onclick="search();" style="cursor: pointer;">2</td>
                <td onclick="search();" style="cursor: pointer;">2016</td>
                <td onclick="search();" style="cursor: pointer;">文化创意产业</td>
                <td onclick="search();" style="cursor: pointer;">400</td>
                <td onclick="search();" style="cursor: pointer;">400</td>
                <td onclick="search();" style="cursor: pointer;">文化创意产业办</td>
                <td onclick="search();" style="cursor: pointer;">2017-03-28</td>
                <td><a href="../file/我是一个测试文件.docx" style="cursor: pointer;">详情</a></td>
                <td onclick="search();" style="cursor: pointer;">查看</td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript">
    //添加
    function Add() {
        layer.open({
            type: 2,
            title: false,
            maxmin: false, shadeClose: false,
            closeBtn: 0,
            shade: false,
            maxmin: false,
            area: ['100%', '100%'],
            content: 'AddProject.aspx'
        });
    }

    //对行进行操作 编辑 
    function Edit() {
        layer.open({
            type: 2,
            title: false,
            maxmin: false, shadeClose: false,
            closeBtn: 0,
            shade: false,
            maxmin: false,
            area: ['100%', '100%'],
            content: 'EditProject.aspx'
        });
    }

    //对行进行操作 查看 
    function search() {
        layer.open({
            type: 2,
            title: false,
            maxmin: false, shadeClose: false,
            closeBtn: 0,
            shade: false,
            maxmin: false,
            area: ['100%', '100%'],
            content: 'ProjectDetails.aspx'
        });
    }
</script>

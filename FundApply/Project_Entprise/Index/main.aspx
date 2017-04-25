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
    <style>
        a {
            color: blue;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        $.ajax({
            type: 'post',
            url: '<%=Request.Path%>/ExistsProject',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                if (r.d) {
                    $("#dvFirst").css("display", "none");
                    $("#dvSecond").css("display", "block");
                } else {
                    $("#dvFirst").css("display", "block");
                    $("#dvSecond").css("display", "none");
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: block;" id="dvFirst">
            <div>
                <span class="span-line"></span>
                <label>贵单位还未申请2017上半年产业资金</label>&nbsp;&nbsp;
                <button class="button button-primary button-pill button-tiny" type="button" onclick="Add()">立即申请</button>
            </div>
        </div>
        <div style="display: none;" id="dvSecond">
            <span class="span-line"></span>
            <label>贵单位申请材料已提交</label>
            <button class="button button-primary button-pill button-tiny" type="button" onclick="Add()">申请</button>
            <div style="margin-top: 10px;"></div>
            <table class=" gridtable">
                <tr>
                    <th>序号</th>
                    <th>申请年份</th>
                    <th>申报类型</th>
                    <th>申请资金</th>
                    <th>支持资金</th>
                    <th>审核单位</th>
                    <th>审核状态</th>
                    <th>审核时间</th>
                    <th>操作</th>
                </tr>

                <%for (int i = 0; i < projectApplyModelList.Count; i++){%>
                <tr>
                    <td style="text-align:center;"><%=i + 1 %></td>
                    <td><%=projectApplyModelList[i].CreateTime.ToString("yyyy") %></td>
                    <td><%=projectApplyModelList[i].IndustryId %></td>
                    <td style="text-align:right;"><%=projectApplyModelList[i].ApplyFund %></td>
                    <td style="text-align:right;"><%=projectApplyModelList[i].ApprovalFund %></td>
                    <td><%=projectApplyModelList[i].IndustryId %></td>
                    <td><%=projectApplyModelList[i].ProjectState %></td>
                    <td><%=projectApplyModelList[i].CreateTime.ToString("yyyy-MM-dd") %></td>
                    <td style="text-align:center;">
                        <a href="javascript:void(0);" onclick="Edit(<%=i %>);">修改</a>
                        <a href="javascript:void(0);" onclick="Del(<%=i %>);">删除</a>
                    </td>
                </tr>
                <%} %>
            </table>
        </div>
        <div style="text-align: left; margin: 20px 0px 10px 0px;">
            <span class="span-line"></span>
            <label>历史申报情况</label>
        </div>
        <table class=" gridtable">
            <tr>
                <th>序号</th>
                <th>申请年份</th>
                <th>申报类型</th>
                <th>申请资金</th>
                <th>支持资金</th>
                <th>审核单位</th>
                <th>审核状态</th>
                <th>审核时间</th>
                <th>操作</th>
            </tr>
            <% if (projectApplytHistoryModelLis.Count != 0)
                    {
                        for (int i = 0; i < projectApplytHistoryModelLis.Count; i++)
                {%>
            <tr>
                <td><%=i+1 %></td>
                <td><%=projectApplyModelList[i].CreateTime.ToString("yyyy") %></td>
                <td><%=projectApplyModelList[i].IndustryId %></td>
                <td><%=projectApplyModelList[i].ApplyFund %></td>
                <td><%=projectApplyModelList[i].ApprovalFund %></td>
                <td><%=projectApplyModelList[i].IndustryId %></td>
                <td><%=projectApplyModelList[i].ProjectState %></td>
                <td><%=projectApplyModelList[i].CreateTime.ToString("yyyy-MM-dd") %></td>
                <td>
                    <a href="javascript:void(0);" onclick="Search(<%=i %>);">详情</a>
                </td>
            </tr>
            <%}
        }
        else
        { %>
                <tr>
                    <td colspan="9" style="text-align: center;">暂无相关数据</td>
                </tr>
                <%} %>
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
    function Search() {
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Left" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>左侧菜单</title>
    <link href="css/font/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .iocOpen {
            display: table;
            transition: transform .6s;
            -webkit-transition: transform .6s;
            transform: rotate(90deg);
            -ms-transform: rotate(90deg);
            -webkit-transform: rotate(90deg);
        }
        .iocClose {
            display: table;
            transition: transform .6s;
            -webkit-transition: transform .6s;
            transform: rotate(0deg); 
            -ms-transform: rotate(0deg);
            -webkit-transform: rotate(0deg);
        }
    </style>
</head>
<body style="background: #f0f9fd;">
    <div class="leftDiv">
        <dl class="leftmenu">
<%--            <dd name="1">
                <div class="title lefttop">
                    <a href="Index.aspx?PGID=1" target="rightFrame" style="width: 100%; color: #fff; display: block">首页
                    </a>
                </div>              
            </dd>--%>

            <%--管理员--%>
             <dd name="1">
                <div class="title lefttop">
                    <span><i class="iconfont">&#xe6a7;</i></span>项目管理
                </div>
                  <ul class="menuson">
                    <li name="1" class="active"><cite></cite><a href="ProjectManage/ProjecApply/ProjectList.aspx" target="rightFrame">项目列表</a><i></i></li>
                    <li name="2" ><cite></cite><a href="ProjectManage/StatisticsQuery/StatisticsQuery.aspx" target="rightFrame">统计查询</a><i></i></li>                    
                    <li name="3" ><cite></cite><a href="ProjectManage/EnterpriseQuery/EnterpriseQuery.aspx" target="rightFrame">企业查询</a><i></i></li>
                    
                </ul>
            </dd> 
            <dd name="2">
                <div class="title lefttop">
                    <span><i class="iconfont">&#xe6a7;</i></span>信息管理
                </div>
                <ul class="menuson">
                    <li name="3"><cite></cite><a href="InformationManager/Policy/PolicyList.aspx" target="rightFrame">公示列表</a><i></i></li>
                    <li name="3"><cite></cite><a href="InformationManager/Publicity/PublicityList.aspx" target="rightFrame">政策列表</a><i></i></li>
                </ul>
            </dd>                              
             <dd name="23">
                <div class="title lefttop">
                    <span><i class="iconfont">&#xe6a7;</i></span>系统管理
                </div>
                <ul class="menuson">
                    <li name="24"><cite></cite><a href="AuthorityManage/org/main.aspx" target="rightFrame">部门管理</a><i></i></li>
                    <li name="25"><cite></cite><a href="AuthorityManage/Role/main.aspx" target="rightFrame">岗位管理</a><i></i></li>
                    <li name="26"><cite></cite><a href="AuthorityManage/fun/main.aspx" target="rightFrame">权限管理</a><i></i></li>
                    <li name="27"><cite></cite><a href="AuthorityManage/user/main.aspx" target="rightFrame">用户管理</a><i></i></li>
                    <li name="28"><cite></cite><a href="AuthorityManage/EnterpriseManage/EnterpriseManageList.aspx" target="rightFrame">企业管理</a><i></i></li>
                    <li name="29"><cite></cite><a href="AuthorityManage/TimeManage/TimeManageList.aspx" target="rightFrame">填报时限管理</a><i></i></li>
                    <li name="29"><cite></cite><a href="AuthorityManage/AccountManage/AccountManage.aspx" target="rightFrame">账号管理</a><i></i></li>
                </ul>
            </dd>                 
        </dl>
    </div>

    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/plug/slimscroll/jquery.slimscroll.js"></script>
    <script type="text/javascript">
        $(function () {
            //菜单动态化            
           <%-- for (var i = 1; i < 30; i++) {
                $('[name=' + i + ']').css('display', 'none');    
            }
            var  fun = <%= "["+(HttpContext.Current.Session["RoleEntity"]as RoleEntity).FUN+"]"%>;
            for (var i in fun) {
                if (fun[i]==3||fun[i]==4||fun[i]==5||fun[i]==6||fun[i]==7||fun[i]==8||fun[i]==9||fun[i]==10||fun[i]==11||fun[i]==12||fun[i]==13) {
                    $('[name=2]').css('display', 'block');
                }
                if (fun[i]==15||fun[i]==16||fun[i]==17||fun[i]==18||fun[i]==19) {
                    $('[name=14]').css('display', 'block');
                }
                if (fun[i]==21||fun[i]==22) {
                    $('[name=20]').css('display', 'block');
                }
                if (fun[i]==24||fun[i]==25||fun[i]==26||fun[i]==27||fun[i]==28||fun[i]==29) {
                    $('[name=23]').css('display', 'block');
                }
                $('[name=' + fun[i] + ']').css('display', 'block');
            }--%>

            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active");
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(".leftmenu i").addClass("iocClose");
                    $(this).find('span i').addClass("iocClose");
                    $(this).find('span i').removeClass("iocOpen");
                    $(this).next('ul').slideUp();
                } else {
                    $(".leftmenu i").addClass("iocClose");
                    $(this).find('span i').addClass("iocOpen");
                    $(this).find('span i').removeClass("iocClose");
                    $(this).next('ul').slideDown();
                }
            });

            $(".leftDiv").slimScroll({ width: $(parent.document.getElementById("leftFrame")).width(), height: $(parent.document.getElementById("leftFrame")).height(), size: '5px', color: '#000', borderRadius: '7px', railBorderRadius: '7px' });
        });

    </script>
</body>
</html>

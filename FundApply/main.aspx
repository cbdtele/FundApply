﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="MainBak" %>

<!DOCTYPE>
<html>
<head>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,Chrome=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>朝阳区发改委产业资金申请平台</title>
    <link rel="shortcut icon" href="logo.png" />
    <style>
        body {
            width: 1211px;
            margin: 0 auto;
        }
    </style>
</head>

<frameset eset cols="*,1024,*" frameborder="no" border="0" framespacing="0">
    <frame src="HtmlPage.html"></frame>
    <frameset rows="88,*" cols="*" frameborder="no" border="0" framespacing="0">
          <frame src="top.html" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
          <frameset cols="*" frameborder="no" border="0" framespacing="0">           
               
            <frame src="Project_Entprise/main.aspx"  name="rightFrame" id="rightFrame" title="rightFrame" />

       <%--     <frame src="Project_CYB/main.aspx"  name="rightFrame" id="rightFrame" title="rightFrame" />--%>

<%--            <frame src="Project_FGW/main.aspx"  name="rightFrame" id="rightFrame" title="rightFrame" />--%>
          </frameset>
        </frameset>
    <frame src="HtmlPage.html"></frame>  
</frameset>
</html>
<script type="text/javascript">
    //我只是一个小测试dddddffffffffhhhhhhhhhhhhhh
</script>

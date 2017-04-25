<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FundApply.Index1" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
	<title>朝阳区重点产业发展引导资金信息管理平台</title>
	<link rel="stylesheet" type="text/css" href="css/instyle.css">
    <link rel="shortcut icon" href="../images/logo.png" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/html5zoo.js"></script>
	<script type="text/javascript" src="js/lovelygallery.js"></script>
</head>
<body>
	<div id="wrap">
		<div id="topwrap">
			<div id="top"></div>
		</div>
		<div id="bannerwrap">
			<div id="banner" style="overflow:hidden;">
				<img class="" style="position:absolute;left:0px;" src="images/index-img1.jpg">
				<div class="pics_wrap" style="overflow:hidden;">
				<div id="html5zoo-1">
					<ul class="html5zoo-slides" style="display:none;">
					<li><a href=""><img src="images/index-img1.jpg" /></a></li>
					<li><a href=""><img src="images/index-img2.jpg" /></a></li>
					<li><a href=""><img src="images/index-img3.jpg" /></a></li>
					<li><a href=""><img src="images/index-img4.jpg" /></a></li>
					<li><a href=""><img src="images/index-img5.jpg" /></a></li>
					</ul>
				</div>
			</div>
				<div class="blueline"></div>
			</div>
		</div>
		<div id="contwrap">
			<div id="cont">
				<div class="main">
					<div class="left">
						<div class="tt"><img src="images/tt.png"></div>
						<div class="list">
							<div class="list_one">
								<ul>
									<li><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范 </span><span class="date">[2017-4-6]</span></a></li>
									<li style="border:0px;"><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范... </span><span class="date">[2017-4-6]</span></a></li>
								</ul>
							</div>
							<div class="list_two">
								<ul>
									<li><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范... </span><span class="date">[2017-4-6]</span></a></li>
									<li><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范... </span><span class="date">[2017-4-6]</span></a></li>
									<li><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范... </span><span class="date">[2017-4-6]</span></a></li>
									<li><a href="##"><span class="des">关于印发《朝阳区属国有企业房产出租管理专项规范... </span><span class="date">[2017-4-6]</span></a></li>
								</ul>
							</div>
							<div class="more"><a href="##"><img src="images/more.png"></a></div>
						</div>
					</div>
					<div class="mid">
						<img src="images/line.png">
					</div>
					<div class="right">
						<div class="PT">
							<div class="pts" style="margin-right: 14px;"><a href="EntpriseLogin.aspx" target="_blank"><img src="images/QySb.jpg"></a></div>
							<div class="pts" style="margin-right: 14px;"><a href="EntpriseLogin.aspx" target="_blank"><img src="images/login-reg.jpg"></a></div>
							<div class="pts"><a href="ManageLogin.aspx" target="_blank"><img src="images/innerGL.jpg"></a></div>
						</div>
						<div class="lists">
							<div class="tts"><img src="images/tts.png"></div>
							<div class="uls">
								<ul>
									<li class="addcolor"><a href="##"><span class="des">金融业</span><span class="date">2017/2/1—2017/4/1</span></a></li>
									<li><a href="##"><span class="des">文化创意产业</span></a></li>
									<li><a href="##"><span class="des">高薪技术产业</span></a></li>
									<li class="addcolor"><a href="##"><span class="des">高新技术产业（信息服务业）</span><span class="date">2017/2/1—2017/4/1</span></a></li>
									<li><a href="##"><span class="des">总部经济及服务业</span></a></li>
									<li><a href="##"><span class="des">中小企业发展</span></a></li>
								</ul>
							</div>
							
						</div>
					</div>
					<div style="clear:both"></div>
				</div>
			</div>
		</div>
		<div id="footerwrap">
			<div id="footer">
				<img class="footerbg" src="images/footer.png">
				<div class="linkwrap">
					<div class="link-tt">
						<img src="images/links.png">
					</div>
					<div class="linkmain">
						<div style="margin-left:5px;"><a href="http://www.bjpc.gov.cn/" target="_blank"><img src="images/linkimg1.png"></a></div>
						<div><a href="http://xxb.bjchy.gov.cn/" target="_blank"><img src="images/linkimg2.png"></a></div>
						<div><a href="http://www.chycci.gov.cn/" target="_blank"><img src="images/linkimg3.png"></a></div>
						<div><a href="http://finance.bjchy.gov.cn/web/775/index.html" target="_blank"><img src="images/linkimg4.png"></a></div>
						<div><a href="http://sww.bjchy.gov.cn/web/995/index.html" target="_blank"><img src="images/linkimg5.png"></a></div>
						<div><a href="http://www.zgccyy.gov.cn/" target="_blank"><img src="images/linkimg6.png"></a></div>
						<div><a href="http://www.wcsyq.gov.cn/" target="_blank"><img src="images/linkimg7.png"></a></div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<script type="text/javascript">
	$(document).ready(function(){
		$("ul li a .des").each(function(){
  	var str = $(this).html();
  	var returnStr = str.substr(0,23);
  	if(str.length > 23){
  		returnStr +="…";
  	}
  	$(this).attr("title",str).attr("alt",str).html(returnStr);
  })
	})
	</script>
</body>
</html>
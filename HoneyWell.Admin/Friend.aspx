<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friend.aspx.cs" Inherits="HoneyWell.Admin.Friend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
    <link rel="stylesheet"   href="css/public.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".btnpadding").hover(function () {
                $(this).addClass("bgcolor")
            }, function () {
                $(this).removeClass("bgcolor")
            });
        });
    </script>
    <script type="text/javascript" src="js/DataValid.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#btnSave").click(function () {
                DataAdd();
            });

            $("#btnSet").click(function () {
                $("#txtLoginName").val("");
                $("#txtLoginPassword").val("");
                $("#txtSecretCode").val("");
            });
            
            function DataAdd() {
                //获取表单值
                var LoginName = $("#txtLoginName").val();
                var LoginPassword = $("#txtLoginPassword").val();
                var SecretCode = $("#txtSecretCode").val();

                //TODO:数据有效性验证\格式验证\非空验证等
                if (IsNull(LoginName)) {
                    alert("用户名不能为空!");
                    document.getElementById("txtLoginName").focus();
                    return false;
                }

                if (IsNull(LoginPassword)) {
                    alert("密码不能为空!");
                    document.getElementById("txtLoginPassword").focus();
                    return false;
                }

                if (IsNull(SecretCode)) {
                    alert("暗码不能为空!");
                    document.getElementById("txtSecretCode").focus();
                    return false;
                }

                //参数Json串
                var paras = { RqtAction: "login", LoginName: LoginName, LoginPassword: LoginPassword, SecretCode: SecretCode };

                $.post("handlers/login/sys_Login_Check.ashx", paras, function (data) {
                    if (data == "error01") {
                        alert("暗码错误，请重新输入！");
                    }
                    if (data == "error02") {
                        alert("用户名或密码错误，请重新输入！");
                    }
                    if (data == "success") {
                        window.location.href = "Index.aspx";
                    }
                }, "text");

            }


        });
    </script>
</head>

<body style="background:#1d2024;">
    <form id="form1" runat="server" >
	<div class="headline">©后台管理系统</div>
	<div class="widget-box">
    	<div class="bdframe">
            <label class="header">请输入您的信息</label>
            <hr style="margin: 10px 0 20px 0;" />
            <div class="divhg">用户名：<input type="text"  id="txtLoginName"   onkeyup="value=value.replace(/[^\w\.\/]/ig,'')"   class="inputtxt"  placeholder="请输入用户名"/></div>
            <div class="divhg">密<span style="visibility: hidden;">占</span>码：<input type="password"  id="txtLoginPassword" class="inputtxt"  placeholder="请输入密码" /></div>
            <div class="divhg">暗<span style="visibility: hidden;">占</span>码：<input type="password"  id="txtSecretCode"   class="inputtxt"  placeholder="请输入暗码" /></div>
            <div  style="margin-top:14%;">
            	<span class="btntxt" style="margin-left:22%;"><span class="btnpadding" id="btnSave" onclick="">登&nbsp;&nbsp;录</span></span>
            	<span class="btntxt"><span class="btnpadding" id="btnSet"  onclick="">清&nbsp;&nbsp;空</span></span>
            </div>     
        </div>
        <div class="tflogo"></div>
        <div class="footbg"></div>
    </div>
    </form>
</body>
</html>

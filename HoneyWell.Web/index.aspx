<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HoneyWell.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Cache-Control" content="max-age=0"/>
    <meta name="apple-touch-fullscreen" content="yes"/>
    <meta name="apple-mobile-web-app-capable" content="yes"/>
    <meta name="apple-mobile-web-app-status-bar-style" content="black"/>
    <meta name="format-detection" content="telphone=no, email=no"/>
    <meta name="renderer" content="webkit"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta http-equiv="Cache-Control" content="no-siteapp"/>
    <meta name="msapplication-tap-highlight" content="no"/>
    <meta name="description" content="霍尼韦尔"/>
    <meta name="keywords" content="微商城"/>
    <title>敬请期待</title>
    <link rel="stylesheet" href="./css/flexible.css"/>
    <script type="text/javascript" src="./js/flexible.js"></script>
    <style>
        #wrap {
            width: 100%;
            height: 100%;
        }
        .logo {
            width: 2.31rem;
            height: 0.65rem;
            margin-top: 0.46rem;
            margin-left: 0.47rem;
        }
        .sorry {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
            width: 6.85rem;
            height: 4.87rem;
            margin: auto;
        }
    </style>
</head>
<body>
<div id="wrap">
    <img src="./img/ready/logo.png" alt="Honeywell" class="logo"/>
    <img src="./img/ready/sorry.png" alt="商城暂未上线，敬请期待！" class="sorry"/>
</div>
</body>
</html>

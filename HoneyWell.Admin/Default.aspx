<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HoneyWell.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
    <meta name="description" content="Static & Default" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"  href="css/bootstrap.min.css" />
    <link rel="stylesheet"  href="css/ace.min.css" />
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>

    <script language="javascript" type="text/javascript">
        $(function () {

            $("#BtnSign").click(function () {
                DataAdd("add")
            });

            function DataAdd(t) {
                var loginName = $("#txtLoginName").val();


                //参数Json串
                var paras = { loginName: loginName };

                $.post("../handlers/system/sys_Default.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回
                        location.href = "Default.aspx";
                }, "text");
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" value="<%=LoginName%>" id="txtLoginName" />
        <div class="container-fluid" id="main-container">
            <div id="main-content" class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>欢迎界面<small><i class="icon-double-angle-right"></i></small></h1>
                    </div>
         
                    <div class="row-fluid"> 
                        <div class="alert alert-block alert-success">
                            <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                            <i class="icon-ok green"></i><br />您现在使用的上海友赢信息科技有限公司的系统后台，互动使用方式，功能强大，操作简单！<br /><br />
                        </div>
                        <div class="space-6"></div>
                     </div> 
                </div>  
            </div>
        </div>
    </form>
</body>
</html>

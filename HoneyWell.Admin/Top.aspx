<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="HoneyWell.Admin.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
    <link rel="stylesheet"   href="css/bootstrap.min.css" />
    <link rel="stylesheet"   href="css/ace.min.css" />
    <script language="javascript">
        function logout() {
            if (confirm("您确定要退出系统吗？"))
                top.location = "LoginOut.aspx";
            return false;
        }
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar navbar-inverse">
          <div class="navbar-inner">
            <div class="container-fluid"> <a class="brand" href="#"><small><i class="icon-leaf"></i>后台管理系统</small> </a>
              <ul class="nav ace-nav pull-right">
                <li class="light-blue user-profile"> 
                <a class="user-menu dropdown-toggle" href="#" data-toggle="dropdown"> 
                    <img  src="images/avatar2.png" class="nav-user-photo" /> 
                    <span id="user_info"> <small>欢迎,</small> <%=UserName%> </span> 
                    <i class="icon-caret-down"></i> 
                </a>
                 </li>
                <li><a href="#" target="_self" onClick="logout();"><i class="icon-off"></i>退出</a></li>
              </ul>
            </div>
          </div>
        </div>
    </form>
</body>
</html>

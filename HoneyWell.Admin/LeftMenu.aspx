<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.aspx.cs" Inherits="HoneyWell.Admin.LeftMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
    <meta  name="description" content="Static & Left" />
    <meta  name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/public.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/leftmune.js"></script>
</head>
<body>
    <div class="leftmune">
	 <div class="total">
        <%=str_menu%>
      </div>
    </div>
</body>
</html>

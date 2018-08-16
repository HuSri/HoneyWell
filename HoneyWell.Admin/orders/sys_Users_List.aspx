<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Users_List.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Users_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" id="main-container">
            <input type="hidden" runat="server" id="StrItemId" value="" />
            <div id="main-content" class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">用户列表</h1>
                    </div>
                    <div class="table-header">
                        用户姓名或昵称：  
                    <input type="text" runat="server" id="txt_Name" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    手机号：&nbsp;&nbsp;  
                    <input type="text" runat="server" id="txt_Phone" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    性别：&nbsp;&nbsp;  
                        <asp:DropDownList ID="txtSex" runat="server" Style="width: 80px; margin-top: 10px">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="0">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>姓名</th>
                                <th>昵称</th>
                                <th>手机号</th>
                                <th>出生年月</th>
                                <th>性别</th>
                                <th>邮箱</th>
                                <th>注册时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><a href="<%#EditUrl(Eval("ID").ToString()) %>"><%#Eval("Name")%></a></td>
                                        <td><%#Eval("NickName")%></td>
                                        <td><%#Eval("Phone")%></td>
                                        <td><%#GetDate(Eval("DateBirth").ToString())%></td>
                                        <td><%#GetSex(Eval("Sex").ToString())%></td>
                                        <td><%#Eval("Email")%></td>
                                        <td><%#Eval("CreateTime")%></td>
                                        <td><a href="<%#OrdersUrl(Eval("Phone").ToString()) %>">订单信息</a>&nbsp;&nbsp;<a href="<%#ReturnUrl(Eval("Phone").ToString()) %>">退货信息</a>&nbsp;&nbsp;<a href="<%#AreaUrl(Eval("Phone").ToString()) %>">地址信息</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tbody>
                            <tr class="left_txt">
                                <td colspan="9" style="text-align: center; background-color: #ffffff">
                                    <mycols:MccNetPager ID="MyPager" StyleString="class='scott'" Next=">" Last=">>" Pres="..."
                                        Nexts="..." Pre="<" First="<<" Pages="10" runat="server" Pagesize="20" OnPageIndexChange="MyPager_PageIndexChange">
                                    </mycols:MccNetPager>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

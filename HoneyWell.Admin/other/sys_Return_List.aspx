<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Return_List.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Return_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>退货列表</title>
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
                        <h1 class="telelsz">退货列表<small><button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button></small></h1>
                    </div>
                    <div class="table-header">
                     用户账号：  
                    <input type="text" runat="server" id="txt_Phone" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    订单编号：&nbsp;&nbsp;  
                    <input type="text" runat="server" id="txt_ONumber" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    处理状态：&nbsp;&nbsp;  
                        <asp:DropDownList ID="txtRStatus" runat="server" Style="width: 80px; margin-top: 10px">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="0">已处理</asp:ListItem>
                            <asp:ListItem Value="1">未处理</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>用户账号</th>
                                <th>订单编号</th>
                                <th>退货理由</th>
                                <th>申请时间</th>
                                <th>退货回复</th>
                                <th>回复时间</th>
                                <th>处理状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><a href="<%#UsersUrl(Eval("Phone").ToString())%>""><%#Eval("Phone")%></a></td>
                                        <td><%#Eval("ONumber")%></td>
                                        <td><%#Eval("RReason")%></td>
                                        <td><%#Eval("RATime")%></td>
                                        <td><%#Eval("RReply")%></td>
                                        <td><%#Eval("RReplyTime")%></td>
                                        <td><%#GetStatus(Eval("RStatus").ToString())%></td>
                                        <td><a href="<%#EditUrl(Eval("ID").ToString())%>"">查看</a></td>
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

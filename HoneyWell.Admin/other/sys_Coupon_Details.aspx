<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Coupon_Details.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Coupon_Details" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>优惠券列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <link rel="stylesheet" href="../css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" id="main-container">
            <div id="main-content" class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">优惠券明细表<small><i class="icon-double-angle-right"></i><a href="sys_Coupon_List.aspx">优惠券列表</a></small></h1>
                    </div>
                    <div class="table-header">  优惠券状态：
                        <asp:DropDownList runat="server" ID="txtCState" style="width: 130px; margin-top: 10px;">
                            <asp:ListItem Value="">==请选择==</asp:ListItem>
                            <asp:ListItem Value="0">未使用</asp:ListItem>
                            <asp:ListItem Value="1">已领取</asp:ListItem>
                            <asp:ListItem Value="2">已过期</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th style="width: 70px">编号</th>
                                <th>优惠券类型</th>
                                <th>优惠券名称</th>
                                <th>主编号</th>
                                <th>优惠券明细编号</th>
                                <th>生成时间</th>
                                <th>状态</th>
                                <th>领取人</th>
                                <th>领取时间</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server" >
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#GetType(Eval("CCode").ToString())%></td>
                                        <td><%#GetName(Eval("CCode").ToString())%></td>
                                        <td><%#Eval("CCode")%></td>
                                        <td><%#Eval("CSmallCode")%></td>
                                        <td><%#Eval("CTime")%></td>
                                        <td><%#GetCState(Eval("CState").ToString()) %></td>
                                        <td><%#Eval("ReceiveUser")%></td>
                                        <td><%#Eval("ReceiveTime")%></td>
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

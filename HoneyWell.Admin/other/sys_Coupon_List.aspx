<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Coupon_List.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Coupon_List" %>

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
                        <h1 class="telelsz">优惠券列表<small><i class="icon-double-angle-right"></i><a href="sys_Coupon_Manage.aspx">新增优惠券</a></small></h1>
                    </div>
                    <div class="table-header">
                    <input type="hidden" runat="server" style="width: 130px; margin-top: 10px;" />
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th style="width:70px">编号</th>
                                <th >优惠券类型</th>
                                <th >优惠券名称</th>
                                <th >优惠券编号</th>
                                <th >优惠券内容</th>
                                <th >开始时间</th>
                                <th >结束时间</th>
                                <th >发行数量</th>
                                <th >操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#GetCType(Eval("CType").ToString())%></td>
                                        <td><%#Eval("CName")%></td>
                                        <td><%#Eval("CCode")%></td>
                                        <td><%#GetNum(Eval("CSum").ToString(),Eval("CDeduction").ToString())%></td>
                                        <td><%#Eval("StartingTime")%></td>
                                        <td><%#Eval("EndTime")%></td>
                                        <td><%#Eval("IssueNum")%></td>
                                        <td><a href="<%#DetailsUrl(Eval("CCode").ToString())%>">明细</a>
                                            &nbsp;<a href="<%#EditUrl(Eval("ID").ToString())%>">修改</a></td>
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

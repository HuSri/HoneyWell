   <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Orders_List.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Orders_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" id="main-container">
            <div id="main-content" class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">订单列表<small><button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button></small></h1>
                    </div>
                    <div class="table-header">
                    用户账号：  
                    <input type="text" runat="server" id="txt_Phone" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    订单编号：  
                    <input type="text" runat="server" id="txt_ONumber" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    发票类型：&nbsp;&nbsp;  
                    <asp:DropDownList ID="txtOType" runat="server" style="width:80px; margin-top:10px;">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem Value="0">个人</asp:ListItem>
                        <asp:ListItem Value="1">公司</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    支付方式：&nbsp;&nbsp;  
                    <input type="text" runat="server" id="txt_IType" style="width: 120px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    订单状态：&nbsp;&nbsp;  
                    <asp:DropDownList ID="txtOStatus" runat="server" style="width:80px; margin-top:10px;">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem Value="0">待付款</asp:ListItem>
                        <asp:ListItem Value="1">待发货</asp:ListItem>
                        <asp:ListItem Value="2">已发货</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>用户账号</th>
                                <th>下单时间</th>
                                <th>订单编号</th>
                                <th>发票类型</th>
                                <th>订单金额</th>
                                <th>支付方式</th>
                                <th>订单状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><a href="<%#UsersUrl(Eval("Phone").ToString()) %>"><%#Eval("Phone")%></a></td>
                                        <td><%#Eval("CreateTime")%></td>
                                        <td><%#Eval("ONumber")%></td>
                                        <td><%#GetOType(Eval("OType").ToString())%></td>
                                        <td><%#Eval("OActuallyPaid")%></td>
                                        <td><%#GetIType(Eval("IType").ToString())%></td>
                                        <td><%#GetOStatus(Eval("OStatus").ToString())%></td>
                                        <td style="width: 200px"><a href="<%#OrdersUrl(Eval("ID").ToString()) %>">详情信息</a>&nbsp;&nbsp;<a href="<%#InvoiceUrl(Eval("ONumber").ToString()) %>">发票信息</a>&nbsp;&nbsp;
                                            <a href="<%#ReceiptUrl(Eval("ID").ToString()) %>">收货地址</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tbody>
                            <tr class="left_txt">
                                <td colspan="20" style="text-align: center; background-color: #ffffff">
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

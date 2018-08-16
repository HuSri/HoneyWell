<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Receipt_List.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Receipt_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>地址列表</title>
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
                        <h1 class="telelsz">地址信息<small><button class="btn" type="button" id="back" onclick="javascript:history.go(-1);"><i class="icon-undo"></i>返回上一步</button></small></h1>
                    </div>
                    <div class="table-header"> 
                    <input type="hidden" runat="server" style="width: 120px; margin-top: 10px;" /> &nbsp;&nbsp;&nbsp;&nbsp; 
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>收货人</th>
                                <th>手机号</th>
                                <th>地区</th>
                                <th>街道</th>
                                <th>邮政编码</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#Eval("RName")%></td>
                                        <td><%#Eval("RPhone")%></td>
                                        <td><%#GetArea(Eval("Province").ToString(),Eval("City").ToString(),Eval("Area").ToString())%></td>
                                        <td><%#Eval("RAddress")%></td>
                                        <td><%#Eval("RZipCode")%></td>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Focus_List.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Focus_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>焦点图列表</title>
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
                        <h1 class="telelsz">焦点图列表<small><i class="icon-double-angle-right"></i><a href="sys_Focus_Manage.aspx">新增焦点图</a></small></h1>
                    </div>
                    <div class="table-header">
                        焦点图编码：  
                    <input type="text" runat="server" id="txt_FCode" style="width: 150px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        焦点图名称：  
                    <input type="text" runat="server" id="txt_FName" style="width: 150px; margin-top: 10px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th style="width:70px">编号</th>
                                <th >焦点图编码</th>
                                <th>焦点图名称</th>
                                <th style="width:70px">焦点图顺序</th>
                                <th >添加人</th>
                                <th >添加时间</th>
                                <th >操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server" OnItemCommand="rptLoop_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#Eval("FCode")%></td>
                                        <td><a href="<%#EditUrl(Eval("ID").ToString())%>"><%#Eval("FName")%></a></td>
                                        <td><%#Eval("FOrder")%></td>
                                        <td><%#Eval("CreateUser")%></td>
                                        <td><%#Eval("CreateTime")%></td>
                                        <td><a href="<%#EditUrl(Eval("ID").ToString())%>">修改</a>
                                            &nbsp;<asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认操作?')"><font color="red">删除</font></asp:LinkButton></td>
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

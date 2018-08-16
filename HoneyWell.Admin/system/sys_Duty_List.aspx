<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Duty_List.aspx.cs" Inherits="HoneyWell.system.sys_Duty_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色列表</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css"/>
    <link rel="stylesheet"   href="../css/ace.min.css"/>
    <link rel="stylesheet"   href="../css/style.css"/>
</head>
<body>
 <form id="form1" runat="server">
<div class="container-fluid" id="main-container">
    <div id="main-content" class="clearfix">
        <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">角色列表<small><i class="icon-double-angle-right"></i><a href="sys_Duty_Manage.aspx">新增角色</a></small></h1>
                    </div>
                	<div class="table-header"> 
                    角色名称：  
                    <input type="text" runat="server" id="txt_DutyName" style="width:150px; margin-top:10px;"  /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width:80px;"  OnClick="btnSearch_Click" />         
                   </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>角色名称</th>
                                <th>角色说明</th>
                                <th>添加人</th>
                                <th>添加时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptLoop" runat="server"  >
                        <ItemTemplate>
                               <tr>
                                    <td><%# Container.ItemIndex + 1%></td>
                                    <td><%#Eval("DutyName")%></td>
                                    <td><%#Eval("DutyDesc")%></td>
                                    <td><%#Eval("CreateUser")%></td>
                                    <td><%#Eval("CreateTime")%></td>
                                    <td><a href="<%#EditUrl(Eval("ID").ToString())%>">修改</a></td>
                                </tr>                    
                          
                         </ItemTemplate>
                         </asp:Repeater>
                          </tbody>
                           <tbody>
                           <tr   class="left_txt">
                           <td colspan="9"  style="text-align:center; background-color:#ffffff"  >
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

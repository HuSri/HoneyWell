<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Log_List.aspx.cs" Inherits="HoneyWell.system.sys_Log_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>日志列表</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css"/>
    <link rel="stylesheet"   href="../css/ace.min.css"/>
    <link rel="stylesheet"   href="../css/style.css"/>
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {

            $("#txtDivisionId").bind("change", BindItem);
            $("#txtItemId").bind("change", BindItem);

            //绑定项目
            function BindItem() {

                var paras = { DivisionId: $("#txtDivisionId").val(), ItemId: $("#txtItemId").val() };
                $.post("../handlers/system/sys_Member_BindItem1.ashx", paras, function (data) {
                    $("#StrItemId").val($("#txtItemId").val());
                    $("#txtItemId").empty();
                    $("#txtItemId").append(data);
                }, "HTML");
            }



        });
    </script>
</head>
<body>
 <form id="form1" runat="server">
<div class="container-fluid" id="main-container">
    <input type="hidden" runat="server" id="StrItemId"  value=""/>
    <div id="main-content" class="clearfix">
        <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">日志列表</h1>
                    </div>
                	<div class="table-header"> 
                    角色名称：  
                    <asp:DropDownList ID="txtDutyId" runat="server" style="width:133px; margin-top:10px; "></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    标&nbsp;&nbsp;题：&nbsp;&nbsp;  
                    <input type="text" runat="server" id="txt_TitleName" style="width:120px; margin-top:10px;"  /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    内&nbsp;&nbsp;容：&nbsp;&nbsp;  
                    <input type="text" runat="server" id="txt_Depicts" style="width:180px; margin-top:10px;"  /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width:80px;"  OnClick="btnSearch_Click" />         
                   </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>角色名称</th>
                                <th>用户名</th>
                                <th>标 题</th>
                                <th width="300px;">内 容</th>
                                <th>操作时间</th>
                               
                            </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptLoop" runat="server"  >
                        <ItemTemplate>
                               <tr>
                                    <td><%# Container.ItemIndex + 1%></td>
                                    <td><%# GetDuty(Eval("DutyId").ToString())%></td>
                                    <td><%#Eval("LoginName")%></td>
                                    <td><%#Eval("TitleName")%></td>
                                    <td><%#Eval("Depicts")%></td>
                                    <td><%#Eval("CreateTime")%></td>
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

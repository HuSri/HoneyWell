<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="sys_Product_List.aspx.cs" Inherits="HoneyWell.Admin.product.sys_Product_List" %>

<%@ Register Assembly="PublicControls" Namespace="PublicControls" TagPrefix="mycols" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
</head>
    <script type="text/javascript">
        $(function () {
            $("#txt_PTypeMain").bind("change", BindTypeSmall);
            $("#txt_PTypeSmall").bind("change", BindType);
            //绑定类别
            function BindTypeSmall() {
                var paras = { TCode: $("#txt_PTypeMain").val(), TLevel: 2 };
                $.post("../handlers/product/sys_Product.ashx", paras, function (data) {
                    $("#txt_PTypeSmall").empty();
                    $("#txt_PTypeSmall").append(data);
                    $("#hfPTypeSmall").val();
                    $("#hfPTypeMain").val($("#txt_PTypeMain").val());
                },"HTML");
            }
            
            function BindType() {
                if ($("#txt_PTypeSmall").val() != "") {
                    $("#hfPTypeSmall").val($("#txt_PTypeSmall").val());
                }
                else {
                    $("#hfPTypeSmall").val("");
                }
            }
        })
    </script>
    <script type="text/javascript" >
        function getPType(PTypeMain, PTypeSmall) {
            var paras = { TCode: PTypeMain, TLevel: 2 };
            $.post("../handlers/product/sys_Product.ashx", paras, function (data) {
                $("#txt_PTypeSmall").empty();
                $("#txt_PTypeSmall").append(data);
                $("#txt_PTypeMain").val(PTypeMain);
                $("#hfPTypeMain").val(PTypeMain);
                $("#txt_PTypeSmall").val(PTypeSmall);
                $("#hfPTypeSmall").val(PTypeSmall);
            }, "HTML");
        }
    </script>
<body>
    <form id="form1" runat="server">
  <asp:HiddenField ID="hfPTypeMain"   runat="server"  Value="" />
 <asp:HiddenField ID="hfPTypeSmall" runat="server"  Value="" />
        <div class="container-fluid" id="main-container">
            <div id="main-content" class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1 class="telelsz">产品列表<small><i class="icon-double-angle-right"></i><a href="sys_Product_Manage.aspx">新增产品</a></small></h1>
                    </div>
                    <div class="table-header">
                        产品大类：
                     <asp:DropDownList ID="txt_PTypeMain" runat="server" Style="width: 130px; margin-top: 10px;"></asp:DropDownList>
                        产品小类：
                     <asp:DropDownList ID="txt_PTypeSmall" runat="server" Style="width: 130px; margin-top: 10px;"></asp:DropDownList>
                        &nbsp;产品名称：  
                    <input type="text" runat="server" id="txt_PName" style="width: 150px; margin-top: 10px;" />
                        &nbsp; 产品规格：  
                    <input type="text" runat="server" id="txt_PFormat" style="width: 150px; margin-top: 10px;" />
                        &nbsp; 适用机型：
                    <input type="text" runat="server" id="txt_PMould" style="width: 150px; margin-top: 10px;" />
                        &nbsp; 是否推荐：
                     <asp:DropDownList ID="txt_PRecommend" runat="server" Style="width: 80px; margin-top: 10px;">
                         <asp:ListItem Value="">请选择</asp:ListItem>
                         <asp:ListItem Value="0">是</asp:ListItem>
                         <asp:ListItem Value="1">否</asp:ListItem>
                     </asp:DropDownList>
                        &nbsp; 是否上架：
                     <asp:DropDownList ID="txt_PShelf" runat="server" Style="width: 80px; margin-top: 10px;">
                         <asp:ListItem Value="">请选择</asp:ListItem>
                         <asp:ListItem Value="0">是</asp:ListItem>
                         <asp:ListItem Value="1">否</asp:ListItem>
                     </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnSearch" runat="server" Text="查 询" Style="width: 80px;" OnClick="btnSearch_Click" />
                    </div>
                    <table id="table_report" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th style="width: 70px">编号</th>
                                <th>产品类别</th>
                                <th>产品名称</th>
                                <th>产品缩略图</th>
                                <th>市场价</th>
                                <th>零售价</th>
                                <th>库存数量</th>
                                <th style="width: 60px">是否推荐</th>
                                <th style="width: 60px">是否上架</th>
                                <th style="width: 130px">操作时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server" OnItemCommand="rptLoop_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#GetType(Eval("PTypeMain").ToString(),Eval("PTypeSmall").ToString())%></td>
                                        <td><%#Eval("PName")%></td>
                                        <td><%#GetUrl(Eval("PSmallPic").ToString())%></td>
                                        <td><%#Eval("PMarket")%></td>
                                        <td><%#Eval("PRetail")%></td>
                                        <td><%#Eval("PStock")%></td>
                                        <td><%#GetRecommend(Eval("PRecommend").ToString())%></td>
                                        <td><%#GetShelf(Eval("PShelf").ToString())%></td>
                                        <td><%#Eval("ModifyTime")%></td>
                                        <td><a href="<%#EditUrl(Eval("ID").ToString())%>">修改</a>
                                            &nbsp;<asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认操作?')"><font color="red">删除</font></asp:LinkButton></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tbody>
                            <tr class="left_txt">
                                <td colspan="20" style="text-align: center; background-color: #ffffff;">
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

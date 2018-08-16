<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Area_Menu.aspx.cs" Inherits="HoneyWell.paras.sys_Area_Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <script language="javascript" type="text/javascript">
       function editshow(Text, Value) {
           //alert("你当前选择的节点名称为：" + Text);
           //alert("nodeValue:" + Value);
           if (Value == "000000") {
               window.parent.right.location.href = "sys_Area_Add.aspx?nodeText=" + Text + "&nodeValue=" + Value + "";
           }
           else {
               window.parent.right.location.href = "sys_Area_Manage.aspx?nodeText=" + Text + "&nodeValue=" + Value + "";
           }
       }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:5px; padding-left:20px;">
       <asp:TreeView ID="TreeView1" runat="server" ImageSet="Faq" >
        <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
        <NodeStyle  Font-Names="Tahoma" Font-Size="10pt" ForeColor="DarkBlue"  HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True"  HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
     </div>
    </form> 
</body>
</html>


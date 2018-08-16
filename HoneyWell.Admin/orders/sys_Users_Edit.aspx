<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Users_Edit.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Users_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <script language="javascript" type="text/javascript" >
         $(function () {
            $("#btnSaveBack").click(function () {
                DataAdd("")
            });
            function DataAdd(t) {
                var Id = $("#hdnPKID").val();
                var PassWord = $("#txtUserPassword").val();

                var paras = { Id: Id, PassWord: PassWord };
                $.post("../handlers/orders/sys_Users_Manage.ashx", paras, function (data) {
                    alert(data);
                    location.href = "sys_Users_List.aspx";
                }, "text");
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <input type="hidden" value="<%=PKID%>" id="hdnPKID" />
        <div class="container-fluid" id="main-container">
            <div class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>用户管理<small><i class="icon-double-angle-right"></i><a href="sys_Users_List.aspx">用户列表</a></small></h1>
                    </div>
                    <div class="row-fluid">

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;OpenID</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OpenID %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;手机号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=Phone %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;密码</label>
                            <div class="controls" style="padding-top: 5px">
                                <input type="password"  id="txtUserPassword" value="<%=PassWord %>" style="width:100px;"/>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;姓名</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=Name %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;头像</label>
                            <div class="controls">
                                <div id="preview">
                                    <img id="imghead" src="<%=SPic%>" />
                                </div>
                                <%=SPicLink %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;昵称</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=NickName %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;出生日期</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=DateBirth %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;性别</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=StrSex%>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;邮箱</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=Email%>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;注册时间</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=CreateTime%>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button>
                            &nbsp; &nbsp;
                        <button class="btn btn-info" type="button" id="btnSaveBack" onclick="">
                            <i class="icon-ok"></i>完成并返回列表</button>
                        </div>

                        <div class="space-24ger"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

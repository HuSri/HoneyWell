<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Return_Edit.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Return_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>退货管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {

            $("#btnSave").click(function () {
                DataAdd("reset")
            });

            $("#btnSaveBack").click(function () {
                DataAdd("")
            });

            function DataAdd(t) {
                var RReply = $("#txtRReply").val();
                var RStatus = $("#txtRStatus").val();

                //TODO:数据有效性验证\格式验证\非空验证等
                if (RReply=="") {
                    alert("退货回复不能为空!");
                    return false;
                }

                //ID作为区别何种操作
                var Id = $("#hdnPKID").val();

                //参数Json串
                var paras = { Id: Id, RReply: RReply, RStatus: RStatus };

                $.post("../handlers/other/sys_Return_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回列表
                        location.href = "sys_Return_List.aspx";

                }, "text");
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <input type="hidden" value="<%= PKID%>" id="hdnPKID" />
        <div class="container-fluid" id="main-container">
            <div class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>退货管理 <small><i class="icon-double-angle-right"></i><a href="sys_Return_Edit.aspx">退货列表</a></small></h1>
                    </div>
                    <div class="row-fluid">

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;登录账号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=Phone %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;订单编号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=ONumber %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;退货理由</label>
                            <div class="controls">
                                <textarea id="txtRReason" style="width: 250px; height: 100px;" runat="server"></textarea>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;申请时间</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=RATime %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;退货回复</label>
                            <div class="controls">
                                <textarea id="txtRReply" style="width: 250px; height: 100px;" runat="server"></textarea>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;回复时间</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=RReplyTime %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2">&nbsp;处理状态</label>
                            <div class="controls">
                                <select style="width: 100px" id="txtRStatus"><%=StrStatus %></select>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button>
                            &nbsp; &nbsp;
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

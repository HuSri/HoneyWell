<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Invoice_Edit.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Invoice_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发票信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="container-fluid" id="main-container">
            <div class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>发票信息<small><i class="icon-double-angle-right"></i><a href="sys_Orders_List.aspx">订单列表</a></small></h1>
                    </div>
                    <div class="row-fluid">

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;订单编号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=ONumber %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;发票类型</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=StrICode %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;发票抬头</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=IGainGround %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;发票税号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=ITaxNumber %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;备注说明</label>
                            <div class="controls">
                                <textarea id="txtIRemarks" runat="server" style="width: 300px; height: 150px;"></textarea>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button>
                        </div>

                        <div class="space-24ger"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

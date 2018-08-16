<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Receipt_Edit.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Receipt_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>地址管理</title>
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
                        <h1>收货地址<small><i class="icon-double-angle-right"></i><a href="sys_Orders_List.aspx">订单列表</a></small></h1>
                    </div>
                    <div class="row-fluid">

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;用户账号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=Phone %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;姓名</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=RName %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;手机号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=RPhone %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;地址信息</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=StrArea %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;邮政编码</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=RZipCode %>
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

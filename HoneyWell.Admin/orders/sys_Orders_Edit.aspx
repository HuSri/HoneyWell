<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Orders_Edit.aspx.cs" Inherits="HoneyWell.Admin.orders.sys_Orders_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>详情信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <style type="text/css">
        .fluid {
        float:left;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {

            $("#btnSave").click(function () {
                DataAdd("reset")
            });

            $("#btnSaveBack").click(function () {
                DataAdd("")
            });

            function DataAdd(t) {
                var OStatus = $("#txtOStatus").val();

                //ID作为区别何种操作
                var Id = $("#hdnPKID").val();

                //参数Json串
                var paras = { Id: Id, OStatus: OStatus};

                $.post("../handlers/orders/sys_Orders_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回列表
                        location.href = "sys_Orders_List.aspx";

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
                        <h1>详情信息<small><i class="icon-double-angle-right"></i><a href="sys_Orders_List.aspx">订单列表</a></small></h1>
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
                                <%=StrOType %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;创建时间</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=CreateTime %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;快递公司</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=CCompany %>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;快递单号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=SNumber%>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;安装费</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OFee %>&nbsp;元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;运费</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OFare %>&nbsp;元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;应付金额</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OCope %>&nbsp;元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;实付金额</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OActuallyPaid %>&nbsp;元
                            </div>
                        </div>

                        <div class="control-group"  style="float:left;margin-left:450px;margin-top:-450px">
                            <label class="control-label" for="form-field-1">&nbsp;支付方式</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=StrIType %>
                            </div>
                        </div>

                        <div class="control-group"  style="float:left;margin-left:450px;margin-top:-400px">
                            <label class="control-label" for="form-field-1">&nbsp;收货人姓名</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OName %>
                            </div>
                        </div>

                        <div class="control-group" style="float:left;margin-left:450px;margin-top:-350px">
                            <label class="control-label" for="form-field-1">&nbsp;收货人手机号</label>
                            <div class="controls" style="padding-top: 5px">
                                <%=OPhone %>
                            </div>
                        </div>
                        
                        <div class="control-group" style="float:left;margin-left:450px;margin-top:-300px">
                            <label class="control-label" for="form-field-1">&nbsp;收货人地址信息</label>
                            <div class="controls" style="padding-top: 5px">
                                    <%=StrArea%>
                                    <%=OAddress %>
                            </div>
                        </div>

                        <div class="control-group" style="float:left;margin-left:450px;margin-top:-250px">
                            <label class="control-label" for="form-field-2">备注说明</label>
                            <div class="controls">
                                <textarea id="txtRemarks" style="width: 200px; height: 100px;" runat="server"></textarea>
                            </div>
                        </div>

                        <div class="control-group" style="float:left;margin-left:450px;margin-top:-100px">
                            <label class="control-label" for="form-field-1">&nbsp;订单状态</label>
                            <div class="controls">
                                <select style="width: 80px" id="txtOStatus"><%=StrOStatus %></select>
                            </div>
                        </div>

                        <h2 style="margin-left:10px">商品信息</h2>
                        <table id="table_report" class="table table-striped table-bordered table-hover" style="width:900px">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>产品名称</th>
                                <th>产品缩略图</th>
                                <th>产品规格</th>
                                <th>市场价</th>
                                <th>零售价</th>
                                <th>购买数量</th>
                                <th>合计金额</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptLoop" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1%></td>
                                        <td><%#Eval("SName")%></td>
                                        <td><%#GetUrl(Eval("SSmallPic").ToString())%></td>
                                        <td><%#Eval("SFormat")%></td>
                                        <td><%#Eval("SMarket")%></td>
                                        <td><%#Eval("SRetail")%></td>
                                        <td><%#Eval("SQuantity")%></td>
                                        <td><%#Eval("SSum")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Coupon_Manage.aspx.cs" Inherits="HoneyWell.Admin.other.sys_Coupon_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>优惠券管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <script type="text/javascript" src="../date/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#btnSave").click(function () {
                DataAdd("reset")
            });

            $("#btnSaveBack").click(function () {
                DataAdd("")
            });

            function DataAdd(t) {

                var CType = $("#txtCType").val();
                var CName = $("#txtCName").val();
                var CSum = $("#txtCSum").val();
                var Deduction = $("#txtDeduction").val();
                var TDateS = $("#txtTDateS").val();
                var TDateE = $("#txtTDateE").val();
                var IssueNum = $("#txtIssueNum").val();
                var Remark = $("#txtRemark").val();

                //TODO:数据有效性验证\格式验证\非空验证等
                if (CType == "0") {
                    alert("请选择优惠券类型!");
                    return false;
                }
                if (CName == "") {
                    alert("优惠券名称不能为空!");
                    return false;
                }
                //ID作为区别何种操作
                var Id = $("#hdnPKID").val();
                var CCode = $("#hdnCCode").val();

                //参数Json串
                var paras = { Id: Id, CType: CType, CName: CName,CCode:CCode, CSum: CSum, Deduction: Deduction, TDateS: TDateS, TDateE: TDateE, IssueNum: IssueNum, Remark: Remark };

                $.post("../handlers/other/sys_Coupon_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回列表
                        location.href = "sys_Coupon_List.aspx";
                }, "text");
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <input type="hidden" value="<%=PKID%>" id="hdnPKID" />
        <input type="hidden" value="<%=CCode%>" id="hdnCCode" />
        <div class="container-fluid" id="main-container">
            <div class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>新增优惠券<small><i class="icon-double-angle-right"></i><a href="sys_Coupon_List.aspx">优惠券列表</a></small></h1>
                    </div>
                    <div class="row-fluid">
                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;优惠券类型</label>
                            <div class="controls">
                                <select id="txtCType" style="width: 150px;"><%=StrCType %></select>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2"><font color="red">*</font>&nbsp;优惠券名称</label>
                            <div class="controls">
                                <input type="text" id="txtCName" value="<%=CName%>" placeholder="优惠券名称不能为空" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-2"><font color="red">*</font>&nbsp;满：</label>
                            <div class="controls">
                                <input type="text" id="txtCSum" style="width: 100px" value="<%=CSum%>" />&nbsp;元&nbsp;&nbsp;减：&nbsp;&nbsp;<input type="text" id="txtDeduction" style="width: 100px" value="<%=Deduction%>" />&nbsp;元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;开始时间</label>
                            <div class="controls">
                                <input type="text" runat="server" id="txtTDateS" style="width: 100px;" onclick="WdatePicker({ startDate: '%y-%M-%d ', dateFmt: 'yyyy-MM-dd ' });" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;结束时间</label>
                            <div class="controls">
                                <input type="text" runat="server" id="txtTDateE" style="width: 100px;" onclick="WdatePicker({ startDate: '%y-%M-%d ', dateFmt: 'yyyy-MM-dd ' });" />
                            </div>
                        </div>
                     
                        <div class="control-group">
                            <label class="control-label" for="form-field-2"><font color="red">*</font>&nbsp;发行数量</label>
                            <div class="controls">
                                <input type="text" id="txtIssueNum" value="<%=IssueNum%>"/>
                            </div>
                        </div>
                       
                        <div class="control-group">
                            <label class="control-label" for="form-field-2">备注信息</label>
                            <div class="controls">
                                <textarea id="txtRemark" style="width:250px;height:100px;" runat="server"></textarea>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button>
                            &nbsp; &nbsp;
                        <button class="btn btn-info" type="button" id="btnSave" onclick="">
                            <i class="icon-ok"></i>完成并继续添加</button>
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

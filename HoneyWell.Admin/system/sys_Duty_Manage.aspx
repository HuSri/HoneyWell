<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Duty_Manage.aspx.cs" Inherits="HoneyWell.system.sys_Duty_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色管理</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css" />
    <link rel="stylesheet"   href="../css/ace.min.css" />
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
                var DutyName = $("#txtDutyName").val();
                var DutyDesc = $("#txtDutyDesc").val();
                var MenuSetting = $("#MenuSetting").val();


                //TODO:数据有效性验证\格式验证\非空验证等
                if (IsNull(DutyName)) {
                    alert("角色名称不能为空!");
                    return false;
                }

                if (IsNull(DutyDesc)) {
                    alert("角色说明不能为空!");
                    return false;
                }
                //ID作为区别何种操作
                var Id = $("#hdnPKID").val();

                //参数Json串
                var paras = { Id: Id, DutyName: DutyName, DutyDesc: DutyDesc, MenuSetting: MenuSetting };

                $.post("../handlers/system/sys_Duty_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回列表
                        location.href = "sys_Duty_List.aspx";

                }, "text");
            }
        });
    </script>

     <script type="text/javascript">
         function checkJX(jxd) {
             var str = "";
             var cb = document.getElementsByName("cb");
             var invalue = "";

             for (var i = 0; i < cb.length; i++) {

                 if (cb[i].checked == true) {
                     sel = cb[i];
                     str = str + "," + sel.value + "";

                 }

             }
             document.getElementById("MenuSetting").value = str.substring(1);
         }
                   
    </script> 
 
</head>
<body>
    <form id="form1" runat="server"  class="form-horizontal">
       <input type="hidden" value="<%= PKID%>" id="hdnPKID" />
       <input type="hidden" value="<%= MenuSetting%>" id="MenuSetting" />
       <div class="container-fluid" id="main-container"> 
          <div  class="clearfix">
            <div id="page-content" class="clearfix">
              <div class="page-header position-relative">
                <h1>角色管理 <small><i class="icon-double-angle-right"></i><a href="sys_Duty_List.aspx">角色列表</a></small></h1>
              </div>
              <div class="row-fluid">
       
                  <div class="control-group">
                    <label class="control-label" for="form-field-1"><font color=red>*</font>&nbsp;角色名称</label>
                    <div class="controls">
                      <input type="text" id="txtDutyName" value="<%=DutyName %>"  placeholder="角色名称不能为空"/>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-2"><font color=red>*</font>&nbsp;角色说明</label>
                    <div class="controls">
                      <input type="text"  id="txtDutyDesc" value="<%=DutyDesc %>"  placeholder="角色说明不能为空"/> 
                    </div>
                  </div>

                  <div class="control-group">
                    <label class="control-label" for="form-field-2" >模块权限</label>
                     <div class="controls"  style=" padding-top:4px;">
                        <span id="sp_MenuSetting"  runat="server"></span>
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

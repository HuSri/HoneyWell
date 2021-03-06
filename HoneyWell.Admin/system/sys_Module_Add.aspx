﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Module_Add.aspx.cs" Inherits="HoneyWell.system.sys_Module_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模块信息管理</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css" />
    <link rel="stylesheet"   href="../css/ace.min.css" />
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script language="javascript">
        function valCode() {

            var txt_MenuCode = document.getElementById("txt_MenuCode").value;
            var txt_MenuNameC = document.getElementById("txt_MenuNameC").value;

            if (txt_MenuCode.length == 0) {
                alert("模块代码不能为空!");
                return false;
            }

            if (txt_MenuNameC.length == 0) {
                alert("模块名称不能为空!");
                return false;
            }


            return true;
        }
 
    </script>
</head>
<body>
    <form id="form1" runat="server"  class="form-horizontal">
         <input type="hidden" id="h_MenuLevel" runat="server" value="" />
       <div class="container-fluid" id="main-container"> 
          <div  class="clearfix">
            <div id="page-content" class="clearfix">
              <div class="page-header position-relative">
                <h1>模块管理</h1> <small>&nbsp;&nbsp;<input type="button" ID="Button1"  class="button01" value="上一步" onclick="javascript:history.go(-1);" /></small>
              </div>
              <div class="row-fluid">
                   <div class="control-group">
                    <label class="control-label" for="form-field-1">父级名称</label>
                    <div class="controls">
                      <label id="lab_ParentName" style="margin-top:5px; font-weight:800px" runat="server"></label>
                    </div>
                  </div>
       
                  <div class="control-group">
                    <label class="control-label" for="form-field-1"><font color=red>*</font>&nbsp;模块代码</label>
                    <div class="controls">
                      <input type="text" id="txt_MenuCode" runat="server" placeholder="模块代码不能为空" style="width:120px"/>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-2"><font color=red>*</font>&nbsp;模块名称</label>
                    <div class="controls">
                      <input type="text" id="txt_MenuNameC" runat="server"  placeholder="模块名称不能为空"/>
                   </div>
                  </div>
                   

                  <div class="control-group">
                    <label class="control-label" for="form-field-2">显示顺序</label>
                    <div class="controls">
                      <input type="text" id="txt_MenuOrder" runat="server"  style="width:50px" onKeyUp="if(isNaN(value))execCommand('undo')"/>
                    </div>     
                  </div>

                  <div class="control-group">
                    <label class="control-label" for="form-field-2">链接地址</label>
                    <div class="controls">
                      <input type="text" id="txt_MenuUrl" runat="server"  style="width:300px"/>
                    </div> 
                  </div> 
                    
                  <div class="form-actions">
                     <button class="btn btn-info" type="button"  id="save"  onclick="return save_onclick()"><i class="icon-ok"></i>保存</button>
                    &nbsp; &nbsp;
                     <button class="btn btn-info" type="button"  id="reset"   onclick="return reset_onclick()"><i class="icon-ok"></i>重置</button>
                  </div>
                   <span style="display:none;"><asp:Button  ID="btnSave"   runat="server"   Text="Button"    OnClientClick="return valCode()"   onclick="btnSave_Click" /></span>
                   <div class="space-24ger"></div>
              </div>
            </div>
          </div>
        </div>
  </form>
          
            <script language="javascript">

                function save_onclick() {
                    $("#btnSave").click();
                }
                function reset_onclick() {
                    location.href = "sys_Module_Add.aspx";
                }
            </script>
</body>
</html>


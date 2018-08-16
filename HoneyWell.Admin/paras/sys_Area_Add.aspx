<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Area_Add.aspx.cs" Inherits="HoneyWell.paras.sys_Area_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>区域信息管理</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css" />
    <link rel="stylesheet"   href="../css/ace.min.css" />
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script language="javascript">
        function valCode() {

            var txt_ClassCode = document.getElementById("txt_ClassCode").value;
            var txt_ClassName = document.getElementById("txt_ClassName").value;

            if (txt_ClassCode.length == 0) {
                alert("区域代码不能为空!");
                return false;
            }

            if (txt_ClassName.length == 0) {
                alert("区域名称不能为空!");
                return false;
            }

            return true;
        }
 
    </script>
</head>
<body>
    <form id="form1" runat="server"  class="form-horizontal">
         <input type="hidden" id="h_ClassLevel" runat="server" value="" />
         <div class="container-fluid" id="main-container"> 
          <div  class="clearfix">
            <div id="page-content" class="clearfix">
              <div class="page-header position-relative">
                <h1>区域管理</h1> <small>&nbsp;&nbsp;<input type="button" ID="Button1"  class="button01" value="上一步" onclick="javascript:history.go(-1);" /></small>
              </div>
              <div class="row-fluid">
                   <div class="control-group">
                    <label class="control-label" for="form-field-1">父级名称</label>
                    <div class="controls">
                      <label id="lab_ParentName" style="margin-top:5px; font-weight:800px" runat="server"></label>
                    </div>
                  </div>
       
                  <div class="control-group">
                    <label class="control-label" for="form-field-1">区域代码</label>
                    <div class="controls">
                      <input type="text" id="txt_ClassCode" runat="server" placeholder="区域代码不能为空" style="width:130px"/>&nbsp;<font color=red>*</font>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-2">区域名称</label>
                    <div class="controls">
                      <input type="text" id="txt_ClassName" runat="server"  placeholder="区域名称不能为空"/>&nbsp;<font color=red>*</font>
                   </div>
                  </div>
                   

                  <div class="control-group">
                    <label class="control-label" for="form-field-2">显示顺序</label>
                    <div class="controls">
                      <input type="text" id="txt_ClassOrder" runat="server"  style="width:50px" onKeyUp="if(isNaN(value))execCommand('undo')"/>
                    </div>     
                  </div>

                  <div class="control-group">
                    <label class="control-label" for="form-field-2">关键字</label>
                    <div class="controls">
                      <input type="text" id="txt_KeyWord" runat="server"  style="width:100px"/>
                    </div> 
                  </div> 
                    
                  <div class="form-actions">
                     <button class="btn btn-info" type="button"  id="save"  onclick="return save_onclick()"><i class="icon-ok"></i>保存</button>
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
                    location.href = "sys_Area_Add.aspx";
                }
            </script>
</body>
</html>



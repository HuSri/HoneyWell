<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Member_Manage.aspx.cs" Inherits="HoneyWell.system.sys_Member_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <meta name="viewport"    content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet"   href="../css/bootstrap.min.css" />
    <link rel="stylesheet"   href="../css/ace.min.css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {

            //添加按钮事件
            $("#btnSave").click(function () {
                DataAdd("reset");
            });

            $("#btnSaveBack").click(function () {
                DataAdd("");
            });


            $("#txtDutyId").bind("change", BindSetting);
      

            function DataAdd(t) {

                //获取表单值
                var DutyId = $("#txtDutyId").val();
                var AdminUser = $("#txtAdminUser").val();
                var AdminPassWord = $("#txtAdminPassWord").val();
                var AdminPassWordS = $("#txtAdminPassWordS").val();
                var Remark = $("#txtRemark").val();

                var AdminPassWordOld = $("#AdminPassWordOld").val();

                //ID作为区别何种操作
                var Id = $("#hdnPKID").val();


                //TODO:数据有效性验证\格式验证\非空验证等
                if (DutyId == "0") {
                    alert("角色名称不能为空!");
                    return false;
                }


                if (IsNull(AdminUser)) {
                    alert("用户名不能为空!");
                    return false;
                }


                if (!IsAccount(AdminUser)) {
                    alert("用户名不合法，请重新输入!");
                    return false;
                }
                 

                if (Id > 0) {
                    if (AdminPassWord != "") {
                        if (!IsPwd(AdminPassWord)) {
                            alert("新密码不合法，请重新输入!");
                            return false;
                        }

                        if (IsNull(AdminPassWordS)) {
                            alert("确认新密码不能为空!");
                            return false;
                        }

                        if (AdminPassWord != AdminPassWordS) {
                            alert("新密码和确认新密码必须一致!");
                            return false;
                        }
                    }
                }
                else {
                    if (IsNull(AdminPassWord)) {
                        alert("密码不能为空!");
                        return false;
                    }

                    if (!IsPwd(AdminPassWord)) {
                        alert("密码不合法，请重新输入!");
                        return false;
                    }

                    if (IsNull(AdminPassWordS)) {
                        alert("确认密码不能为空!");
                        return false;
                    }

                    if (AdminPassWord != AdminPassWordS) {
                        alert("密码和确认密码必须一致!");
                        return false;
                    }

                }

                 


                //参数Json串
                var paras = {
                    Id: Id,
                    DutyId: DutyId,
                    AdminUser: AdminUser,
                    AdminPassWord: AdminPassWord,
                    AdminPassWordOld: AdminPassWordOld,
                    Remark: Remark
                };




                $.post("../handlers/system/sys_Member_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                        $(":input", "#form1").not(":button,:submit,:reset,:hidden").val("").removeAttr("checked");
                    else //写入成功之后返回列表
                        location.href = "sys_Member_List.aspx";

                }, "text");
            }
        });
    </script>
 
</head>
<body>
    <form id="form1" runat="server"  class="form-horizontal">
       <input type="hidden" value="<%= PKID%>" id="hdnPKID" />
       <input type="hidden" value="<%= AdminPassWordOld%>" id="AdminPassWordOld" />
       <div class="container-fluid" id="main-container"> 
          <div  class="clearfix">
            <div id="page-content" class="clearfix">
              <div class="page-header position-relative">
                <h1>用户管理<small><i class="icon-double-angle-right"></i><a href="sys_Member_List.aspx">用户列表</a></small></h1>
              </div>
              <div class="row-fluid">
       
                  <div class="control-group">
                    <label class="control-label" for="form-field-1"><font color=red>*</font>&nbsp;角色名称</label>
                    <div class="controls">
                       <select id="txtDutyId" style="width:150px"><%=DutyStr%></select>&nbsp;<font color=red>*</font>
                    </div>
                  </div>

                   
                  <div class="control-group">
                    <label class="control-label" for="form-field-1"><font color=red>*</font>&nbsp;用 户 名</label>
                    <div class="controls">
                      <input type="text" id="txtAdminUser" value="<%=AdminUser %>"  placeholder="用户名不能为空" <%=AdminUserR%> />&nbsp;<font color=red>[必须以字母开头，长度在5~20之间，只能包含字母、数字和下划线]</font>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-1" id="lab_pw" runat="server"><font color=red>*</font>&nbsp;密&nbsp;&nbsp;&nbsp;&nbsp;码</label>
                    <div class="controls">
                      <input type="password" id="txtAdminPassWord" value="" placeholder="密码不能为空" />&nbsp;<font color=red>[必须以字母开头，长度在5~30之间，只能包含字母、数字和下划线]</font>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-1" id="lab_pw_c"  runat="server"><font color=red>*</font>&nbsp;确认密码</label>
                    <div class="controls">
                      <input type="password" id="txtAdminPassWordS" value="" placeholder="确认密码不能为空" />&nbsp;<font color=red>[确认密码必须与密码一致]</font>
                    </div>
                  </div>


                  <div class="control-group">
                    <label class="control-label" for="form-field-2">备注说明</label>
                    <div class="controls">
                      <input type="text" id="txtRemark" value="<%=Remark %>"  style="width:300px"/>
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

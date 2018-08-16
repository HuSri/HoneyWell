using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;
using HoneyWell.Model;
using HoneyWell.BLL;

namespace HoneyWell.system
{
    public partial class sys_Module_Manage : UserPage
    {
        public string nodeText = DNTRequest.GetString("nodeText");
        public string nodeValue = DNTRequest.GetString("nodeValue");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定数据
        public void BindData()
        {
            if (nodeText != "")
            {
                HoneyWell.Model.Sys_Menu sys_Model = new HoneyWell.BLL.Sys_Menu().GetModel(Utils.ToInt(nodeValue));
                txt_MenuCode.Value = sys_Model.MenuCode;
                txt_MenuNameC.Value = sys_Model.MenuNameC;
                txt_MenuOrder.Value = sys_Model.MenuOrder.ToString();
                txt_MenuUrl.Value = sys_Model.MenuUrl;
                h_ParentID.Value = sys_Model.ParentID.ToString();
                h_MenuLevel.Value = sys_Model.MenuLevel.ToString();
            }
        }
        #endregion


        #region 对象赋值
        public HoneyWell.Model.Sys_Menu SetObjectValue()
        {
            HoneyWell.Model.Sys_Menu sys_Model = new HoneyWell.Model.Sys_Menu();
            sys_Model.ID = Utils.ToInt(nodeValue);
            sys_Model.MenuCode = txt_MenuCode.Value.Trim();
            sys_Model.MenuNameC = txt_MenuNameC.Value.Trim();
            sys_Model.MenuNameE = "";
            sys_Model.ParentID = Utils.ToInt(h_ParentID.Value);
            sys_Model.MenuLevel = Utils.ToInt(h_MenuLevel.Value);
            sys_Model.MenuOrder = Utils.ToInt(txt_MenuOrder.Value.Trim());
            sys_Model.MenuUrl = txt_MenuUrl.Value.Trim();
            sys_Model.MenuDesc = "";
            sys_Model.MoreCol1 = "";
            sys_Model.MoreCol2 = "";
            sys_Model.ModifyUser = GetUserName();
            sys_Model.ModifyTime = DateTime.Now; 
            return sys_Model;
        }
        #endregion



        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool result =false;
            HoneyWell.Model.Sys_Menu menu = SetObjectValue();
            if (Utils.ToInt(nodeValue) > 0)
            {
                result = new HoneyWell.BLL.Sys_Menu().Update(menu);
            }
            
            if (result ==true)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');location.href='sys_Module_Manage.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'", true);
            }
        }

        
        protected void btnDel_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (Utils.ToInt(nodeValue) > 0)
            {
                HoneyWell.Model.Sys_Menu info = new HoneyWell.BLL.Sys_Menu().GetModel(Convert.ToInt32(nodeValue));
                HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                logs.ID = 0;
                logs.DutyId = Utils.ToInt(GetDutyId());
                logs.LoginName = GetUserName();
                logs.TitleName = "模块管理";
                logs.Depicts = "删除模块信息,名称为：" + info.MenuNameC + "";
                logs.CreateTime = DateTime.Now;
                logs.IpAddress = Request.UserHostAddress;
                logs.MoreCol1 = "";
                logs.MoreCol2 = "";
                new HoneyWell.BLL.Sys_Logs().Add(logs);
                result = new HoneyWell.BLL.Sys_Public().Delete("Sys_Menu", " ID=" + Utils.ToInt(nodeValue) + "");
            }


            if (result > 0)
            {
              ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.location='sys_Module_Tree.aspx'", true);
            }
        }
    }
}
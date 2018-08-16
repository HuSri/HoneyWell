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
    public partial class sys_Module_Add : UserPage
    {
        private string nodeText = DNTRequest.GetString("nodeText");
        private string nodeValue = DNTRequest.GetString("nodeValue");
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
            if (Utils.ToInt(nodeValue) > 0)
            {
                HoneyWell.Model.Sys_Menu menu = new HoneyWell.BLL.Sys_Menu().GetModel(Utils.ToInt(nodeValue));
                h_MenuLevel.Value = menu.MenuLevel.ToString();
                lab_ParentName.InnerHtml = menu.MenuNameC;
            }
            else
            {
                h_MenuLevel.Value = "0";
                lab_ParentName.InnerHtml = nodeText;
            }
        }
        #endregion


        #region 对象赋值
        public HoneyWell.Model.Sys_Menu SetObjectValue()
        {
            HoneyWell.Model.Sys_Menu sys_Model = new HoneyWell.Model.Sys_Menu();
            sys_Model.MenuCode = txt_MenuCode.Value.Trim();
            sys_Model.MenuNameC = txt_MenuNameC.Value.Trim();
            sys_Model.MenuNameE = "";
            sys_Model.ParentID = Utils.ToInt(nodeValue);
            sys_Model.MenuLevel = Utils.ToInt(h_MenuLevel.Value) + 1;
            sys_Model.MenuOrder = Utils.ToInt(txt_MenuOrder.Value.Trim());
            sys_Model.MenuUrl = txt_MenuUrl.Value.Trim();
            sys_Model.MenuDesc = "";
            sys_Model.MoreCol1 = "";
            sys_Model.MoreCol2 = "";
            sys_Model.CreateUser = GetUserName();
            sys_Model.CreateTime = DateTime.Now;
            sys_Model.ModifyUser = GetUserName();
            sys_Model.ModifyTime = DateTime.Now;

            return sys_Model;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            HoneyWell.Model.Sys_Menu menu = SetObjectValue();
            result = new HoneyWell.BLL.Sys_Menu().Add(menu);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.location='sys_Module_Tree.aspx'", true);
            }
        }
    }
}
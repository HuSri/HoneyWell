using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.other
{
    public partial class sys_Focus_List : UserPage
    {
        //查询条件信息
        public string Code = "";
        public string Name = "";
        public string Pageindex = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                SelectInfo();
                pageBind();
            }
        }

        #region 查询信息
        public void SelectInfo()
        {
            if (!string.IsNullOrEmpty(Request["Code"]))
            {
                Code =Encrypt.PageDispelParam(Request["Code"]);
            }
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                Name =Encrypt.PageDispelParam(Request["Name"]);
            }
            if (!string.IsNullOrEmpty(Request["Pageindex"]))
            {
                Pageindex =Request["Pageindex"];
            }
        }
        #endregion

        public void pageBind()
        {
            string strWhere = " ";

            if (txt_FCode.Value.Trim().Length > 0)
            {
                strWhere += " and FCode like '%" + txt_FCode.Value.Trim() + "%'";
            }
            if (Code != "")
            {
                strWhere += " and FCode like '%" + Code + "%'";
                txt_FCode.Value = Code;
            }

            if (txt_FName.Value.Trim().Length > 0)
            {
                strWhere += " and FName like '%" + txt_FName.Value.Trim() + "%'";
            }
            if (Name != "")
            {
                strWhere += " and FName like '%" + Name + "%'";
                txt_FName.Value = Name;
            }

            if (Pageindex!="")
            {
                MyPager.Pageindex =Utils.ToInt(Pageindex);
            }

            string tableName = "Sys_Focus";
            string showField = " ID,FCode,FName,FOrder,CreateUser,CreateTime";
            string orderField = "ID";
            int count = 0;

            DataSet ds = new HoneyWell.BLL.Sys_Public().GetList(tableName, showField, orderField, MyPager.Pagesize, MyPager.Pageindex + 1, 0, strWhere, out count);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
            MyPager.Count = count;
        }

        protected void rptLoop_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "del")
                {
                    HoneyWell.Model.Sys_Focus info = new HoneyWell.BLL.Sys_Focus().GetModel(Convert.ToInt32(e.CommandArgument));
                    HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                    logs.ID = 0;
                    logs.DutyId = Utils.ToInt(GetDutyId());
                    logs.LoginName = GetUserName();
                    logs.TitleName = "焦点图列表";
                    logs.Depicts = "删除焦点图信息,名称为：" + info.FName + "";
                    logs.CreateTime = DateTime.Now;
                    logs.IpAddress = Request.UserHostAddress;
                    logs.MoreCol1 = "";
                    logs.MoreCol1 = "";
                    new HoneyWell.BLL.Sys_Logs().Add(logs);
                    new HoneyWell.BLL.Sys_Public().Delete("Sys_Focus", " ID=" + Convert.ToInt32(e.CommandArgument) + "");
                    ScriptManager.RegisterClientScriptBlock(rptLoop, GetType(), "", "alert('操作成功!');location.href='sys_Focus_List.aspx?Code=" + txt_FCode.Value.Trim() + "&Name=" + txt_FName.Value.Trim() + "&Pageindex=" + MyPager.Pageindex + "';", true);
                }
            }
        }
        protected void MyPager_PageIndexChange(object sender, EventArgs e)
        {
            pageBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pageBind();
        }

        #region 返回修改链接地址
        public string EditUrl(string Id)
        {
            return "sys_Focus_Manage.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "&Code=" + Encrypt.PageSecuityParam(txt_FCode.Value.Trim()) + "&Name=" +Encrypt.PageSecuityParam(txt_FName.Value.Trim()) + "&Pageindex=" + MyPager.Pageindex + "";
        }
        #endregion
    }
}
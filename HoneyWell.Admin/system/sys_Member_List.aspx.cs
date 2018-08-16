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
using System.Text;
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;
using HoneyWell.Model;
using HoneyWell.BLL;
using HoneyWell.DAL;
using HoneyWell.COMM;

namespace HoneyWell.system
{
    public partial class sys_Member_List : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                pageBind();
                BindDuty();
            }
        }


        #region 绑定角色
        public void BindDuty()
        {
            txtDutyId.Items.Clear();
            ListItem item1 = new ListItem("==请选择==", "");
            txtDutyId.Items.Add(item1);
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(" ID,DutyName", "sys_Duty", " order by DutyDesc").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = dt.Rows[i]["DutyName"].ToString();
                item.Value = dt.Rows[i]["ID"].ToString();
                txtDutyId.Items.Add(item);
            }
        }
        #endregion

        public void pageBind()
        {
            string strWhere = " ";


            if (txtDutyId.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and DutyId = '" + txtDutyId.SelectedValue.Trim() + "'";
            }


            if (txtLoginName.Value.Trim().Length > 0)
            {
                strWhere += " and AUserName ='" + txtLoginName.Value.Trim() + "'";
            }

            string tableName = "Sys_Admin";
            string showField = " ID,DutyId,AUserName,Remark,ModifyTime";
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

                    HoneyWell.Model.Sys_Admin info = new HoneyWell.BLL.Sys_Admin().GetModel(Convert.ToInt32(e.CommandArgument));

                    HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                    logs.ID = 0;
                    logs.DutyId = Utils.ToInt(GetDutyId());
                    logs.LoginName = GetUserName();
                    logs.TitleName = "用户信息";
                    logs.Depicts = "删除用户信息,名称为：" + info.AUserName + "";
                    logs.CreateTime = DateTime.Now;
                    logs.IpAddress = Request.UserHostAddress;
                    logs.MoreCol1 = "";
                    logs.MoreCol1 = "";
                    new HoneyWell.BLL.Sys_Logs().Add(logs);
                    new HoneyWell.BLL.Sys_Public().Delete("Sys_Admin", " ID=" + Convert.ToInt32(e.CommandArgument) + "");
                    ScriptManager.RegisterClientScriptBlock(rptLoop, GetType(), "", "alert('操作成功!');location.href='" + Request.Url + "';", true);
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


        #region 返回角色名称
        public string GetDuty(string DutyId)
        {
            string Type_Str = "";
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData("top 1 DutyName", "Sys_Duty", " and ID='" + DutyId + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                Type_Str = dt.Rows[0]["DutyName"].ToString();
            }

            return Type_Str;
        }
        #endregion


        #region 返回修改链接地址
        public string EditUrl(string Id)
        {
            return "sys_Member_Manage.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "";
        }
        #endregion
    }
}
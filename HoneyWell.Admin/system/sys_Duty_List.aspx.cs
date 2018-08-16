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
using HoneyWell.DAL;
using HoneyWell.COMM;

namespace HoneyWell.system
{
    public partial class sys_Duty_List : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                pageBind();
            }
        }

        public void pageBind()
        {
            string strWhere = " ";

            if (txt_DutyName.Value.Trim().Length > 0)
            {
                strWhere += " and DutyName like '%" + txt_DutyName.Value.Trim() + "%'";
            }
            string tableName = "Sys_Duty";
            string showField = " ID,DutyName,DutyDesc,CreateUser,CreateTime";
            string orderField = "ID";
            int count = 0;

            DataSet ds = new HoneyWell.BLL.Sys_Public().GetList(tableName, showField, orderField, MyPager.Pagesize, MyPager.Pageindex + 1, 0, strWhere, out count);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
            MyPager.Count = count;
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
            return "sys_Duty_Manage.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "";
        }
        #endregion
    }
}
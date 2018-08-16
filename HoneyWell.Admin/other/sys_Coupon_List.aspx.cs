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
    public partial class sys_Coupon_List : UserPage
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

            string tableName = "Sys_Coupon";
            string showField = " ID,CType,CName,CCode,CSum,CDeduction,StartingTime,EndTime,IssueNum";
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

        public string GetNum(string CSum,string CDeduction)
        {
            return "满"+CSum+"元减"+CDeduction+"元";
        }

        public string GetCType(string CType)
        {
            string name = "";
            switch (CType)
            {
                case "1":
                    name = "抵扣券";
                        break;
                case "2":
                    name = "折扣券";
                    break;
                case "3":
                    name = "现金券";
                    break;
            }
            return name;
        }


        #region 返回链接地址
        //修改链接
        public string EditUrl(string Id)
        {
            return "sys_Coupon_Manage.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "";
        }
        //明细链接
        public string DetailsUrl(string CCode)
        {
            return "sys_Coupon_Details.aspx?GLogin="+Encrypt.PageSecuityParam(GetUserName())+ "&CCode=" + Encrypt.PageSecuityParam(CCode) +"";
        }
        #endregion
    }
}
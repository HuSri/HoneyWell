using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;

namespace HoneyWell.Admin.other
{
    public partial class sys_Coupon_Details : UserPage
    {

        public string CCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["CCode"]))
            {
                CCode = Encrypt.PageDispelParam(Request["CCode"]);
            }
            if (!IsPostBack)
            {
                pageBind();
            }
        }


        public void pageBind()
        {
            string strWhere = "";
            if (txtCState.SelectedValue.Length>0)
            {
                strWhere += "and CState='"+txtCState.SelectedValue.Trim()+"'";
            }
                 
             strWhere += " and CCode ='" + CCode + "'";
            string tableName = "Sys_Coupon_Details";
            string showField = " ID,CCode,CSmallCode,CTime,CState,ReceiveUser,ReceiveTime";
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

        #region 返回优惠券类型
        public string GetType(string Code)
        {
            string name = "";
            DataTable dt=new BLL.Sys_Public().SelectData("CType","Sys_Coupon","and CCode='"+Code+"'").Tables[0];
            if (dt!=null && dt.Rows.Count>0)
            {
                switch (dt.Rows[0]["CType"].ToString())
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
            }
            return name;
        }
        #endregion

        #region 返回优惠券名称
        public string GetName(string Code)
        {
            string name = "";
            DataTable dt = new BLL.Sys_Public().SelectData("CName","Sys_Coupon","and CCode='"+Code+"'").Tables[0];
            if (dt!=null && dt.Rows.Count>0)
            {
                name = dt.Rows[0]["CName"].ToString();
            }
            return name;
        }
        #endregion

        #region 返回优惠券状态
        public string GetCState(string CState)
        {
            string name = "";
            switch (CState)
            {
                case "0":
                    name = "未使用";
                    break;
                case "1":
                    name = "已领取";
                    break;
                case "2":
                    name = "已过期";
                    break;
            }
            return name;
        }
        #endregion


    }
}
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
    public partial class sys_Return_List : UserPage
    {
        public string Phone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                if (!string.IsNullOrEmpty(Request["Phone"]))
                {
                    Phone = Encrypt.PageDispelParam(Request["Phone"]);
                }
                pageBind();
            }
        }

        public void pageBind()
        {
            string strWhere = " ";


            if (txt_Phone.Value.Trim().Length > 0)
            {
                strWhere += " and Phone like '%" + txt_Phone.Value.Trim() + "%'";
            }
            if (Phone!="")
            {
                strWhere += " and Phone like '%" + Phone + "%'";
                txt_Phone.Value = Phone;
            }

            if (txt_ONumber.Value.Trim().Length > 0)
            {
                strWhere += " and ONumber like '%" + txt_ONumber.Value.Trim() + "%'";
            }

            if (txtRStatus.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and RStatus =" + txtRStatus.SelectedValue.Trim() + "";
            }

            string tableName = "Sys_Return";
            string showField = " ID,Phone,ONumber,RReason,RATime,RReply,RReplyTime,RStatus";
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

        #region 返回订单处理状态
        public string GetStatus(string Status)
        {
            string strStatus = "";
            switch (Status)
            {
                case "0":
                    strStatus = "未处理";
                    break;
                case "1":
                    strStatus = "已处理";
                    break;
            }
            return strStatus;
        }
        #endregion

        #region 返回修改链接地址
        public string EditUrl(string Id)
        {
            return "sys_Return_Edit.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "&rPhone="+txt_Phone.Value.Trim()+ "&rONumber="+txt_ONumber.Value.Trim()+ "&rRStatus="+txtRStatus.SelectedValue.Trim()+"&Pageindex="+MyPager.Pageindex+"";
        }
        //返回用户列表
        public string UsersUrl(string Phone)
        {
            return "../orders/sys_Users_List.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        #endregion
    }
}
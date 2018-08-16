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

namespace HoneyWell.Admin.orders
{
    public partial class sys_Users_List : UserPage
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


            if (txt_Name.Value.Trim().Length > 0)
            {
                strWhere += " and Name like '%" + txt_Name.Value.Trim() + "%' or NickName like '%" + txt_Name.Value.Trim()+"%'";
            }

            if (txt_Phone.Value.Trim().Length > 0)
            {
                strWhere += " and Phone like '%" + txt_Phone.Value.Trim() + "%'";
            }
            if (Phone!="")
            {
                strWhere += " and Phone like '%" + Phone + "%'";
                txt_Phone.Value = Phone;
            }

            if (txtSex.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and Sex =" + txtSex.SelectedValue.Trim() + "";
            }

            string tableName = "Sys_Users";
            string showField = " ID,Name,NickName,Phone,DateBirth,Sex,Email,CreateTime";
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
        #region 返回性别
        public string GetSex(string Sex)
        {
            string strSex = "";
            switch (Sex)
            {
                case "0":
                    strSex = "男";
                    break;
                case "1":
                    strSex = "女";
                    break;
            }
            return strSex;
        }
        #endregion


        public string GetDate(string Date)
        {
            return Utils.ToString(Utils.ToDateTime(Date).ToString("yyyy-MM-dd"));
        }
        #region 返回链接地址
        //返回用户信息
        public string EditUrl(string ID)
        {
            return "sys_Users_Edit.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Text=" + Encrypt.PageSecuityParam(ID) + "";
        }
        //返回订单信息
        public string OrdersUrl(string Phone)
        {
            return "sys_Orders_List.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        //返回退货信息
        public string ReturnUrl(string Phone)
        {
            return "../other/sys_Return_List.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        //返回地址信息
        public string AreaUrl(string Phone)
        {
            return "sys_Receipt_List.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        #endregion

    }
}
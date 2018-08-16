using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;

namespace HoneyWell.Admin.orders
{
    public partial class sys_Orders_List : UserPage
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

            if (Phone!="")
            {
                strWhere += " and Phone like '%" + Phone + "%'";
                txt_Phone.Value = Phone;
            }

            if (txt_ONumber.Value.Trim().Length > 0)
            {
                strWhere += " and ONumber like '%" + txt_ONumber.Value.Trim() + "%'";
            }

            if (txtOType.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and OType =" + txtOType.SelectedValue.Trim() + "";
            }

            if (txt_IType.Value.Trim().Length > 0)
            {
                strWhere += " and IType =" + txt_IType.Value.Trim() + "";
            }

            if (txtOStatus.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and OStatus =" + txtOStatus.SelectedValue.Trim() + "";
            }

            string tableName = "Sys_Orders";
            string showField = " ID,Phone,ONumber,OType,CCompany,SNumber,OFee,OFare,OCope,OActuallyPaid,IType,OStatus,CreateTime";
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
        #region 返回发票类型
        public string GetOType(string OType)
        {
            string strOType = "";
            switch (OType)
            {
                case "0":
                    strOType = "个人";
                    break;
                case "1":
                    strOType = "企业";
                    break;
            }
            return strOType;
        }
        #endregion

        #region 返回支付方式
        public string GetIType(string IType)
        {
            string strIType = "";
            switch (IType)
            {
                case "0":
                    strIType = "在线支付";
                    break;
                case "1":
                    strIType = "货到付款";
                    break;
            }
            return strIType;
        }
        #endregion

        #region 返回订单状态
        public string GetOStatus(string OStatus )
        {
            string strOStatus = "";
            switch (OStatus)
            {
                case "0":
                    strOStatus = "待付款";
                    break;
                case "1":
                    strOStatus = "待发货";
                    break;
                case "2":
                    strOStatus = "已发货";
                    break;
            }
            return strOStatus;
        }
        #endregion

        #region 返回链接地址
        //返回订单信息
        public string OrdersUrl(string Id)
        {
            return "sys_Orders_Edit.aspx?GLogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "";
        }
        //返回发票信息
        public string InvoiceUrl(string ONumber)
        {
            return "sys_Invoice_Edit.aspx?GLogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&ONumber=" + Encrypt.PageSecuityParam(ONumber) + "";
        }
        //返回地址信息
        public string ReceiptUrl(string ID)
        {
            return "sys_Receipt_Edit.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        //返回用户列表
        public string UsersUrl(string Phone)
        {
            return "sys_Users_List.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Phone=" + Encrypt.PageSecuityParam(Phone) + "";
        }
        #endregion

    }
}
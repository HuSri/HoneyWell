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
    public partial class sys_Orders_Edit : UserPage
    {
        public int PKID = 0;
        public string ONumber = "";
        public string OType = "";
        public string CCompany = "";
        public string SNumber = "";
        public decimal OFee = 0;
        public decimal OFare = 0;
        public decimal OCope = 0;
        public decimal OActuallyPaid = 0;
        public string IType = "";
        public string OName = "";
        public string OPhone = "";
        public string OStatus = "";
        public string ProvinceStr = "";
        public string CityStr = "";
        public string AreaStr = "";
        public string OAddress = "";
        public string StrOStatus = "";
        public string CreateTime = "";

        public string Number = "";
        public string StrArea = "";//收货地址信息
        public string StrIType = "";//支付方式
        public string StrOType = "";//发票类型

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Ttext"]))
                {
                    PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                    BindModel();
                    pageBind();
                }

            }
        }

        /// <summary>
        /// 绑定单体对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Orders sys_BLL = new BLL.Sys_Orders();
            Model.Sys_Orders sys_Model = sys_BLL.GetModel(PKID);
            ONumber = sys_Model.ONumber;
            OType = sys_Model.OType;
            GetOType(OType);
            CCompany = sys_Model.CCompany;
            SNumber = sys_Model.SNumber;
            OFee = sys_Model.OFee;
            OFare = sys_Model.OFare;
            OCope = sys_Model.OCope;
            OActuallyPaid = sys_Model.OActuallyPaid;
            IType = sys_Model.IType;
            GetIType(IType);
            OName = sys_Model.OName;
            OPhone = sys_Model.OPhone;
            GetArea(sys_Model.Province, sys_Model.City, sys_Model.Area);
            OAddress = sys_Model.OAddress;
            OStatus = sys_Model.OStatus;
            GetOStatus(OStatus);
            txtRemarks.Value = sys_Model.Remarks;
            CreateTime = sys_Model.CreateTime.ToString();
        }

        //收货地址信息
        public void GetArea(string Province, string City, string Area)
        {
            DataTable dt1 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + Province + "").Tables[0];
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                StrArea += dt1.Rows[0]["AreaName"].ToString();
            }
            DataTable dt2 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + City + "").Tables[0];
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                StrArea += "--" + dt2.Rows[0]["AreaName"].ToString();
            }
            DataTable dt3 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + Area + "").Tables[0];
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                StrArea += "--" + dt3.Rows[0]["AreaName"].ToString();
            }
        }

        //发票类型
        public void GetOType(string OType)
        {
            switch (OType)
            {
                case "0":
                    StrOType = "个人";
                    break;
                case "1":
                    StrOType = "企业";
                    break;
            }
        }

        //支付方式
        public void GetIType(string IType)
        {
            switch (IType)
            {
                case "0":
                    StrIType = "在线支付";
                    break;
                case "1":
                    StrIType = "货到付款";
                    break;
            }
        }

        #region 返回订单状态
        public void GetOStatus(string OStatus)
        {
            string StrSelect1 = "";
            string StrSelect2 = "";
            string StrSelect3 = "";
            if (OStatus=="0")
            {
                StrSelect1 = "selected";
                StrOStatus += "<option value=\"0\" "+StrSelect1+">待付款</option>";
                StrOStatus += "<option value=\"1\" " + StrSelect2 + ">待发货</option>";
                StrOStatus += "<option value=\"2\" " + StrSelect3 + ">已发货</option>";
            }
            if (OStatus == "1")
            {
                StrSelect2 = "selected";
                StrOStatus += "<option value=\"0\" " + StrSelect1 + ">待付款</option>";
                StrOStatus += "<option value=\"1\" " + StrSelect2 + ">待发货</option>";
                StrOStatus += "<option value=\"2\" " + StrSelect3 + ">已发货</option>";
            }
            if (OStatus == "2")
            {
                StrSelect3 = "selected";
                StrOStatus += "<option value=\"0\" " + StrSelect1 + ">待付款</option>";
                StrOStatus += "<option value=\"1\" " + StrSelect2 + ">待发货</option>";
                StrOStatus += "<option value=\"2\" " + StrSelect3 + ">已发货</option>";
            }
        }
        #endregion

        public void pageBind()
        {
            string strWhere = " ";

            if (ONumber != "")
            {
                strWhere += " and ONumber =" + ONumber + "";
            }

            string tableName = "Sys_Shopping";
            string showField = " ID,SName,SSmallPic,SFormat,SMarket,SRetail,SQuantity,SSum";

            DataSet ds = new HoneyWell.BLL.Sys_Public().SelectData( showField, tableName, strWhere);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
        }

        #region 查看图片
        public string GetUrl(string SSmallPic)
        {
            return "<a href =\"" + GetImgUrl() + "" + SSmallPic + "\" target=\"_blank\"><font color=blue>查看图片</font></a><br />";
        }
        #endregion
    }
}
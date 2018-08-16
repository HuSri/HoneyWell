using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.other
{
    public partial class sys_Coupon_Manage : System.Web.UI.Page
    {
        public int PKID = 0;
        public string CType = "";
        public string StrCType = "";
        public string CCode = "";
        public string CName = "";
        public decimal CSum =0;
        public decimal Deduction =0;
        public int IssueNum = 0;
        public string Pageindex = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request["Ttext"]))
                {
                    PKID =Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                }
                if (PKID>0)
                {
                    BindModel();
                }
                else {
                    CTypeAdd();
                }

            }
        }
        /// <summary>
        /// 绑定对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Coupon sys_Bll = new BLL.Sys_Coupon();
            Model.Sys_Coupon sys_Model = sys_Bll.GetModel(PKID);
            CType = sys_Model.CType;
            CTypeUpdate(CType);
            CCode = sys_Model.CCode;
            CName = sys_Model.CName;
            CSum = sys_Model.CSum;
            Deduction = sys_Model.CDeduction;
            txtTDateS.Value = sys_Model.StartingTime.ToString();
            txtTDateE.Value = sys_Model.EndTime.ToString();
            IssueNum = sys_Model.IssueNum;
            txtRemark.Value = sys_Model.Remark;
        }

        /// <summary>
        /// 优惠券新增
        /// </summary>
        public void CTypeAdd()
        {
            StrCType += "<option value=\"0\">==请选择==</option>";
            StrCType += "<option value=\"1\">抵扣券</option>";
        }

        public void CTypeUpdate(string CType)
        {
            string selected1 = "";
            if (CType=="1")
            {
                selected1 = "selected";
            }
            StrCType += "<option value=\"1\" selected=\"" + selected1 + "\">抵扣券</option>";
        }
    }
}
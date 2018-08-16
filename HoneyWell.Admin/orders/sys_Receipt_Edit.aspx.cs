using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.orders
{
    public partial class sys_Receipt_Edit : System.Web.UI.Page
    {
        public string RName = "";
        public string Phone = "";
        public string RPhone = "";
        public string StrArea = "";
        public string RZipCode = "";
        public string StrRDefault = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Phone"]))
                {
                    Phone = Encrypt.PageDispelParam(Request["Phone"]);
                }
            }
        }
        void BindModel()
        {
            DataTable dt = new BLL.Sys_Public().SelectData("ID","Sys_Receipt","and Phone='"+ Phone + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                BLL.Sys_Receipt sys_BLL = new BLL.Sys_Receipt();
                Model.Sys_Receipt sys_Model = sys_BLL.GetModel(Utils.ToInt(dt.Rows[0]["ID"].ToString()));
                Phone = sys_Model.Phone;
                RName = sys_Model.RName;
                RPhone = sys_Model.RPhone;
                GetArea(sys_Model.Province, sys_Model.City, sys_Model.Area);
                RZipCode = sys_Model.RZipCode;

            }

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
    }
}
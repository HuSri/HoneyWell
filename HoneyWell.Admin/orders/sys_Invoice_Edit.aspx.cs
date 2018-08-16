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
    public partial class sys_Invoice_Edit : System.Web.UI.Page
    {
        public string Number = "";
        public string Phone = "";
        public string ONumber = "";
        public string ICode = "";
        public string IGainGround = "";
        public string ITaxNumber = "";
        public string IRemarks = "";

        public string StrICode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Encrypt.PageDispelParam(Request["ONumber"])))
                {
                    Number = Encrypt.PageDispelParam(Request["ONumber"]);
                    BindModel();
                }
            }
        }

        //绑定数据
        void BindModel()
        {
            string strWhere = "and ONumber='"+Number+"'";
            string tableName = "Sys_Invoice";
            string showField = " ID";
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(showField,tableName,strWhere).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                BLL.Sys_Invoice sys_BLL = new BLL.Sys_Invoice();
                Model.Sys_Invoice sys_Model = sys_BLL.GetModel(Utils.ToInt(dt.Rows[0]["ID"].ToString()));
                ONumber = sys_Model.ONumber;
                ICode = sys_Model.ICode;
                GetICode(ICode);
                IGainGround = sys_Model.IGainGround;
                ITaxNumber = sys_Model.ITaxNumber;
                txtIRemarks.Value = sys_Model.IRemarks;
            }

        }
        public void GetICode(string  ICode)
        {
            switch (ICode)
            {
                case "0":
                    StrICode = "个人";
                    break;
                case "1":
                    StrICode = "企业";
                    break;   
            }
     
            
        }

    }
}
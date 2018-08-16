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
    public partial class sys_Return_Edit : System.Web.UI.Page
    {
        public int PKID = 0;
        public string Phone = "";
        public string ONumber = "";
        public DateTime RATime ;
        public DateTime RReplyTime ;
        public string Status = "";
        public string StrStatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                BindModel();
            }
        }

        //绑定数据
        void BindModel()
        {
            BLL.Sys_Return sys_BLL = new BLL.Sys_Return();
            Model.Sys_Return sys_Model = sys_BLL.GetModel(PKID);
            Phone = sys_Model.Phone;
            ONumber = sys_Model.ONumber;
            txtRReason.Value = sys_Model.RReason;
            RATime = sys_Model.RATime;
            txtRReply.Value = sys_Model.RReply;
            RReplyTime = sys_Model.RReplyTime;
            Status = sys_Model.RStatus;
            GetStatus(Status);
        }

        public void GetStatus(string  Status)
        {
            string StrSelect1 = "";
            string StrSelect2 = "";
            if (Status=="0")
            {
                StrSelect1 = "selected";
                StrStatus += "<option value=\"0\" "+ StrSelect1 + ">未处理</option>";
                StrStatus += "<option value=\"1\" >已处理</option>";
            }
            else {
                StrSelect2 = "selected";
                StrStatus += "<option value=\"0\" >未处理</option>";
                StrStatus += "<option value=\"1\" "+ StrSelect2+ ">已处理</option>";
            }
        }
    }
}
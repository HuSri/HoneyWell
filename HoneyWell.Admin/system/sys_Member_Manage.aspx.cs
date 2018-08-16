using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;
using HoneyWell.Model;
using HoneyWell.BLL;
using HoneyWell.DAL;
using HoneyWell.COMM;

namespace HoneyWell.system
{
    public partial class sys_Member_Manage : UserPage
    {
        #region 公共参数

        public int PKID = 0;
        public int DutyID = 0;
        public string AdminUser = "";
        public string AdminUserR = "";
        public string AdminPassWordOld = "";
        public string Remark = "";


        //初始化角色
        public string DutyStr = "";




        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Ttext"]))
                {
                    PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                }

                if (PKID > 0)
                {
                    BindModel();
                    lab_pw.InnerHtml = "<font color=red>*</font>&nbsp;新 密 码";
                    lab_pw_c.InnerHtml = "<font color=red>*</font>&nbsp;确认新密码";
                    AdminUserR = "readonly";
                    InitDutyUpdate();
                }
                else
                {
                    lab_pw.InnerHtml = "<font color=red>*</font>&nbsp;密&nbsp;&nbsp;&nbsp;&nbsp;码";
                    lab_pw_c.InnerHtml = "<font color=red>*</font>&nbsp;确认密码";
                    AdminUserR = "";
                    InitDutyAdd();
                }

            }
        }


        /// <summary>
        /// 绑定单体对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Admin sys_BLL = new BLL.Sys_Admin();
            Model.Sys_Admin sys_Model = sys_BLL.GetModel(PKID);
            DutyID = sys_Model.DutyID;
            AdminUser = sys_Model.AUserName;
            AdminPassWordOld = sys_Model.APassWord;
            Remark = sys_Model.Remark;
        }



        /// <summary>
        /// 初始化角色-更新
        /// </summary>
        void InitDutyUpdate()
        {
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(" ID,DutyName", "Sys_Duty", " order by DutyDesc").Tables[0];
            string str_selected = "";
            StringBuilder sbDuty = new StringBuilder();
            //拼接HTML-角色
            if (DutyID == 0)
            {
                str_selected = "selected=\"selected\"";
            }
            sbDuty.Append("<option value='0' " + str_selected + ">==请选择==</option>");
            foreach (DataRow dr in dt.Rows)
            {
                if (StringHelper.NullToInt(dr["ID"]) == DutyID)
                {
                    sbDuty.Append("<option value=" + StringHelper.NullToInt(dr["ID"]) + " selected=\"selected\">" + StringHelper.NullToStr(dr["DutyName"]) + "</option>");
                }
                else
                {
                    sbDuty.Append("<option value=" + StringHelper.NullToInt(dr["ID"]) + "  >" + StringHelper.NullToStr(dr["DutyName"]) + "</option>");
                }

            }

            DutyStr = sbDuty.ToString();
        }


        /// <summary>
        /// 初始化角色-新增
        /// </summary>
        void InitDutyAdd()
        {
            BLL.Sys_Duty sys_duty_bll = new BLL.Sys_Duty();
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(" ID,DutyName", "Sys_Duty", " order by DutyDesc").Tables[0];
            StringBuilder sbDuty = new StringBuilder();
            //拼接HTML-角色
            sbDuty.Append("<option value='0'>==请选择==</option>");
            foreach (DataRow dr in dt.Rows)
            {
                sbDuty.Append("<option value=" + StringHelper.NullToInt(dr["ID"]) + "  >" + StringHelper.NullToStr(dr["DutyName"]) + "</option>");
            }

            DutyStr = sbDuty.ToString();
        }


    }
}
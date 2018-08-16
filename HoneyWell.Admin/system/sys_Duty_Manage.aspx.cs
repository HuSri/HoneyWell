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
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;
using HoneyWell.Model;
using HoneyWell.BLL;
using HoneyWell.DAL;
using HoneyWell.COMM;

namespace HoneyWell.system
{
    public partial class sys_Duty_Manage : System.Web.UI.Page
    {
        #region 公共参数
        public int PKID = 0;
        public string DutyName = "";
        public string DutyDesc = "";
        public string MenuSetting = "";
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

                }
                else
                {
                    BindMenu();
                }

            }
        }

        /// <summary>
        /// 绑定单体对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Duty sys_BLL = new BLL.Sys_Duty();
            Model.Sys_Duty sys_Model = sys_BLL.GetModel(PKID);
            DutyName = sys_Model.DutyName;
            DutyDesc = sys_Model.DutyDesc;
            MenuSetting = sys_Model.MenuSetting;

            string txt_str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
            DataTable dt = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and MenuLevel=1 order by MenuOrder").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt_str = txt_str + "<tr>";
                txt_str = txt_str + "<td width='10%' align='left' valign='top'>" + dt.Rows[i]["MenuNameC"].ToString() + "：</td>";
                DataTable dt1 = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and ParentID=" + dt.Rows[i]["ID"].ToString() + " and MenuLevel=2 order by MenuOrder").Tables[0];
                txt_str = txt_str + "<td width='90%' align='left'>";
                txt_str = txt_str + "<table  border='0' cellspacing='0' cellpadding='0'>";
                txt_str = txt_str + "<tr>";
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    string str_checked = "";
                    if (sys_Model.MenuSetting.ToString().Length > 0)
                    {
                        string[] S_MenuSetting = sys_Model.MenuSetting.ToString().Split(',');
                        for (int j = 0; j < S_MenuSetting.Length; j++)
                        {
                            if (S_MenuSetting[j] == dt1.Rows[k]["ID"].ToString())
                            {
                                str_checked = "checked='true'";
                            }
                        }
                    }

                    txt_str = txt_str + "<td align='left'>";
                    txt_str = txt_str + "&nbsp;&nbsp;<input type=\"checkbox\"  " + str_checked + " style=\"margin-bottom:7px;\"   onclick=\"checkJX(" + dt1.Rows[k]["Id"].ToString() + ");\" name='cb' id=\"cb_" + dt1.Rows[k]["Id"].ToString() + "\"  value='" + dt1.Rows[k]["Id"].ToString() + "' ></input>";
                    txt_str = txt_str + "&nbsp;" + dt1.Rows[k]["MenuNameC"].ToString() + "";

                    DataTable dt2 = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and ParentID=" + dt1.Rows[k]["ID"].ToString() + " and MenuLevel=3 order by MenuOrder").Tables[0];
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        txt_str = txt_str + ":<br>";
                        for (int g = 0; g < dt2.Rows.Count; g++)
                        {
                            string str_checked1 = "";
                            if (sys_Model.MenuSetting.ToString().Length > 0)
                            {
                                string[] S_MenuSetting1 = sys_Model.MenuSetting.ToString().Split(',');
                                for (int m = 0; m < S_MenuSetting1.Length; m++)
                                {
                                    if (S_MenuSetting1[m] == dt2.Rows[g]["ID"].ToString())
                                    {
                                        str_checked1 = "checked='true'";
                                    }

                                }
                            }

                            txt_str = txt_str + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\"  " + str_checked1 + " style=\"margin-bottom:7px;\"   onclick=\"checkJX(" + dt2.Rows[g]["Id"].ToString() + ");\" name='cb' id=\"cb_" + dt2.Rows[g]["Id"].ToString() + "\"  value='" + dt2.Rows[g]["Id"].ToString() + "' ></input>";
                            txt_str = txt_str + "&nbsp;" + dt2.Rows[g]["MenuNameC"].ToString() + "";
                        }
                    }


                    txt_str = txt_str + "</td>";

                    if (k == 5 || k == 11 || k == 17)
                    {
                        txt_str = txt_str + "</tr><tr>";
                    }
                }
                txt_str = txt_str + "</table>";
                txt_str = txt_str + "</td>";
                txt_str = txt_str + "</tr>";

            }
            txt_str = txt_str + "</table>";
            sp_MenuSetting.InnerHtml = txt_str;
        }


        /// <summary>
        /// 绑定模块权限 
        /// </summary>
        void BindMenu()
        {
            string txt_str = "<table width='90%' border='0' cellspacing='0' cellpadding='0'>";
            DataTable dt = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and MenuLevel=1 order by MenuOrder").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt_str = txt_str + "<tr>";
                txt_str = txt_str + "<td width='10%' align='left' height='25' valign='middle'>" + dt.Rows[i]["MenuNameC"].ToString() + "：</td>";
                DataTable dt1 = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and ParentID=" + dt.Rows[i]["ID"].ToString() + " and MenuLevel=2 order by MenuOrder").Tables[0];
                txt_str = txt_str + "<td width='90%' align='left' height='25'  valign='middle'>";
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    txt_str = txt_str + "&nbsp;&nbsp;<input type=\"checkbox\" style=\"margin-bottom:7px;\"  onclick=\"checkJX(" + dt1.Rows[k]["Id"].ToString() + ");\" name='cb' id=\"cb_" + dt1.Rows[k]["Id"].ToString() + "\"  value='" + dt1.Rows[k]["Id"].ToString() + "' ></input>";
                    txt_str = txt_str + "&nbsp;" + dt1.Rows[k]["MenuNameC"].ToString() + "";

                }
                txt_str = txt_str + "</td>";
                txt_str = txt_str + "</tr>";

            }
            txt_str = txt_str + "</table>";
            sp_MenuSetting.InnerHtml = txt_str;
        }

    }
}
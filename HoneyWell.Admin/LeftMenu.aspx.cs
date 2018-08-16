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

namespace HoneyWell.Admin
{
    public partial class LeftMenu : System.Web.UI.Page
    {
        public string str_menu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
            }
        }

        #region 绑定模块信息
        public void BindMenu()
        {
            string MenuSetting = "";
            string TableName = "Sys_Duty";
            string ShowField = " top 1 MenuSetting";
            string OrderField = " and ID='" + Request.Cookies["Fadmin"]["DutyID"].ToString() + "'";
            DataTable dt_user = new HoneyWell.BLL.Sys_Public().SelectData(ShowField, TableName, OrderField).Tables[0];
            if (dt_user != null && dt_user.Rows.Count > 0)
            {
                MenuSetting = dt_user.Rows[0]["MenuSetting"].ToString();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('非法登陆系统后台@！');selfIn.location.href='Friend.aspx';</script>");
                Response.End();
            }

            DataTable dt1 = new HoneyWell.BLL.Sys_Menu().GroupMenuTree("", " and ID in (select ParentID from Sys_Menu where ID in(" + MenuSetting + ")  group by ParentID) and MenuLevel='1' order by MenuOrder").Tables[0];
            for (int k = 0; k < dt1.Rows.Count; k++)
            {
                str_menu += "<div class=\"overall\">";
                str_menu += " <div class=\"mainmenu\"><i></i><span>" + dt1.Rows[k]["MenuNameC"].ToString() + "</span> <b></b></div>";
                str_menu += " <div class=\"submenu\">";
                str_menu += "  <ul>";
                DataTable dt2 = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and ID in (" + MenuSetting + ") and ParentID=" + dt1.Rows[k]["ID"].ToString() + " and MenuLevel='2' order by MenuOrder").Tables[0];
                for (int j = 0; j < dt2.Rows.Count; j++)
                {

                    DataTable dt3 = new HoneyWell.BLL.Sys_Menu().GetMenuTree("", " and ID in (" + MenuSetting + ") and ParentID=" + dt2.Rows[j]["ID"].ToString() + " and MenuLevel='3' order by MenuOrder").Tables[0];
                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        str_menu += "<li>";
                        str_menu += " <div class=\"second\"><img src=\"images/line1.png\" class=\"dashe\" /><span>" + dt2.Rows[j]["MenuNameC"].ToString() + "</span><i ></i></div>";
                        str_menu += " <div class=\"three\">";
                        str_menu += "  <ul>";
                        for (int m = 0; m < dt3.Rows.Count; m++)
                        {
                            string str_style1 = "";
                            if (dt3.Rows.Count - 1 == m && dt2.Rows.Count - 1 == j)
                            {
                                str_style1 = "style=\"border-bottom:none;\"";
                            }
                            else
                            {
                                str_style1 = "";
                            }

                            str_menu += "<li " + str_style1 + "><img src=\"images/line1.png\" class=\"threeimg\" /><a href=\"" + dt3.Rows[m]["MenuUrl"].ToString() + "\" target=\"main\"><span>" + dt3.Rows[m]["MenuNameC"].ToString() + "</span></a> <i></i></li>";
                        }
                        str_menu += "   </ul>";
                        str_menu += "  </div>";
                    }
                    else
                    {
                        string str_style2 = "";
                        if (dt2.Rows.Count - 1 == j)
                        {
                            str_style2 = "style=\"border-bottom:none;\"";
                        }
                        else
                        {
                            str_style2 = "";
                        }
                        str_menu += "<li>";
                        str_menu += " <div class=\"second\" " + str_style2 + "><img src=\"images/line1.png\" class=\"dashe\" /><a href=\"" + dt2.Rows[j]["MenuUrl"].ToString() + "\" target=\"main\"><span>" + dt2.Rows[j]["MenuNameC"].ToString() + "</span></a><i ></i></div>";
                    }

                    str_menu += "</li>";

                }

                str_menu += "   </ul>";
                str_menu += "  </div>";
                str_menu += "  </div>";
            }

        }
        #endregion
    }
}
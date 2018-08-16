using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HoneyWell.Model;
using HoneyWell.BLL;
using HoneyWell.DAL;
using HoneyWell.COMM;

namespace HoneyWell.Admin.Method
{
    public class CheckUrl 
    {
        /// <summary>
        /// 页面权限验证
        /// </summary>
        public void CheckUrlUser()
        {
            System.Web.UI.Page page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;
            try
            {
                string strUrl = HttpContext.Current.Request.FilePath;
                string UserName = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["Fadmin"]["UserName"].ToString());
                string PassWord = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["Fadmin"]["PassWord"].ToString());

                string tableName = "V_Sys_Admin";
                string sqlWhere = " and AUserName='" + UserName + "' and APassWord='" + Encrypt.MakeSecuritySHA(PassWord) + "'";
                string showField = "top 1 MenuSetting";
                DataTable dt_user = new HoneyWell.BLL.Sys_Public().SelectData(showField, tableName, sqlWhere).Tables[0];
                if (dt_user != null && dt_user.Rows.Count > 0)
                {
                    string MenuSetting = dt_user.Rows[0]["MenuSetting"].ToString();
                    string sqlWhere1= " and ID in (" + MenuSetting + ")";
                    DataTable dt_menu = new HoneyWell.BLL.Sys_Public().SelectData("MenuUrl", "Sys_Menu", sqlWhere1).Tables[0];
                    if (dt_menu != null && dt_menu.Rows.Count > 0)
                    {
                        int k = 0;
                        for (int i = 0; i < dt_menu.Rows.Count; i++)
                        {
                            if (dt_menu.Rows[i]["MenuUrl"].ToString() == strUrl)
                            {
                                k += 1;
                            }

                        }
                        if (k <= 0)
                        {
                            HttpContext.Current.Response.Write("<script language='javascript'>");
                            HttpContext.Current.Response.Write("window.alert('您没有权限查看该页面!');");
                            HttpContext.Current.Response.Write("window.close();");
                            HttpContext.Current.Response.Write("</script>");
                            HttpContext.Current.Response.End();
                        }
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script language='javascript'>");
                        HttpContext.Current.Response.Write("window.alert('异常登陆系统1!');");
                        HttpContext.Current.Response.Write("window.close();");
                        HttpContext.Current.Response.Write("</script>");
                        HttpContext.Current.Response.End();
                    }
                }

                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>");
                    HttpContext.Current.Response.Write("window.alert('异常登陆系统2!');");
                    HttpContext.Current.Response.Write("window.close();");
                    HttpContext.Current.Response.Write("</script>");
                    HttpContext.Current.Response.End();
                }


            }
            catch (Exception)
            {
                    HttpContext.Current.Response.Write("<script language='javascript'>");
                    HttpContext.Current.Response.Write("window.alert('异常登陆系统3!');");
                    HttpContext.Current.Response.Write("window.close();");
                    HttpContext.Current.Response.Write("</script>");
                    HttpContext.Current.Response.End();
            }

        }
    }
}
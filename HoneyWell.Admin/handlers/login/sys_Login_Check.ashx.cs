using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using HoneyWell.DBUtility;
using HoneyWell.COMM;
using HoneyWell.Admin.Method;

namespace HoneyWell.handlers.login
{
    /// <summary>
    /// sys_Login_Check 的摘要说明
    /// </summary>
    public class sys_Login_Check : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string RqtAction = StringHelper.NullToStr(context.Request["RqtAction"]);
            if (RqtAction == "login")
            {
                Sys_Login_Check(context);
            }
        }
        void Sys_Login_Check(HttpContext context)
        {

            string LoginName = StringHelper.NullToStr(Filter.FilterData(context.Request["LoginName"]));
            string LoginPassword = StringHelper.NullToStr(Filter.FilterData(context.Request["LoginPassword"]));
            string SecretCode = StringHelper.NullToStr(Filter.FilterData(context.Request["SecretCode"]));
            string retMsg = "";

            if (SecretCode != "123456")
            {
                retMsg = "error01";
                context.Response.Write(retMsg);
                context.Response.End();
            }

            string tableName = "Sys_Admin";
            string sqlWhere = " and AUserName='" + LoginName + "' and APassWord='" + Encrypt.MakeSecuritySHA(LoginPassword) + "'";
            string showField = "top 1 Id,DutyID";

            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(showField, tableName, sqlWhere).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                HttpCookie cookie = new HttpCookie("Fadmin");
                cookie["DutyId"] = dt.Rows[0]["DutyID"].ToString();
                cookie["UserName"] = LoginName;
                cookie["PassWord"] = LoginPassword;
                HttpContext.Current.Response.Cookies.Add(cookie);


                HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                logs.ID = 0;
                logs.DutyId = Utils.ToInt(dt.Rows[0]["DutyID"].ToString());
                logs.LoginName = LoginName;
                logs.TitleName = "用户登录";
                logs.Depicts = "系统后台登陆,会员名为：" + LoginName + "";
                logs.CreateTime = DateTime.Now;
                logs.IpAddress = HttpContext.Current.Request.UserHostAddress;
                logs.MoreCol1 = "";
                logs.MoreCol2 = "";
                new HoneyWell.BLL.Sys_Logs().Add(logs);

                retMsg = "success";
                context.Response.Write(retMsg);
                context.Response.End();

            }
            else
            {
                retMsg = "error02";
                context.Response.Write(retMsg);
                context.Response.End();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
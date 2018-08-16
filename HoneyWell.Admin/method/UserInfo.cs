using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HoneyWell.Admin.Method
{
    public class UserInfo
    {

        /// <summary>
        /// 获取DutyId
        /// </summary>
        public string GetDutyId()
        {
            string DutyId = "";
            try
            {
                DutyId = Convert.ToString(HttpContext.Current.Request.Cookies["Fadmin"]["DutyId"]);
            }
            catch (Exception)
            {
                System.Web.UI.Page page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;
                HttpContext.Current.Response.Redirect(page.ResolveUrl("~/") + "Friend.aspx");
            }

            return DutyId;
        }

         

        /// <summary>
        /// 获取UserName
        /// </summary>
        public string GetUserName()
        {
            string userName = "";
            try
            {
                userName = Convert.ToString(HttpContext.Current.Request.Cookies["Fadmin"]["UserName"]);
            }
            catch (Exception)
            {
                System.Web.UI.Page page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;
                HttpContext.Current.Response.Redirect(page.ResolveUrl("~/") + "Friend.aspx");
            }

            return userName;
        }

    }


}
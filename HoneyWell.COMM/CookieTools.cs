//*******************************************************************//
//
//** 文件名:   CookieTools.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成设置和茯取Cookie值功能的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Web;
using System.Security;
using System.Web.Security;

namespace HoneyWell.COMM
{
    public class CookieTools
    {
        /// <summary>
        /// 设置带参数Cookies的值和时间
        /// </summary>
        /// <param name="cookieName">HttpCookie实例名</param>      
        /// <param name="val">Cookies的值</param>
        /// <param name="date">Cookies的会话时间(单位：分钟)</param>    
        public static void SetCookieValue(string cookieName, string val, int date)
        {
            DateTime dt = DateTime.Now;
            HttpCookie htp = new HttpCookie(cookieName);
            htp.Values.Add(FormsAuthentication.HashPasswordForStoringInConfigFile(cookieName, "MD5"), val);
            if (date > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, date, 0);
                htp.Expires = dt.Add(ts);
            }
            HttpContext.Current.Response.AppendCookie(htp);
        }

        /// <summary>
        /// 接受带参数Cookies的值
        /// </summary>       
        /// <param name="name">接受Cookies的实例名</param>
        /// <returns>sring值</returns>
        public static string GetCookieValue(string cookieName)
        {
            string result = string.Empty;
            try
            {
                HttpCookie htp = HttpContext.Current.Request.Cookies[cookieName];
                if (!string.IsNullOrEmpty(cookieName) && htp != null)
                {
                    result = htp.Values[FormsAuthentication.HashPasswordForStoringInConfigFile(cookieName, "MD5")].ToString();
                }
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        /// <summary>
        /// 清除Cookie值
        /// </summary>
        /// <param name="name"></param>
        public static void ClearCookie(string cookieName)
        {
            try
            {
                HttpCookie htp = HttpContext.Current.Request.Cookies[cookieName];
                if (!string.IsNullOrEmpty(cookieName) && htp != null)
                {
                    htp.Expires = DateTime.Now.AddYears(-1);
                    htp.Values.Add(FormsAuthentication.HashPasswordForStoringInConfigFile(cookieName, "MD5"), null);
                    HttpContext.Current.Response.Cookies.Add(htp);
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(cookieName))
                    HttpContext.Current.Response.Cookies.Remove(cookieName);
            }
        }
    }
}

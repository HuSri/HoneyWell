using System;
using System.Web;

namespace HoneyWell.DBUtility
{
    /// <summary>
    /// Request操作类
    /// </summary>
    public class DNTRequest
    {

        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }
        private static int _userID = 0;
        public static int userID
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["zluser"];
                if (cookie == null || cookie["uid"] == null)
                    return 0;
                else
                    return AllTableHelp.jieId(cookie["uid"]);
            }
            set
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["zluser"];
                cookie["uid"] = AllTableHelp.jieId(value.ToString()).ToString();
                _userID = value;
            }
        }
        private static int _fustate = 0;
        public static int fustate
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["zluser"];
                if (cookie == null || cookie["fustate"] == null)
                    return 0;
                else
                    return AllTableHelp.jieId(cookie["fustate"]);
            }
            set
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["zluser"];
                cookie["fustate"] = AllTableHelp.jieId(value.ToString()).ToString();
                _fustate = value;
            }
        }

        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;

        }


        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }


        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }



        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }


        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }



        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }


        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }


        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }


        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }



        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }



        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }


        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            else
            {
                return GetQueryInt(strName, defValue);
            }
        }


        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }



        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }


        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            else
            {
                return GetQueryFloat(strName, defValue);
            }
        }



    }
}


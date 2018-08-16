using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.handlers.product
{
    /// <summary>
    /// sys_Product 的摘要说明
    /// </summary>
    public class sys_Product : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Product(context);
        }

        void Sys_Product(HttpContext context)
        {
            int TCode = Utils.ToInt(StringHelper.NullToStr(context.Request["TCode"]));
            int TLevel =Utils.ToInt(StringHelper.NullToStr(context.Request["TLevel"]));
            StringBuilder sbType = new StringBuilder();
            DataTable dt = new BLL.Sys_Public().SelectData("ID,TName", "Sys_Type", "and TLevel=1 and TCode=" + TCode + " Order by TOrder ").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dt1 = new BLL.Sys_Public().SelectData("TCode,TName", "Sys_Type", "and TLevel=" + TLevel + " and ParentId=" + dt.Rows[0]["ID"] + " Order by TOrder ").Tables[0];
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    sbType.Append("<option value='0'>==请选择==</option>");
                    foreach (DataRow dr in dt1.Rows)
                    {
                        sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + ">" + StringHelper.NullToStr(dr["TName"]) + "</option>");
                    }
                }
                else
                {
                    sbType.Append("<option value='0'>==请选择==</option>");
                }
            }
            else
            {
                sbType.Append("<option value='0'>==请选择==</option>");
            }
            context.Response.Write(sbType.ToString());
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
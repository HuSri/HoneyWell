using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;

namespace HoneyWell.Admin.handlers.orders
{
    /// <summary>
    /// sys_Users_Manage 的摘要说明
    /// </summary>
    public class sys_Users_Manage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Users_Manage(context);
        }

        void Sys_Users_Manage(HttpContext context)
        {
            #region 处理请求参数 
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            string PassWord = StringHelper.NullToStr(Encrypt.MakeSecurityMD(context.Request["PassWord"]));
            #endregion


            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();
            #region 更新操作
            Model.Sys_Users sys_Model = new BLL.Sys_Users().GetModel(pkid);
            BLL.Sys_Users sys_BLL = new BLL.Sys_Users();
            sys_Model.ID = pkid;
            sys_Model.PassWord = PassWord;
            sys_Model.ModifyUser = user.GetUserName();
            sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
            bool ret = sys_BLL.Update(sys_Model);
            if (ret == true)
            {
                retMsg = "更新成功";
                jsonRet = "{retMsg:\"" + retMsg + "\"}";
            }
            else
            {
                retMsg = "更新失败";
                jsonRet = "{retMsg:\"" + retMsg + "\"}";
            }

            context.Response.Write(retMsg);
            context.Response.End();

            #endregion

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
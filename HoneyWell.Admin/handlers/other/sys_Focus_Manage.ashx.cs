using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.handlers.other
{
    /// <summary>
    /// sys_Focus_Manage 的摘要说明
    /// </summary>
    public class sys_Focus_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Focus_Manage(context);
        }

        void Sys_Focus_Manage(HttpContext context)
        {
            #region 处理请求参数 
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            string FCode = StringHelper.NullToStr(context.Request["FCode"]);
            string FName = StringHelper.NullToStr(context.Request["FName"]);
            string FPicUrl = StringHelper.NullToStr(context.Request["FPicUrl"]);
            string FOrder = StringHelper.NullToStr(context.Request["FOrder"]);
            #endregion


            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();
            if (pkid < 1)
            {
                #region 添加操作
                Model.Sys_Focus sys_Model = new Model.Sys_Focus();
                BLL.Sys_Focus sys_BLL = new BLL.Sys_Focus();
                sys_Model.FCode = FCode;
                sys_Model.FName = FName;
                sys_Model.FSmallPic = FPicUrl;
                sys_Model.FOrder = Utils.ToInt(FOrder);
                sys_Model.CreateUser = user.GetUserName();
                sys_Model.CreateTime = DateTime.Now.ToLocalTime();
                sys_Model.ModifyUser = user.GetUserName();
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                sys_Model.MoreCol1 = "";
                sys_Model.MoreCol2 = "";
                int ret = sys_BLL.Add(sys_Model);
                if (ret > 0)
                {
                    retMsg = "添加成功";
                    jsonRet = "{retMsg:\"" + retMsg + "\"}";
                }
                else
                {
                    retMsg = "添加失败";
                    jsonRet = "{retMsg:\"" + retMsg + "\"}";
                }
                context.Response.Write(retMsg);
                context.Response.End();

                #endregion
            }
            else
            {
                #region 更新操作
                Model.Sys_Focus sys_Model = new BLL.Sys_Focus().GetModel(pkid);
                BLL.Sys_Focus sys_BLL = new BLL.Sys_Focus();
                sys_Model.ID = pkid;
                sys_Model.FCode = FCode;
                sys_Model.FName = FName;
                sys_Model.FSmallPic = FPicUrl;
                sys_Model.FOrder = Utils.ToInt(FOrder);
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
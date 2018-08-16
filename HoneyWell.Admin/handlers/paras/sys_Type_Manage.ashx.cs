using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoneyWell.COMM;
using HoneyWell.DBUtility;
using HoneyWell.Admin.Method;

namespace HoneyWell.Admin.handlers.paras
{
    /// <summary>
    /// sys_Type_Manage 的摘要说明
    /// </summary>
    public class sys_Type_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           Sys_Type_Manage(context);
        }

        void Sys_Type_Manage(HttpContext context)
        {
            #region 处理请求参数 
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id); 
            string TCode = StringHelper.NullToStr(context.Request["TCode"]);
            string TName = StringHelper.NullToStr(context.Request["TName"]);
            string TPicUrl = StringHelper.NullToStr(context.Request["TPicUrl"]);
            string TOrder = StringHelper.NullToStr(context.Request["TOrder"]);
            string NodeValue = StringHelper.NullToStr(context.Request["NodeValue"]);
            string MenuLevel = StringHelper.NullToStr(context.Request["MenuLevel"]);
            #endregion


            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();
            if (pkid < 1)
            {
                #region 添加操作
                Model.Sys_Type sys_Model = new Model.Sys_Type();
                BLL.Sys_Type sys_BLL = new BLL.Sys_Type();
                sys_Model.TCode = TCode;
                sys_Model.TName = TName;
                sys_Model.TSmallPic = TPicUrl;
                sys_Model.ParentId = Utils.ToInt(NodeValue);
                sys_Model.TLevel = Utils.ToInt(MenuLevel) + 1;
                sys_Model.TOrder = Utils.ToInt(TOrder);
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
                Model.Sys_Type sys_Model = new BLL.Sys_Type().GetModel(pkid);
                BLL.Sys_Type sys_BLL = new BLL.Sys_Type();
                sys_Model.ID = pkid;
                sys_Model.TCode = TCode;
                sys_Model.TName = TName;
                sys_Model.TSmallPic = TPicUrl; 
                sys_Model.TOrder = Utils.ToInt(TOrder); 
                sys_Model.ModifyUser = user.GetUserName();
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                bool ret = sys_BLL.Update(sys_Model);
                if (ret==true)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using HoneyWell.COMM;
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;

namespace HoneyWell.handlers.system
{
    /// <summary>
    /// sys_Duty_Manage 的摘要说明
    /// </summary>
    public class sys_Duty_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Duty_Manage(context);
        }
        void Sys_Duty_Manage(HttpContext context)
        {
            #region 处理请求参数
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            string DutyName = StringHelper.NullToStr(context.Request["DutyName"]);
            string DutyDesc = StringHelper.NullToStr(context.Request["DutyDesc"]);
            string MenuSetting = StringHelper.NullToStr(context.Request["MenuSetting"]);
            #endregion



            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();

            if (pkid < 1)
            {
                #region 添加操作
                Model.Sys_Duty sys_Model = new Model.Sys_Duty();
                BLL.Sys_Duty sys_BLL = new BLL.Sys_Duty();
                sys_Model.DutyName = DutyName;
                sys_Model.DutyDesc = DutyDesc;
                sys_Model.MenuSetting = MenuSetting;
                sys_Model.CreateTime = DateTime.Now.ToLocalTime();
                sys_Model.CreateUser = user.GetUserName();
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                sys_Model.ModifyUser = user.GetUserName();
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
                Model.Sys_Duty sys_Model = new BLL.Sys_Duty().GetModel(pkid);
                BLL.Sys_Duty sys_BLL = new BLL.Sys_Duty();
                sys_Model.ID = pkid;
                sys_Model.DutyName = DutyName;
                sys_Model.DutyDesc = DutyDesc;
                sys_Model.MenuSetting = MenuSetting;
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                sys_Model.ModifyUser = user.GetUserName();
                sys_Model.MoreCol1 = "";
                sys_Model.MoreCol2 = "";

                bool ret = sys_BLL.Update(sys_Model);
                if (ret ==true)
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
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
    /// sys_Member_Manage 的摘要说明
    /// </summary>
    public class sys_Member_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Member_Manage(context);
        }
        void Sys_Member_Manage(HttpContext context)
        {
            #region 处理请求参数
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            int DutyId = StringHelper.NullToInt(context.Request["DutyId"]);
            string AdminUser = StringHelper.NullToStr(context.Request["AdminUser"]);
            string AdminPassWord = StringHelper.NullToStr(context.Request["AdminPassWord"]);
            string AdminPassWordOld = StringHelper.NullToStr(context.Request["AdminPassWordOld"]);
            string Remark = StringHelper.NullToStr(context.Request["Remark"]);
            #endregion



            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();

            if (pkid < 1)
            {
                #region 添加操作 
                //判断用户名是否重复
                DataSet ds = new BLL.Sys_Public().SelectData("top 1 ID,AUserName", "Sys_Admin", " and AUserName='" + AdminUser + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    retMsg = "您输入的用户名已存在，请重新输入！";
                    jsonRet = "{retMsg:\"" + retMsg + "\"}";
                    context.Response.Write(retMsg);
                    context.Response.End();
                }

                Model.Sys_Admin sys_Model = new Model.Sys_Admin();
                BLL.Sys_Admin sys_BLL = new BLL.Sys_Admin();
                sys_Model.DutyID = DutyId;
                sys_Model.AUserName = AdminUser;
                sys_Model.TrueName = "";
                sys_Model.Remark = Remark;
                sys_Model.APassWord = Encrypt.MakeSecuritySHA(AdminPassWord);
                sys_Model.CreateTime = DateTime.Now.ToLocalTime();
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
                Model.Sys_Admin sys_Model = new BLL.Sys_Admin().GetModel(pkid);
                BLL.Sys_Admin sys_BLL = new BLL.Sys_Admin();
                sys_Model.ID = pkid;
                sys_Model.DutyID = DutyId;
                sys_Model.AUserName = AdminUser;
                sys_Model.TrueName = "";
                sys_Model.Remark = Remark;
                if (AdminPassWord != "")
                {
                    sys_Model.APassWord = Encrypt.MakeSecuritySHA(AdminPassWord);
                }
                else
                {
                    sys_Model.APassWord = AdminPassWordOld;
                }
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                sys_Model.MoreCol1 = "";
                sys_Model.MoreCol2 = "";

                bool ret = sys_BLL.Update(sys_Model);
                if (ret==true)
                {
                    string tableName1 = "Sys_Admin";
                    string sqlWhere1 = " and AUserName='" + AdminUser + "' ";
                    sqlWhere1 += " and APassWord='" + Encrypt.MakeSecuritySHA(AdminPassWord) + "'";
                    string showField1 = "top 1 Id,DutyID";
                    DataTable dt1 = new BLL.Sys_Public().SelectData(showField1, tableName1, sqlWhere1).Tables[0];
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        HttpCookie cookie = new HttpCookie("Fadmin");
                        cookie["DutyId"] = dt1.Rows[0]["DutyID"].ToString();
                        cookie["UserName"] = AdminUser;
                        cookie["PassWord"] = AdminPassWord;
                        HttpContext.Current.Response.Cookies.Add(cookie);

                        Model.Sys_Logs logs = new Model.Sys_Logs();
                        logs.ID = 0;
                        logs.DutyId = Utils.ToInt(dt1.Rows[0]["DutyID"].ToString());
                        logs.LoginName = AdminUser;
                        logs.TitleName = "用户中心";
                        logs.Depicts = "用户密码修改,会员名为：" + AdminUser + "";
                        logs.CreateTime = DateTime.Now;
                        logs.IpAddress = HttpContext.Current.Request.UserHostAddress;
                        logs.MoreCol1 = "";
                        logs.MoreCol2 = "";
                        new BLL.Sys_Logs().Add(logs);
                    }

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
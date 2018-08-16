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
    /// sys_Coupon_Manage 的摘要说明
    /// </summary>
    public class sys_Coupon_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Coupon(context);
        }

         void Sys_Coupon(HttpContext context)
        {
            #region 处理请求参数 
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            string CType = StringHelper.NullToStr(context.Request["CType"]);
            string CName = StringHelper.NullToStr(context.Request["CName"]);
            string CCode = StringHelper.NullToStr(context.Request["CCode"]);
            string CSum = StringHelper.NullToStr(context.Request["CSum"]);
            string Deduction = StringHelper.NullToStr(context.Request["Deduction"]);
            string TDateS = StringHelper.NullToStr(context.Request["TDateS"]);
            string TDateE = StringHelper.NullToStr(context.Request["TDateE"]);
            int IssueNum =Utils.ToInt(StringHelper.NullToStr(context.Request["IssueNum"]));
            string Remark = StringHelper.NullToStr(context.Request["Remark"]);
            #endregion

            #region 随机数
            Random ra = new Random();
            string str = "qwertyuiopasdfghjklzxcvbnm_";
            string reulst = "";
            for (int i=0;i<6;i++)
            {
                reulst += str[ra.Next(str.Length)];
            }
            #endregion
            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();
            if (pkid < 1)
            {
                #region 添加操作
                Model.Sys_Coupon sys_Model = new Model.Sys_Coupon();
                BLL.Sys_Coupon sys_BLL = new BLL.Sys_Coupon();
                sys_Model.CType = CType;
                sys_Model.CName = CName;
                sys_Model.CCode = reulst;
                sys_Model.CSum = decimal.Parse(CSum);
                sys_Model.CDeduction = decimal.Parse(Deduction);
                sys_Model.StartingTime =Utils.ToDateTime(TDateS);
                sys_Model.EndTime = Utils.ToDateTime(TDateE);
                sys_Model.IssueNum =IssueNum;
                sys_Model.Remark = Remark;
                sys_Model.CreateUser = user.GetUserName();
                sys_Model.CreateTime = DateTime.Now.ToLocalTime();
                sys_Model.ModifyUser = user.GetUserName();
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                sys_Model.MoreCol1 = "";
                sys_Model.MoreCol2 = "";
                int ret = sys_BLL.Add(sys_Model);
                if (ret > 0)
                {
                    int ret1 = 0;
                    for (int i=0;i<IssueNum;i++)
                    {
                        string num = ra.Next(1,1000000).ToString();
                        Model.Sys_Coupon_Details sys_Model1 = new Model.Sys_Coupon_Details();
                        BLL.Sys_Coupon_Details sys_BLL1 = new BLL.Sys_Coupon_Details();
                        sys_Model1.CCode = reulst;
                        sys_Model1.CSmallCode= reulst + "-" + num;
                        sys_Model1.CNum = 1;
                        sys_Model1.CTime = DateTime.Now.ToLocalTime();
                        sys_Model1.CState = "0";
                        sys_Model1.ReceiveTime = DateTime.Now.ToLocalTime();
                         ret1 = sys_BLL1.Add(sys_Model1);
                    }
                    if (ret1 > 0)
                    {
                        retMsg = "添加成功";
                        jsonRet = "{retMsg:\"" + retMsg + "\"}";
                    }
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
                Model.Sys_Coupon sys_Model = new BLL.Sys_Coupon().GetModel(pkid);
                BLL.Sys_Coupon sys_BLL = new BLL.Sys_Coupon();
                sys_Model.ID = pkid;
                sys_Model.CType = CType;
                sys_Model.CName = CName;
                sys_Model.CCode = CCode;
                sys_Model.CSum = decimal.Parse(CSum);
                sys_Model.CDeduction = decimal.Parse(Deduction);
                sys_Model.StartingTime = Utils.ToDateTime(TDateS);
                sys_Model.EndTime = Utils.ToDateTime(TDateE);
                sys_Model.IssueNum =IssueNum;
                sys_Model.Remark = Remark;
                sys_Model.ModifyUser = user.GetUserName();
                sys_Model.ModifyTime = DateTime.Now.ToLocalTime();
                bool ret = sys_BLL.Update(sys_Model);
                if (ret == true)
                {
                    new BLL.Sys_Public().Delete("Sys_Coupon_Details", "CCode='"+ CCode + "'");
                    int ret1 = 0;
                    for (int i = 0; i < IssueNum; i++)
                    {
                        string num = ra.Next(1,1000000).ToString();
                        Model.Sys_Coupon_Details sys_Model1 = new Model.Sys_Coupon_Details();
                        BLL.Sys_Coupon_Details sys_BLL1 = new BLL.Sys_Coupon_Details();
                        sys_Model1.CCode = CCode;
                        sys_Model1.CSmallCode = CCode + "-" + num;
                        sys_Model1.CNum = 1;
                        sys_Model1.CTime = DateTime.Now.ToLocalTime();
                        sys_Model1.CState = "0";
                        sys_Model1.ReceiveTime = DateTime.Now.ToLocalTime();
                        ret1 = sys_BLL1.Add(sys_Model1);
                    }
                    if (ret1 > 0)
                    {
                        retMsg = "更新成功";
                        jsonRet = "{retMsg:\"" + retMsg + "\"}";
                    }
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
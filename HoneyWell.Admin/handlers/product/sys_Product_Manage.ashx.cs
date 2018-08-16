using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.handlers.product
{
    /// <summary>
    /// sys_Product_Manage 的摘要说明
    /// </summary>
    public class sys_Product_Manage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Sys_Product_Manage(context);
        }

        void Sys_Product_Manage(HttpContext context)
        {
            #region 处理请求参数 
            string Id = context.Request["Id"];
            int pkid = 0;
            if (!string.IsNullOrEmpty(Id))
                pkid = Convert.ToInt32(Id);
            string PTypeMain = StringHelper.NullToStr(context.Request["PTypeMain"]);
            string PTypeSmall = StringHelper.NullToStr(context.Request["PTypeSmall"]);
            string PProperty = StringHelper.NullToStr(context.Request["PProperty"]);
            string PName = StringHelper.NullToStr(context.Request["PName"]);
            string PPicUrl = StringHelper.NullToStr(context.Request["PPicUrl"]);
            string DPicUrl = StringHelper.NullToStr(context.Request["DPicUrl"]);
            string PMarket = StringHelper.NullToStr(context.Request["PMarket"]);
            string PRetail = StringHelper.NullToStr(context.Request["PRetail"]);
            string PFormat = StringHelper.NullToStr(context.Request["PFormat"]);
            string PParam = StringHelper.NullToStr(context.Request["PParam"]);
            string PMould = StringHelper.NullToStr(context.Request["PMould"]);
            string PStock = StringHelper.NullToStr(context.Request["PStock"]);
            string PRecommend = StringHelper.NullToStr(context.Request["PRecommend"]);
            string PShelf = StringHelper.NullToStr(context.Request["PShelf"]);
            string PDetails = StringHelper.NullToStr(context.Request["PDetails"]);
            #endregion


            string jsonRet = "";
            string retMsg = "";

            UserInfo user = new UserInfo();
            if (pkid < 1)
            {
                #region 添加操作
                Model.Sys_Product sys_Model = new Model.Sys_Product();
                BLL.Sys_Product sys_BLL = new BLL.Sys_Product();
                sys_Model.PTypeMain = PTypeMain;
                sys_Model.PTypeSmall = PTypeSmall;
                sys_Model.PProperty = PProperty;
                sys_Model.PName = PName;
                sys_Model.PSmallPic = PPicUrl;
                sys_Model.PDetailPic = DPicUrl;
                sys_Model.PMarket = decimal.Parse(PMarket);
                sys_Model.PRetail = decimal.Parse(PRetail);
                sys_Model.PFormat = PFormat;
                sys_Model.PParam = PParam;
                sys_Model.PMould = PMould;
                sys_Model.PStock = Utils.ToInt(PStock);
                sys_Model.PRecommend = PRecommend;
                sys_Model.PShelf = PShelf;
                sys_Model.PDetails = PDetails;
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
                Model.Sys_Product sys_Model = new BLL.Sys_Product().GetModel(pkid);
                BLL.Sys_Product sys_BLL = new BLL.Sys_Product();
                sys_Model.ID = pkid;
                sys_Model.PTypeMain = PTypeMain;
                sys_Model.PTypeSmall = PTypeSmall;
                sys_Model.PProperty = PProperty;
                sys_Model.PName = PName;
                sys_Model.PSmallPic = PPicUrl;
                sys_Model.PDetailPic = DPicUrl;
                sys_Model.PMarket = decimal.Parse(PMarket);
                sys_Model.PRetail = decimal.Parse(PRetail);
                sys_Model.PFormat = PFormat;
                sys_Model.PParam = PParam;
                sys_Model.PMould = PMould;
                sys_Model.PStock = Utils.ToInt(PStock);
                sys_Model.PRecommend = PRecommend;
                sys_Model.PShelf = PShelf;
                sys_Model.PDetails = PDetails;
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
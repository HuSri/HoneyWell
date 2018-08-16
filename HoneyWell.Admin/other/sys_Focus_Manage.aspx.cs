using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.other
{
    public partial class sys_Focus_Manage : UserPage
    {
        #region 公共参数
        public int PKID = 0;
        public string FCode = "";
        public string FName = "";
        public string FPic = "";
        public int FOrder = 0;

        public string FPic_List = "";

        //查询条件信息
        public string Code = "";
        public string Name = "";
        public string Pageindex = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Ttext"]))
                {
                    PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                }

                if (PKID > 0)
                {
                    SelectInfo();
                    BindModel();                  
                }
                else
                {
                    FPic = "../images/upload_img.jpg";
                }

            }
        }
        #region 查询信息
        public void SelectInfo()
        {
            if (!string.IsNullOrEmpty(Request["Code"]))
            {
                Code =Request["Code"];
            }
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                Name = Request["Name"];
            }
            if (!string.IsNullOrEmpty(Request["Pageindex"]))
            {
                Pageindex =Request["Pageindex"];
            }
        }
        #endregion

        /// <summary>
        /// 绑定单体对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Focus sys_BLL = new BLL.Sys_Focus();
            Model.Sys_Focus sys_Model = sys_BLL.GetModel(PKID);
            FCode = sys_Model.FCode;
            FName = sys_Model.FName;
            FOrder = sys_Model.FOrder;
            FPic = sys_Model.FSmallPic;
            if (FPic != "")
            {
                string[] sArray = FPic.Split(',');
                foreach (string j in sArray)
                {
                    FPic_List += "<li>";
                    FPic_List += "<input type=\"hidden\" name=\"ImgName\" value=\"" + j.ToString() + "\" />";
                    FPic_List += "<div class=\"img-box\">";
                    FPic_List += "<img src=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" onclick=\"setOpenImg(this.src);\" bigsrc=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" />";
                    FPic_List += "</div>";
                    FPic_List += "<a href=\"javascript:;\" onclick=\"delImg(this);\">删除</a>";
                    FPic_List += "</li>";
                }
            }
        }

    }
}
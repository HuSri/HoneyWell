using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;
using HoneyWell.COMM;
using HoneyWell.DBUtility;

namespace HoneyWell.Admin.orders
{
    public partial class sys_Users_Edit : UserPage
    {
        public int PKID = 0;
        public string OpenID ="";
        public string Phone = "";
        public string PassWord = "";
        public string Name = "";
        public string SmallPic = "";
        public string NickName = "";
        public string DateBirth ;
        public string Sex = "";
        public string Email = "";
        public DateTime CreateTime ;

        public string SPic = "";
        public string SPicLink = "";
        public string StrSex = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Text"]));
                BindModel();
            }
        }

        void BindModel()
        {
            BLL.Sys_Users sys_BLL = new BLL.Sys_Users();
            Model.Sys_Users sys_Model = sys_BLL.GetModel(PKID);
            OpenID = sys_Model.OpenID;
            Phone = sys_Model.Phone;
            PassWord = sys_Model.PassWord;
            Name = sys_Model.Name;
            NickName = sys_Model.NickName;
            DateBirth =Utils.ToDateTime(sys_Model.DateBirth).ToString("yyyy-MM-dd");
            Sex = sys_Model.Sex;
            GetSex(Sex);
            Email = sys_Model.Email;
            CreateTime = sys_Model.CreateTime;

            if (sys_Model.SmallPic.ToString().Trim() == "")
            {
                SPic = "../images/upload_img.jpg";
            }
            else
            {
                SPic = GetImgUrl() + sys_Model.SmallPic;
                SPicLink = "<a href=\"" + GetImgUrl() + sys_Model.SmallPic + "\"  target=\"_blank\"><font color=blue>查看图片</font></a><br />";
            }
        }

        #region 返回性别
        public void GetSex(string Sex)
        {
            switch (Sex)
            {
                case "0":
                    StrSex = "男";
                    break;
                case "1":
                    StrSex = "女";
                    break;
            }
        }
        #endregion
    }
}
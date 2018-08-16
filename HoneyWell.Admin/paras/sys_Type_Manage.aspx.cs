using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HoneyWell.Admin.Method;
using HoneyWell.DBUtility;
using HoneyWell.Model;
using HoneyWell.BLL;

namespace HoneyWell.Admin.paras
{
    public partial class Sys_Type_Manage : UserPage
    {
        public string nodeText = DNTRequest.GetString("nodeText");
        public string nodeValue = DNTRequest.GetString("nodeValue");

        public string TPic = "";
        public string TPic_List = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定数据
        public void BindData()
        {
            if (nodeText != "")
            {
                HoneyWell.Model.Sys_Type sys_Model = new HoneyWell.BLL.Sys_Type().GetModel(Utils.ToInt(nodeValue));
                txtCCode.Value = sys_Model.TCode;
                txtCName.Value = sys_Model.TName ;
                txtCOrder.Value = sys_Model.TOrder.ToString();
                TPic = sys_Model.TSmallPic;
                if (TPic != "")
                {
                    string[] sArray = TPic.Split(',');
                    foreach (string j in sArray)
                    {
                        TPic_List += "<li>";
                        TPic_List += "<input type=\"hidden\" name=\"ImgName\" value=\"" + j.ToString() + "\" />";
                        TPic_List += "<div class=\"img-box\">";
                        TPic_List += "<img src=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" onclick=\"setOpenImg(this.src);\" bigsrc=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" />";
                        TPic_List += "</div>";
                        TPic_List += "<a href=\"javascript:;\" onclick=\"delImg(this);\">删除</a>";
                        TPic_List += "</li>";
                    }
                }
            }
        }
        #endregion

   


        protected void btnDel_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (Utils.ToInt(nodeValue) > 0)
            {
                HoneyWell.Model.Sys_Type info = new HoneyWell.BLL.Sys_Type().GetModel(Convert.ToInt32(nodeValue));
                HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                logs.ID = 0;
                logs.DutyId = Utils.ToInt(GetDutyId());
                logs.LoginName = GetUserName();
                logs.TitleName = "类别管理";
                logs.Depicts = "删除类别信息,名称为：" + info.TName + "";
                logs.CreateTime = DateTime.Now;
                logs.IpAddress = Request.UserHostAddress;
                logs.MoreCol1 = "";
                logs.MoreCol2 = "";
                new HoneyWell.BLL.Sys_Logs().Add(logs);
                result = new HoneyWell.BLL.Sys_Public().Delete("Sys_Type", " ID=" + Utils.ToInt(nodeValue) + "");
            }


            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.location='Sys_Type_Tree.aspx'", true);
            }
        }
    }
}
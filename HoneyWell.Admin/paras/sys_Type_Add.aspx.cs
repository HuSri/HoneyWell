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
    public partial class Sys_Type_Add : UserPage
    {
        public string nodeText = DNTRequest.GetString("nodeText");
        public string nodeValue = DNTRequest.GetString("nodeValue");
        public string menuLevel = "";
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
            if (Utils.ToInt(nodeValue) > 0)
            {
                HoneyWell.Model.Sys_Type menu = new HoneyWell.BLL.Sys_Type().GetModel(Utils.ToInt(nodeValue));
                menuLevel = menu.TLevel.ToString();
                lab_ParentName.InnerHtml = menu.TName;
            }
            else
            {
                menuLevel = "0";
                lab_ParentName.InnerHtml = nodeText;
            }
        }
        #endregion
         
    }
}
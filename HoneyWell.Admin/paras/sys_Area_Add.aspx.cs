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

namespace HoneyWell.paras
{
    public partial class sys_Area_Add : UserPage
    {
        private string nodeText = DNTRequest.GetString("nodeText");
        private string nodeValue = DNTRequest.GetString("nodeValue");
        public int nodeId = 0;
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
            if (nodeValue != "000000")
            {
                string tableName = "Sys_Area";
                string showField = " top 1 ID";
                string strWhere = " and AreaCode='" + nodeValue + "'";
                DataTable dt = new BLL.Sys_Public().SelectData(showField, tableName, strWhere).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    nodeId = Utils.ToInt(dt.Rows[0]["ID"].ToString());
                }
            } 

            if (nodeId > 0)
            {
                HoneyWell.Model.Sys_Area area = new HoneyWell.BLL.Sys_Area().GetModel(nodeId);
                h_ClassLevel.Value = area.AreaLevel.ToString();
                lab_ParentName.InnerHtml = area.AreaName;
            }
            else
            {
                h_ClassLevel.Value = "0";
                lab_ParentName.InnerHtml = nodeText;
            }
        }
        #endregion


        #region 对象赋值
        public HoneyWell.Model.Sys_Area SetObjectValue()
        {
            HoneyWell.Model.Sys_Area area = new HoneyWell.Model.Sys_Area();
            area.AreaCode = txt_ClassCode.Value.Trim();
            area.AreaName = txt_ClassName.Value.Trim();
            area.ParentAreaCode = nodeValue;
            area.AreaLevel = Utils.ToInt(h_ClassLevel.Value) + 1;
            area.AreaOrder = Utils.ToInt(txt_ClassOrder.Value.Trim());
            area.KeyWord = txt_KeyWord.Value.Trim(); ;
            area.CreateUser = GetUserName();
            area.CreateTime = DateTime.Now;
            area.ModifyUser = GetUserName();
            area.ModifyTime = DateTime.Now;
            area.MoreCol1 = "";
            area.MoreCol2 = "";

            return area;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //判断区域代码是否重复
            DataSet ds = new HoneyWell.BLL.Sys_Public().SelectData("top 1 ID", "Sys_Area", " and AreaCode='" + txt_ClassCode.Value.Trim() + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script language='javascript'>alert('您输入的区域代码已存在，请重新输入!');location.href='sys_Area_Add.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'</script>");
                Response.End();
            }

            //判断区域名称是否重复
            DataSet ds1 = new HoneyWell.BLL.Sys_Public().SelectData("top 1 ID", "Sys_Area", " and AreaName='" + txt_ClassName.Value.Trim() + "'");
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script language='javascript'>alert('您输入的区域名称已存在，请重新输入!');location.href='sys_Area_Add.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'</script>");
                Response.End();
            }

            int result = 0;
            HoneyWell.Model.Sys_Area area = SetObjectValue();
            result = new HoneyWell.BLL.Sys_Area().Add(area);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.location='sys_Area_Tree.aspx'", true);
            }
        }
    }
}
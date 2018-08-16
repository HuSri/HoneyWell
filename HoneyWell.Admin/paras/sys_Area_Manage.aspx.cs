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
    public partial class sys_Area_Manage : UserPage
    {
        public string nodeText = DNTRequest.GetString("nodeText");
        public string nodeValue = DNTRequest.GetString("nodeValue");
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
            if (nodeText != "")
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
                try
                {
                    HoneyWell.Model.Sys_Area area = new HoneyWell.BLL.Sys_Area().GetModel(nodeId);
                    txt_ClassCode.Value = area.AreaCode;
                    txt_ClassName.Value = area.AreaName;
                    txt_ClassOrder.Value = area.AreaOrder.ToString();
                    txt_KeyWord.Value = area.KeyWord;
                    h_ParentCode.Value = area.ParentAreaCode;
                    h_ClassLevel.Value = area.AreaLevel.ToString();
                }
                catch(Exception e)
                {
                    Response.Write(e.Message);
                }
            }
        }
        #endregion


        #region 对象赋值
        public HoneyWell.Model.Sys_Area SetObjectValue()
        {
            string tableName = "Sys_Area";
            string showField = " top 1 ID";
            string strWhere = " and AreaCode='" + nodeValue + "'";
            DataTable dt = new BLL.Sys_Public().SelectData(showField, tableName, strWhere).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                nodeId = Utils.ToInt(dt.Rows[0]["ID"].ToString());
            }
            HoneyWell.Model.Sys_Area area = new HoneyWell.Model.Sys_Area();
            area.ID = nodeId;
            area.AreaCode = txt_ClassCode.Value.Trim();
            area.AreaName = txt_ClassName.Value.Trim();
            area.ParentAreaCode = h_ParentCode.Value;
            area.AreaLevel = Utils.ToInt(h_ClassLevel.Value);
            area.AreaOrder = Utils.ToInt(txt_ClassOrder.Value.Trim());
            area.KeyWord = txt_KeyWord.Value.Trim();
            area.ModifyUser = GetUserName();
            area.ModifyTime = DateTime.Now;
            area.MoreCol1 = "";
            area.MoreCol2 = "";

            return area;
        }
        #endregion



        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            HoneyWell.Model.Sys_Area area = SetObjectValue();
                
            if (nodeValue != "")
            {
                //判断区域代码是否重复
                DataSet ds = new HoneyWell.BLL.Sys_Public().SelectData("top 1 ID", "Sys_Area", " and AreaCode='" + txt_ClassCode.Value.Trim() + "' and AreaCode<>'" + nodeValue + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>alert('您输入的区域代码已存在，请重新输入!');location.href='sys_Area_Manage.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'</script>");
                    Response.End();
                }

                //判断区域名称是否重复
                DataSet ds1 = new HoneyWell.BLL.Sys_Public().SelectData("top 1 ID", "Sys_Area", " and AreaName='" + txt_ClassName.Value.Trim() + "' and AreaCode<>'" + nodeValue + "'");
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>alert('您输入的区域名称已存在，请重新输入!');location.href='sys_Area_Manage.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'</script>");
                    Response.End();
                }

                result = new HoneyWell.BLL.Sys_Area().Update(area);
            }

            if (true)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');location.href='sys_Area_Manage.aspx?nodeText=" + nodeText + "&nodeValue=" + nodeValue + "'", true);
            }
        }


        protected void btnDel_Click(object sender, EventArgs e)
        {
            int result = 0;
            string tableName = "Sys_Area";
            string showField = " top 1 ID";
            string strWhere = " and AreaCode='" + nodeValue + "'";
            DataTable dt = new BLL.Sys_Public().SelectData(showField, tableName, strWhere).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                nodeId = Utils.ToInt(dt.Rows[0]["ID"].ToString());
            }
            if (nodeId > 0)
            {
                HoneyWell.Model.Sys_Area info = new HoneyWell.BLL.Sys_Area().GetModel(nodeId);

                HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                logs.ID = 0;
                logs.DutyId = Utils.ToInt(GetDutyId());
                logs.LoginName = GetUserName();
                logs.TitleName = "区域管理";
                logs.Depicts = "删除区域信息,名称为：" + info.AreaName + "";
                logs.CreateTime = DateTime.Now;
                logs.IpAddress = Request.UserHostAddress;
                logs.MoreCol1 = "";
                logs.MoreCol2 = "";
                new HoneyWell.BLL.Sys_Logs().Add(logs);

                result = new HoneyWell.BLL.Sys_Public().Delete("Sys_Area", " ID=" + nodeId + ""); 
            }


            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "", "alert('操作成功!');parent.location='sys_Area_Tree.aspx'", true);
            }
        }
    }
}
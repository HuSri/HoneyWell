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
using HoneyWell.DAL;

namespace HoneyWell.system
{
    public partial class sys_Log_List : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                pageBind();
                BindDuty();
            }
        }


        #region 绑定角色
        public void BindDuty()
        {
            txtDutyId.Items.Clear();
            ListItem item1 = new ListItem("==请选择==", "");
            txtDutyId.Items.Add(item1);
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData(" ID,DutyName", "sys_Duty", " order by DutyDesc").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = dt.Rows[i]["DutyName"].ToString();
                item.Value = dt.Rows[i]["ID"].ToString();
                txtDutyId.Items.Add(item);
            }
        }
        #endregion




        public void pageBind()
        {
            string strWhere = " ";


            if (txtDutyId.SelectedValue.Trim().Length > 0)
            {
                strWhere += " and DutyId = '" + txtDutyId.SelectedValue.Trim() + "'";
            }

            if (txt_TitleName.Value.Trim().Length > 0)
            {
                strWhere += " and TitleName like '%" + txt_TitleName.Value.Trim() + "%'";
            }

            if (txt_Depicts.Value.Trim().Length > 0)
            {
                strWhere += " and Depicts like '%" + txt_Depicts.Value.Trim() + "%'";
            }

            string tableName = "Sys_Logs";
            string showField = " ID,DutyId,LoginName,TitleName,Depicts,IpAddress,CreateTime";
            string orderField = "ID";
            int count = 0;

            DataSet ds = new HoneyWell.BLL.Sys_Public().GetList(tableName, showField, orderField, MyPager.Pagesize, MyPager.Pageindex + 1, 0, strWhere, out count);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
            MyPager.Count = count;
        }



        protected void MyPager_PageIndexChange(object sender, EventArgs e)
        {
            pageBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pageBind();
        }


        #region 返回角色名称
        public string GetDuty(string DutyId)
        {
            string Type_Str = "";
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData("top 1 DutyName", "Sys_Duty", " and ID='" + DutyId + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                Type_Str = dt.Rows[0]["DutyName"].ToString();
            }

            return Type_Str;
        }
        #endregion


    }
}
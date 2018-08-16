using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.COMM;

namespace HoneyWell.Admin.orders
{
    public partial class sys_Receipt_List : System.Web.UI.Page
    {
        public string Phone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["Phone"]))
            {
                Phone = Encrypt.PageDispelParam(Request["Phone"]);
            }
            pageBind();
        }
        
        void pageBind()
        {
            string strWhere = "and Phone='"+Phone+"'";
            string tableName = "Sys_Receipt";
            string showField = "RName,RPhone,Province,City,Area,RAddress,RZipCode";
            string orderField = "ID";
            int count = 0;
            DataSet ds = new BLL.Sys_Public().GetList(tableName,showField,orderField,MyPager.Pagesize,MyPager.Pageindex+1,0,strWhere,out count);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
            MyPager.Count = count;
        }

        protected void MyPager_PageIndexChange(object sender, EventArgs e)
        {
            pageBind();
        }

        public string GetArea(string Province,string City,string Area)
        {
            string StrArea = "";
            DataTable dt1 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + Province + "").Tables[0];
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                StrArea += dt1.Rows[0]["AreaName"].ToString();
            }
            DataTable dt2 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + City + "").Tables[0];
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                StrArea += "--" + dt2.Rows[0]["AreaName"].ToString();
            }
            DataTable dt3 = new BLL.Sys_Public().SelectData("AreaName", "Sys_Area", "and AreaCode=" + Area + "").Tables[0];
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                StrArea += "--" + dt3.Rows[0]["AreaName"].ToString();
            }
            return StrArea;
        }
    }
}
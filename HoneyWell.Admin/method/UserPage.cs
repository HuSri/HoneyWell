using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HoneyWell.Model;
using HoneyWell.BLL;
using HoneyWell.COMM;

namespace HoneyWell.Admin.Method
{
    public class UserPage : Page
    {
        public UserPage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            ShowPage();
        }
        protected override void OnInit(EventArgs e)
        {
            try
            {

                string UserName = HttpContext.Current.Server.UrlDecode(Request.Cookies["Fadmin"]["UserName"].ToString());
                string PassWord = HttpContext.Current.Server.UrlDecode(Request.Cookies["Fadmin"]["PassWord"].ToString());
                string tableName = "Sys_Admin";
                string sqlWhere = " and AUserName='" + UserName + "' and APassWord='" + Encrypt.MakeSecuritySHA(PassWord) + "'";
                string showField = "top 1 Id";
                DataTable dt_user = new HoneyWell.BLL.Sys_Public().SelectData(showField, tableName, sqlWhere).Tables[0];
                if (dt_user == null || dt_user.Rows.Count <= 0)
                {
                    Response.Write("<script language='javascript'>");
                    Response.Write("window.alert('非法登陆系统!');");
                    Response.Write("location.href='" + ResolveUrl("~/") + "Friend.aspx';");
                    Response.Write("</script>");
                    Response.End();
                }
                 
            }
            catch (Exception)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("window.alert('异常登陆系统1!');");
                Response.Write("location.href='" + ResolveUrl("~/") + "Friend.aspx';");
                Response.Write("</script>");
            }
 

            base.OnInit(e);
        }

 

        /// <summary>
        /// 获取DutyId
        /// </summary>
        public string GetDutyId()
        {
            string DutyId = "";
            try
            {
                DutyId = Convert.ToString(Request.Cookies["Fadmin"]["DutyId"]);
            }
            catch (Exception)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("window.alert('获取角色ID异常!');");
                Response.Write("location.href='" + ResolveUrl("~/") + "Friend.aspx';");
                Response.Write("</script>");
            }

            return DutyId;
        }
         

        /// <summary>
        /// 获取UserName
        /// </summary>
        public string GetUserName()
        {
            string userName = "";
            try
            {
                userName = Convert.ToString(Request.Cookies["Fadmin"]["UserName"]);
            }
            catch (Exception)
            {

                Response.Write("<script language='javascript'>");
                Response.Write("window.alert('获取用户名异常!');");
                Response.Write("location.href='" + ResolveUrl("~/") + "Friend.aspx';");
                Response.Write("</script>");
            }

            return userName;
        }


        /// <summary>
        /// 获取图片路径==后台
        /// </summary>
        public string GetImgUrl()
        {
            return ConfigurationManager.AppSettings["ImgUrl1"];
        }

        /// <summary>
        /// 获取图片路径==手机端
        /// </summary>
        public string GetImgUrl1()
        {
            return ConfigurationManager.AppSettings["ImgUrl2"];
        }

        /// <summary>
        /// 导出Execl
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="ExeclName">Execl名称</param>
        public void ExcelEpl(DataTable dt, string ExeclName)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.Charset = "UTF-8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + ExeclName + "" + DateTime.Now.ToString("yyyy年MM月dd日") + ".xls");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //表格开始部分
            sb.AppendLine("<table x:str border=1 cellpadding=0 cellspacing=0 style='border-collapse: collapse;table-layout:'>");
            //取得数据表各列标题
            string colHeaders = "<td style='vnd.ms-excel.numberformat:@;text-align:center;'>序号</td>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colHeaders += "<td style='vnd.ms-excel.numberformat:@;text-align:center;'>" + dt.Columns[i].Caption.ToString() + "</td>";
            }
            colHeaders = "<tr style='font-weight:bold'>" + colHeaders + "</tr>";
            sb.AppendLine(colHeaders);
            if (dt.Rows.Count > 0)
            {
                //逐行处理数据
                string rowItems = "";
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    //dt.Rows[k]["序号"] = (k + 1).ToString();
                    rowItems += "<td style='vnd.ms-excel.numberformat:@'>" + (k + 1) + "</td>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        rowItems += "<td style='vnd.ms-excel.numberformat:@'>" + dt.Rows[k][j].ToString() + "</td>";
                    }
                    rowItems = "<tr>" + rowItems + "</tr>\n";
                    //当前行数据写入sb，并且置空rowItems以便下行数据
                    sb.AppendLine(rowItems);
                    rowItems = "";
                }
            }
            Response.Write(sb.ToString());
            Response.End();

        }
        /// <summary>
        /// 导出Execl
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="ExeclName">Execl名称</param>
        public void ExcelEpl2(DataTable dt, string ExeclName)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.Charset = "UTF-8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + ExeclName + "" + DateTime.Now.ToString("yyyy年MM月dd日") + ".xls");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //表格开始部分
            sb.AppendLine("<table x:str border=1 cellpadding=0 cellspacing=0 style='border-collapse: collapse;table-layout:'>");
            //取得数据表各列标题
            string colHeaders = "<td style='vnd.ms-excel.numberformat:@;text-align:center;'>序号</td>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colHeaders += "<td style='vnd.ms-excel.numberformat:@;text-align:center;'>" + dt.Columns[i].Caption.ToString() + "</td>";
            }
            colHeaders = "<tr style='font-weight:bold'>" + colHeaders + "</tr>";
            sb.AppendLine(colHeaders);
            if (dt.Rows.Count > 0)
            {
                //逐行处理数据
                string rowItems = "";
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    //dt.Rows[k]["序号"] = (k + 1).ToString();
                    rowItems += "<td style='vnd.ms-excel.numberformat:@'>" + (k + 1) + "</td>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        rowItems += "<td style='vnd.ms-excel.numberformat:@'>" + dt.Rows[k][j].ToString() + "</td>";
                    }
                    rowItems = "<tr>" + rowItems + "</tr>\n";
                    //当前行数据写入sb，并且置空rowItems以便下行数据
                    sb.AppendLine(rowItems);
                    rowItems = "";
                }
            }
            Response.Write(sb.ToString());
            Response.End();

        }

        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            return;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.COMM;
using HoneyWell.DBUtility;
using HoneyWell.Admin.Method;

namespace HoneyWell.Admin.product
{
    public partial class sys_Product_List : UserPage
    {
        public string Pageindex = "";
        public string Ptypemain = "";
        public string Ptypesmall = "";
        public string Pname = "";
        public string Pformat = "";
        public string Pmould = "";
        public string Precommend = "";
        public string Pshelf = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl url = new CheckUrl();
                url.CheckUrlUser();
                BindType();
                SelectInfo();
                pageBind();
            }
        }

        #region 查询条件信息
        void SelectInfo()
        {
            if (!string.IsNullOrEmpty(Request["Pageindex"]))
            {
                Pageindex =Encrypt.PageDispelParam(Request["Pageindex"]);
            }
            if (!string.IsNullOrEmpty(Request["Ptypemain"]))
            {
                Ptypemain = Request["Ptypemain"];
            }
            if (!string.IsNullOrEmpty(Request["Ptypesmall"]))
            {
                Ptypesmall = Request["Ptypesmall"];
            }
            if (!string.IsNullOrEmpty(Request["Pname"]))
            {
                Pname = Request["Pname"];
            }
            if (!string.IsNullOrEmpty(Request["Precommend"]))
            {
                Precommend = Request["Precommend"];
            }
            if (!string.IsNullOrEmpty(Request["Pshelf"]))
            {
                Pshelf = Request["Pshelf"];
            }
        }
        #endregion

        #region 绑定类别名称
        void BindType()
        {
            txt_PTypeMain.Items.Clear();
            ListItem item1 = new ListItem("==请选择==", "");
            ListItem item2 = new ListItem("==请选择==", "");
            txt_PTypeMain.Items.Add(item1);
            DataTable dt = new HoneyWell.BLL.Sys_Public().SelectData("TCode,TName", "Sys_Type", "and TLevel=1 order by ID desc").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = dt.Rows[i]["TName"].ToString();
                item.Value = dt.Rows[i]["TCode"].ToString();
                txt_PTypeMain.Items.Add(item);
            }
            txt_PTypeSmall.Items.Add(item2);
        }
        #endregion

        public void pageBind()
        {
            string strWhere = "";

            if (hfPTypeMain.Value.Length > 0)
            {
                strWhere += " and PTypeMain ='" + hfPTypeMain.Value + "'";
            }
            if (Ptypemain != "")
            {
                strWhere += " and PTypeMain ='" + Ptypemain + "'";      
            }
            if (hfPTypeSmall.Value.Length>0)
            {
                strWhere += "and PTypeSmall ='" + hfPTypeSmall.Value + "'";
            }
            if (Ptypesmall != "")
            {
                strWhere += " and PTypeSmall ='" + Ptypesmall + "'";
            }

            if (txt_PName.Value.Trim().Length > 0)
            {
                strWhere += " and PName like '%" + txt_PName.Value.Trim() + "%'";
            }
            if (Pname != "")
            {
                strWhere += " and PName like '%" + Pname + "%'";
                txt_PName.Value = Pname;
            }

            if (txt_PRecommend.SelectedValue.Length > 0)
            {
                strWhere += " and PRecommend ='" + txt_PRecommend.SelectedValue.Trim() + "'";
            }
            if (Precommend != "")
            {
                strWhere += " and PRecommend = '" + Precommend + "'";
                txt_PRecommend.SelectedValue = Precommend;
            }
            
            if (txt_PShelf.SelectedValue.Length > 0)
            {
                strWhere += " and PShelf ='" + txt_PShelf.SelectedValue.Trim() + "'";
            }
            if (Pshelf != "")
            {
                strWhere += " and PShelf = '" + Pshelf + "'";
                txt_PShelf.SelectedValue = Pshelf;
            }

            //返回当前页面
            if (Pageindex != "")
            {
                MyPager.Pageindex =Utils.ToInt(Pageindex);
            }

            string tableName = "Sys_Product";
            string showField = " ID,PTypeMain,PTypeSmall,PName,PSmallPic,PMarket,PRetail,PStock,PRecommend,PShelf,ModifyTime";
            string orderField = "ID";
            int count = 0;

            DataSet ds = new HoneyWell.BLL.Sys_Public().GetList(tableName, showField, orderField, MyPager.Pagesize, MyPager.Pageindex + 1, 0, strWhere, out count);
            rptLoop.DataSource = ds;
            rptLoop.DataBind();
            MyPager.Count = count;
        }

        protected void rptLoop_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "del")
                {
                    HoneyWell.Model.Sys_Product info = new HoneyWell.BLL.Sys_Product().GetModel(Convert.ToInt32(e.CommandArgument));
                    HoneyWell.Model.Sys_Logs logs = new HoneyWell.Model.Sys_Logs();
                    logs.ID = 0;
                    logs.DutyId = Utils.ToInt(GetDutyId());
                    logs.LoginName = GetUserName();
                    logs.TitleName = "产品管理";
                    logs.Depicts = "删除产品信息,名称为：" + info.PName + "";
                    logs.CreateTime = DateTime.Now;
                    logs.IpAddress = Request.UserHostAddress;
                    logs.MoreCol1 = "";
                    logs.MoreCol2 = "";
                    new HoneyWell.BLL.Sys_Logs().Add(logs);
                    new HoneyWell.BLL.Sys_Public().Delete("Sys_Product", " ID=" + Convert.ToInt32(e.CommandArgument) + "");
                    ScriptManager.RegisterClientScriptBlock(rptLoop, GetType(), "", "alert('操作成功!');location.href='sys_Product_List.aspx?Pageindex=" + Encrypt.PageSecuityParam(MyPager.Pageindex.ToString()) + "&Ptypemain=" + hfPTypeMain.Value + "&Ptypesmall=" + hfPTypeSmall.Value + "&Pname=" + txt_PName.Value.Trim() + "&Precommend=" + txt_PRecommend.SelectedValue.Trim() + "&Pshelf=" + txt_PShelf.SelectedValue.Trim() + "';", true);
                }
            }
        }

        #region 返回类别名称
        public string GetType(string PTypeMain,string PTypeSmall)
        {
            string Name = "";
            string tableName = "Sys_Type";
            string showField = "TName";
            string strWhere1 = "and TCode='" + PTypeMain + "'";
            string strWhere2 = "and TCode='" + PTypeSmall + "'";
            DataTable dt1 = new HoneyWell.BLL.Sys_Public().SelectData(showField, tableName, strWhere1).Tables[0];
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                DataTable dt2 = new HoneyWell.BLL.Sys_Public().SelectData(showField, tableName, strWhere2).Tables[0];
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    Name += dt1.Rows[0]["TName"].ToString();
                    Name += "--" + dt2.Rows[0]["TName"].ToString();
                }
                else
                {
                    Name = dt1.Rows[0]["TName"].ToString();
                }
            }
            return Name;
        }
        #endregion

        #region 查看图片
        public string GetUrl(string PSmallPic)
        {
            return "<a href =\"" + GetImgUrl() +"/upload/product/" + PSmallPic + "\" target=\"_blank\"><font color=blue>查看图片</font></a><br />";
        }
        #endregion

        #region 返回是否推荐
        public string GetRecommend(string Recommend)
        {
            string Name = "";
            switch (Recommend)
            {
                case "0":
                    Name = "是";
                    break;
                case "1":
                    Name = "否";
                    break;
            }
            return Name;
        }
        #endregion

        #region 返回是否上架
        public string GetShelf(string PShelf)
        {
            string Name1 = "";
            switch (PShelf)
            {
                case "0":
                    Name1 = "是";
                    break;
                case "1":
                    Name1 = "否";
                    break;
            }
            return Name1;
        }
        #endregion

        protected void MyPager_PageIndexChange(object sender, EventArgs e)
        {
            pageBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pageBind();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "getPType('" + hfPTypeMain.Value + "','" + hfPTypeSmall.Value + "')", true);
        }

        #region 返回修改链接地址
        public string EditUrl(string Id)
        {
            return "sys_Product_Manage.aspx?GLlogin=" + Encrypt.PageSecuityParam(GetUserName()) + "&Ttext=" + Encrypt.PageSecuityParam(Id) + "&Pageindex=" + Encrypt.PageSecuityParam(MyPager.Pageindex.ToString()) + "&Ptypemain="+hfPTypeMain.Value+"&Ptypesmall="+hfPTypeSmall.Value+"&Pname=" + txt_PName.Value.Trim() + "&Precommend="+txt_PRecommend.SelectedValue.Trim()+"&Pshelf="+txt_PShelf.SelectedValue.Trim()+"";
        }
        #endregion
    }
}
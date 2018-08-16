using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace HoneyWell.Admin.paras
{
    public partial class Sys_Type_Menu : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_Tv(Tree_Table(), TreeView1.Nodes, null, "id", "parent_id", "name");
            } 
        }

        private DataTable Tree_Table()
        { 
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("id", typeof(string)));        //id列   类型int
            dt.Columns.Add(new DataColumn("parent_id", typeof(string))); //父id列 类型int
            dt.Columns.Add(new DataColumn("name", typeof(string)));     //名称列  类型string
            //构造根节点
            dr = dt.NewRow();
            var node0 = dr[0] = "0";
            dr[1] = DBNull.Value;
            dr[2] = "根目录";
            dt.Rows.Add(dr);
            //构造一级菜单
            string TableName = "Sys_Type";
            string SqlWhere = " and TLevel=1 order by TOrder asc";
            DataSet ds = new HoneyWell.BLL.Sys_Type().GetTypeTree(TableName, SqlWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    var node1 = dr[0] = ds.Tables[0].Rows[i]["ID"].ToString();
                    dr[1] = node0;//（子节点）属于根节点
                    dr[2] = ds.Tables[0].Rows[i]["TName"].ToString();
                    dt.Rows.Add(dr);

                    //构造二级菜单 
                    string SqlWhere1 = "  and TLevel=2 and ParentId=" + Utils.ToInt(node1) + " order by TOrder asc";
                    DataSet ds1 = new HoneyWell.BLL.Sys_Type().GetTypeTree(TableName, SqlWhere1);
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            dr = dt.NewRow();
                            var node2 = dr[0] = ds1.Tables[0].Rows[j]["ID"].ToString();
                            dr[1] = node1;
                            dr[2] = ds1.Tables[0].Rows[j]["TName"].ToString();
                            dt.Rows.Add(dr);
                             
                            //构造三级菜单 
                            string SqlWhere2 = "  and TLevel=3 and ParentID=" + Utils.ToInt(node2) + " order by TOrder asc";
                            DataSet ds2 = new HoneyWell.BLL.Sys_Type().GetTypeTree(TableName, SqlWhere2);
                            if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                            {
                                for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                                {
                                    dr = dt.NewRow();
                                    var node3 = dr[0] = ds2.Tables[0].Rows[k]["ID"].ToString();
                                    dr[1] = node2;
                                    dr[2] = ds2.Tables[0].Rows[k]["TName"].ToString();
                                    dt.Rows.Add(dr);
                                }
                            }
                        } 
                    }
                }
            }
            return dt;
        }

        #region 绑定TreeView
        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="p_Node">TreeNode（TreeView的一个节点）</param>
        /// <param name="pid_val">父id的值</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        protected void Bind_Tv(DataTable dt, TreeNode p_Node, string pid_val, string id, string pid, string text)
        {
            DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
            dv.RowFilter = filter;//利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (DataRowView row in dv)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                if (p_Node == null)//如果为根节点
                {
                    tn.Value = row[id].ToString();           //节点的Value值，一般为数据库的id值
                    tn.Text = row[text].ToString();          //节点的Text，节点的文本显示
                    TreeView1.Nodes.Add(tn);                 //将该节点加入到tn中
                    Bind_Tv(dt, tn, tn.Value, id, pid, text);//递归（反复调用这个方法，直到把数据取完为止）
                }
                else//如果不是根节点
                {
                    tn.Value = row[id].ToString();           //节点Value值
                    tn.Text = row[text].ToString();          //节点Text值
                    p_Node.ChildNodes.Add(tn);               //该节点加入到上级节点中
                    Bind_Tv(dt, tn, tn.Value, id, pid, text);//递归
                }
            }
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="pid_val">父id的值</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
        {
            DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
            TreeNode tn;                   //建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
            dv.RowFilter = filter;//利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                tn.Value = drv[id].ToString();//节点的Value值，一般为数据库的id值
                tn.Text = drv[text].ToString();//节点的Text，节点的文本显示

                tn.NavigateUrl = "javascript:editshow('" + tn.Text + "','" + tn.Value + "');";

                tnc.Add(tn);//将该节点加入到TreeNodeCollection（节点集合）中
                Bind_Tv(dt, tn.ChildNodes, tn.Value, id, pid, text);//递归（反复调用这个方法，直到把数据取完为止）
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using HoneyWell.DBUtility;

namespace HoneyWell.DAL
{
   public class Sys_Public
    {
        /// <summary>
        /// 数据查询方法
        /// </summary>
        public DataSet SelectData(string showFile, string TableName, string SqlWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tableName", TableName);
            ht.Add("showFile", showFile);
            ht.Add("strWhere", SqlWhere);
            DataSet ds = SqlHelper.GetDataSetDetail("sp_GetList", SysConn.PublicConn, ht);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        public bool BoolData(string Query, string TableName, string SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Query + "  from " + TableName + " ");
            strSql.Append(" where 1=1 " + SqlWhere + "");
            DataTable dt = SelectData(Query, TableName, SqlWhere).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string TableName, int PageSize, int PageIndex)
        {
            Hashtable ht = new Hashtable();
            ht.Add("TableName", TableName);
            ht.Add("PageSize", PageSize);
            ht.Add("PageIndex", PageIndex);
            return SqlHelper.GetDataSetDetail("sp_GetList", SysConn.PublicConn, ht);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string tableName, string showField, string orderField, int pageSize, int pageIndex, int orderType, string strWhere, out int pageCount)
        {
            pageCount = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@tableName", SqlDbType.VarChar,50),
                    new SqlParameter("@showField", SqlDbType.VarChar,500),
                    new SqlParameter("@orderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int),
                    new SqlParameter("@pageIndex", SqlDbType.Int),
                    new SqlParameter("@orderType", SqlDbType.Int),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@PageCount", SqlDbType.Int)};

            parameters[0].Value = tableName;
            parameters[1].Value = showField;
            parameters[2].Value = orderField;
            parameters[3].Value = pageSize;
            parameters[4].Value = pageIndex;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            IList list = null;
            DataSet ds = SqlHelper.GetDataSetDetail("sp_GetPageList", SysConn.PublicConn, parameters, out list);
            if (list != null)
            {
                pageCount = int.Parse(list[0].ToString());
            }
            return ds;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(string TableName, string strWhere)
        {
            Hashtable ht = new Hashtable();
            ht.Add("tableName", TableName);
            ht.Add("strWhere", strWhere);
            int count = SqlHelper.ExecuteSQL("sp_Delete", SysConn.PublicConn, ht);
            return count;
        }
    }
}

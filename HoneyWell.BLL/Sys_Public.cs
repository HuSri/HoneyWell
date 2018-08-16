using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HoneyWell.BLL
{
   public class Sys_Public
    {
        HoneyWell.DAL.Sys_Public dal = new DAL.Sys_Public();
        /// <summary>
        /// 数据查询方法
        /// </summary>
        public DataSet SelectData(string showFile, string TableName, string SqlWhere)
        {
            return dal.SelectData(showFile, TableName, SqlWhere);
        }
        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        public bool BoolData(string Query, string TableName, string SqlWhere)
        {
            return dal.BoolData(Query, TableName, SqlWhere);
        }

        /// <summary>
        /// 根据分页获得数据列表 D:\item\HoneyWell\HoneyWell.BLL\Sys_Public.cs
        /// </summary>
        public DataSet GetList(string TableName, int PageSize, int PageIndex)
        {
            return dal.GetList(TableName, PageSize, PageIndex);
        }

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        public DataSet GetList(string tableName, string showField, string orderField, int pageSize, int pageIndex, int orderType, string strWhere, out int pageCount)
        {
            return dal.GetList(tableName, showField, orderField, pageSize, pageIndex, orderType, strWhere, out pageCount);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(string TableName, string strWhere)
        {
            return dal.Delete(TableName, strWhere);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using HoneyWell.COMM;

namespace HoneyWell.BLL {
	 	/// <summary>
 	///Sys_Area
 	/// </summary>
		public class Sys_Area
	{
		 DAL.Sys_Area dal=new DAL.Sys_Area();
		
		#region 基本方法================================
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Sys_Area model)
		{
						return dal.Add(model);
					}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Sys_Area model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Area GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        ///// <summary>
        ///// 菜单分组
        ///// </summary>
        //public DataSet GroupTypeTree(string TableName, string SqlWhere)
        //{
        //    return dal.GroupTypeTree(TableName, SqlWhere);
        //}

        /// <summary>
        /// 自定义菜单
        /// </summary>
        public DataSet GetTypeTree(string TableName, string SqlWhere)
        {
            return dal.GetTypeTree(TableName, SqlWhere);
        }
        #endregion
    }
}
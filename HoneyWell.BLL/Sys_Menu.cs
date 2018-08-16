using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using HoneyWell.COMM;

namespace HoneyWell.BLL {
	 	/// <summary>
 	///Sys_Menu
 	/// </summary>
		public class Sys_Menu
	{
		 DAL.Sys_Menu dal=new DAL.Sys_Menu();
		
		#region 基本方法================================
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Sys_Menu model)
		{
						return dal.Add(model);
					}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Sys_Menu model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Menu GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 菜单分组
        /// </summary>
        public DataSet GroupMenuTree(string TableName, string SqlWhere)
        {
            return dal.GroupMenuTree(TableName, SqlWhere);
        }

        /// <summary>
        /// 自定义菜单
        /// </summary>
        public DataSet GetMenuTree(string TableName, string SqlWhere)
        {
            return dal.GetMenuTree(TableName, SqlWhere);
        }
        #endregion
    }
}
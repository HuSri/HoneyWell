using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using HoneyWell.COMM;

namespace HoneyWell.BLL {
	 	/// <summary>
 	///Sys_Orders
 	/// </summary>
		public class Sys_Orders
	{
		 DAL.Sys_Orders dal=new DAL.Sys_Orders();
		
		#region 基本方法================================
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Sys_Orders model)
		{
						return dal.Add(model);
					}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Sys_Orders model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Orders GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		#endregion
	}
}
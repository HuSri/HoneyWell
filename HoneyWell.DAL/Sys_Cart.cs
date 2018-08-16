using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using HoneyWell.DBUtility;
using HoneyWell.COMM;

namespace HoneyWell.DAL
{
		/// <summary>
    /// 数据访问类:Sys_Cart
    /// </summary>
		public  class Sys_Cart
	{ 

   		#region 基本方法================================
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Cart");
			strSql.Append(" where ");
			                                       strSql.Append(" ID = @ID  ");
                            						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Sys_Cart model)
		{
           	StringBuilder strSql = new StringBuilder();
            StringBuilder str1 = new StringBuilder();//数据字段
            StringBuilder str2 = new StringBuilder();//数据参数
			//利用反射获得属性的所有公共属性
            PropertyInfo[] pros = model.GetType().GetProperties();
            List<SqlParameter> paras = new List<SqlParameter>();
			strSql.Append("insert into  Sys_Cart(");
            foreach (PropertyInfo pi in pros)
            {
			    //如果不是主键则追加sql字符串
                if (!pi.Name.Equals("ID"))
                {
				    //判断属性值是否为空
                    if (pi.GetValue(model, null) != null)
                    {
                        str1.Append(pi.Name + ",");//拼接字段
                        str2.Append("@" + pi.Name + ",");//声明参数
                        paras.Add(new SqlParameter("@" + pi.Name, pi.GetValue(model, null)));//对参数赋值
                    }
                }
            }
            strSql.Append(str1.ToString().Trim(','));
            strSql.Append(") values (");
            strSql.Append(str2.ToString().Trim(','));
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY;");
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), paras.ToArray());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                                    
            	return Convert.ToInt32(obj);
                                                 
            }	
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Sys_Cart model)
		{
			StringBuilder strSql = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
			//利用反射获得属性的所有公共属性
            PropertyInfo[] pros = model.GetType().GetProperties();
            List<SqlParameter> paras = new List<SqlParameter>();
			strSql.Append("update Sys_Cart set ");
            foreach (PropertyInfo pi in pros)
            {
			    //如果不是主键则追加sql字符串
                if (!pi.Name.Equals("ID"))
                {
				    //判断属性值是否为空
                    if (pi.GetValue(model, null) != null)
                    {
                        str1.Append(pi.Name + "=@" + pi.Name + ",");//声明参数
                        paras.Add(new SqlParameter("@" + pi.Name, pi.GetValue(model, null)));//对参数赋值
                    }
                }
            }
            strSql.Append(str1.ToString().Trim(','));
            strSql.Append(" where ID=@ID ");
            paras.Add(new SqlParameter("@ID", model.ID));
            return DbHelperSQL.ExecuteSql(strSql.ToString(), paras.ToArray()) > 0;
		}


		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Cart GetModel(int ID)
		{
            StringBuilder strSql = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            Model.Sys_Cart model = new Model.Sys_Cart();
			//利用反射获得属性的所有公共属性
            PropertyInfo[] pros = model.GetType().GetProperties();
            foreach (PropertyInfo p in pros)
            {
                str1.Append(p.Name + ",");//拼接字段
            }
            strSql.Append("select top 1 " + str1.ToString().Trim(','));
            strSql.Append(" from Sys_Cart");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DataTable dt = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];

            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
		}
		#endregion
		
		#region 扩展方法================================
		/// <summary>
        /// 将对象转换实体
        /// </summary>
        public Model.Sys_Cart DataRowToModel(DataRow row)
        {
            Model.Sys_Cart model = new Model.Sys_Cart();
            if (row != null)
            {
                //利用反射获得属性的所有公共属性
                Type modelType = model.GetType();
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
				    //查找实体是否存在列表相同的公共属性
                    PropertyInfo proInfo = modelType.GetProperty(row.Table.Columns[i].ColumnName);
                    if (proInfo != null && row[i] != DBNull.Value)
                    {
                        proInfo.SetValue(model, row[i], null);//用索引值设置属性值
                    }
                }
            }
            return model;
        }
		#endregion 
	 
	}
}
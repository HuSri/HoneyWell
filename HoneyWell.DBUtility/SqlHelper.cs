//*******************************************************************//
//
//** 文件名:   SqlHelper.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成数据库的一些公共类的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace HoneyWell.DBUtility
{
    public class SqlHelper
    {
        #region 执行ExecuteNonQuery
        /// <summary>
        /// 执行ExecuteNonQuery
        /// </summary>
        /// <param name="cmdType">Sql语句类型</param>
        /// <param name="cmdText">Sql语句或存储过程名</param>
        /// <param name="cmdParms">Parm数组</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, string sysConn, params SqlParameter[] cmdParms)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(sysConn))
            {
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                if (cmdParms != null)
                {
                    foreach (SqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }
                try
                {
                    conn.Open();
                    val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch
                {
                    val = -1;
                }
                finally
                {
                    conn.Close();
                }
            }
            return val;
        }
        #endregion

        #region 获得SqlParameter实例
        /// <summary>
        /// 获得SqlParameter实例
        /// </summary>
        /// <param name="ParamName">字段名</param>
        /// <param name="Value">赋值</param>
        /// <returns>返回一个SqlParameter实例</returns>
        public static SqlParameter MakeParam(string paramName, object value)
        {
            return new SqlParameter(paramName, value);
        }

        public static SqlParameter MakeParam(string paramName, object value, ParameterDirection direction)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = value;
            param.Direction = direction;
            return param;
        }
        #endregion

        #region 获得DateSet实例
        /// <summary>
        /// 获得DateSet实例
        /// </summary>      
        /// <param name="cmdType">Sql语句类型</param>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="cmdParms">Parm数组</param>   
        /// <returns>返回DateSet实例</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, string sysConn, params SqlParameter[] cmdParms)
        {
            SqlConnection conn = new SqlConnection(sysConn);
            System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
            da.SelectCommand.CommandType = cmdType;
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                if (cmdParms != null)
                {
                    foreach (SqlParameter parm in cmdParms)
                        da.SelectCommand.Parameters.Add(parm);
                }
                da.Fill(ds, "NewTable");
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                da.Dispose();
                conn.Close();
            }
            return ds;
        }
        #endregion

        #region 获得DateSet数据集
        /// <summary>
        /// 获得数据集
        /// </summary>      
        /// <param name="ProcedureName">存储过程名</param>
        /// <returns>返回IList实例</returns>
        public static DataSet GetDataSetDetail(string ProcedureName, string sysConn)
        {
            SqlConnection conn = new SqlConnection(sysConn);
            System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(ProcedureName, conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "NewTable");
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                da.Dispose();
                conn.Close();
            }
            return ds;
        }

        /// <summary>
        /// 获得数据集
        /// </summary>      
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="ht">表示层传递过来的哈希表对象</param>  
        /// <returns>返回IList实例</returns>
        public static DataSet GetDataSetDetail(string ProcedureName, string sysConn, Hashtable ht)
        {
            // ＝＝＝获得数据库源，返回DataSet为数据源＝＝＝
            DataSet ds = new DataSet();

            // 处理传递过来的参数
            SqlParameter[] Parms = new SqlParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            int i = 0;
            while (et.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp = MakeParam("@" + et.Key.ToString(), et.Value);
                Parms[i] = sp;
                i = i + 1;
            }
            ds = ExecuteDataSet(CommandType.StoredProcedure, ProcedureName, sysConn, Parms);
            return ds;
        }

        /// <summary>
        /// 获得带输入参数数据集
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="sysConn">连接字符串</param>
        /// <param name="parms">SqlParameter数组</param>
        /// <param name="list">输入参数值</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSetDetail(string procedureName, string sysConn, SqlParameter[] parms, out IList list)
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet(CommandType.StoredProcedure, procedureName, sysConn, parms);
            list = ExecuteOutPut(parms);
            return ds;
        }
        #endregion

        #region 获得SqlDataReader实例
        /// <summary>
        /// 获得SqlDataReader实例
        /// </summary>      
        /// <param name="cmdType">Sql语句类型</param>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="cmdParms">Parm数组</param>  
        /// <returns>返回SqlDataReader实例</returns>
        public static SqlDataReader ExecuteDataReader(CommandType cmdType, string cmdText, string sysConn, params SqlParameter[] cmdParms)
        {
            SqlConnection conn = new SqlConnection(sysConn);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            SqlDataReader sdr = null;
            try
            {
                conn.Open();
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                cmd.Dispose();
                sdr.Close();
                conn.Close();
            }
            return sdr;
        }
        #endregion

        #region 获得OutPut实例
        /// <summary>
        /// 获得OutPut实例
        /// </summary>
        /// <param name="cmdParms">SqlParameter数组</param>
        /// <returns></returns>
        public static IList ExecuteOutPut(params SqlParameter[] cmdParms)
        {
            IList list = new ArrayList();
            try
            {
                foreach (SqlParameter param in cmdParms)
                {
                    if (param.Direction == ParameterDirection.Output)
                    {
                        list.Add(param.Value);
                    }
                }
            }
            catch
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 获得OutPut实例
        /// </summary>      
        /// <param name="cmdType">Sql语句类型</param>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="inputLen">输入参数的长度</param>
        /// <param name="sysConn">链接字符串</param>
        /// <param name="cmdParms">Param数组</param>   
        /// <returns></returns>
        public static IList ExecuteOutPut(CommandType cmdType, string cmdText, int inputLen, string sysConn, params SqlParameter[] cmdParms)
        {
            // ＝＝＝获得数据库源，返回IList为数据源＝＝＝
            IList Ilst = new ArrayList();
            int count = 0;//控件循环次数
            SqlConnection conn = new SqlConnection(sysConn);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;
            try
            {
                conn.Open();
                int len = cmdParms.Length;
                if (cmdParms != null)
                {
                    foreach (SqlParameter parm in cmdParms)
                    {
                        if (count < inputLen)
                        {
                            cmd.Parameters.Add(parm);
                        }
                        else
                        {
                            break;
                        }
                        count++;
                    }
                    switch (len - inputLen)
                    {
                        case 1:
                            SqlParameter rst11 = cmd.Parameters.AddWithValue(cmdParms[inputLen].ParameterName, cmdParms[inputLen].Value);
                            rst11.Direction = ParameterDirection.Output;
                            rst11.Size = 50;

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            Ilst.Add(rst11.Value);
                            break;
                        case 2:
                            SqlParameter rst21 = cmd.Parameters.AddWithValue(cmdParms[len - 2].ParameterName, cmdParms[len - 2].Value);
                            rst21.Direction = ParameterDirection.Output;
                            rst21.Size = 50;

                            SqlParameter rst22 = cmd.Parameters.AddWithValue(cmdParms[len - 1].ParameterName, cmdParms[len - 1].Value);
                            rst22.Direction = ParameterDirection.Output;
                            rst22.Size = 50;

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            Ilst.Add(rst21.Value);
                            Ilst.Add(rst22.Value);
                            break;
                        case 3:
                            SqlParameter rst31 = cmd.Parameters.AddWithValue(cmdParms[len - 3].ParameterName, cmdParms[len - 3].Value);
                            rst31.Direction = ParameterDirection.Output;
                            rst31.Size = 50;

                            SqlParameter rst32 = cmd.Parameters.AddWithValue(cmdParms[len - 2].ParameterName, cmdParms[len - 2].Value);
                            rst32.Direction = ParameterDirection.Output;
                            rst32.Size = 50;

                            SqlParameter rst33 = cmd.Parameters.AddWithValue(cmdParms[len - 1].ParameterName, cmdParms[len - 1].Value);
                            rst33.Direction = ParameterDirection.Output;
                            rst33.Size = 50;

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            Ilst.Add(rst31.Value);
                            Ilst.Add(rst32.Value);
                            Ilst.Add(rst33.Value);
                            break;
                        default:
                            break;

                    }
                }

            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return Ilst;
        }
        #endregion

        #region 获得输出单个数据库源
        /// <summary>
        /// 获得输出单个数据库源
        /// </summary>      
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="alParam">字段,字段参数名</param>
        /// <param name="alValue">字段,字段参数值</param>
        /// <returns>返回IList实例</returns>
        public static IList GetParamOutPut(string ProcedureName, string sysConn, Hashtable htInPut, Hashtable htOutPut)
        {
            // ＝＝＝获得数据库源，返回IList为数据源＝＝＝
            IList Ilst = new ArrayList();

            // 处理传递过来的参数           
            SqlParameter[] Parms = new SqlParameter[htInPut.Count + htOutPut.Count];
            IDictionaryEnumerator etInPut = htInPut.GetEnumerator();
            IDictionaryEnumerator etOutPut = htOutPut.GetEnumerator();
            int i = 0;
            //作哈希表循环
            while (etInPut.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp1 = MakeParam("@" + etInPut.Key.ToString(), etInPut.Value);
                Parms[i] = sp1;
                i++;
            }
            while (etOutPut.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp2 = MakeParam("@" + etOutPut.Key.ToString(), etOutPut.Value);
                Parms[i] = sp2;
                i++;
            }
            Ilst = ExecuteOutPut(CommandType.StoredProcedure, ProcedureName, htInPut.Count, sysConn, Parms);

            return Ilst;
        }
        #endregion

        #region 获得单个子数据库源
        /// <summary>
        /// 获得单个子数据库源
        /// </summary>      
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="ht">表示层传递过来的哈希表对象</param>  
        /// <returns>返回IList实例</returns>
        public static IList GetParamDetail(string ProcedureName, string sysConn, Hashtable ht)
        {
            // ＝＝＝获得数据库源，返回IList为数据源＝＝＝
            IList Ilst = new ArrayList();

            // 处理传递过来的参数
            SqlParameter[] Parms = new SqlParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            int i = 0;
            while (et.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp = MakeParam("@" + et.Key.ToString(), et.Value);
                Parms[i] = sp;
                i = i + 1;
            }
            using (DataSet ds = ExecuteDataSet(CommandType.StoredProcedure, ProcedureName, sysConn, Parms))
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Ilst.Add(ds.Tables[0].Rows[0][j]);
                }
            }
            return Ilst;
        }
        #endregion

        #region 数获得全部数据库源
        /// <summary>
        /// 不带参数获得全部数据库源
        /// </summary>      
        /// <param name="ProcedureName">存储过程名</param>        
        /// <returns>返回SqlDataReader实例</returns>
        public static SqlDataReader GetDataReaderDetail(string ProcedureName, string sysConn)
        {
            // ＝＝＝获得数据库源，返回SqlDataReader为数据源＝＝＝
            SqlDataReader sdr = null;

            // 定义空参数
            SqlParameter[] Parms = null;

            sdr = ExecuteDataReader(CommandType.StoredProcedure, ProcedureName, sysConn, Parms);
            return sdr;
        }

        /// <summary>
        /// 带参数获得全部数据库源
        /// </summary>     
        /// <param name="ProcedureName">存储过程名</param>
        /// <param name="ht">表示层传递过来的哈希表对象</param>   
        /// <returns>返回SqlDataReader实例</returns>
        public static SqlDataReader GetDataReaderDetail(string ProcedureName, string sysConn, Hashtable ht)
        {
            // ＝＝＝获得数据库源，返回SqlDataReader为数据源＝＝＝
            SqlDataReader sdr = null;

            // 处理传递过来的参数
            SqlParameter[] Parms = new SqlParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            int i = 0;
            while (et.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp = MakeParam("@" + et.Key.ToString(), et.Value);
                Parms[i] = sp;
                i = i + 1;
            }
            sdr = ExecuteDataReader(CommandType.StoredProcedure, ProcedureName, sysConn, Parms);
            return sdr;
        }
        #endregion

        #region 插入、修改、删除记录操作
        /// <summary>
        /// 插入、修改、删除记录操作
        /// </summary>       
        /// <param name="cmdType">sql语句类型</param>
        /// <param name="str_Sql">sql语句</param>
        /// <param name="ht">表示层传递过来的哈希表对象</param>
        public static int ExecuteSQL(string ProcedureName, string sysConn, Hashtable ht)
        {
            int rst = -1;
            SqlParameter[] Parms = new SqlParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            int i = 0;
            //作哈希表循环
            while (et.MoveNext())
            {
                System.Data.SqlClient.SqlParameter sp = MakeParam("@" + et.Key.ToString(), et.Value);
                Parms[i] = sp;
                i++;
            }
            try
            {
                rst = ExecuteNonQuery(CommandType.StoredProcedure, ProcedureName, sysConn, Parms);
            }
            catch (Exception)
            {
                
                throw;
            }
            return rst;
        }
        #endregion

        #region 执行一条计算查询结果语句，返回查询结果（object）
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, string sysConn)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetSingle(string SQLString, int Times, string sysConn)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetSingle(CommandType cmdType, string SQLString, string sysConn, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = SQLString;
                        cmd.CommandType = cmdType;
                        if (cmdParms != null)
                        {
                            foreach (SqlParameter parm in cmdParms)
                                cmd.Parameters.Add(parm);
                        }

                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion

        #region 公用方法
        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName, string sysConn)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql, sysConn);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <param name="sysConn"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName, string sysConn)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql, sysConn);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 判断是否存在记录
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sysConn"></param>
        /// <returns></returns>
        public static bool Exists(string strSql, string sysConn)
        {
            object obj = GetSingle(strSql, sysConn);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName, string sysConn)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            object obj = GetSingle(strsql, sysConn);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(CommandType cmdType, string strSql, string sysConn, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(cmdType, strSql, sysConn, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null)) { p.Value = DBNull.Value; }
                command.Parameters.Add(p);
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public static DataSet Query(string SQLString, string sysConn)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                connection.Close();
                connection.Dispose();
                return ds;
            }
        }


        public static DataSet Query(string SQLString, string sysConn, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    connection.Close();
                    return ds;
                }
            }
        }


        public static DataTable QueryTable(string SQLString, string sysConn)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                connection.Close();
                connection.Dispose();
                return ds.Tables[0];
            }
        }


        public static DataTable QueryTable(string SQLString, string sysConn, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    connection.Close();
                    return ds.Tables[0];
                }
            }
        }


        public static int ExecuteSql(string SQLString, string sysConn, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sysConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        connection.Open();
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        connection.Close();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }



        #endregion
    }
}

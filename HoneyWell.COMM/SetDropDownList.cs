//*******************************************************************//
//
//** 文件名:   SetDropDownList.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成下拉列表的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace HoneyWell.COMM
{
    public class SetDropDownList
    {
        #region 填充DropDownList下拉列表值
        /// 填充DropDownList下拉列表值
        /// </summary>        
        /// <param name="ddl">下拉控件</param>
        /// <param name="KeyValue">绑定下拉控件的Value值</param>
        /// <param name="KeyText">绑定下拉控件的Text值</param>  
        /// <param name="index">插入的索引位置</param> 
        public static void FillDropDownList(DropDownList ddl, string KeyValue, string KeyText,int index)
        {
            ddl.Items.Clear();
            ListItem lt = new ListItem();
            lt.Value = KeyValue;
            lt.Text = KeyText;
            ddl.Items.Insert(index, lt);           
        }
        #endregion   

        #region 填充DropDownList下拉列表值
        /// <summary>
        /// 填充DropDownList下拉列表值
        /// </summary>
        /// <param name="ds">读取数据集中的值</param>
        /// <param name="ddl">下拉控件</param>
        /// <param name="KeyValue1">绑定的第1个索引关键值</param>
        /// <param name="KeyValue2">绑定的第2个索引关键值</param>
        public static void FillDropDownList(DataSet ds, DropDownList ddl, int KeyValue1, int KeyValue2)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem lt = new ListItem();
                    lt.Value = ds.Tables[0].Rows[i][KeyValue1].ToString();
                    lt.Text = ds.Tables[0].Rows[i][KeyValue2].ToString();
                    ddl.Items.Add(lt);
                }
            }  
        }
        /// <summary>
        /// 填充DropDownList下拉列表值
        /// </summary>
        /// <param name="ds">读取数据集中的值</param>
        /// <param name="ddl">下拉控件</param>
        /// <param name="KeyValue1">绑定的第1个索引关键值</param>
        /// <param name="KeyValue2">绑定的第2个索引关键值</param>
        /// <param name="Defualt">设置下拉列表的第1个默认值</param>
        public static void FillDropDownList(DataSet ds, DropDownList ddl, int KeyValue1, int KeyValue2, string Defualt)
        {
            ddl.Items.Clear();
            ListItem lt = new ListItem();
            lt.Value = "0";
            lt.Text = Defualt;
            ddl.Items.Add(lt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem lt1 = new ListItem();
                    lt1.Value = ds.Tables[0].Rows[i][KeyValue1].ToString();
                    lt1.Text = ds.Tables[0].Rows[i][KeyValue2].ToString();
                    ddl.Items.Add(lt1);
                }
            }
        }
        /// <summary>
        /// 填充DropDownList下拉列表值
        /// </summary>
        /// <param name="dv">读取视图中的值</param>
        /// <param name="ddl">下拉控件</param>
        /// <param name="KeyValue1">绑定的第1个索引关键值</param>
        /// <param name="KeyValue2">绑定的第2个索引关键值</param>
        public static void FillDropDownList(DataView dv, DropDownList ddl, int KeyValue1, int KeyValue2)
        {
            if (dv.Table.Rows.Count > 0)
            {
                ddl.Items.Clear();
                for (int i = 0; i < dv.Table.Rows.Count; i++)
                {
                    ListItem lt = new ListItem();
                    lt.Value = dv.Table.Rows[i][KeyValue1].ToString();
                    lt.Text = dv.Table.Rows[i][KeyValue2].ToString();
                    ddl.Items.Add(lt);
                }
            }
        }
        /// <summary>
        /// 填充DropDownList下拉列表值
        /// </summary>
        /// <param name="dv">读取视图中s的值</param>
        /// <param name="ddl">下拉控件</param>
        /// <param name="KeyValue1">绑定的第1个索引关键值</param>
        /// <param name="KeyValue2">绑定的第2个索引关键值</param>
        /// <param name="Defualt">设置下拉列表的第1个默认值</param>
        public static void FillDropDownList(DataView dv, DropDownList ddl, int KeyValue1, int KeyValue2, string Defualt)
        {
            ddl.Items.Clear();
            ListItem lt = new ListItem();
            lt.Value = "0";
            lt.Text = Defualt;
            ddl.Items.Add(lt);
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    ListItem lt1 = new ListItem();
                    lt1.Value = dv.Table.Rows[i][KeyValue1].ToString();
                    lt1.Text = dv.Table.Rows[i][KeyValue2].ToString();
                    ddl.Items.Add(lt1);
                }
            }
        }
        #endregion   

        #region 填充DropDownList下拉列表数字
        /// <summary>
        /// 填充DropDownList下拉列表数字
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        /// <param name="start">第1个数字</param>
        /// <param name="end">最后1个数字</param>
        /// <param name="sel">是否设置默认值0</param>
        /// <returns></returns>
        public int FillNumber(DropDownList ddl,int start, int end, bool sel)
        {
            if (sel == true)
            {
                for (int i = start; i < end; i++)
                {
                    if (i < 10)
                        ddl.Items.Add("0" + i.ToString());
                    else
                        ddl.Items.Add(i.ToString());
                }
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    ddl.Items.Add(i.ToString());
                }
            }
            return end;
        }
        #endregion       
    }
}

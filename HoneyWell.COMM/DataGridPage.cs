//*******************************************************************//
//
//** 文件名:   DataGridPage.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成DataGrid中部分功能的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;

namespace HoneyWell.COMM
{
    public class DataGridPage
    {

        #region 设置DataGrid中的复选框
        /// <summary>
        /// 设置DataGrid中的复选框
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>
        /// <param name="cbAllSelect">执行操作的全选框名</param>
        /// <param name="cbSngName">执行操作的单选框名</param>
        public void DgChecked(DataGrid dg, CheckBox cbAllSelect, string cbSngName)
        {
            CheckBox cbSelect = new CheckBox();
            if (cbAllSelect.Checked)
            {
                foreach (DataGridItem itm in dg.Items)
                {
                    cbSelect = (CheckBox)itm.FindControl(cbSngName);
                    cbSelect.Checked = true;
                }
            }
            else
            {
                foreach (DataGridItem itm in dg.Items)
                {
                    cbSelect = (CheckBox)itm.FindControl(cbSngName);
                    cbSelect.Checked = false;
                }
            }
        }
        #endregion

        #region 设置DataGrid中的单选框的值
        /// <summary>
        /// 设置DataGrid中的单选框的值
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>       
        /// <param name="cbSngName">执行操作的单选框名</param>
        public ArrayList DgCheckedValue(DataGrid dg, string cbSngName)
        {
            ArrayList al = new ArrayList();
            CheckBox cbSelect = new CheckBox();

            foreach (DataGridItem itm in dg.Items)
            {
                cbSelect = (CheckBox)itm.FindControl(cbSngName);
                if (cbSelect.Checked == true)
                    al.Add(dg.DataKeys[itm.ItemIndex].ToString());
            }

            return al;
        }
        #endregion

        #region DataGrid自动生成编号
        /// <summary>
        /// DataGrid自动生成编号
        /// 放在DataGrid控件ItemDataBound事件中调用
        /// </summary>
        /// <param name="columns">表示绑定列的索引</param>
        public void DgAddID(object sender, DataGridItemEventArgs e, int columns)
        {
            if (e.Item.ItemIndex != -1)
            {
                int num = e.Item.ItemIndex + 1;
                e.Item.Cells[columns].Text = num.ToString();
            }
        }
        #endregion

        #region DataGrid中防止删除最后一条记录出错
        /// <summary>
        /// DataGrid中防止删除最后一条记录出错
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>
        /// <param name="size">删除当页的数目</param>
        /// <returns></returns>
        public int DgPreventError(DataGrid dg, int size)
        {
            int lastEditPage = dg.CurrentPageIndex;
            if ((dg.PageCount - dg.CurrentPageIndex) == 1 && dg.Items.Count == size)
            {
                if (dg.PageCount > 1)
                {
                    lastEditPage = lastEditPage - 1;
                }
                else
                {
                    lastEditPage = 0;
                }
            }
            dg.CurrentPageIndex = lastEditPage;
            return lastEditPage;
        }
        #endregion

        #region DataGrid换行、随鼠标改变颜色
        /// <summary>
        /// DataGrid换行、随鼠标改颜色
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>
        /// <param name="e">ItemDataBound的中事件</param>
        /// <returns></returns>
        public void DgNewLine(DataGrid dg, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header)
            {
                e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\"" + "#EFF3F7" + "\"");
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\"" + e.Item.Style["BACKGROUND-COLOR"] + "\"");
                dg.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
        }
        #endregion

        #region DataGrid换行
        /// <summary>
        /// DataGrid换行
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>
        /// <param name="e">ItemDataBound的中事件</param>
        /// <returns></returns>
        public void DgNewLine1(DataGrid dg, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header)
            {
                dg.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
        }
        #endregion

        #region DataGrid 改变行颜色
        /// <summary>
        /// DataGrid 改变行颜色
        /// </summary>
        /// <param name="dg">执行操作的DataGrid名</param>
        /// <param name="e">ItemDataBound的中事件</param>
        /// <param name="cssclass">需要调用的样式</param>
        /// <returns></returns>
        public void DgChangeLine(DataGrid dg, DataGridItemEventArgs e, string cssclass)
        {
            if (e.Item.ItemIndex != -1)
            {
                int row = e.Item.ItemIndex + 1;
                if (row % 2 == 1)
                {
                    e.Item.CssClass = cssclass;
                }
            }
            dg.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
        }
        #endregion
    }
}

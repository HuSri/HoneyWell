//*******************************************************************//
//
//** 文件名:   RagdioButtonList.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成RagdioButtonList控件数据填充的设置
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

namespace HoneyWell.COMM
{
    public class RadioButtonListPic
    {
        #region 实例化RadioButtonList控件,用于装载用户头像
        /// <summary>
        /// 装载用户头像
        /// </summary>
        /// <param name="rblface">RadioButtonList控件</param>
        /// <param name="path">图片路径</param>
        /// <param name="width">装载图片的宽度</param>
        /// <param name="height">装载图片的高度</param>
        /// <param name="num">装载数目</param>
        /// <returns></returns>
        public int FillRadioButtonListPic(RadioButtonList rblface, string path, int width, int height, int num)
        {
            int result = -1;
            for (int i = 0; i < num; i++)
            {
                rblface.Items.Add(i.ToString());
                rblface.Items[i].Text = "<img  src=" + path + i.ToString() + ".gif" + " width=" + width + " height=" + height + " />";
                rblface.Items[i].Value = path + i.ToString() + ".gif";
            }
            rblface.Items[0].Selected = true;
            return result;
        }
        #endregion

        #region 实例化RadioButtonList控件,用于装载控件名
        /// <summary>
        /// 装载用户名称
        /// </summary>
        /// <param name="rblface">RadioButtonList控件</param>
        /// <param name="Text">装载控件名</param>
        /// <param name="Value">装载控件值</param>
        /// <param name="num">装载数目</param>
        /// <returns></returns>
        public int FillRadioButtonListName(RadioButtonList rblName, string Text, string Value, int num)
        {
            int result = -1;
            for (int i = 0; i < num; i++)
            {
                rblName.Items.Add(i.ToString());
                rblName.Items[i].Text = Text + (i + 1).ToString();
                rblName.Items[i].Value = Value + (i + 1).ToString();
            }
            rblName.Items[0].Selected = true;
            return result;
        }
        #endregion
    }
}

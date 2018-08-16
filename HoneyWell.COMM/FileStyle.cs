//*******************************************************************//
//
//** 文件名:   FileStyle.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成程序中一些数据显示的样式设置
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
using System.Drawing;

namespace HoneyWell.COMM
{
    public class FileStyle
    {
        #region 设置字段显示长度
        /// <summary>
        /// 设置字段显示长度,用"..."替换
        /// </summary>
        /// <param name="str">要设置的字段</param>
        /// <param name="len">要设置的长度</param>
        /// <returns></returns>
        public string CutTitle(string str, int len)
        {
            int intLen = str.Length;
            int start = 0;
            int end = intLen;
            int single = 0;
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Convert.ToInt32(chars[i]) > 255)
                {
                    start += 2;
                }
                else
                {
                    start += 1;
                    single++;
                }
                if (start >= len)
                {

                    if (end % 2 == 0)
                    {
                        if (single % 2 == 0)
                        {
                            end = i + 1;
                        }
                        else
                        {
                            end = i;
                        }
                    }
                    else
                    {
                        end = i + 1;
                    }
                    break;
                }
            }
            string temp = str.Substring(0, end);
            if (str.Length > end)
            {
                return temp + "...";
            }
            else
            {
                return temp;
            }
        }
        #endregion

        #region 设置字段显示长度
        /// <summary>
        /// 设置字段显示长度,用" "替换
        /// </summary>
        /// <param name="str">要设置的字段</param>
        /// <param name="len">要设置的长度</param>
        /// <returns></returns>
        public string CutTitle1(string str, int len)
        {
            int intLen = str.Length;
            int start = 0;
            int end = intLen;
            int single = 0;
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Convert.ToInt32(chars[i]) > 255)
                {
                    start += 2;
                }
                else
                {
                    start += 1;
                    single++;
                }
                if (start >= len)
                {

                    if (end % 2 == 0)
                    {
                        if (single % 2 == 0)
                        {
                            end = i + 1;
                        }
                        else
                        {
                            end = i;
                        }
                    }
                    else
                    {
                        end = i + 1;
                    }
                    break;
                }
            }
            string temp = str.Substring(0, end);
            if (str.Length > end)
            {
                return temp + "";
            }
            else
            {
                return temp;
            }
        }
        #endregion

        #region 设置货币显示格式,返回string类型
        /// <summary>
        /// 设置货币显示格式
        /// </summary>
        /// <param name="price">表示要显示的货币字符串</param>
        /// <returns>String</returns>
        public string MoneyFormat(string price)
        {
            string str = price;
            try
            {
                string dubPrice = str.Substring(str.LastIndexOf(".") + 0, 3);
                string sngPrice = str.Substring(str.LastIndexOf(".") + 2, 1);
                if (dubPrice == ".00")
                    str = Double.Parse(price).ToString() + dubPrice;
                else if (sngPrice == "0")
                    str = Double.Parse(price).ToString() + sngPrice;
                else
                    str = Double.Parse(price).ToString();
            }
            catch
            {

            }
            return str;
        }
        #endregion

        #region 设置TextBox输入输出格式 返回string类型
        /// <summary>
        /// 设置TextBox输入输出格式 返回string类型
        /// </summary>
        /// <param name="sel">sel=0表示输入,sel=1表示输出</param>
        /// <param name="str">表示要输入输出的TextBox控件值</param>
        /// <returns></returns>
        public string TxtFormat(int sel, string str)
        {
            string txt = str;
            switch (sel)
            {
                case 0:
                    txt = txt.Replace("\n", "<br/>");
                    txt = txt.Replace("\t", "  ");
                    txt = txt.Replace(" ", "&nbsp;");
                    break;
                case 1:
                    txt = txt.Replace("<br/>", "\n");
                    txt = txt.Replace("  ", "\t");
                    txt = txt.Replace("&nbsp;", " ");
                    break;
                default: break;
            }
            return txt;
        }
        #endregion

        #region 验证上传图片的格式
        /// <summary>
        /// 验证上传图片的格式
        /// </summary>
        /// <param name="fup">上传控件</param>       
        /// <returns></returns>        
        public int CheckPicFormat(FileUpload fup)
        {
            int result = -1;
            if (fup.HasFile)
            {
                Boolean fileOK = false;
                String fileExtension = System.IO.Path.GetExtension(fup.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                if (fileOK == true)
                {
                    result = 2; //图片格式正确
                }
                else
                {
                    result = 3; //图片格式错识
                }
            }
            else
            {
                result = 1; //上传空图片
            }
            return result;
        }
        #endregion

        
    }
}

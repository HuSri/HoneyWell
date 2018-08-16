//*******************************************************************//
//
//** 文件名:   PageValidate.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成字符验证的函数设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HoneyWell.COMM
{
    /// <summary>
    /// ParamVerify 的摘要说明。
    /// </summary>
    public class PageValidate
    {
        #region 检验字符串
        /// <summary>
        /// 检验字符串是否有非法字符
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyString(string strInput)
        {
            //参数检查
            if (strInput == null || strInput.Trim() == "") return true;

            //检查是否有非法字符
            if (Regex.IsMatch(strInput, "([<>'\"])|(delete from)|(drop table)"))
                return false;
            else
                return true;
        }
        #endregion

        #region 检验日期字符串
        /// <summary>
        /// 检验日期字符串是否合法
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyDate(string strInput)
        {
            if (strInput == null || strInput.Trim() == "") return false;

            try
            {
                Convert.ToDateTime(strInput);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 检验时间字符串
        /// <summary>
        /// 检验时间字符串，验证格式（YYYY-MM-DD hh:mm:ss）
        /// </summary>
        /// <param name="strInput">要验证的字符串</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyDateTime(string strInput)
        {
            //参数检查
            if (strInput == null || strInput.Trim() == "") return false;

            if (Regex.IsMatch(strInput, @"^(\d{4})(-|/)?((0[1-9])|(1[0-2]))(-|/)?(((0[1-9])|([1-2][0-9]))|(3[0-1])) ([0-1][0-9])|(2[0-3]):([0-5][0-9]):([0-5][0-9])$"))
                return true;
            else
                return false;
        }
        #endregion

        #region 检验编码字符串
        /// <summary>
        /// 检验是否是正确的编码字符串，格式：字母、数字、“-”、“_”
        /// </summary>
        /// <param name="strInput">输入字符</param>
        /// <param name="minsize">最小长度</param>
        /// <param name="maxsize">最大长度</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyNo(string strInput, int minsize, int maxsize)
        {
            //参数检查
            if (strInput == null) return false;

            String expression = @"^(((\w)|(_)|(-)|(\s)){" + minsize + "," + maxsize + @"})$";
            if (Regex.IsMatch(strInput, expression))
                return true;
            else
                return false;
        }
        #endregion

        #region 检验数字字符串
        /// <summary>
        /// 检验数字字符串
        /// </summary>
        /// <param name="strInput">输入字符</param>
        /// <param name="length">数字长度（不算小数点）</param>
        /// <param name="precision">小数点后的位数</param>
        /// <param name="allowMinus">是否允许为负数</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyDecimal(string strInput, int length, int precision, bool allowMinus)
        {
            String expression;
            //参数检查
            if (strInput == null) return false;

            //判断是否可为负数
            if (allowMinus)
                expression = @"^(-{0,1}[0-9]{0," + (length - precision).ToString() + @"}\.{0,1}|\.[0-9]{1," + precision.ToString() + @"}|-{0,1}[0-9]{1," + (length - precision).ToString() + @"}\.[0-9]{0," + precision.ToString() + @"})$";
            else
                expression = @"^([0-9]{0," + (length - precision).ToString() + @"}\.{0,1}|\.[0-9]{1," + precision.ToString() + @"}|-{0,1}[0-9]{1," + (length - precision).ToString() + @"}\.[0-9]{0," + precision.ToString() + @"})$";

            if (Regex.IsMatch(strInput, expression))
                return true;
            else
                return false;
        }
        #endregion

        #region 检验变长字符串
        /// <summary>
        /// 检验变长字符串
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="minsize">最小长度</param>
        /// <param name="maxsize">最大长度</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyVarchar(string strInput, int minsize, int maxsize)
        {
            //参数检查
            if (strInput == null) return false;

            if (VerifyString(strInput) && strInput.Length >= minsize && strInput.Length <= maxsize)
                return true;
            else
                return false;
        }
        #endregion

        #region 检验整数字符串
        /// <summary>
        /// 检验整数字符串
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="allowMinus">是否允许为负数</param>
        /// <returns>是否通过检验</returns>
        public static bool VerifyInt(string strInput, bool allowMinus)
        {
            int i;
            //参数检查
            if (strInput == null) return false;

            try
            {
                i = Convert.ToInt32(strInput.Trim());
                if (allowMinus == false && i < 0)
                    return false;
                else
                    return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion
    }
}

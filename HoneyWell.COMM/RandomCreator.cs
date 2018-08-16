//*******************************************************************//
//
//** 文件名:   RandomCreator.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成随机数字的生成
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyWell.COMM
{
    public class RandomCreator
    {
        #region 生成指定长度的随机数字
        /// <summary>
        /// 生成指定长度的随机数字
        /// </summary>
        /// <param name="length">要生成随机数的长度</param>
        /// <param name="isMinus">是否生成负数</param>
        /// <returns>生成的随机数字</returns>
        public static string CreateNumberRandom(int length, bool isMinus)
        {
            string Result = "";
            if (length < 1) length = 9;

            System.Random Random = new Random();

            for (int i = 0; i < length; i++)
            {
                Result += Random.Next(10);
            }

            if (isMinus) Result = "-" + Result;

            return Result;
        }
        #endregion

        #region 根据当前时间生成随机数字,到毫秒
        /// <summary>
        /// 根据当前时间生成随机数字,到毫秒
        /// </summary>
        /// <returns>生成的随机数字</returns>
        public static string CreateRandomByDateTime()
        {
            //return DateTime.Now.ToString("yyyyMMddhhmmsszz");
            return DateTime.Now.ToString("yyMMddhhmmss") + DateTime.Now.Millisecond.ToString();
        }
        #endregion

        #region 创建随机编号
        /// <summary>
        /// 创建随机编号
        /// </summary>
        /// <returns></returns>
        public static string CreateRandomNum()
        {
            return CreateRandomByDateTime() + CreateNumberRandom(4, false);
        }
        #endregion
    }
}

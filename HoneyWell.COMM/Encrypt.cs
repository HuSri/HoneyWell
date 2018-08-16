//*******************************************************************//
//
//** 文件名:   Encrypt.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成数据加密的函数设置
//
//** 描  述:   增加RC4加密算法
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Web.Security;

namespace HoneyWell.COMM
{
    public class Encrypt
    {
        #region 采用MD5对信息进行加密
        public static string MakeSecurityMD(string info)
        {
            string result = string.Empty;
            result = FormsAuthentication.HashPasswordForStoringInConfigFile(info, "md5");
            return result;
        }
        #endregion

        #region 采用Sha1对信息进行加密
        public static string MakeSecuritySHA(string info)
        {
            string result = string.Empty;
            result = FormsAuthentication.HashPasswordForStoringInConfigFile(info, "sha1");
            return result;
        }
        #endregion

        #region 页面传参加密
        public static string PageSecuityParam(string param)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(param));
        }
        #endregion

        #region 页面传参解密
        public static string PageDispelParam(string param)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(param));
        }
        #endregion
    }
}

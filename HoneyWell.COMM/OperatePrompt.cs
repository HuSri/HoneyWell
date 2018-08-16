//*******************************************************************//
//
//** 文件名:   OperatePrompt.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成按钮提示框的设置
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
    public class OperatePrompt : System.Web.UI.Page
    {
        /// <summary>
        /// 设置编辑按钮提示框
        /// </summary>
        /// <param name="imb"></param>
        public void AddPrompt(System.Web.UI.WebControls.WebControl imb)
        {
            imb.Attributes.Add("onclick", "return confirm('您确定要添加吗?')");
        }

        /// <summary>
        /// 设置编辑按钮提示框
        /// </summary>
        /// <param name="imb"></param>
        public void EditPrompt(System.Web.UI.WebControls.WebControl imb)
        {
            imb.Attributes.Add("onclick", "return confirm('您确定要重新编辑吗?')");
        }

        /// <summary>
        /// 设置删除按钮提示框
        /// </summary>
        /// <param name="imb"></param>
        public void DelPrompt(System.Web.UI.WebControls.WebControl imb)
        {
            imb.Attributes.Add("onclick", "return confirm('删除将无法恢复,您确定要删除?')");
        }
    }
}

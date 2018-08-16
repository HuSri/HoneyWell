//*******************************************************************//
//
//** 文件名:   SendPageParam.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成通过Post/Get页面传参的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace HoneyWell.COMM
{
    public enum MethodType
    {
        Post = 0,
        Get = 1
    }

    public class SendPageParam
    {
        private string url = "";
        private MethodType method = MethodType.Post;
        private string formName = "formName";
        private NameValueCollection inputs = new NameValueCollection();

        public string Url
        {
            get { return url; }
            set { this.url = value; }
        }

        public MethodType Method
        {
            get { return method; }
            set { this.method = value; }
        }

        public string FormName
        {
            get { return formName; }
            set { this.formName = value; }
        }
        public NameValueCollection Inputs
        {
            get { return inputs; }
            set { this.inputs = value; }
        }

        public void Add(string name, string value)
        {
            this.Inputs.Add(name, value);
        }

        /// <summary>
        /// 执行发送post/get请求
        /// </summary>
        public void ExecuteSend()
        {
            StringBuilder sbWrite = new StringBuilder();
            sbWrite.Append("<html><head>");
            sbWrite.Append(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));

            sbWrite.Append(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method.ToString(), Url));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                sbWrite.Append(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
            }
            sbWrite.Append("</form>");
            sbWrite.Append("</body><html>");

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(sbWrite.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 执行发送post/get请求
        /// </summary>
        public void ExecuteSend(out string postHtml)
        {
            postHtml = "";
            StringBuilder sbWrite = new StringBuilder();
            sbWrite.Append("<html><head>");
            sbWrite.Append(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            sbWrite.Append("<script src=\"Scripts/jquery-1.4.1.js\"></script>");
            sbWrite.Append("<script > $(function () { $('input[type=submit]').hide(); })</script>");

            sbWrite.Append(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\"  >", FormName, Method.ToString(), Url));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                sbWrite.Append(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
            }
            sbWrite.Append("<input type=\"submit\" />");
            sbWrite.Append("</form>");
            sbWrite.Append("</body><html>");

            postHtml = sbWrite.ToString();
        }

        /// <summary>
        /// 执行发送post/get请求
        /// </summary>
        public void ExecuteSend(string url)
        {
            this.Url = url;
            this.ExecuteSend();
        }
    }
}

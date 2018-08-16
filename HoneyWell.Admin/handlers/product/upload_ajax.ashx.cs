using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HoneyWell.COMM;

namespace HoneyWell.Admin.handlers.product
{
    /// <summary>
    /// upload_ajax 的摘要说明
    /// </summary>
    public class upload_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");
            switch (action)
            {
                case "uploadfile": //编辑器上传附件
                    EditorUploadFile(context);
                    break;
                default:          //普通上传
                    UpLoadFile(context);
                    break;
            }
        }

        #region 上传文件处理===================================
        private void UpLoadFile(HttpContext context)
        {

            string _delfile = DTRequest.GetString("DelFilePath");    //要删除的文件
            string fileName = DTRequest.GetString("name");           //文件名 

            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(context.Request.InputStream); //获取文件流
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (DTRequest.GetQueryString("IsWater") == "1")
            {
                _iswater = true;
            }
            if (DTRequest.GetQueryString("IsThumbnail") == "1")
            {
                _isthumbnail = true;
            }
            if (byteData.Length == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            UpLoad upLoad = new UpLoad();
            string msg = upLoad.FileSaveAs(byteData, fileName, _isthumbnail, _iswater);
            //删除已存在的旧文件
            if (!string.IsNullOrEmpty(_delfile))
            {
                upLoad.DeleteFile(_delfile);
            }
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }
        #endregion


        /// <summary>
        /// 上传附件
        /// </summary>
        private void EditorUploadFile(HttpContext context)
        {
            HttpPostedFile upFile = context.Request.Files["upfile"];
            FileSave(context, upFile, false);
        }


        /// <summary>
        /// 统一保存文件
        /// </summary>
        private void FileSave(HttpContext context, HttpPostedFile upFiles, bool isWater)
        {
            if (upFiles == null)
            {
                showError(context, "请选择要上传文件！");
                return;
            }
            //检查是否允许匿名上传
            /*if (sysConfig.fileanonymous == 0 && !new ManagePage().IsAdminLogin() && !new BasePage().IsUserLogin())
            {
                showError(context, "禁止匿名非法上传！");
                return;
            }*/
            //获取文件信息
            string fileName = upFiles.FileName;
            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(upFiles.InputStream); //获取文件流
            //开始上传
            string remsg = new UpLoad().FileSaveAs(byteData, fileName, false, isWater);
            Dictionary<string, object> dic = JsonHelper.DataRowFromJSON(remsg);
            string status = dic["status"].ToString();
            string msg = dic["msg"].ToString();
            if (status == "0")
            {
                showError(context, msg);
                return;
            }
            string filePath = dic["path"].ToString(); //取得上传后的路径
            showSuccess(context, fileName, filePath); //输出成功提示
        }


        /// <summary>
        /// 显示错误提示
        /// </summary>
        private void showError(HttpContext context, string message)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = message;
            hash["error"] = message;
            context.Response.AddHeader("Content-Type", "text/plain; charset=UTF-8");
            context.Response.Write(JsonHelper.ObjectToJSON(hash));
            context.Response.End();
        }

        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void showSuccess(HttpContext context, string fileName, string filePath)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "SUCCESS";
            hash["url"] = filePath;
            hash["title"] = fileName;
            hash["original"] = fileName;
            context.Response.AddHeader("Content-Type", "text/plain; charset=UTF-8");
            context.Response.Write(JsonHelper.ObjectToJSON(hash));
            context.Response.End();
        }

        /// <summary>
        /// 重新组合扩展名
        /// </summary>
        private string GetExtension(string extStr)
        {
            if (string.IsNullOrEmpty(extStr))
            {
                return "[]";
            }
            string[] strArr = extStr.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (string str in strArr)
            {
                sb.Append("\"." + str + "\",");
            }
            return "[" + sb.ToString().TrimEnd(',') + "]";
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
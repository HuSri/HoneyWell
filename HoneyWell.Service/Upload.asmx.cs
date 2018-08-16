using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HoneyWell.Service
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Upload : System.Web.Services.WebService
    {

        [WebMethod]
        public bool UploadFile_GoodsImg(byte[] FileByte, String fileName)
        {
            bool result = false;
            string uploadPath = ConfigurationManager.AppSettings["ImgPath"];
            string filePath = string.Format(uploadPath + "\\{0}", fileName);
            if (!File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.CreateNew))
                {
                    stream.Write(FileByte, 0, FileByte.Length);
                    result = true;
                }
            }
            return result;
        }
    }
}

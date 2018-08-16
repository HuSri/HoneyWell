using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;
using System.Configuration;
using System.Text;
using HoneyWell.DBUtility;

namespace HoneyWell.COMM
{
    public class UpLoad
    {

        public string GetImageName()
        {
            Random rd = new Random();
            StringBuilder serial = new StringBuilder();
            serial.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
            serial.Append(rd.Next(0, 999999).ToString());
            return serial.ToString();

        }

        /// <summary>
        /// 通过文件流上传文件方法
        /// </summary>
        /// <param name="byteData">文件字节数组</param>
        /// <param name="fileName">文件名</param>
        /// <param name="isThumbnail">是否生成缩略图</param>
        /// <param name="isWater">是否打水印</param>
        /// <returns>上传成功返回JSON字符串</returns>
        public string FileSaveAs(byte[] byteData, string fileName, bool isThumbnail, bool isWater)
        {
            try
            {
                int imgmaxheight = 1600;
                int imgmaxwidth = 1600;

                string fileExt = Path.GetExtension(fileName).Trim('.'); //文件扩展名，不含“.”
                string newFileName =  GetImageName() + "." + fileExt; 

                string upLoadPath = GetUpLoadPath();                   //本地上传目录相对路径
                string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //本地上传目录的物理路径
                string newFilePath = upLoadPath + newFileName;         //本地上传后的路径

                //检查文件字节数组是否为NULL
                if (byteData == null)
                {
                    return "{\"status\": 0, \"msg\": \"请选择要上传的文件！\"}";
                }
                //检查文件扩展名是否合法
                if (!CheckFileExt(fileExt))
                {
                    return "{\"status\": 0, \"msg\": \"不允许上传" + fileExt + "类型的文件！\"}";
                }
                //检查文件大小是否合法
                if (!CheckFileSize(fileExt, byteData.Length))
                {
                    return "{\"status\": 0, \"msg\": \"文件超过限制的大小！\"}";
                }

                //如果是图片，检查图片是否超出最大尺寸，是则裁剪
                if (IsImage(fileExt) && (imgmaxheight > 0 || imgmaxwidth > 0))
                {
                    byteData = Thumbnail.MakeThumbnailImage(byteData, fileExt, imgmaxwidth, imgmaxheight);
                }

                //检查本地上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }
                //保存主文件
                FileHelper.SaveFile(byteData, fullUpLoadPath + newFileName);
                string Img = "";
                ImgUpload.Upload upload = new ImgUpload.Upload();
                if (upload.UploadFile_GoodsImg(byteData, newFileName) == true)
                {
                    //处理完毕，返回JOSN格式的文件信息
                    Img= "{\"status\": 1, \"msg\": \"上传文件成功！\", \"name\": \"" + fileName + "\", \"nname\": \"" + newFileName + "\", \"path\": \""
                            + newFilePath + "\", \"size\": " + byteData.Length + ", \"ext\": \"" + fileExt + "\"}";
                }
                return Img;

            }
            catch
            {
                return "{\"status\": 0, \"msg\": \"上传过程中发生意外错误！\"}";
            }
        }

        /// <summary>
        /// 删除上传文件
        /// </summary>
        /// <param name="fileUri">相对地址或网址</param>
        public void DeleteFile(string fileUri)
        {
            string webpath = "/";
            string filepath = "upload";
            //文件不应是上传文件，防止跨目录删除
            if (fileUri.IndexOf("..") == -1 && fileUri.ToLower().StartsWith(webpath.ToLower() + filepath.ToLower()))
            {
                FileHelper.DeleteUpFile(fileUri);
            }
        }

        #region 私有方法
        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath()
        {

            string path = "/upload/product/"; //站点目录+上传目录 
            return path;
        }

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        private bool IsImage(string _fileExt)
        {
            ArrayList al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            string fileextension = "gif,jpg,jpeg,png,bmp,rar,zip,doc,xls,txt";
            string videoextension = "flv,mp3,mp4,avi";
            //检查危险文件
            string[] excExt = { "asp", "aspx", "ashx", "asa", "asmx", "asax", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = (fileextension + "," + videoextension).Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <param name="_fileSize">文件大小(B)</param>
        private bool CheckFileSize(string _fileExt, int _fileSize)
        {
            string videoextension = "flv,mp3,mp4,avi";
            int imgsize = 10240;
            int videosize = 102400;
            int attachsize = 51200;
            //将视频扩展名转换成ArrayList
            ArrayList lsVideoExt = new ArrayList(videoextension.ToLower().Split(','));
            //判断是否为图片文件
            if (IsImage(_fileExt))
            {
                if (imgsize > 0 && _fileSize > imgsize * 1024)
                {
                    return false;
                }
            }
            else if (lsVideoExt.Contains(_fileExt.ToLower()))
            {
                if (videosize > 0 && _fileSize > videosize * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (attachsize > 0 && _fileSize > attachsize * 1024)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查文件地址是否文件服务器地址
        /// </summary>
        /// <param name="url">文件地址</param>
        private bool IsExternalIPAddress(string url)
        {
            var uri = new Uri(url);
            switch (uri.HostNameType)
            {
                case UriHostNameType.Dns:
                    var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                    foreach (IPAddress ipAddress in ipHostEntry.AddressList)
                    {
                        byte[] ipBytes = ipAddress.GetAddressBytes();
                        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (!IsPrivateIP(ipAddress))
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case UriHostNameType.IPv4:
                    return !IsPrivateIP(IPAddress.Parse(uri.DnsSafeHost));
            }
            return false;
        }

        /// <summary>
        /// 检查IP地址是否本地服务器地址
        /// </summary>
        /// <param name="myIPAddress">IP地址</param>
        private bool IsPrivateIP(IPAddress myIPAddress)
        {
            if (IPAddress.IsLoopback(myIPAddress)) return true;
            if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();
                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 172.16.0.0/16
                else if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                else if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
                // 169.254.0.0/16
                else if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}

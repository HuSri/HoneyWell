//*******************************************************************//
//
//** 文件名:   FileManager.cs
//
//** 创建人:   姚清
//
//** 日  期:   2014/09/19
//
//** 描  述:   主要完成文件管理的设置
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Drawing;

namespace HoneyWell.COMM
{
    public class FileManager
    {
        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="directoryPath">文件夹路径或文件夹名</param>
        public static bool CreateDirectory(string directoryPath)
        {
            bool rst = false;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                if (Directory.Exists(directoryPath))
                    rst = true;
            }
            return rst;

        }
        #endregion

        #region 删除文件夹
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="directoryPath">文件夹路径或文件夹名</param>
        /// <param name="real">是否删除文件中的子目录</param>
        public static bool DeleteDirectory(string directoryPath, bool real)
        {
            bool rst = false;
            if (System.IO.Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.Delete(directoryPath, real);
                }
                catch
                { }
                if (!File.Exists(directoryPath))
                    rst = true;
            }
            return rst;
        }
        #endregion

        #region 重命名文件夹
        /// <summary>
        /// 重命名文件夹
        /// </summary>
        /// <param name="directoryPath1">文件夹旧名</param>
        /// <param name="directoryPath2">文件夹新名</param>
        public static bool MoveDirectory(string directoryPath1, string directoryPath2)
        {
            bool rst = false;
            if (Directory.Exists(directoryPath2))
            {
                Directory.Delete(directoryPath2, true);
            }

            Directory.Move(directoryPath1, directoryPath2);
            if (File.Exists(directoryPath2))
                rst = true;
            return rst;

        }
        #endregion

        #region 创建文件
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName">文件路径及文件名</param>
        /// <param name="content">文件内容</param>
        public static bool CreateFile(string fileName, byte[] content)
        {
            bool rst = false;
            using (FileStream fs = File.Create(fileName, content.Length))
            {
                fs.Write(content, 0, content.Length);
            }
            if (File.Exists(fileName))
                rst = true;
            return rst;
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件地址</param>
        public static bool DeleteFile(string fileName)
        {
            bool rst = false;
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                if (!File.Exists(fileName))
                    rst = true;
            }
            return rst;
        }
        #endregion

        #region 重命名文件
        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="oldFileName">旧文件名</param>
        /// <param name="newFileName">新文件名</param>
        public static bool RenameFile(string oldFileName, string newFileName)
        {
            bool rst = false;
            if (File.Exists(oldFileName))
            {
                File.Move(oldFileName, newFileName);
                if (File.Exists(newFileName))
                    rst = true;
            }
            return rst;
        }
        #endregion

        #region 复制文件
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcPath">原始文件</param>
        /// <param name="aimPath">目标文件</param>
        /// <returns></returns>
        public static bool CopyFile(string srcPath, string aimPath)
        {
            bool rst = false;
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath)) Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (Directory.Exists(file))
                        CopyFile(file, aimPath + Path.GetFileName(file));
                    // 否则直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
                string[] newFileList = Directory.GetFileSystemEntries(aimPath);
                if (fileList.Length == newFileList.Length)
                    rst = true;
            }
            catch
            {
                rst = false;
            }
            return rst;
        }
        #endregion

        #region 压缩图片
        /// <summary>
        /// 图片压缩处理
        /// </summary>
        /// <param name="ImgUrl">图片路径</param>
        /// <param name="intThumbWidth">压缩图片宽度</param>
        /// <param name="intThumbHeight">压缩图片高度</param>
        /// <param name="sThumbExtension">压缩前缀</param>
        /// <param name="sSavePath">压缩路径</param>
        /// <param name="FileName">压缩图片名称</param>
        /// <returns></returns>
        public static string SetYsImgUrl(string ImgUrl, int intThumbWidth, int intThumbHeight, string sThumbExtension, string sSavePath, string FileName)
        {
            string smallImagePath = "";
            try
            {
                //int intThumbWidth = 640;
                //int intThumbHeight = 480;
                //string sThumbExtension = "";
                //string sSavePath = "/UpLoad2/owner/";
                //原图加载
                using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImgUrl)))
                {
                    //原图宽度和高度
                    int width = sourceImage.Width;
                    int height = sourceImage.Height;
                    int smallWidth;
                    int smallHeight;
                    //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)
                    if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight)
                    {
                        smallWidth = intThumbWidth;
                        smallHeight = intThumbWidth * height / width;
                    }
                    else
                    {
                        smallWidth = intThumbHeight * width / height;
                        smallHeight = intThumbHeight;
                    }
                    //判断缩略图在当前文件夹下是否同名称文件存在
                    int file_append = 0;
                    string sThumbFile = sThumbExtension + FileName;
                    while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
                    {
                        file_append++;
                        sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(FileName) +
                            file_append.ToString() + System.IO.Path.GetExtension(FileName);
                    }
                    //缩略图保存的绝对路径
                    smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath) + sThumbFile;
                    //新建一个图板,以最小等比例压缩大小绘制原图
                    using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight))
                    {
                        //绘制中间图
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                        {
                            //高清,平滑
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.Clear(Color.Black);
                            g.DrawImage(
                            sourceImage,
                            new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                            new System.Drawing.Rectangle(0, 0, width, height),
                            System.Drawing.GraphicsUnit.Pixel
                            );
                        }
                        //新建一个图板,以缩略图大小绘制中间图
                        using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight))
                        {
                            //绘制缩略图
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1))
                            {
                                //高清,平滑
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                int lwidth = (smallWidth - intThumbWidth) / 2;
                                int bheight = (smallHeight - intThumbHeight) / 2;
                                g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                g.Dispose();
                                bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }
                    smallImagePath = sSavePath + sThumbFile;
                }
            }
            catch
            {
                ////出错则删除
                //System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
                return "No3";
            }

            return smallImagePath;
        }
        #endregion
    }
}

using System;
using System.IO;
using System.Web;
using System.Text;
using System.Collections;
using System.Configuration;


namespace HoneyWell.Service.Method
{

    /// <summary>
    /// 文件结构
    /// </summary>
    public struct MyFileInfo
    {
        public string FileName;//服务器端的文件名
        public string SFileName;//客户端的文件名
        public byte[] FileData;//文件的2进制数据
    }
    /// <summary>
    /// 表单项收集
    /// </summary>
    public class FormCollection : DictionaryBase
    {
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void Add(string Key, string Value)
        {
            Dictionary.Add(Key, Value);
        }
        /// <summary>
        /// 获取或设置对应的键值
        /// </summary>
        /// <param name="Key">键</param>
        /// <returns>值</returns>
        public string this[string Key]
        {
            get { return (string)Dictionary[Key]; }
            set { Dictionary[Key] = value; }
        }
        /// <summary>
        /// 重写叠代借口返回，返回string类型
        /// </summary>
        /// <returns>IEnumerator叠代接口</returns>
        public new IEnumerator GetEnumerator()
        {
            foreach (DictionaryEntry de in Dictionary)
            {
                yield return (string)de.Value;
            }
        }
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="Key">要删除的键值</param>
        public void Remove(string Key)
        {
            Dictionary.Remove(Key);
        }
    }

    /// <summary>
    /// 上传文件收集，信息为2进制
    /// </summary>
    public class FileCollection : DictionaryBase
    {
        public void Add(string Key, MyFileInfo fileInfo)
        {
            Dictionary.Add(Key, fileInfo);
        }
        public void Remove(string Key)
        {
            Dictionary.Remove(Key);
        }
        /// <summary>
        /// 重写迭代接口接口
        /// </summary>
        /// <returns>返回文件的MyFileInfo结构体</returns>
        public new IEnumerator GetEnumerator()
        {
            foreach (DictionaryEntry de in Dictionary)
            {
                yield return (MyFileInfo)de.Value;
            }
        }
        public MyFileInfo this[string Key]
        {
            get { return (MyFileInfo)Dictionary[Key]; }
            set { Dictionary[Key] = value; }
        }
    }

    /// <summary>
    /// 文件上传类
    /// </summary>
    public class UpLoad
    {
        #region 变量申明
        private byte[] FormData;   //表单的2进制数据数组
        private int formSize;      //总上传字节数
        private string allowExts;  //默认的可以上传的文件扩展名称
        private string rootPath;   //文件保存的目录
        private string fileErr;    //文件错误信息，例如文件大小超过，扩展名不允许
        private string allFile;    //保存所有成功上传的文件名称

        private int maxFileSize;   //默认上传大小为200kb
        private int fileCount;     //总的上传的文件个数

        private byte[] SplitStr;   //2进制分隔符号
        private int SplitStrLen;   //分隔符号长度
        byte[] CLStr = new byte[] { 13, 10 };//2进制回车

        private FileCollection fileCollections = new FileCollection();//文件信息集合
        private FormCollection formCollections = new FormCollection();//表单信息集合

        private BinaryReader binReader;//2进制读取器
        #endregion

        #region 属性
        /// <summary>
        /// 默认的可以上传的文件扩展名称
        /// </summary>
        public string AllowExts
        {
            get { return allowExts; }
            set { allowExts = value; }
        }
        /// <summary>
        /// 文件保存的目录
        /// </summary>
        public string RootPath
        {
            get { return rootPath; }
            set
            {
                string tempPath = value;
                if (tempPath.LastIndexOf("/") == -1)
                    rootPath = tempPath + "/";
                else
                    rootPath = tempPath;
            }
        }
        /// <summary>
        /// 错误信息，只读属性
        /// </summary>
        public string ErrorStr
        {
            get
            {
                if (fileErr != "")
                    fileErr = "发生如下错误\n" + fileErr;
                return fileErr;
            }
        }
        /// <summary>
        /// 文件信息集合，2进制流形式缓存数据，只读属性
        /// </summary>
        public FileCollection FileCollections
        {
            get { return fileCollections; }
        }
        /// <summary>
        /// 表单信息集合，只读属性
        /// </summary>
        public FormCollection FormCollections
        {
            get { return formCollections; }
        }
        /// <summary>
        /// 所有文件在服务器上生成的文件名，只读属性
        /// </summary>
        public string FileNames
        {
            get
            {
                return allFile;
            }
        }
        /// <summary>
        /// 文件数量，只读属性
        /// </summary>
        public int FileCount
        {
            get { return fileCount; }
        }
        #endregion

        public UpLoad()
        {
            allowExts = "jpg|png|gif";
            rootPath = "/Upload/";
            maxFileSize = 500;
            allFile = "";
            fileErr = "";
            fileCount = 0;
        }
        /// <summary>
        /// 保存文件到硬盘
        /// </summary>
        public void Save()
        {
            string FilePath = "";
            FileStream fileStream;
            foreach (MyFileInfo mfi in fileCollections)
            {
                try
                {
                    FilePath = HttpContext.Current.Server.MapPath(rootPath + mfi.FileName);//获取文件的物理路径
                    fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
                    fileStream.Write(mfi.FileData, 0, mfi.FileData.Length);
                    fileStream.Flush();
                    fileStream.Close();
                }
                catch
                {
                    fileErr += mfi.SFileName + "保存失败！\n";
                }
            }
        }
        /// <summary>
        /// 以时间和文件第几个为文件重新命名
        /// </summary>
        /// <param name="Ext">扩展名</param>
        /// <param name="fileCount">第几个文件，防止服务器处理速度快，一个时间内能处理几个文件，那么用时间生成的文件名有可能被覆盖。</param>
        /// <returns>新文件名</returns>
        private string getFileName(string Ext, int fileCount)
        {
            return DateTime.Now.ToString().Replace(":", "").Replace(" ", "").Replace("-", "") + fileCount.ToString() + "." + Ext;
        }
        /// <summary>
        /// 获取表单数据项目
        /// </summary>
        public void CollectFormDatas()
        {
            string sfilename = "", fileExt = "", FileName = "";
            string Key = "";//表单键名称
            int DataSize, headstart, headend;
            formSize = HttpContext.Current.Request.TotalBytes;
            //if (formSize < 1)
            //{
            //    ErrHandle("没有选择上传的文件！");
            //}

            FormData = new byte[formSize];

            binReader = new BinaryReader(HttpContext.Current.Request.InputStream);
            binReader.Read(FormData, 0, formSize);

            SplitStrLen = InStrB(0, FormData, CLStr);
            SplitStr = new byte[SplitStrLen];

            binReader.BaseStream.Position = 0;//设置流位置
            binReader.Read(SplitStr, 0, SplitStrLen);//获取2进制分隔符号 
            headstart = SplitStrLen + 2;//第一个集合的描述信息位置                      
            do
            {
                headend = InStrB(headstart, FormData, new byte[] { CLStr[0], CLStr[1], CLStr[0], CLStr[1] });//两对回车换行符 
                DataSize = InStrB(headend + 4, FormData, SplitStr) - (headend + 4) - 2;
                fileExt = getExt(headstart, headend - headstart, ref sfilename, ref Key);
                if (fileExt == null)//表单集合
                {
                    formCollections.Add(Key, ReadData(headend + 4, DataSize));
                }
                else if (fileExt != "")//文件
                {
                    if (!checkFileSize(DataSize))
                        fileErr = fileErr + sfilename + "上传失败，文件大小超过" + maxFileSize + "KB！\n";
                    else if (!checkExt(fileExt))
                        fileErr = fileErr + sfilename + "上传失败，文件类型 " + fileExt + " 不允许上传！\n";
                    else
                    {
                        //fileCount = fileCount + 1;//累计文件个数
                        //FileName = getFileName(fileExt, fileCount);
                        FileName = sfilename;
                        ReadData(headend + 4, DataSize, Key, FileName, sfilename);
                    }
                }
                //计算下项开始位置
                headstart = (headend + 4) + DataSize + 2 + (SplitStrLen + 2);
            } while (headstart + 2 < formSize);
            //关闭流
            binReader.Close();
            //记录上传图片名称+错误信息 
            //JsonLog("system", sfilename,"Error:" + fileErr);   
        }

        ////Json日志
        //private void JsonLog(string UName, string sfilename, string fileErr)
        //{
        //    Model.Sys_LogJson.Sys_LogJson sys_Model = new Model.Sys_LogJson.Sys_LogJson();
        //    BLL.Sys_LogJson.Sys_LogJson sys_Bll = new BLL.Sys_LogJson.Sys_LogJson();
        //    sys_Model.UName = UName;
        //    sys_Model.UJson = sfilename;
        //    sys_Model.CreateTime = DateTime.Now.ToLocalTime();
        //    sys_Model.MoreCol1 = fileErr;
        //    sys_Model.MoreCol2 = "";
        //    sys_Bll.Add(sys_Model);
        //}

        private void ErrHandle(string ErrMsg)
        {
            ErrMsg = ErrMsg.Replace("'", "\'");//防止脚本符号的嵌套出错
            HttpContext.Current.Response.Write("<script>alert('" + ErrMsg + "');history.back();</" + "script>");
            HttpContext.Current.Response.End();
        }

        private string getExt(int start, int DataSize, ref string filename, ref string Key)
        {
            string fileExt = null, desInfo = "";
            byte[] desBytes = new byte[DataSize];
            desBytes = ReadBytes(start, DataSize);
            desInfo = Encoding.UTF8.GetString(desBytes);
            desInfo = desInfo.Substring(desInfo.IndexOf("name=\"") + 6);
            Key = desInfo.Substring(0, desInfo.IndexOf("\""));
            int fnStart = desInfo.IndexOf("filename=\"");
            if (fnStart != -1)
            {
                filename = desInfo.Substring(fnStart + 10);
                if (filename.IndexOf("\"") != 0)//有可能未上传文件
                {
                    filename = filename.Substring(0, filename.IndexOf("\""));
                    fileExt = Path.GetExtension(filename).ToLower().Substring(1);
                }
                else
                    fileExt = "";
            }
            return fileExt;
        }

        /// <summary>
        /// 验证单个文件大小
        /// </summary>
        /// <param name="datasize">文件大小</param>
        /// <returns>是否合格</returns>
        private bool checkFileSize(int datasize)
        {
            if (datasize > maxFileSize * 1024)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 验证扩展名是否允许
        /// </summary>
        /// <param name="fileExt">扩展名</param>
        /// <returns>是否合格</returns>
        private bool checkExt(string fileExt)
        {
            string[] exts = allowExts.Split('|');
            foreach (string ext in exts)
            {
                if (ext == fileExt)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取流中的字节数组
        /// </summary>
        /// <param name="DataStart">流开始处</param>
        /// <param name="DataSize">数组大小</param>
        /// <returns>字节数组</returns>
        private byte[] ReadBytes(int DataStart, int DataSize)
        {
            byte[] ReturnBytes = new byte[DataSize];
            binReader.BaseStream.Position = DataStart;
            binReader.Read(ReturnBytes, 0, DataSize);
            return ReturnBytes;
        }

        /// <summary>
        /// 读取bytes数组数据
        /// </summary>
        /// <param name="DataStart">开始位置</param>
        /// <param name="DataSize">大小</param>
        private string ReadData(int DataStart, int DataSize)
        {
            if (DataSize < 1)
                return "";
            else
            {
                byte[] bytesData = new byte[DataSize];
                bytesData = ReadBytes(DataStart, DataSize);
                string Str = Encoding.UTF8.GetString(bytesData);
                if (Str == "\r\n")
                    return "";
                else
                    return Str;
            }
        }

        /// <summary>
        /// 读取bytes数组数据
        /// </summary>
        /// <param name="DataStart">开始位置</param>
        /// <param name="DataSize">大小</param>
        /// <param name="Key">键名称</param>
        /// <param name="FileName">服务器的文件名</param>
        /// <param name="sFileName">客户端的文件名</param>        
        private void ReadData(int DataStart, int DataSize, string Key, string FileName, string sFileName)
        {
            MyFileInfo myFileInfo = new MyFileInfo();
            myFileInfo.FileData = ReadBytes(DataStart, DataSize);
            myFileInfo.FileName = FileName;
            myFileInfo.SFileName = sFileName;
            fileCollections.Add(Key, myFileInfo);
            allFile += FileName + ",";
        }

        /// <summary>
        /// 搜索给定2进制数在数组中的位置
        /// </summary>
        /// <param name="startPosition">要搜索开始的位置,默认为0</param>
        /// <param name="b">要搜索的2进制数组</param>
        /// <param name="sb">搜索的2进制数数组</param>
        /// <returns>所在位置，找不到默认为-1</returns>
        private int InStrB(int startPosition, byte[] b, byte[] sb)
        {
            int blen = b.Length;
            if (startPosition >= blen)
                return -1;
            int sblen = sb.Length;
            int postion = -1;
            if (sblen == 0)
                return -1;
            for (int i = startPosition; i < blen; i++)
            {
                if (b[i] == sb[0])
                {
                    int TempI = i + 1;
                    bool Find = true;
                    for (int j = 1; j < sblen && TempI < blen; j++, TempI++)
                    {
                        if (b[TempI] == sb[j])
                            continue;
                        else
                        {
                            Find = false;
                            break;
                        }
                    }
                    if (Find)
                    {
                        postion = i;
                        break;
                    }
                }
            }
            return postion;
        }
    }
}
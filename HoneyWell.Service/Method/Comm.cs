using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace HoneyWell.Service.Method
{
    public class Comm
    {

        /// <summary>
        /// 日志保存
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="content"></param>
        public static void WriteLog(String content)
        {
            string strNewsPath = "";
            strNewsPath = @"D:\hbw\item\HoneyWell\HoneyWell.Service\Log\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            String smb = content;
            if (!File.Exists(strNewsPath))
            {
                File.Create(strNewsPath).Close();
            }
            StreamReader rd = new StreamReader(strNewsPath);
            string aadd = rd.ReadToEnd();
            smb = aadd + content;
            rd.Close();
            StreamWriter sw = new StreamWriter(strNewsPath);
            sw.WriteLine(smb);
            sw.Close();
        }

        /// <summary>
        /// 日志写入
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="content"></param>
        public static void LogWrite(string Method, string jsonResult)
        {
            //保存到日志文件 
            WriteLog(DateTime.Now.ToString() + " Method:" + Method);
            WriteLog(jsonResult + "\r\n");
        }

        // 拼接数据查询列转为Json格式
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str1 = dt.Rows[i][j].ToString().UnicodeEncode();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + str1 + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }

            Json.Append("]");
            return Json.ToString();
        }

        // 采用Base64编码
        public static string StringToBase64(string info)
        {
            string strPath = "";
            System.Text.Encoding encode = System.Text.Encoding.UTF8;
            byte[] bytedata = encode.GetBytes(info);
            strPath = Convert.ToBase64String(bytedata, 0, bytedata.Length);
            return strPath;
        }

        // 采用Base64解码
        public static string Base64ToString(string info)
        {
            string strPath = "";
            byte[] bpath = Convert.FromBase64String(info);
            strPath = System.Text.ASCIIEncoding.Default.GetString(bpath);
            return strPath;
        }

    }

    /// <summary>
    /// JSON序列化和反序列化辅助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// JSON序列化
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }


        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }
    }


    public static class JsonToL
    {
        public static List<T> JSONStringToList<T>(this string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            Serializer.MaxJsonLength = Int32.MaxValue;
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }
    }


    public static class StringExtension
    {
        #region unicode 字符转义
        /// <summary>  
        /// 转换输入字符串中的任何转义字符。如：Unicode 的中文 \u8be5  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static string UnicodeDencode(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            return Regex.Unescape(str);
        }
        /// <summary>  
        /// 将字符串进行 unicode 编码  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static string UnicodeEncode(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            StringBuilder strResult = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    strResult.Append("\\u");
                    strResult.Append(((int)str[i]).ToString("x4"));
                }
            }
            return strResult.ToString();
        }
        #endregion

    }

}
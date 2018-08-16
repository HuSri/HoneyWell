using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HoneyWell.COMM
{
    public class CompressTools
    {

        /// <summary>
        /// 对字符串进行压缩
        /// </summary>
        /// <param name="str">待压缩的字符串</param>
        /// <returns>压缩后的字符串</returns>
        public static string CompressString(string str)
        {
            string compressString = "";
            byte[] compressBeforeByte = Encoding.Unicode.GetBytes(str);
            byte[] compressAfterByte = Compress(compressBeforeByte);
            compressString = Encoding.Unicode.GetString(compressAfterByte);
            return compressString;
        }
        /// <summary>
        /// 对字符串进行解压缩
        /// </summary>
        /// <param name="str">待解压缩的字符串</param>
        /// <returns>解压缩后的字符串</returns>
        public static string DecompressString(string str)
        {
            string compressString = "";
            byte[] compressBeforeByte = Encoding.Unicode.GetBytes(str);
            byte[] compressAfterByte = Decompress(compressBeforeByte);
            compressString = Encoding.Unicode.GetString(compressAfterByte);
            return compressString;
        }
        /// <summary>
        /// 对文件进行压缩
        /// </summary>
        /// <param name="sourceFile">待压缩的文件名</param>
        /// <param name="destinationFile">压缩后的文件名</param>
        public static void CompressFile(string sourceFile, string destinationFile)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 对文件进行解压缩
        /// </summary>
        /// <param name="sourceFile">待解压缩的文件名</param>
        /// <param name="destinationFile">解压缩后的文件名</param>
        /// <returns></returns>
        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 对byte数组进行压缩
        /// </summary>
        /// <param name="data">待压缩的byte数组</param>
        /// <returns>压缩后的byte数组</returns>
        //public static byte[] Compress(byte[] data)
        //{
        //    try
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        GZipStream zip = new GZipStream(ms, CompressionMode.Compress,true);
        //        zip.Write(data, 0, data.Length);
        //        zip.Close();
        //        byte[] buffer = new byte[ms.Length];
        //        ms.Position=0;
        //        ms.Read(buffer, 0, buffer.Length);
        //        ms.Close();
        //        return buffer;

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}      

        //public static byte[] Decompress(byte[] data)
        //{
        //    try
        //    {
        //        MemoryStream ms = new MemoryStream(data);
        //        GZipStream zip = new GZipStream(ms,CompressionMode.Decompress,true);
        //        MemoryStream msreader = new MemoryStream();
        //        byte[] buffer = new byte[0x1000];
        //        while (true)
        //        {
        //            int reader=zip.Read(buffer, 0, buffer.Length);
        //            if (reader <= 0)
        //            {
        //                break;
        //            }
        //            msreader.Write(buffer, 0, reader);                   
        //        }
        //        zip.Close();
        //        ms.Close();
        //        msreader.Position = 0;
        //        buffer = msreader.ToArray();
        //        msreader.Close();
        //        return buffer;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        /// <summary>
        /// 对二进制数组进行压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            Stream zipStream = null;
            zipStream = new GZipStream(ms, CompressionMode.Compress, true);
            zipStream.Write(data, 0, data.Length);
            zipStream.Close();
            ms.Position = 0;
            byte[] compressed_data = new byte[ms.Length];
            ms.Read(compressed_data, 0, int.Parse(ms.Length.ToString()));
            return compressed_data;
        }

        /// <summary>
        /// 解压二进制数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                Stream zipStream = null;
                zipStream = new GZipStream(ms, CompressionMode.Decompress);
                byte[] dc_data = null;
                dc_data = EtractBytesFormStream(zipStream, data.Length);
                return dc_data;
            }
            catch
            {
                return null;
            }
        }


        public static byte[] EtractBytesFormStream(Stream zipStream, int dataBlock)
        {
            try
            {
                byte[] data = null;
                int totalBytesRead = 0;
                while (true)
                {
                    Array.Resize(ref data, totalBytesRead + dataBlock + 1);
                    int bytesRead = zipStream.Read(data, totalBytesRead, dataBlock);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    totalBytesRead += bytesRead;
                }
                Array.Resize(ref data, totalBytesRead);
                return data;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 对目标文件夹进行压缩，将压缩结果保存为指定文件
        /// </summary>
        /// <param name="dirPath">目标文件夹</param>
        /// <param name="fileName">压缩文件</param>
        public static void Compress(string dirPath, string fileName)
        {
            ArrayList list = new ArrayList();
            foreach (string f in Directory.GetFiles(dirPath))
            {
                byte[] destBuffer = File.ReadAllBytes(f);
                SerializeFileInfo sfi = new SerializeFileInfo(f, destBuffer);
                list.Add(sfi);
            }
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new MemoryStream())
            {
                formatter.Serialize(s, list);
                s.Position = 0;
                CreateCompressFile(s, fileName);
            }
        }

        /**/
        /// <summary>
        /// 对目标压缩文件解压缩，将内容解压缩到指定文件夹
        /// </summary>
        /// <param name="fileName">压缩文件</param>
        /// <param name="dirPath">解压缩目录</param>
        public static void DeCompress(string fileName, string dirPath)
        {
            using (Stream source = File.OpenRead(fileName))
            {
                using (Stream destination = new MemoryStream())
                {
                    using (GZipStream input = new GZipStream(source, CompressionMode.Decompress, true))
                    {
                        byte[] bytes = new byte[4096];
                        int n;
                        while ((n = input.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            destination.Write(bytes, 0, n);
                        }
                    }
                    destination.Flush();
                    destination.Position = 0;
                    DeSerializeFiles(destination, dirPath);
                }
            }
        }

        private static void DeSerializeFiles(Stream s, string dirPath)
        {
            BinaryFormatter b = new BinaryFormatter();
            ArrayList list = (ArrayList)b.Deserialize(s);

            foreach (SerializeFileInfo f in list)
            {
                string newName = dirPath + Path.GetFileName(f.FileName);
                using (FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(f.FileBuffer, 0, f.FileBuffer.Length);
                    fs.Close();
                }
            }
        }

        private static void CreateCompressFile(Stream source, string destinationName)
        {
            using (Stream destination = new FileStream(destinationName, FileMode.Create, FileAccess.Write))
            {
                using (GZipStream output = new GZipStream(destination, CompressionMode.Compress))
                {
                    byte[] bytes = new byte[4096];
                    int n;
                    while ((n = source.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        output.Write(bytes, 0, n);
                    }
                }
            }
        }

        [Serializable]
        class SerializeFileInfo
        {
            public SerializeFileInfo(string name, byte[] buffer)
            {
                fileName = name;
                fileBuffer = buffer;
            }

            string fileName;
            public string FileName
            {
                get
                {
                    return fileName;
                }
            }

            byte[] fileBuffer;
            public byte[] FileBuffer
            {
                get
                {
                    return fileBuffer;
                }
            }
        }
    }
}

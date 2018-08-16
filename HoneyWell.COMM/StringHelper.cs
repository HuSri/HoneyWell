//*******************************************************************//
//
//** 文件名:   StringHelper.cs
//
//** 创建人:   刘政伟
//
//** 日  期:   2014/10/15
//
//** 描  述:   主要完成字符串通用帮助类的编写
//**
//
//** 版  本:   架构设计  V1.0版
//
//*******************************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace HoneyWell.COMM
{
    public class StringHelper
    {
        /// <summary>
        /// 截取指定长度字符
        /// </summary>
        /// <param name="val">被截取字符串</param>
        /// <param name="len">保留长度</param>
        /// <returns>截取之后的值</returns>
        public static string SubStr(object val, int len)
        {
            if (val.ToString().Length > len)
                return val.ToString().Substring(0, len);
            else
                return val.ToString();
        }

        /// <summary>
        /// 查找字符
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public static string StrSplit(string s1, string s2, string s3)
        {
            int n = s1.IndexOf(s2);
            if (n > 0)
            {
                s1 = s1.Substring(n + s2.Length);
                int n1 = s1.IndexOf(s3);
                s1 = s1.Remove(n1);
                return s1;
            }
            else
                return "";
        }

        /// <summary>
        /// 替换HTML标签
        /// </summary>
        /// <param name="Htmlstring">含Html字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Htmlstring.Replace("\n", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }


        /// <summary>
        /// 将NULL转换成空字符
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象或空字符</returns>
        public static string NullToStr(object obj)
        {
            if (obj == null ||
                string.IsNullOrEmpty(obj.ToString()) ||
                obj.ToString().Trim().Length <= 0 ||
                obj.ToString().Trim() == "")
                return "";
            else
                return obj.ToString();
        }

        /// <summary>
        /// 将NULL转换成整型零
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象或整型零</returns>
        public static int NullToInt(object obj)
        {
            if (NullToStr(obj) == "" || !IsNumeric(obj.ToString().Trim()))
                return 0;
            else
                return Convert.ToInt32(NullToDecimal(obj.ToString().Trim()));
        }

        /// <summary>
        /// 将NULL转换成浮点型零
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象或浮点型零</returns>
        public static Double NullToDouble(object obj)
        {
            if (NullToStr(obj) == "" || !IsNumeric(obj.ToString().Trim()))
                return 0;
            else
                return Convert.ToDouble(obj.ToString().Trim());
        }

        /// <summary>
        /// 将NULL转换成十进制零
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象或十进制零</returns>
        public static Decimal NullToDecimal(object obj)
        {
            if (NullToStr(obj) == "" || !IsNumeric(obj.ToString().Trim()))
                return 0;
            else
                return Convert.ToDecimal(obj.ToString().Trim());
        }

        /// <summary>
        /// 将NULL转换成默认日期
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>默认日期</returns>
        public static DateTime NullToDateTime(object obj)
        {
            if (NullToStr(obj) == "" || !IsDateTime(obj.ToString().Trim()))
                return Convert.ToDateTime("1900/01/01");
            else
                return Convert.ToDateTime(obj.ToString().Trim());
        }

        /// <summary>
        /// 判断输入是英文还是中文
        /// </summary>
        /// <param name="InputString">传入字符串</param>
        /// <returns>返回（０：传人参数为空，１：中文，２：英文）</returns>
        public static int GetEnglishOrChinese(string InputString)
        {
            if (string.IsNullOrEmpty(InputString))
            {
                return 0;
            }
            int QueryType = 0;
            byte BytesInput;
            //得到ASC码，用来判断中文或拼音．
            BytesInput = ((byte[])System.Text.Encoding.ASCII.GetBytes(InputString.Substring(0, 1)))[0];
            if ((BytesInput >= 65 && BytesInput <= 90) || (BytesInput >= 97 && BytesInput <= 122))
            {
                QueryType = 2;
            }
            else
            {
                QueryType = 1;
            }
            return QueryType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sString"></param>
        /// <returns></returns>
        public static string HTMLEncode(string sString)
        {
            if (sString != string.Empty)
            {
                if (sString.Contains("'"))
                {
                    return "";
                }

                //sString.Replace("<", "&lt;");
                //sString.Replace(">", "&rt;");
                //sString.Replace(((char)34).ToString(), "&quot;");
                //sString.Replace(((char)39).ToString(), "&#39;");
                //sString.Replace(((char)13).ToString(), "");
                //sString.Replace("'", "&nbsp;");
                //sString.Replace("\"", " ");
                //sString.Replace("\r\n", "<BR> ");
            }
            return (sString);
        }

        /// <summary>
        /// 验证字符串是Boolean
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 字符串是Boolean, false = 字符串不是Boolean</returns>
        public static bool IsBoolean(string validatedString)
        {
            return validatedString.ToUpper() == bool.TrueString.ToUpper() || validatedString.ToUpper() == bool.FalseString.ToUpper();
        }

        /// <summary>
        /// 返回格式化的日期字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="cultureInforName">区域文化名称</param>
        /// <param name="format">格式化字符串</param>
        /// <returns>格式化的日期字符串</returns>
        public static string GetFormatedDateTimeString(DateTime dt, string cultureInforName, string format)
        {
            CultureInfo cultureInfo = new CultureInfo(cultureInforName);
            return dt.ToString(format, cultureInfo);
        }

        /// <summary>
        /// 验证字符串是否为数字（正则表达式）（true = 是数字, false = 不是数字）
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 是数字, false = 不是数字</returns>
        public static bool IsNumeric(string validatedString)
        {
            const string NumericPattern = @"^[-]?\d+[.]?\d*$";
            return Regex.IsMatch(validatedString, NumericPattern);
        }

        /// <summary>
        /// 验证字符串只包含为数字或字母（正则表达式）（true = 只包含数字或字母, false = 还有其他字符）
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 只包含数字或字母, false = 还有其他字符</returns>
        public static bool IsJustIncludeNumericOrLetter(string validatedString)
        {
            const string NumericOrLetterPattern = @"^[a-zA-Z0-9]+$";

            return Regex.IsMatch(validatedString, NumericOrLetterPattern);

        }

        /// <summary>
        /// 验证字符串是时间日期(true = 字符串是时间日期, false = 字符串不是时间日期)
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 字符串是时间日期, false = 字符串不是时间日期</returns>
        public static bool IsDateTime(string validatedString)
        {
            try
            {
                DateTime t = DateTime.Parse(validatedString);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 验证字符串包含中文字符(true = 包含, false = 不包含)
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 包含, false = 不包含</returns>
        public static bool HasChinese(string validatedString)
        {
            const string ChinesePattern = @"[\u4e00-\u9fa5]";

            return Regex.IsMatch(validatedString, ChinesePattern);
        }

        /// <summary>
        /// 验证字符串全部是中文字符(true = 全部是中文字符, false = 包含非中文字符)
        /// </summary>
        /// <param name="validatedString">被验证的字符串</param>
        /// <returns>true = 包含, false = 不包含</returns>
        public static bool IsAllOfChinese(string validatedString)
        {
            const string AllOfChinesePattern = @"^[\u4e00-\u9fa5]+$";
            return Regex.IsMatch(validatedString, AllOfChinesePattern);
        }

        /// <summary>
        /// 获取字符串中中文字符的数量
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns>中文字符的数量</returns>
        public static int GetChineseCount(string inputString)
        {
            const string ChinesePattern = @"/[\u4e00-\u9fa5]/g";
            return Regex.Matches(inputString, ChinesePattern).Count;
        }

        /// <summary>
        /// 获取字符串真实长度（中文算两个字节）
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns>字符串真实长度（中文算两个字节）</returns>
        public static int GetRealyStringLength(string inputString)
        {
            return inputString.Length + GetChineseCount(inputString);
        }

        /// <summary>
        /// 判断是否存在HTML转义标记
        /// </summary>
        /// <param name="strResponseXML">含HTML转义标记原文</param>
        /// <returns>true:存在; false:不存在</returns>
        /// <returns>2011-01-21     leixia      create</returns>
        public static bool IsDelHtmlTags(string strHtml)
        {
            string strHtmlTags = @"&.*?;";
            return Regex.IsMatch(strHtml, strHtmlTags);
        }

        /// <summary>
        /// 删除HTML转义标记
        /// </summary>
        /// <param name="strResponseXML">含HTML转义标记原文</param>
        /// <returns>删除HTML标记后</returns>
        /// <returns>2011-01-21     leixia      create</returns>
        public static string ClearHtmlCode(string strHtml)
        {
            string strHtmlTags = @"(&#){1}.+;{1}";
            return Regex.Replace(strHtml, strHtmlTags, "");
        }

        /// <summary>
        /// 数字格式化短格式
        /// </summary>
        /// <param name="number">待转换数字</param>
        /// <returns>短格式</returns>
        public static string FormatShortNumber(decimal strNumber)
        {
            string formatNumber = string.Empty;

            if (strNumber.ToString().Length <= 3)
            {
                formatNumber = strNumber.ToString();
            }
            else if (strNumber.ToString().Length <= 4)
            {
                formatNumber = string.Format("{0:0,00}", strNumber);
                //formatNumber = string.Format("{0:0,00}", strNumber);
            }
            else if (strNumber.ToString().Length <= 6)
            {
                formatNumber = string.Format("{0:0,}", strNumber) + "K";
            }
            else if (strNumber.ToString().Length <= 9)
            {
                decimal temp = decimal.Parse(string.Format("{0:0,,}", strNumber * 10)) / 10;
                formatNumber = temp + "M";
            }
            else
            {
                decimal temp = decimal.Parse(string.Format("{0:0,,,}", strNumber * 10)) / 10;
                formatNumber = temp + "B";
            }

            return "\"" + formatNumber + "\"";
        }

        #region 获取拼音字符
        private static Int32[] pyValue = new Int32[]
        {
            -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
            -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
            -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
            -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
            -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
            -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
            -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
            -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
            -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
            -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
            -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
            -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
            -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
            -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
            -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
            -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
            -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
            -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
            -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
            -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
            -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
            -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
            -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
            -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
            -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
            -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
            -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
            -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
            -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
            -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
            -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
            -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
            -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
        };

        private static String[] pyName = new String[]
        {
            "a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben",
            "beng","bi","bian","biao","bie","bin","bing","bo","bu","ba","cai","can",
            "cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen","cheng",
            "chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong",
            "cou","cu","cuan","cui","cun","cuo","da","dai","dan","dang","dao","de",
            "deng","di","dian","diao","die","ding","diu","dong","dou","du","duan","dui",
            "dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo",
            "fou","fu","ga","gai","gan","gang","gao","ge","gei","gen","geng","gong",
            "gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han",
            "hang","hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan",
            "huang","hui","hun","huo","ji","jia","jian","jiang","jiao","jie","jin","jing",
            "jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke",
            "ken","keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo",
            "la","lai","lan","lang","lao","le","lei","leng","li","lia","lian","liang",
            "liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun",
            "luo","ma","mai","man","mang","mao","me","mei","men","meng","mi","mian",
            "miao","mie","min","ming","miu","mo","mou","mu","na","nai","nan","nang",
            "nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning",
            "niu","nong","nu","nv","nuan","nue","nuo","O","Ou","pa","pai","pan",
            "pang","pao","pei","pen","peng","pi","pian","piao","pie","pin","ping","po",
            "pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu",
            "quan","que","qun","ran","rang","rao","re","ren","reng","ri","rong","rou",
            "ru","ruan","rui","run","ruo","sa","sai","san","sang","sao","se","sen",
            "seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu",
            "shua","shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan",
            "sui","sun","suo","ta","tai","tan","tang","tao","te","teng","ti","tian",
            "tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo","wa","wai",
            "wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao",
            "xie","xin","xing","xiong","xiu","xu","xuan","xue","xun","ya","yan","yang",
            "yao","ye","yi","yin","ying","yo","yong","you","yu","yuan","yue","yun",
            "za", "zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan",
            "zhang","zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan",
            "zhuang","zhui","zhun","zhuo","zi","zong","zou","zu","zuan","zui","zun","zuo"
        };

        public static string ConvertToPinyin(string hzString)
        {
            // 匹配中文字符
            Regex regex = new Regex("^[\u4e00-\u9fa5]$");
            byte[] array = new byte[2];
            string pyString = "";
            int chrAsc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] noWChar = hzString.ToCharArray();

            for (int j = 0; j < noWChar.Length; j++)
            {
                // 中文字符
                if (regex.IsMatch(noWChar[j].ToString()))
                {
                    array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());
                    i1 = (short)(array[0]);
                    i2 = (short)(array[1]);
                    chrAsc = i1 * 256 + i2 - 65536;
                    if (chrAsc > 0 && chrAsc < 160)
                    {
                        pyString += noWChar[j];
                    }
                    else
                    {
                        // 修正部分文字
                        if (chrAsc == -9254)  // 修正“圳”字
                            pyString += "Zhen";
                        else
                        {
                            for (int i = (pyValue.Length - 1); i >= 0; i--)
                            {
                                if (pyValue[i] <= chrAsc)
                                {
                                    pyString += pyName[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                // 非中文字符
                else
                {
                    pyString += noWChar[j].ToString();
                }
            }
            return pyString;
        }

        public static String ConvertToPinyinAbbr(String hzString)
        {
            String singleWord = String.Empty;
            StringBuilder abbrString = new StringBuilder();

            for (Int32 i = 0; i < hzString.Length; i++)
            {
                if (hzString.Substring(i, 1) == "（" || hzString.Substring(i, 1) == "）" ||
                    hzString.Substring(i, 1) == "，" || hzString.Substring(i, 1) == "、" ||
                    hzString.Substring(i, 1) == "！" || hzString.Substring(i, 1) == "？" ||
                    hzString.Substring(i, 1) == "＆" || hzString.Substring(i, 1) == "％")
                    abbrString.Append(String.Empty);
                else
                    if (!ConvertToPinyin(hzString.Substring(i, 1)).Equals(String.Empty))
                        abbrString.Append(ConvertToPinyin(hzString.Substring(i, 1)).Substring(0, 1));
            }

            return abbrString.ToString();
        }
        #endregion

        #region 替换特殊字符
        /// <summary>
        /// 替换特殊字符
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string FilterData(string Htmlstring)
        {

            if (Htmlstring == null)
            {

                return "";

            }

            else
            {
                //删除脚本

                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

                //删除HTML

                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

               // Htmlstring = Regex.Replace(Htmlstring, @"([rn])[s]+", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);



                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "xa1", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "xa2", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "xa3", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "xa9", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&#(d+);", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, "/r", "", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, "/n", "", RegexOptions.IgnoreCase);



                //特殊的字符

                Htmlstring = Htmlstring.Replace("*", "");

                Htmlstring = Htmlstring.Replace("--", "");

                Htmlstring = Htmlstring.Replace("?", "");

                Htmlstring = Htmlstring.Replace(",", "");

                Htmlstring = Htmlstring.Replace("/", "");

                Htmlstring = Htmlstring.Replace(";", "");

                Htmlstring = Htmlstring.Replace("*/", "");

                Htmlstring = Htmlstring.Replace("rn", "");

                Htmlstring = Htmlstring.Replace("'", "");

               // Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();



                return Htmlstring;

            }



        }
        #endregion

    }
}

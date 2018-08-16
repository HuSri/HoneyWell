using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace HoneyWell.Admin.Method
{
    public class Filter
    {
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

                //Htmlstring = Regex.Replace(Htmlstring, @"([rn])[s]+", "", RegexOptions.IgnoreCase);

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

                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();



                return Htmlstring;

            } 

        }
    }
}
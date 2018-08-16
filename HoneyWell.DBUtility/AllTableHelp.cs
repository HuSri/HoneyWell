using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HoneyWell.DBUtility
{
    public class AllTableHelp
    {
        public static string jiaId(string id)
        {
            return new SymmetricMethod().Encrypto(id);
        }


        public static string jieMi(string id)
        {
            return new SymmetricMethod().Decrypto(id);
        }

        public static int jieId(string id)
        {
            try
            {
                return int.Parse(jieMi(id));
            }
            catch { return 0; }
        }

    }
}

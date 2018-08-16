using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HoneyWell.DAL
{
   public class SysConn
    {
        public static readonly string PublicConn = ConfigurationManager.AppSettings["PublicConn"].ToString();
    }
}

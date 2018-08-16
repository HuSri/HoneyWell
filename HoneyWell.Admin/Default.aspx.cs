using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.Admin.Method;

namespace HoneyWell.Admin
{
    public partial class Default : UserPage
    {
        public string LoginName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginName = GetUserName();

            }
        }
    }
}
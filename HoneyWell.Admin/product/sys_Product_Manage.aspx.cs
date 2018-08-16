using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyWell.COMM;
using HoneyWell.DBUtility;
using HoneyWell.Admin.Method;

namespace HoneyWell.Admin.product
{
    public partial class sys_Product_Manage : UserPage
    {
        public int PKID = 0;
        public string StrClass1 = "";
        public string StrClass2 = "";
        public string StrClass3 = "";
        public string PName = "";
        public string PTypeMain = "";
        public string PTypeSmall = "";
        public string PProperty = "";
        public decimal PMarket = 0;
        public decimal PRetail = 0;
        public string PFormat = "";
        public string PParam = "";
        public string PMould = "";
        public int PStock = 0;
        public string PRecommend = "";
        public string PShelf = "";

        public string PPic = "";
        public string PPic_List = "";

        public string DPic = "";
        public string DPic_List = ""; 

        public string ImgBigUrl = "";

        //查询信息
        public string Ptypemain = "";
        public string Ptypesmall = "";
        public string Pname = "";
        public string Pageindex = "";
        public string Precommend = "";
        public string Pshelf = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Ttext"]))
                {
                    PKID = Utils.ToInt(Encrypt.PageDispelParam(Request["Ttext"]));
                }          
                if (PKID > 0)
                {
                    SelectInfo();
                    BindModel();
                    PtypeMainUpdate();
                    PtypeSmallUpdate();
                    PPropertyUpdate();
                }
                else {
                    PtypeMainAdd();
                    PtypeSmallAdd();
                    PPropertyAdd();
                    PPic = "../images/upload_img.jpg";
                    DPic = "../images/upload_img.jpg"; 
                }
            }         
        }

        #region 查询条件信息
        void SelectInfo()
        {
            if (!string.IsNullOrEmpty(Request["Pageindex"]))
            {
                Pageindex = Request["Pageindex"];
            }
            if (!string.IsNullOrEmpty(Request["Ptypemain"]))
            {
                Ptypemain = Request["Ptypemain"];
            }
            if (!string.IsNullOrEmpty(Request["Ptypesmall"]))
            {
                Ptypesmall = Request["Ptypesmall"];
            }
            if (!string.IsNullOrEmpty(Request["Pname"]))
            {
                Pname = Request["Pname"];
            }
            if (!string.IsNullOrEmpty(Request["Precommend"]))
            {
                Precommend = Request["Precommend"];
            }
            if (!string.IsNullOrEmpty(Request["Pshelf"]))
            {
                Pshelf = Request["Pshelf"];
            }
        }
        #endregion
        
        /// <summary>
        /// 绑定对象
        /// </summary>
        void BindModel()
        {
            BLL.Sys_Product sys_BLL = new BLL.Sys_Product();
            Model.Sys_Product sys_Model = sys_BLL.GetModel(PKID);
            PTypeMain = sys_Model.PTypeMain.ToString();
            PTypeSmall = sys_Model.PTypeSmall.ToString();
            PProperty=sys_Model.PProperty;
            PName = sys_Model.PName;
            PMarket =sys_Model.PMarket;
            PRetail = sys_Model.PRetail;
            PFormat = sys_Model.PFormat;
            PParam = sys_Model.PParam;
            PMould = sys_Model.PMould;
            PStock = sys_Model.PStock;
            PRecommend = sys_Model.PRecommend;
            PShelf = sys_Model.PShelf;
            txtPDetails.Value = sys_Model.PDetails;
            PPic = sys_Model.PSmallPic;
            DPic = sys_Model.PDetailPic;
            if (PPic != "")
            {
                string[] sArray = PPic.Split(',');
                foreach (string j in sArray)
                {
                    PPic_List += "<li>";
                    PPic_List += "<input type=\"hidden\" name=\"ImgName\" value=\"" + j.ToString() + "\" />";
                    PPic_List += "<div class=\"img-box\">";
                    PPic_List += "<img src=\"" + GetImgUrl() + "/upload/product/"+ j.ToString() + "\" onclick=\"setOpenImg(this.src);\" bigsrc=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" />";
                    PPic_List += "</div>";
                    PPic_List += "<a href=\"javascript:;\" onclick=\"delImg(this);\">删除</a>";
                    PPic_List += "</li>";
                }
            } 

            if (DPic != "")
            {
                string[] sArray = DPic.Split(',');
                foreach (string j in sArray)
                {
                    DPic_List += "<li>";
                    DPic_List += "<input type=\"hidden\" name=\"ImgName\" value=\"" + j.ToString() + "\" />";
                    DPic_List += "<div class=\"img-box\">";
                    DPic_List += "<img src=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\"  onclick=\"setOpenImg(this.src);\" bigsrc=\"" + GetImgUrl() + "/upload/product/" + j.ToString() + "\" />";
                    DPic_List += "</div> ";
                    DPic_List += "<a href=\"javascript:;\" onclick=\"delImg(this);\">删除</a>";
                    DPic_List += "</li>";
                }
            } 
            
        }

        /// <summary>
        /// 初始化大类-新增
        /// </summary>
        void PtypeMainAdd()
        {
            DataSet ds = new BLL.Sys_Public().SelectData("TCode,TName", "Sys_Type", "and ParentId=0 Order by TOrder");
            DataTable dt = new DataTable();
            StringBuilder sbType = new StringBuilder();
            if (ds != null)
                dt = ds.Tables[0];
            //拼接HTML
            sbType.Append("<option value='0'>==请选择==</option>");
            foreach (DataRow dr in dt.Rows)
            {
                sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + "  >");
                sbType.Append("" + StringHelper.NullToStr(dr["TName"]) + "");
                sbType.Append("</option>");
            }

            StrClass1 = sbType.ToString();
        }

        /// <summary>
        /// 初始化大类-更新
        /// </summary>
        void PtypeMainUpdate()
        {
            DataSet ds = new BLL.Sys_Public().SelectData("TCode,TName", "Sys_Type", "and ParentId=0 Order by TOrder");
            DataTable dt = new DataTable();
            string str_selected = "";
            StringBuilder sbType = new StringBuilder();
            if (ds != null)
                dt = ds.Tables[0];
            //拼接HTML-信息类型
            if (PTypeMain=="")
            {
                str_selected = "selected=\"selected\"";
            }
            sbType.Append("<option value='0' " + str_selected + ">==请选择==</option>");
            foreach (DataRow dr in dt.Rows)
            {
                if (Utils.ToString(StringHelper.NullToStr(dr["TCode"])) == PTypeMain)
                {
                    sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + " selected=\"selected\">");
                    sbType.Append("" + StringHelper.NullToStr(dr["TName"]) + "");
                    sbType.Append("</option>");
                }
                else
                {
                    sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + "  >");
                    sbType.Append("" + StringHelper.NullToStr(dr["TName"]) + "");
                    sbType.Append("</option>");
                }

            }

            StrClass1 = sbType.ToString();
        }

        /// <summary>
        /// 初始化小类-新增
        /// </summary>
        void PtypeSmallAdd()
        {
            StrClass2 ="<option value=\"0\">==请选择==</option>";
        }

        /// <summary>
        /// 初始化小类-更新
        /// </summary>
        void PtypeSmallUpdate()
        {
            DataTable dt = new BLL.Sys_Public().SelectData("ID,TName", "Sys_Type", "and TLevel=1 and TCode='"+PTypeMain+"' Order by TOrder").Tables[0];
            StringBuilder sbType = new StringBuilder();
            if (dt!=null && dt.Rows.Count>0)
            {
                DataSet ds1 = new BLL.Sys_Public().SelectData("TCode,TName", "Sys_Type", "and TLevel=2 and  ParentId="+dt.Rows[0]["ID"]+" Order by TOrder");
                DataTable dt1 = new DataTable();
                string str_selected = "";
                if (ds1 != null)
                    dt1 = ds1.Tables[0];
                //拼接HTML-信息类型
                if (PTypeMain == "")
                {
                    str_selected = "selected=\"selected\"";
                    sbType.Append("<option value='0' " + str_selected + ">==请选择==</option>");
                }

                foreach (DataRow dr in dt1.Rows)
                {
                    if (Utils.ToString(StringHelper.NullToStr(dr["TCode"])) == PTypeSmall)
                    {
                        sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + " selected=\"selected\">");
                        sbType.Append("" + StringHelper.NullToStr(dr["TName"]) + "");
                        sbType.Append("</option>");
                    }
                    else
                    {
                        sbType.Append("<option value=" + StringHelper.NullToStr(dr["TCode"]) + "  >");
                        sbType.Append("" + StringHelper.NullToStr(dr["TName"]) + "");
                        sbType.Append("</option>");
                    }

                }
            }
            StrClass2 = sbType.ToString();
        }
        /// <summary>
        /// 属性新增
        /// </summary>
        void PPropertyAdd()
        {
            StrClass3 += "<option value=\"0\">==请选择==</option>";
            StrClass3 += "<option value=\"1\">一级</option>";
            StrClass3 += "<option value=\"2\">二级</option>";
            StrClass3 += "<option value=\"3\">三级</option>";
            StrClass3 += "<option value=\"4\">四级</option>";
            StrClass3 += "<option value=\"5\">五级</option>";
        }
        /// <summary>
        /// 属性更新
        /// </summary>
        public void  PPropertyUpdate( )
        {
            string selected1 = "";
            string selected2 = "";
            string selected3 = "";
            string selected4 = "";
            string selected5 = "";
            StringBuilder sbType = new StringBuilder();
            if (PProperty=="1")
            {
                selected1 = "selected";
            }
           else if (PProperty == "2")
            {
                selected2 = "selected";
            }
           else if (PProperty == "3")
            {
                selected3 = "selected";
            }
           else if (PProperty == "4")
            {
                selected4 = "selected";
            }
            else 
            {   
                selected5 = "selected";
            } 
            sbType.Append("<option value=\"1\" " + selected1 + ">一级</option>");
            sbType.Append("<option value=\"2\" " + selected2 + ">二级</option>");
            sbType.Append("<option value=\"3\" " + selected3 + ">三级</option>");
            sbType.Append("<option value=\"4\" " + selected4 + ">四级</option>");
            sbType.Append("<option value=\"5\" " + selected5 + ">五级</option>");
            sbType.Append("</select>");
            StrClass3 = sbType.ToString();
        }
        
    }
}
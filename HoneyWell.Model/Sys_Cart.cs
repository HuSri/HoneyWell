using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Cart
		public class Sys_Cart
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 手机号（登录账号）
        /// </summary>		
		private string _phone;
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }        
		/// <summary>
		/// 产品ID
        /// </summary>		
		private int _pid;
        public int PID
        {
            get{ return _pid; }
            set{ _pid = value; }
        }        
		/// <summary>
		/// 产品名称
        /// </summary>		
		private string _cname;
        public string CName
        {
            get{ return _cname; }
            set{ _cname = value; }
        }        
		/// <summary>
		/// 产品缩略图
        /// </summary>		
		private string _csmallpic;
        public string CSmallPic
        {
            get{ return _csmallpic; }
            set{ _csmallpic = value; }
        }        
		/// <summary>
		/// 产品规格
        /// </summary>		
		private string _cformat;
        public string CFormat
        {
            get{ return _cformat; }
            set{ _cformat = value; }
        }        
		/// <summary>
		/// 市场价
        /// </summary>		
		private decimal _cmarket;
        public decimal CMarket
        {
            get{ return _cmarket; }
            set{ _cmarket = value; }
        }        
		/// <summary>
		/// 零售价
        /// </summary>		
		private decimal _cretail;
        public decimal CRetail
        {
            get{ return _cretail; }
            set{ _cretail = value; }
        }        
		/// <summary>
		/// 购买数量
        /// </summary>		
		private int _cquantity;
        public int CQuantity
        {
            get{ return _cquantity; }
            set{ _cquantity = value; }
        }        
		/// <summary>
		/// 添加人
        /// </summary>		
		private string _createuser;
        public string CreateUser
        {
            get{ return _createuser; }
            set{ _createuser = value; }
        }        
		/// <summary>
		/// 添加时间
        /// </summary>		
		private DateTime _createtime = DateTime.Now;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// 修改人
        /// </summary>		
		private string _modifyuser;
        public string ModifyUser
        {
            get{ return _modifyuser; }
            set{ _modifyuser = value; }
        }        
		/// <summary>
		/// 修改时间
        /// </summary>		
		private DateTime _modifytime = DateTime.Now;
        public DateTime ModifyTime
        {
            get{ return _modifytime; }
            set{ _modifytime = value; }
        }        
		/// <summary>
		/// 扩充字段1
        /// </summary>		
		private string _morecol1;
        public string MoreCol1
        {
            get{ return _morecol1; }
            set{ _morecol1 = value; }
        }        
		/// <summary>
		/// 扩充字段2
        /// </summary>		
		private string _morecol2;
        public string MoreCol2
        {
            get{ return _morecol2; }
            set{ _morecol2 = value; }
        }        
		   
	}
}
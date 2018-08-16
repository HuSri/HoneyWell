using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Shopping
		public class Sys_Shopping
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
		/// 订单编号
        /// </summary>		
		private string _onumber;
        public string ONumber
        {
            get{ return _onumber; }
            set{ _onumber = value; }
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
		private string _sname;
        public string SName
        {
            get{ return _sname; }
            set{ _sname = value; }
        }        
		/// <summary>
		/// 产品缩略图
        /// </summary>		
		private string _ssmallpic;
        public string SSmallPic
        {
            get{ return _ssmallpic; }
            set{ _ssmallpic = value; }
        }        
		/// <summary>
		/// 市场价
        /// </summary>		
		private decimal _smarket;
        public decimal SMarket
        {
            get{ return _smarket; }
            set{ _smarket = value; }
        }        
		/// <summary>
		/// 零售价
        /// </summary>		
		private decimal _sretail;
        public decimal SRetail
        {
            get{ return _sretail; }
            set{ _sretail = value; }
        }        
		/// <summary>
		/// 产品规格
        /// </summary>		
		private string _sformat;
        public string SFormat
        {
            get{ return _sformat; }
            set{ _sformat = value; }
        }        
		/// <summary>
		/// 购买数量
        /// </summary>		
		private int _squantity;
        public int SQuantity
        {
            get{ return _squantity; }
            set{ _squantity = value; }
        }        
		/// <summary>
		/// 合计金额
        /// </summary>		
		private decimal _ssum;
        public decimal SSum
        {
            get{ return _ssum; }
            set{ _ssum = value; }
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
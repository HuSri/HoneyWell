using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Coupon
		public class Sys_Coupon
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
		/// 优惠券类型
        /// </summary>		
		private string _ctype;
        public string CType
        {
            get{ return _ctype; }
            set{ _ctype = value; }
        }        
		/// <summary>
		/// 优惠券编码
        /// </summary>		
		private string _ccode;
        public string CCode
        {
            get{ return _ccode; }
            set{ _ccode = value; }
        }        
		/// <summary>
		/// 优惠券名称
        /// </summary>		
		private string _cname;
        public string CName
        {
            get{ return _cname; }
            set{ _cname = value; }
        }        
		/// <summary>
		/// 总计金额
        /// </summary>		
		private decimal _csum;
        public decimal CSum
        {
            get{ return _csum; }
            set{ _csum = value; }
        }        
		/// <summary>
		/// 抵扣金额
        /// </summary>		
		private decimal _cdeduction;
        public decimal CDeduction
        {
            get{ return _cdeduction; }
            set{ _cdeduction = value; }
        }        
		/// <summary>
		/// 发行数量
        /// </summary>		
		private int _issuenum;
        public int IssueNum
        {
            get{ return _issuenum; }
            set{ _issuenum = value; }
        }        
		/// <summary>
		/// 开始时间
        /// </summary>		
		private DateTime _startingtime;
        public DateTime StartingTime
        {
            get{ return _startingtime; }
            set{ _startingtime = value; }
        }        
		/// <summary>
		/// 结束时间
        /// </summary>		
		private DateTime _endtime;
        public DateTime EndTime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
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
		private DateTime _createtime;
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
		private DateTime _modifytime;
        public DateTime ModifyTime
        {
            get{ return _modifytime; }
            set{ _modifytime = value; }
        }        
		/// <summary>
		/// 可扩充字段1
        /// </summary>		
		private string _morecol1;
        public string MoreCol1
        {
            get{ return _morecol1; }
            set{ _morecol1 = value; }
        }        
		/// <summary>
		/// 可扩充字段2
        /// </summary>		
		private string _morecol2;
        public string MoreCol2
        {
            get{ return _morecol2; }
            set{ _morecol2 = value; }
        }        
		   
	}
}
using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Coupon_Details
		public class Sys_Coupon_Details
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
		/// 主编号
        /// </summary>		
		private string _ccode;
        public string CCode
        {
            get{ return _ccode; }
            set{ _ccode = value; }
        }        
		/// <summary>
		/// 明细编号
        /// </summary>		
		private string _csmallcode;
        public string CSmallCode
        {
            get{ return _csmallcode; }
            set{ _csmallcode = value; }
        }        
		/// <summary>
		/// 数量
        /// </summary>		
		private int _cnum;
        public int CNum
        {
            get{ return _cnum; }
            set{ _cnum = value; }
        }        
		/// <summary>
		/// 生成时间
        /// </summary>		
		private DateTime _ctime;
        public DateTime CTime
        {
            get{ return _ctime; }
            set{ _ctime = value; }
        }        
		/// <summary>
		/// 状态
        /// </summary>		
		private string _cstate;
        public string CState
        {
            get{ return _cstate; }
            set{ _cstate = value; }
        }        
		/// <summary>
		/// 领取人
        /// </summary>		
		private string _receiveuser;
        public string ReceiveUser
        {
            get{ return _receiveuser; }
            set{ _receiveuser = value; }
        }        
		/// <summary>
		/// 领取时间
        /// </summary>		
		private DateTime _receivetime;
        public DateTime ReceiveTime
        {
            get{ return _receivetime; }
            set{ _receivetime = value; }
        }        
		   
	}
}
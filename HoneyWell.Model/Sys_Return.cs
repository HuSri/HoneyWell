using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Return
		public class Sys_Return
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
		/// 订单编号
        /// </summary>		
		private string _onumber;
        public string ONumber
        {
            get{ return _onumber; }
            set{ _onumber = value; }
        }        
		/// <summary>
		/// 退货理由
        /// </summary>		
		private string _rreason;
        public string RReason
        {
            get{ return _rreason; }
            set{ _rreason = value; }
        }        
		/// <summary>
		/// 申请时间
        /// </summary>		
		private DateTime _ratime;
        public DateTime RATime
        {
            get{ return _ratime; }
            set{ _ratime = value; }
        }        
		/// <summary>
		/// 退货回复
        /// </summary>		
		private string _rreply;
        public string RReply
        {
            get{ return _rreply; }
            set{ _rreply = value; }
        }        
		/// <summary>
		/// RReplyTime
        /// </summary>		
		private DateTime _rreplytime;
        public DateTime RReplyTime
        {
            get{ return _rreplytime; }
            set{ _rreplytime = value; }
        }        
		/// <summary>
		/// RStatus
        /// </summary>		
		private string _rstatus;
        public string RStatus
        {
            get{ return _rstatus; }
            set{ _rstatus = value; }
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
using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Admin
		public class Sys_Admin
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
		/// 用户名
        /// </summary>		
		private string _ausername;
        public string AUserName
        {
            get{ return _ausername; }
            set{ _ausername = value; }
        }        
		/// <summary>
		/// 密码
        /// </summary>		
		private string _apassword;
        public string APassWord
        {
            get{ return _apassword; }
            set{ _apassword = value; }
        }        
		/// <summary>
		/// 真实姓名
        /// </summary>		
		private string _truename;
        public string TrueName
        {
            get{ return _truename; }
            set{ _truename = value; }
        }        
		/// <summary>
		/// 角色ID
        /// </summary>		
		private int _dutyid;
        public int DutyID
        {
            get{ return _dutyid; }
            set{ _dutyid = value; }
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
		/// 添加时间
        /// </summary>		
		private DateTime _createtime=DateTime.Now;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
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
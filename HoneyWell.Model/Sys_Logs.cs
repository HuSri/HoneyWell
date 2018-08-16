using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Logs
		public class Sys_Logs
	{
   		     
      	/// <summary>
		/// 日志ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 角色ID
        /// </summary>		
		private int _dutyid;
        public int DutyId
        {
            get{ return _dutyid; }
            set{ _dutyid = value; }
        }        
		/// <summary>
		/// 用户名
        /// </summary>		
		private string _loginname;
        public string LoginName
        {
            get{ return _loginname; }
            set{ _loginname = value; }
        }        
		/// <summary>
		/// 标  题
        /// </summary>		
		private string _titlename;
        public string TitleName
        {
            get{ return _titlename; }
            set{ _titlename = value; }
        }        
		/// <summary>
		/// 内  容
        /// </summary>		
		private string _depicts;
        public string Depicts
        {
            get{ return _depicts; }
            set{ _depicts = value; }
        }        
		/// <summary>
		/// IP地址
        /// </summary>		
		private string _ipaddress;
        public string IpAddress
        {
            get{ return _ipaddress; }
            set{ _ipaddress = value; }
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
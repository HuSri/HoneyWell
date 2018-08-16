using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Type
		public class Sys_Type
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
		/// 类别编码
        /// </summary>		
		private string _tcode;
        public string TCode
        {
            get{ return _tcode; }
            set{ _tcode = value; }
        }        
		/// <summary>
		/// 类别名称
        /// </summary>		
		private string _tname;
        public string TName
        {
            get{ return _tname; }
            set{ _tname = value; }
        }        
		/// <summary>
		/// 类别缩略图
        /// </summary>		
		private string _tsmallpic;
        public string TSmallPic
        {
            get{ return _tsmallpic; }
            set{ _tsmallpic = value; }
        }        
		/// <summary>
		/// 类别级别
        /// </summary>		
		private int _tlevel;
        public int TLevel
        {
            get{ return _tlevel; }
            set{ _tlevel = value; }
        }        
		/// <summary>
		/// 父级ID
        /// </summary>		
		private int _parentid;
        public int ParentId
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }        
		/// <summary>
		/// 类别顺序
        /// </summary>		
		private int _torder;
        public int TOrder
        {
            get{ return _torder; }
            set{ _torder = value; }
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
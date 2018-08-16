using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Area
		public class Sys_Area
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
		/// 区域编号
        /// </summary>		
		private string _areacode;
        public string AreaCode
        {
            get{ return _areacode; }
            set{ _areacode = value; }
        }        
		/// <summary>
		/// 区域名称
        /// </summary>		
		private string _areaname;
        public string AreaName
        {
            get{ return _areaname; }
            set{ _areaname = value; }
        }        
		/// <summary>
		/// 父ID
        /// </summary>		
		private string _parentareacode;
        public string ParentAreaCode
        {
            get{ return _parentareacode; }
            set{ _parentareacode = value; }
        }        
		/// <summary>
		/// 层级标记
        /// </summary>		
		private int _arealevel;
        public int AreaLevel
        {
            get{ return _arealevel; }
            set{ _arealevel = value; }
        }        
		/// <summary>
		/// 顺序
        /// </summary>		
		private int _areaorder;
        public int AreaOrder
        {
            get{ return _areaorder; }
            set{ _areaorder = value; }
        }        
		/// <summary>
		/// 关键字
        /// </summary>		
		private string _keyword;
        public string KeyWord
        {
            get{ return _keyword; }
            set{ _keyword = value; }
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
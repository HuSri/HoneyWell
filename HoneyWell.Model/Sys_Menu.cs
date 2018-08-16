using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Menu
		public class Sys_Menu
	{
   		     
      	/// <summary>
		/// 模块权限ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 菜单代码
        /// </summary>		
		private string _menucode;
        public string MenuCode
        {
            get{ return _menucode; }
            set{ _menucode = value; }
        }        
		/// <summary>
		/// 菜单中文名
        /// </summary>		
		private string _menunamec;
        public string MenuNameC
        {
            get{ return _menunamec; }
            set{ _menunamec = value; }
        }        
		/// <summary>
		/// 菜单英文名
        /// </summary>		
		private string _menunamee;
        public string MenuNameE
        {
            get{ return _menunamee; }
            set{ _menunamee = value; }
        }        
		/// <summary>
		/// 父节点
        /// </summary>		
		private int _parentid;
        public int ParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }        
		/// <summary>
		/// 节点值
        /// </summary>		
		private int _menulevel;
        public int MenuLevel
        {
            get{ return _menulevel; }
            set{ _menulevel = value; }
        }        
		/// <summary>
		/// 顺序
        /// </summary>		
		private int _menuorder;
        public int MenuOrder
        {
            get{ return _menuorder; }
            set{ _menuorder = value; }
        }        
		/// <summary>
		/// 链接地址
        /// </summary>		
		private string _menuurl;
        public string MenuUrl
        {
            get{ return _menuurl; }
            set{ _menuurl = value; }
        }        
		/// <summary>
		/// 菜单说明
        /// </summary>		
		private string _menudesc;
        public string MenuDesc
        {
            get{ return _menudesc; }
            set{ _menudesc = value; }
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
using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Users
		public class Sys_Users
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
		/// 微信ID
        /// </summary>		
		private string _openid;
        public string OpenID
        {
            get{ return _openid; }
            set{ _openid = value; }
        }        
		/// <summary>
		/// 手机号(登陆账号)
        /// </summary>		
		private string _phone;
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }        
		/// <summary>
		/// 密码
        /// </summary>		
		private string _password;
        public string PassWord
        {
            get{ return _password; }
            set{ _password = value; }
        }        
		/// <summary>
		/// 用户姓名
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// 头像
        /// </summary>		
		private string _smallpic;
        public string SmallPic
        {
            get{ return _smallpic; }
            set{ _smallpic = value; }
        }        
		/// <summary>
		/// 昵称
        /// </summary>		
		private string _nickname;
        public string NickName
        {
            get{ return _nickname; }
            set{ _nickname = value; }
        }        
		/// <summary>
		/// 出生日期
        /// </summary>		
		private DateTime _datebirth;
        public DateTime DateBirth
        {
            get{ return _datebirth; }
            set{ _datebirth = value; }
        }        
		/// <summary>
		/// 性别
        /// </summary>		
		private string _sex;
        public string Sex
        {
            get{ return _sex; }
            set{ _sex = value; }
        }        
		/// <summary>
		/// 邮箱
        /// </summary>		
		private string _email;
        public string Email
        {
            get{ return _email; }
            set{ _email = value; }
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
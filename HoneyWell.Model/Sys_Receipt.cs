using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Receipt
		public class Sys_Receipt
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
		/// 省份
        /// </summary>		
		private string _province;
        public string Province
        {
            get{ return _province; }
            set{ _province = value; }
        }        
		/// <summary>
		/// 所属城市
        /// </summary>		
		private string _city;
        public string City
        {
            get{ return _city; }
            set{ _city = value; }
        }        
		/// <summary>
		/// 所属地区
        /// </summary>		
		private string _area;
        public string Area
        {
            get{ return _area; }
            set{ _area = value; }
        }        
		/// <summary>
		/// 街道信息
        /// </summary>		
		private string _raddress;
        public string RAddress
        {
            get{ return _raddress; }
            set{ _raddress = value; }
        }        
		/// <summary>
		/// 收货人姓名
        /// </summary>		
		private string _rname;
        public string RName
        {
            get{ return _rname; }
            set{ _rname = value; }
        }        
		/// <summary>
		/// 收货人手机号
        /// </summary>		
		private string _rphone;
        public string RPhone
        {
            get{ return _rphone; }
            set{ _rphone = value; }
        }        
		/// <summary>
		/// 邮政编码
        /// </summary>		
		private string _rzipcode;
        public string RZipCode
        {
            get{ return _rzipcode; }
            set{ _rzipcode = value; }
        }        
		/// <summary>
		/// 是否默认
        /// </summary>		
		private string _rdefault;
        public string RDefault
        {
            get{ return _rdefault; }
            set{ _rdefault = value; }
        }        
		   
	}
}
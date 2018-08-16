using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Invoice
		public class Sys_Invoice
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
		/// 发票编码
        /// </summary>		
		private string _icode;
        public string ICode
        {
            get{ return _icode; }
            set{ _icode = value; }
        }        
		/// <summary>
		/// 发票抬头
        /// </summary>		
		private string _igainground;
        public string IGainGround
        {
            get{ return _igainground; }
            set{ _igainground = value; }
        }        
		/// <summary>
		/// 发票税号
        /// </summary>		
		private string _itaxnumber;
        public string ITaxNumber
        {
            get{ return _itaxnumber; }
            set{ _itaxnumber = value; }
        }        
		/// <summary>
		/// 备注说明
        /// </summary>		
		private string _iremarks;
        public string IRemarks
        {
            get{ return _iremarks; }
            set{ _iremarks = value; }
        }        
		   
	}
}
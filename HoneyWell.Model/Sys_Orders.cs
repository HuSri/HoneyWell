using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Orders
		public class Sys_Orders
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
        /// 用户账号
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
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
		/// 发票类型
        /// </summary>		
		private string _otype;
        public string OType
        {
            get{ return _otype; }
            set{ _otype = value; }
        }        
		/// <summary>
		/// 安装费
        /// </summary>		
		private decimal _ofee;
        public decimal OFee
        {
            get{ return _ofee; }
            set{ _ofee = value; }
        }        
		/// <summary>
		/// 快递公司
        /// </summary>		
		private string _ccompany;
        public string CCompany
        {
            get{ return _ccompany; }
            set{ _ccompany = value; }
        }        
		/// <summary>
		/// 快递单号
        /// </summary>		
		private string _snumber;
        public string SNumber
        {
            get{ return _snumber; }
            set{ _snumber = value; }
        }        
		/// <summary>
		/// OFare
        /// </summary>		
		private decimal _ofare;
        public decimal OFare
        {
            get{ return _ofare; }
            set{ _ofare = value; }
        }        
		/// <summary>
		/// 应付金额
        /// </summary>		
		private decimal _ocope;
        public decimal OCope
        {
            get{ return _ocope; }
            set{ _ocope = value; }
        }        
		/// <summary>
		/// 实付金额(订单金额)
        /// </summary>		
		private decimal _oactuallypaid;
        public decimal OActuallyPaid
        {
            get{ return _oactuallypaid; }
            set{ _oactuallypaid = value; }
        }        
		/// <summary>
		/// 支付方式
        /// </summary>		
		private string _itype;
        public string IType
        {
            get{ return _itype; }
            set{ _itype = value; }
        }        
		/// <summary>
		/// 收货人姓名
        /// </summary>		
		private string _oname;
        public string OName
        {
            get{ return _oname; }
            set{ _oname = value; }
        }        
		/// <summary>
		/// 收货人手机号
        /// </summary>		
		private string _ophone;
        public string OPhone
        {
            get{ return _ophone; }
            set{ _ophone = value; }
        }        
		/// <summary>
		/// 收货人省份
        /// </summary>		
		private string _province;
        public string Province
        {
            get{ return _province; }
            set{ _province = value; }
        }        
		/// <summary>
		/// 收货人城市
        /// </summary>		
		private string _city;
        public string City
        {
            get{ return _city; }
            set{ _city = value; }
        }        
		/// <summary>
		/// 收货人区县
        /// </summary>		
		private string _area;
        public string Area
        {
            get{ return _area; }
            set{ _area = value; }
        }        
		/// <summary>
		/// 收货人街道信息
        /// </summary>		
		private string _oaddress;
        public string OAddress
        {
            get{ return _oaddress; }
            set{ _oaddress = value; }
        }        
		/// <summary>
		/// 订单状态
        /// </summary>		
		private string _ostatus;
        public string OStatus
        {
            get{ return _ostatus; }
            set{ _ostatus = value; }
        }        
		/// <summary>
		/// 备注说明
        /// </summary>		
		private string _remarks;
        public string Remarks
        {
            get{ return _remarks; }
            set{ _remarks = value; }
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
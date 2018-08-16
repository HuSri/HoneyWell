using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HoneyWell.Model{
	 	//Sys_Product
		public class Sys_Product
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
		/// 产品大类
        /// </summary>		
		private string _ptypemain;
        public string PTypeMain
        {
            get{ return _ptypemain; }
            set{ _ptypemain = value; }
        }
        /// <summary>
        /// 产品小类
        /// </summary>		
        private string _ptypesmall;
        public string PTypeSmall
        {
            get { return _ptypesmall; }
            set { _ptypesmall = value; }
        }
        /// <summary>
        /// 产品属性
        /// </summary>		
        private string _pproperty;
        public string PProperty
        {
            get { return _pproperty; }
            set { _pproperty = value; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>		
        private string _pname;
        public string PName
        {
            get{ return _pname; }
            set{ _pname = value; }
        }        
		/// <summary>
		/// 产品缩略图
        /// </summary>		
		private string _psmallpic;
        public string PSmallPic
        {
            get{ return _psmallpic; }
            set{ _psmallpic = value; }
        }        
		/// <summary>
		/// 产品详情图
        /// </summary>		
		private string _pdetailpic;
        public string PDetailPic
        {
            get{ return _pdetailpic; }
            set{ _pdetailpic = value; }
        }        
		/// <summary>
		/// 市场价
        /// </summary>		
		private decimal _pmarket;
        public decimal PMarket
        {
            get{ return _pmarket; }
            set{ _pmarket = value; }
        }        
		/// <summary>
		/// 零售价
        /// </summary>		
		private decimal _pretail;
        public decimal PRetail
        {
            get{ return _pretail; }
            set{ _pretail = value; }
        }        
		/// <summary>
		/// 产品规格
        /// </summary>		
		private string _pformat;
        public string PFormat
        {
            get{ return _pformat; }
            set{ _pformat = value; }
        }        
		/// <summary>
		/// 产品参数
        /// </summary>		
		private string _pparam;
        public string PParam
        {
            get{ return _pparam; }
            set{ _pparam = value; }
        }        
		/// <summary>
		/// 适用机型
        /// </summary>		
		private string _pmould;
        public string PMould
        {
            get{ return _pmould; }
            set{ _pmould = value; }
        }        
		/// <summary>
		/// 产品详情
        /// </summary>		
		private string _pdetails;
        public string PDetails
        {
            get{ return _pdetails; }
            set{ _pdetails = value; }
        }        
		/// <summary>
		/// 是否推荐
        /// </summary>		
		private string _precommend;
        public string PRecommend
        {
            get{ return _precommend; }
            set{ _precommend = value; }
        }        
		/// <summary>
		/// 是否上架
        /// </summary>		
		private string _pshelf;
        public string PShelf
        {
            get{ return _pshelf; }
            set{ _pshelf = value; }
        }        
		/// <summary>
		/// 库存数量
        /// </summary>		
		private int _pstock;
        public int PStock
        {
            get{ return _pstock; }
            set{ _pstock = value; }
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
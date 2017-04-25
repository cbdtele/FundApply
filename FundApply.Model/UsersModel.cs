/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 16:59:41   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace FundApply.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UsersModel
	{
		public UsersModel()
		{}
		#region Model
		private int _id;
		private string _nat_org_code;
        private string _company;
        private string _password;
		private string _linkMan1;
		private string _linkman2;
		private string _mobilephone1;
		private string _mobilephone2;
		private string _telephone1;
		private string _telephone2;
		private string _email1;
		private string _email2;
		private int _state=1;
		private DateTime _createtime;
		private DateTime _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 组织机构代码/统一社会信用代码
		/// </summary>
		public string Nat_Org_Code
		{
			set{ _nat_org_code=value;}
			get{return _nat_org_code;}
		}

        /// <summary>
        /// 组织机构代码/统一社会信用代码
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 联系人1
		/// </summary>
		public string LinkMan1
		{
			set{ _linkMan1=value;}
			get{return _linkMan1;}
		}
		/// <summary>
		/// 联系人2
		/// </summary>
		public string LinkMan2
		{
			set{ _linkman2=value;}
			get{return _linkman2;}
		}
		/// <summary>
		/// 手机1
		/// </summary>
		public string MobilePhone1
		{
			set{ _mobilephone1=value;}
			get{return _mobilephone1;}
		}
		/// <summary>
		/// 手机2
		/// </summary>
		public string MobilePhone2
		{
			set{ _mobilephone2=value;}
			get{return _mobilephone2;}
		}
		/// <summary>
		/// 固定电话1
		/// </summary>
		public string Telephone1
		{
			set{ _telephone1=value;}
			get{return _telephone1;}
		}
		/// <summary>
		/// 固定电话2
		/// </summary>
		public string Telephone2
		{
			set{ _telephone2=value;}
			get{return _telephone2;}
		}
		/// <summary>
		/// 邮箱1
		/// </summary>
		public string Email1
		{
			set{ _email1=value;}
			get{return _email1;}
		}
		/// <summary>
		/// 邮箱2
		/// </summary>
		public string Email2
		{
			set{ _email2=value;}
			get{return _email2;}
		}
		/// <summary>
		/// 状态 默认1：启用，2禁用
		/// </summary>
		public int State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}


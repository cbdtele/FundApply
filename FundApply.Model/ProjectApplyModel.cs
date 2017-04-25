/**  版本信息模板在安装目录下，可自行修改。
* ProjectApply.cs
*
* 功 能： N/A
* 类 名： ProjectApply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 19:27:29   N/A    初版
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
	/// ProjectApply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProjectApplyModel
	{
		public ProjectApplyModel()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _company;
		private int _industryid;
		private decimal _yysr;
		private decimal _tax;
		private int _employee;
		private string _regaddress;
		private string _businessaddress;
		private int _applytypeid;
		private decimal _applyfund;
		private string _attachment;
		private string _projectlinkman;
		private string _projectposition;
		private string _projectmobilphone;
		private string _projectemail;
		private int _projectstate=1;
		private decimal _approvalfund;
		private int _approvalstate=1;
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
		/// 用户Id
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 所属行业Id
		/// </summary>
		public int IndustryId
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		/// <summary>
		/// 上年营业收入
		/// </summary>
		public decimal YYSR
		{
			set{ _yysr=value;}
			get{return _yysr;}
		}
		/// <summary>
		/// 上年税收总额
		/// </summary>
		public decimal TAX
		{
			set{ _tax=value;}
			get{return _tax;}
		}
		/// <summary>
		/// 员工人数
		/// </summary>
		public int Employee
		{
			set{ _employee=value;}
			get{return _employee;}
		}
		/// <summary>
		/// 注册地址
		/// </summary>
		public string RegAddress
		{
			set{ _regaddress=value;}
			get{return _regaddress;}
		}
		/// <summary>
		/// 经营地址
		/// </summary>
		public string BusinessAddress
		{
			set{ _businessaddress=value;}
			get{return _businessaddress;}
		}
		/// <summary>
		/// 申请类型
		/// </summary>
		public int ApplyTypeId
		{
			set{ _applytypeid=value;}
			get{return _applytypeid;}
		}
		/// <summary>
		/// 申请资金
		/// </summary>
		public decimal ApplyFund
		{
			set{ _applyfund=value;}
			get{return _applyfund;}
		}
		/// <summary>
		/// 申报材料
		/// </summary>
		public string Attachment
		{
			set{ _attachment=value;}
			get{return _attachment;}
		}
		/// <summary>
		/// 项目联系人-姓名
		/// </summary>
		public string ProjectLinkMan
		{
			set{ _projectlinkman=value;}
			get{return _projectlinkman;}
		}
		/// <summary>
		/// 项目联系人-职位
		/// </summary>
		public string ProjectPosition
		{
			set{ _projectposition=value;}
			get{return _projectposition;}
		}
		/// <summary>
		/// 项目联系人-手机
		/// </summary>
		public string ProjectMobilPhone
		{
			set{ _projectmobilphone=value;}
			get{return _projectmobilphone;}
		}
		/// <summary>
		/// 项目联系人-邮箱
		/// </summary>
		public string ProjectEmail
		{
			set{ _projectemail=value;}
			get{return _projectemail;}
		}
		/// <summary>
		/// 审核意见-项目状态1.待审核 2.退回修改 3.审核通过
		/// </summary>
		public int ProjectState
		{
			set{ _projectstate=value;}
			get{return _projectstate;}
		}
		/// <summary>
		/// 审批资金
		/// </summary>
		public decimal ApprovalFund
		{
			set{ _approvalfund=value;}
			get{return _approvalfund;}
		}
		/// <summary>
		/// 审批状态 1.未核定 2.已核定
		/// </summary>
		public int ApprovalState
		{
			set{ _approvalstate=value;}
			get{return _approvalstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
        #endregion Model


        public Dic_IndustryModel Dic_IndustryModel{ get; set; }
    }
}


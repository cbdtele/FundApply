/**  版本信息模板在安装目录下，可自行修改。
* ProjectApply_ModifyContent.cs
*
* 功 能： N/A
* 类 名： ProjectApply_ModifyContent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/2 9:56:32   N/A    初版
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
	/// ProjectApply_ModifyContent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProjectApply_ModifyContentModel
	{
		public ProjectApply_ModifyContentModel()
		{}
		#region Model
		private int _id;
		private int _projectapplyid;
		private string _contentbefore;
		private string _contentafter;
		private string _modifyopinion;
		private string _modifycontent;
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
		/// 
		/// </summary>
		public int ProjectApplyId
		{
			set{ _projectapplyid=value;}
			get{return _projectapplyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentBefore
		{
			set{ _contentbefore=value;}
			get{return _contentbefore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentAfter
		{
			set{ _contentafter=value;}
			get{return _contentafter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModifyOpinion
		{
			set{ _modifyopinion=value;}
			get{return _modifyopinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModifyContent
		{
			set{ _modifycontent=value;}
			get{return _modifycontent;}
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

	}
}


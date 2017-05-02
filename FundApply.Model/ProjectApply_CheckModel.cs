/**  版本信息模板在安装目录下，可自行修改。
* ProjectApply_Check.cs
*
* 功 能： N/A
* 类 名： ProjectApply_Check
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
	/// ProjectApply_Check:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProjectApply_CheckModel
	{
		public ProjectApply_CheckModel()
		{}
		#region Model
		private int _id;
		private int _projectapplyid;
		private int? _checkstate=1;
		private string _checkopinion;
		private int? _useridchecker;
		private DateTime? _checktime;
		private DateTime? _createtime;
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
		public int? CheckState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckOpinion
		{
			set{ _checkopinion=value;}
			get{return _checkopinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserIdChecker
		{
			set{ _useridchecker=value;}
			get{return _useridchecker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}


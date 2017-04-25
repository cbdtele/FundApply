/**  版本信息模板在安装目录下，可自行修改。
* Dic_Industry.cs
*
* 功 能： N/A
* 类 名： Dic_Industry
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/20 14:35:49   N/A    初版
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
	/// Dic_Industry:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dic_IndustryModel
	{
		public Dic_IndustryModel()
		{}
		#region Model
		private int _id;
		private string _industryname;
		private int _industryid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 行业名称
		/// </summary>
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IndustryId
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		#endregion Model

	}
}


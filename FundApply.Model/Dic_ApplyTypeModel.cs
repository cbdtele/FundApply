/**  版本信息模板在安装目录下，可自行修改。
* Dic_ApplyType.cs
*
* 功 能： N/A
* 类 名： Dic_ApplyType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/20 14:35:48   N/A    初版
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
	/// Dic_ApplyType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dic_ApplyTypeModel
	{
		public Dic_ApplyTypeModel()
		{}
		#region Model
		private int _id;
		private int _applytypeid_bigid;
		private int _applytypeid_smallid;
		private string _applytypeid_bigname;
		private string _applytypeid_smallname;
        private string _applyTableUrl;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 申请类型-大类
		/// </summary>
		public int ApplyTypeId_BigId
		{
			set{ _applytypeid_bigid=value;}
			get{return _applytypeid_bigid;}
		}
		/// <summary>
		/// 申请类型-小类
		/// </summary>
		public int ApplyTypeId_SmallId
		{
			set{ _applytypeid_smallid=value;}
			get{return _applytypeid_smallid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyTypeId_BigName
		{
			set{ _applytypeid_bigname=value;}
			get{return _applytypeid_bigname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyTypeId_SmallName
		{
			set{ _applytypeid_smallname=value;}
			get{return _applytypeid_smallname;}
		}

        public string ApplyTableUrl
        {
            set { _applyTableUrl = value; }
            get { return _applyTableUrl; }
        }
        #endregion Model



    }
}


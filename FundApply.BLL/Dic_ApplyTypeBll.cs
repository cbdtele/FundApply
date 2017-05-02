/**  版本信息模板在安装目录下，可自行修改。
* Dic_ApplyType.cs
*
* 功 能： N/A
* 类 名： Dic_ApplyType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/20 14:39:34   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using FundApply.Model;
using FundApply.DAL;

namespace FundApply.BLL
{
	/// <summary>
	/// Dic_ApplyType
	/// </summary>
	public partial class Dic_ApplyTypeBll
	{
		private readonly Dic_ApplyTypeDal dal=new Dic_ApplyTypeDal();
		public Dic_ApplyTypeBll()
		{}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dic_ApplyTypeModel GetModel()
		{

			return dal.GetModel();
		}
	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Dic_ApplyTypeModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Dic_ApplyTypeModel> GetBigModelList(string strWhere)
        {
            DataSet ds = dal.GetListBig (strWhere);
            return DataTableToList1(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Dic_ApplyTypeModel> DataTableToList(DataTable dt)
		{
			List<Dic_ApplyTypeModel> modelList = new List<Dic_ApplyTypeModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dic_ApplyTypeModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Dic_ApplyTypeModel> DataTableToList1(DataTable dt)
        {
            List<Dic_ApplyTypeModel> modelList = new List<Dic_ApplyTypeModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Dic_ApplyTypeModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel1(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
		{
			return GetList("");
		}

        public Dic_ApplyTypeModel GetNameById(int applyTypeId_SmallId)
        {
            return dal.GetNameById(applyTypeId_SmallId);
        }
    }
}


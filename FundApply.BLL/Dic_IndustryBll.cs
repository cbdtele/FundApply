/**  版本信息模板在安装目录下，可自行修改。
* Dic_Industry.cs
*
* 功 能： N/A
* 类 名： Dic_Industry
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
    /// Dic_Industry
    /// </summary>
    public partial class Dic_IndustryBll
    {
        private readonly Dic_Industry dal = new Dic_Industry();
        public Dic_IndustryBll()
        { }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Dic_IndustryModel GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
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
        public List<Dic_IndustryModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Dic_IndustryModel> DataTableToList(DataTable dt)
        {
            List<Dic_IndustryModel> modelList = new List<Dic_IndustryModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Dic_IndustryModel model;
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
        public DataSet GetAllList()
        {
            return GetList("");
        }

        public string GetNameById(int industryId)
        {
            return dal.GetNameById(industryId);
        }
    }
}


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
using System.Text;
using System.Data.SqlClient;
using FundApply.Model;
using FundApply.Common.SqlHelper;

namespace FundApply.DAL
{
    /// <summary>
    /// 数据访问类:Dic_Industry
    /// </summary>
    public partial class Dic_Industry
    {
        public Dic_Industry()
        { }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Dic_IndustryModel GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,IndustryName,IndustryId from Dic_Industry ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            Dic_IndustryModel model = new Dic_IndustryModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Dic_IndustryModel DataRowToModel(DataRow row)
        {
            Dic_IndustryModel model = new Dic_IndustryModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["IndustryName"] != null)
                {
                    model.IndustryName = row["IndustryName"].ToString();
                }
                if (row["IndustryId"] != null && row["IndustryId"].ToString() != "")
                {
                    model.IndustryId = int.Parse(row["IndustryId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,IndustryName,IndustryId ");
            strSql.Append(" FROM Dic_Industry ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        public string GetNameById(int industryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select IndustryName ");
            strSql.Append(" from Dic_Industry ");
            strSql.AppendFormat(" where IndustryId={0} ", industryId);
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }
    }
}


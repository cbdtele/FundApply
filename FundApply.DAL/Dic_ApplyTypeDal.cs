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
using System.Text;
using System.Data.SqlClient;
using FundApply.Model;
using FundApply.Common.SqlHelper;

namespace FundApply.DAL
{
	/// <summary>
	/// 数据访问类:Dic_ApplyType
	/// </summary>
	public partial class Dic_ApplyTypeDal
	{
		public Dic_ApplyTypeDal()
		{}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dic_ApplyTypeModel GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ApplyTypeId_BigId,ApplyTypeId_SmallId,ApplyTypeId_BigName,ApplyTypeId_SmallName,ApplyTableUrl from Dic_ApplyType ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Dic_ApplyTypeModel model=new Dic_ApplyTypeModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		    public Dic_ApplyTypeModel DataRowToModel(DataRow row)
		    {
			    Dic_ApplyTypeModel model=new Dic_ApplyTypeModel();
			    if (row != null)
			    {
				    if(row["Id"]!=null && row["Id"].ToString()!="")
				    {
					    model.Id=int.Parse(row["Id"].ToString());
				    }
				    if(row["ApplyTypeId_BigId"]!=null && row["ApplyTypeId_BigId"].ToString()!="")
				    {
					    model.ApplyTypeId_BigId=int.Parse(row["ApplyTypeId_BigId"].ToString());
				    }
				    if(row["ApplyTypeId_SmallId"]!=null && row["ApplyTypeId_SmallId"].ToString()!="")
				    {
					    model.ApplyTypeId_SmallId=int.Parse(row["ApplyTypeId_SmallId"].ToString());
				    }
				    if(row["ApplyTypeId_BigName"]!=null)
				    {
					    model.ApplyTypeId_BigName=row["ApplyTypeId_BigName"].ToString();
				    }
				    if(row["ApplyTypeId_SmallName"]!=null)
				    {
					    model.ApplyTypeId_SmallName=row["ApplyTypeId_SmallName"].ToString();
				    }
                if (row["ApplyTableUrl"] != null)
                {
                    model.ApplyTableUrl = row["ApplyTableUrl"].ToString();
                }
            }
			    return model;
		    }

        /// <summary>
        /// 得到一个对象实体
        /// </summa
        /// ry>
        public Dic_ApplyTypeModel DataRowToModel1(DataRow row)
        {
            Dic_ApplyTypeModel model = new Dic_ApplyTypeModel();
            if (row != null)
            {
              
                if (row["ApplyTypeId_BigId"] != null && row["ApplyTypeId_BigId"].ToString() != "")
                {
                    model.ApplyTypeId_BigId = int.Parse(row["ApplyTypeId_BigId"].ToString());
                }
              
                if (row["ApplyTypeId_BigName"] != null)
                {
                    model.ApplyTypeId_BigName = row["ApplyTypeId_BigName"].ToString();
                }
              
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,ApplyTypeId_BigId,ApplyTypeId_SmallId,ApplyTypeId_BigName,ApplyTypeId_SmallName,ApplyTableUrl");
			strSql.Append(" FROM Dic_ApplyType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListBig(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ApplyTypeId_BigId,ApplyTypeId_BigName ");
            strSql.Append(" FROM Dic_ApplyType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public Dic_ApplyTypeModel GetNameById(int applyTypeId_SmallId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select * from ");
            strSql.Append(" Dic_ApplyType ");
            strSql.AppendFormat(" where ApplyTypeId_SmallId={0} ", applyTypeId_SmallId);

            DataSet ds= DbHelperSQL.Query(strSql.ToString());

            Dic_ApplyTypeModel model = new Dic_ApplyTypeModel();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}


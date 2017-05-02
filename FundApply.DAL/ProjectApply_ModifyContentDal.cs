using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FundApply.Model;
using FundApply.Common.SqlHelper;
namespace FundApply.DAL
{
	/// <summary>
	/// 数据访问类:ProjectApply_ModifyContent
	/// </summary>
	public partial class ProjectApply_ModifyContentDal
	{
		public ProjectApply_ModifyContentDal()
		{}

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ProjectApply_ModifyContent");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProjectApply_ModifyContent");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProjectApply_ModifyContentModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProjectApply_ModifyContent(");
            strSql.Append("ProjectApplyId,ContentBefore,ContentAfter,ModifyOpinion,ModifyContent,CreateTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@ProjectApplyId,@ContentBefore,@ContentAfter,@ModifyOpinion,@ModifyContent,@CreateTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectApplyId", SqlDbType.Int,4),
                    new SqlParameter("@ContentBefore", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContentAfter", SqlDbType.NVarChar,50),
                    new SqlParameter("@ModifyOpinion", SqlDbType.Text),
                    new SqlParameter("@ModifyContent", SqlDbType.Text),
                    new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3)};
            parameters[0].Value = model.ProjectApplyId;
            parameters[1].Value = model.ContentBefore;
            parameters[2].Value = model.ContentAfter;
            parameters[3].Value = model.ModifyOpinion;
            parameters[4].Value = model.ModifyContent;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.UpdateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProjectApply_ModifyContentModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProjectApply_ModifyContent set ");
            strSql.Append("ProjectApplyId=@ProjectApplyId,");
            strSql.Append("ContentBefore=@ContentBefore,");
            strSql.Append("ContentAfter=@ContentAfter,");
            strSql.Append("ModifyOpinion=@ModifyOpinion,");
            strSql.Append("ModifyContent=@ModifyContent,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectApplyId", SqlDbType.Int,4),
                    new SqlParameter("@ContentBefore", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContentAfter", SqlDbType.NVarChar,50),
                    new SqlParameter("@ModifyOpinion", SqlDbType.Text),
                    new SqlParameter("@ModifyContent", SqlDbType.Text),
                    new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ProjectApplyId;
            parameters[1].Value = model.ContentBefore;
            parameters[2].Value = model.ContentAfter;
            parameters[3].Value = model.ModifyOpinion;
            parameters[4].Value = model.ModifyContent;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProjectApply_ModifyContent ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByProjectApplyId(int projectApplyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProjectApply_ModifyContent ");
            strSql.Append(" where ProjectApplyId=@projectApplyId");
            SqlParameter[] parameters = {
                    new SqlParameter("@projectApplyId", SqlDbType.Int,4)
            };
            parameters[0].Value = projectApplyId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProjectApply_ModifyContent ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProjectApply_ModifyContentModel GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProjectApplyId,ContentBefore,ContentAfter,ModifyOpinion,ModifyContent,CreateTime,UpdateTime from ProjectApply_ModifyContent ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            ProjectApply_ModifyContentModel model = new ProjectApply_ModifyContentModel();
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
        public ProjectApply_ModifyContentModel DataRowToModel(DataRow row)
        {
            ProjectApply_ModifyContentModel model = new ProjectApply_ModifyContentModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ProjectApplyId"] != null && row["ProjectApplyId"].ToString() != "")
                {
                    model.ProjectApplyId = int.Parse(row["ProjectApplyId"].ToString());
                }
                if (row["ContentBefore"] != null)
                {
                    model.ContentBefore = row["ContentBefore"].ToString();
                }
                if (row["ContentAfter"] != null)
                {
                    model.ContentAfter = row["ContentAfter"].ToString();
                }
                if (row["ModifyOpinion"] != null)
                {
                    model.ModifyOpinion = row["ModifyOpinion"].ToString();
                }
                if (row["ModifyContent"] != null)
                {
                    model.ModifyContent = row["ModifyContent"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
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
            strSql.Append("select Id,ProjectApplyId,ContentBefore,ContentAfter,ModifyOpinion,ModifyContent,CreateTime,UpdateTime ");
            strSql.Append(" FROM ProjectApply_ModifyContent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,ProjectApplyId,ContentBefore,ContentAfter,ModifyOpinion,ModifyContent,CreateTime,UpdateTime ");
            strSql.Append(" FROM ProjectApply_ModifyContent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ProjectApply_ModifyContent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from ProjectApply_ModifyContent T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}


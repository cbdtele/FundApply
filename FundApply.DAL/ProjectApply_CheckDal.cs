using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FundApply.Model;
using FundApply.Common.SqlHelper;
namespace FundApply.DAL
{
	/// <summary>
	/// 数据访问类:ProjectApply_Check
	/// </summary>
	public partial class ProjectApply_CheckDal
	{
		public ProjectApply_CheckDal()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "ProjectApply_Check"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProjectApply_Check");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ProjectApply_CheckModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProjectApply_Check(");
			strSql.Append("ProjectApplyId,CheckState,CheckOpinion,UserIdChecker,CheckTime,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@ProjectApplyId,@CheckState,@CheckOpinion,@UserIdChecker,@CheckTime,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectApplyId", SqlDbType.Int,4),
					new SqlParameter("@CheckState", SqlDbType.Int,4),
					new SqlParameter("@CheckOpinion", SqlDbType.Text),
					new SqlParameter("@UserIdChecker", SqlDbType.Int,4),
					new SqlParameter("@CheckTime", SqlDbType.Date,3),
					new SqlParameter("@CreateTime", SqlDbType.Date,3)};
			parameters[0].Value = model.ProjectApplyId;
			parameters[1].Value = model.CheckState;
			parameters[2].Value = model.CheckOpinion;
			parameters[3].Value = model.UserIdChecker;
			parameters[4].Value = model.CheckTime;
			parameters[5].Value = model.CreateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool UpDate(ProjectApply_CheckModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("upDate ProjectApply_Check set ");
			strSql.Append("ProjectApplyId=@ProjectApplyId,");
			strSql.Append("CheckState=@CheckState,");
			strSql.Append("CheckOpinion=@CheckOpinion,");
			strSql.Append("UserIdChecker=@UserIdChecker,");
			strSql.Append("CheckTime=@CheckTime,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectApplyId", SqlDbType.Int,4),
					new SqlParameter("@CheckState", SqlDbType.Int,4),
					new SqlParameter("@CheckOpinion", SqlDbType.Text),
					new SqlParameter("@UserIdChecker", SqlDbType.Int,4),
					new SqlParameter("@CheckTime", SqlDbType.Date,3),
					new SqlParameter("@CreateTime", SqlDbType.Date,3),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectApplyId;
			parameters[1].Value = model.CheckState;
			parameters[2].Value = model.CheckOpinion;
			parameters[3].Value = model.UserIdChecker;
			parameters[4].Value = model.CheckTime;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProjectApply_Check ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
            strSql.Append("delete from ProjectApply_Check ");
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
        public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProjectApply_Check ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ProjectApply_CheckModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ProjectApplyId,CheckState,CheckOpinion,UserIdChecker,CheckTime,CreateTime from ProjectApply_Check ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			ProjectApply_CheckModel model=new ProjectApply_CheckModel();
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
		public ProjectApply_CheckModel DataRowToModel(DataRow row)
		{
			ProjectApply_CheckModel model=new ProjectApply_CheckModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ProjectApplyId"]!=null && row["ProjectApplyId"].ToString()!="")
				{
					model.ProjectApplyId=int.Parse(row["ProjectApplyId"].ToString());
				}
				if(row["CheckState"]!=null && row["CheckState"].ToString()!="")
				{
					model.CheckState=int.Parse(row["CheckState"].ToString());
				}
				if(row["CheckOpinion"]!=null)
				{
					model.CheckOpinion=row["CheckOpinion"].ToString();
				}
				if(row["UserIdChecker"]!=null && row["UserIdChecker"].ToString()!="")
				{
					model.UserIdChecker=int.Parse(row["UserIdChecker"].ToString());
				}
				if(row["CheckTime"]!=null && row["CheckTime"].ToString()!="")
				{
					model.CheckTime=DateTime.Parse(row["CheckTime"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select Id,ProjectApplyId,CheckState,CheckOpinion,UserIdChecker,CheckTime,CreateTime ");
			strSql.Append(" FROM ProjectApply_Check ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}


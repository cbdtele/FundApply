using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FundApply.Common.SqlHelper;
using FundApply.Model;

namespace FundApply.DAL
{
	/// <summary>
	/// 数据访问类:ProjectApply
	/// </summary>
	public partial class ProjectApplyDal
	{
		public ProjectApplyDal()
		{}
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ProjectApply");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProjectApplyModel model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProjectApply(");
            strSql.Append("UserId,Company,IndustryId,YYSR,TAX,Employee,RegAddress,BusinessAddress,TaxAddress,ApplyTypeId,ApplyFund,ApplyTable,Attachment,Remarks,ProjectLinkMan,ProjectPosition,ProjectMobilPhone,ProjectEmail,ProjectState,ApprovalFund,ApprovalState,CreateTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Company,@IndustryId,@YYSR,@TAX,@Employee,@RegAddress,@BusinessAddress,@TaxAddress,@ApplyTypeId,@ApplyFund,@ApplyTable,@Attachment,@Remarks,@ProjectLinkMan,@ProjectPosition,@ProjectMobilPhone,@ProjectEmail,@ProjectState,@ApprovalFund,@ApprovalState,@CreateTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@IndustryId", SqlDbType.Int,4),
                    new SqlParameter("@YYSR", SqlDbType.Decimal,9),
                    new SqlParameter("@TAX", SqlDbType.Decimal,9),
                    new SqlParameter("@Employee", SqlDbType.Int,4),
                    new SqlParameter("@RegAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@BusinessAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@TaxAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@ApplyTypeId", SqlDbType.Int,4),
                    new SqlParameter("@ApplyFund", SqlDbType.Decimal,9),
                    new SqlParameter("@ApplyTable", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remarks", SqlDbType.Text),
                    new SqlParameter("@ProjectLinkMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectPosition", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectMobilPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectState", SqlDbType.Int,4),
                    new SqlParameter("@ApprovalFund", SqlDbType.Decimal,9),
                    new SqlParameter("@ApprovalState", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Company;
            parameters[2].Value = model.IndustryId;
            parameters[3].Value = model.YYSR;
            parameters[4].Value = model.TAX;
            parameters[5].Value = model.Employee;
            parameters[6].Value = model.RegAddress;
            parameters[7].Value = model.BusinessAddress;
            parameters[8].Value = model.TaxAddress;
            parameters[9].Value = model.ApplyTypeId;
            parameters[10].Value = model.ApplyFund;
            parameters[11].Value = model.ApplyTable;
            parameters[12].Value = model.Attachment;
            parameters[13].Value = model.Remarks;
            parameters[14].Value = model.ProjectLinkMan;
            parameters[15].Value = model.ProjectPosition;
            parameters[16].Value = model.ProjectMobilPhone;
            parameters[17].Value = model.ProjectEmail;
            parameters[18].Value = model.ProjectState;
            parameters[19].Value = model.ApprovalFund;
            parameters[20].Value = model.ApprovalState;
            parameters[21].Value = model.CreateTime;
            parameters[22].Value = model.UpdateTime;

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
		public bool Update(ProjectApplyModel model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update ProjectApply set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Company=@Company,");
            strSql.Append("IndustryId=@IndustryId,");
            strSql.Append("YYSR=@YYSR,");
            strSql.Append("TAX=@TAX,");
            strSql.Append("Employee=@Employee,");
            strSql.Append("RegAddress=@RegAddress,");
            strSql.Append("BusinessAddress=@BusinessAddress,");
            strSql.Append("TaxAddress=@TaxAddress,");
            strSql.Append("ApplyTypeId=@ApplyTypeId,");
            strSql.Append("ApplyFund=@ApplyFund,");
            strSql.Append("ApplyTable=@ApplyTable,");
            strSql.Append("Attachment=@Attachment,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("ProjectLinkMan=@ProjectLinkMan,");
            strSql.Append("ProjectPosition=@ProjectPosition,");
            strSql.Append("ProjectMobilPhone=@ProjectMobilPhone,");
            strSql.Append("ProjectEmail=@ProjectEmail,");
            strSql.Append("ProjectState=@ProjectState,");
            strSql.Append("ApprovalFund=@ApprovalFund,");
            strSql.Append("ApprovalState=@ApprovalState,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@IndustryId", SqlDbType.Int,4),
                    new SqlParameter("@YYSR", SqlDbType.Decimal,9),
                    new SqlParameter("@TAX", SqlDbType.Decimal,9),
                    new SqlParameter("@Employee", SqlDbType.Int,4),
                    new SqlParameter("@RegAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@BusinessAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@TaxAddress", SqlDbType.NVarChar,50),
                    new SqlParameter("@ApplyTypeId", SqlDbType.Int,4),
                    new SqlParameter("@ApplyFund", SqlDbType.Decimal,9),
                    new SqlParameter("@ApplyTable", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remarks", SqlDbType.Text),
                    new SqlParameter("@ProjectLinkMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectPosition", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectMobilPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProjectState", SqlDbType.Int,4),
                    new SqlParameter("@ApprovalFund", SqlDbType.Decimal,9),
                    new SqlParameter("@ApprovalState", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3),
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Company;
            parameters[2].Value = model.IndustryId;
            parameters[3].Value = model.YYSR;
            parameters[4].Value = model.TAX;
            parameters[5].Value = model.Employee;
            parameters[6].Value = model.RegAddress;
            parameters[7].Value = model.BusinessAddress;
            parameters[8].Value = model.TaxAddress;
            parameters[9].Value = model.ApplyTypeId;
            parameters[10].Value = model.ApplyFund;
            parameters[11].Value = model.ApplyTable;
            parameters[12].Value = model.Attachment;
            parameters[13].Value = model.Remarks;
            parameters[14].Value = model.ProjectLinkMan;
            parameters[15].Value = model.ProjectPosition;
            parameters[16].Value = model.ProjectMobilPhone;
            parameters[17].Value = model.ProjectEmail;
            parameters[18].Value = model.ProjectState;
            parameters[19].Value = model.ApprovalFund;
            parameters[20].Value = model.ApprovalState;
            parameters[21].Value = model.CreateTime;
            parameters[22].Value = model.UpdateTime;
            parameters[23].Value = model.Id;
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
			strSql.Append("delete from ProjectApply ");
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
		/// 得到一个对象实体
		/// </summary>
		public ProjectApplyModel GetModel(int userId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,Company,IndustryId,YYSR,TAX,Employee,RegAddress,BusinessAddress,TaxAddress,ApplyTypeId,ApplyFund,ApplyTable,Attachment,Remarks,ProjectLinkMan,ProjectPosition,ProjectMobilPhone,ProjectEmail,ProjectState,ApprovalFund,ApprovalState,CreateTime,UpdateTime from ProjectApply ");
            strSql.Append(" where UserId=@userId");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
			parameters[0].Value = userId;

			ProjectApplyModel model=new ProjectApplyModel();
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
		public ProjectApplyModel GetModel(string  id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,Company,IndustryId,YYSR,TAX,Employee,RegAddress,BusinessAddress,TaxAddress,ApplyTypeId,ApplyFund,ApplyTable,Attachment,Remarks,ProjectLinkMan,ProjectPosition,ProjectMobilPhone,ProjectEmail,ProjectState,ApprovalFund,ApprovalState,CreateTime,UpdateTime from ProjectApply ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            ProjectApplyModel model = new ProjectApplyModel();
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
        public ProjectApplyModel DataRowToModel(DataRow row)
		{
			ProjectApplyModel model=new ProjectApplyModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["IndustryId"] != null && row["IndustryId"].ToString() != "")
                {
                    model.IndustryId = int.Parse(row["IndustryId"].ToString());
                }
                if (row["YYSR"] != null && row["YYSR"].ToString() != "")
                {
                    model.YYSR = decimal.Parse(row["YYSR"].ToString());
                }
                if (row["TAX"] != null && row["TAX"].ToString() != "")
                {
                    model.TAX = decimal.Parse(row["TAX"].ToString());
                }
                if (row["Employee"] != null && row["Employee"].ToString() != "")
                {
                    model.Employee = int.Parse(row["Employee"].ToString());
                }
                if (row["RegAddress"] != null)
                {
                    model.RegAddress = row["RegAddress"].ToString();
                }
                if (row["BusinessAddress"] != null)
                {
                    model.BusinessAddress = row["BusinessAddress"].ToString();
                }
                if (row["TaxAddress"] != null)
                {
                    model.TaxAddress = row["TaxAddress"].ToString();
                }
                if (row["ApplyTypeId"] != null && row["ApplyTypeId"].ToString() != "")
                {
                    model.ApplyTypeId = int.Parse(row["ApplyTypeId"].ToString());
                }
                if (row["ApplyFund"] != null && row["ApplyFund"].ToString() != "")
                {
                    model.ApplyFund = decimal.Parse(row["ApplyFund"].ToString());
                }
                if (row["ApplyTable"] != null)
                {
                    model.ApplyTable = row["ApplyTable"].ToString();
                }
                if (row["Attachment"] != null)
                {
                    model.Attachment = row["Attachment"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["ProjectLinkMan"] != null)
                {
                    model.ProjectLinkMan = row["ProjectLinkMan"].ToString();
                }
                if (row["ProjectPosition"] != null)
                {
                    model.ProjectPosition = row["ProjectPosition"].ToString();
                }
                if (row["ProjectMobilPhone"] != null)
                {
                    model.ProjectMobilPhone = row["ProjectMobilPhone"].ToString();
                }
                if (row["ProjectEmail"] != null)
                {
                    model.ProjectEmail = row["ProjectEmail"].ToString();
                }
                if (row["ProjectState"] != null && row["ProjectState"].ToString() != "")
                {
                    model.ProjectState = int.Parse(row["ProjectState"].ToString());
                }
                if (row["ApprovalFund"] != null && row["ApprovalFund"].ToString() != "")
                {
                    model.ApprovalFund = decimal.Parse(row["ApprovalFund"].ToString());
                }
                if (row["ApprovalState"] != null && row["ApprovalState"].ToString() != "")
                {
                    model.ApprovalState = int.Parse(row["ApprovalState"].ToString());
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Id,UserId,Company,IndustryId,YYSR,TAX,Employee,RegAddress,BusinessAddress,TaxAddress,ApplyTypeId,ApplyFund,ApplyTable,Attachment,Remarks,ProjectLinkMan,ProjectPosition,ProjectMobilPhone,ProjectEmail,ProjectState,ApprovalFund,ApprovalState,CreateTime,UpdateTime ");
            strSql.Append(" FROM ProjectApply ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
	
        /// <summary>
        /// 该用户是否在这一年申请过项目
        /// </summary>
        public bool ExistsProject(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ProjectApply");
            strSql.Append(" where UserId=@UserId and datediff(year, CreateTime, GETDATE()) = 0");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        public DataSet GetApplyProjectList(int ProjectState,string Company)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.ApplyTypeId_BigName,b.Nat_Org_Code,b.Company,a.ApplyFund,a.ProjectState,a.ApprovalFund,a.UpdateTime,a.TAX,a.YYSR,d.IndustryName,a.Employee,a.RegAddress from projectApply  a");
            strSql.Append(" left join Users b on a.UserId = b.Id left join Dic_ApplyType c on a.ApplyTypeId = c.ApplyTypeId_SmallId left join Dic_Industry d on a.IndustryId = d.IndustryId");
             strSql.Append(" where a.ProjectState = @ProjectState and b.Company like '%%'");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectState", SqlDbType.Int,4),
                     new SqlParameter("@Company", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = ProjectState;
            parameters[1].Value = Company;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
    }
}


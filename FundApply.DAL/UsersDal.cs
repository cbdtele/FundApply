/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 16:59:41   N/A    初版
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
	/// 数据访问类:Users
	/// </summary>
	public partial class UsersDal
    {
        public UsersDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string  nat_org_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where nat_org_code=@nat_org_code");
            SqlParameter[] parameters = {
                    new SqlParameter("@nat_org_code", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = nat_org_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("Nat_Org_Code,Company,Password,Linkman1,LinkMan2,MobilePhone1,MobilePhone2,Telephone1,Telephone2,Email1,Email2,State,CreateTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@Nat_Org_Code,@Company,@Password,@Linkman1,@LinkMan2,@MobilePhone1,@MobilePhone2,@Telephone1,@Telephone2,@Email1,@Email2,@State,@CreateTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Nat_Org_Code", SqlDbType.NVarChar,50),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@Password", SqlDbType.NVarChar,20),
                    new SqlParameter("@Linkman1", SqlDbType.NVarChar,20),
                    new SqlParameter("@LinkMan2", SqlDbType.NVarChar,20),
                    new SqlParameter("@MobilePhone1", SqlDbType.NVarChar,11),
                    new SqlParameter("@MobilePhone2", SqlDbType.NVarChar,11),
                    new SqlParameter("@Telephone1", SqlDbType.NVarChar,20),
                    new SqlParameter("@Telephone2", SqlDbType.NVarChar,20),
                    new SqlParameter("@Email1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email2", SqlDbType.NVarChar,50),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3)};
            parameters[0].Value = model.Nat_Org_Code;
            parameters[1].Value = model.Company;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.LinkMan1;
            parameters[4].Value = model.LinkMan2;
            parameters[5].Value = model.MobilePhone1;
            parameters[6].Value = model.MobilePhone2;
            parameters[7].Value = model.Telephone1;
            parameters[8].Value = model.Telephone2;
            parameters[9].Value = model.Email1;
            parameters[10].Value = model.Email2;
            parameters[11].Value = model.State;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateTime;

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
        public bool Update(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Nat_Org_Code=@Nat_Org_Code,");
            strSql.Append("Company=@Company,");
            strSql.Append("Password=@Password,");
            strSql.Append("Linkman1=@Linkman1,");
            strSql.Append("LinkMan2=@LinkMan2,");
            strSql.Append("MobilePhone1=@MobilePhone1,");
            strSql.Append("MobilePhone2=@MobilePhone2,");
            strSql.Append("Telephone1=@Telephone1,");
            strSql.Append("Telephone2=@Telephone2,");
            strSql.Append("Email1=@Email1,");
            strSql.Append("Email2=@Email2,");
            //strSql.Append("State=@State,");
            //strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Nat_Org_Code", SqlDbType.NVarChar,50),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@Password", SqlDbType.NVarChar,20),
                    new SqlParameter("@Linkman1", SqlDbType.NVarChar,20),
                    new SqlParameter("@LinkMan2", SqlDbType.NVarChar,20),
                    new SqlParameter("@MobilePhone1", SqlDbType.NVarChar,11),
                    new SqlParameter("@MobilePhone2", SqlDbType.NVarChar,11),
                    new SqlParameter("@Telephone1", SqlDbType.NVarChar,20),
                    new SqlParameter("@Telephone2", SqlDbType.NVarChar,20),
                    new SqlParameter("@Email1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email2", SqlDbType.NVarChar,50),
                    //new SqlParameter("@State", SqlDbType.Int,4),
                    //new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3),
                    new SqlParameter("@Id", SqlDbType.Int, 4)};
        parameters[0].Value = model.Nat_Org_Code;
            parameters[1].Value = model.Company;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.LinkMan1;
            parameters[4].Value = model.LinkMan2;
            parameters[5].Value = model.MobilePhone1;
            parameters[6].Value = model.MobilePhone2;
            parameters[7].Value = model.Telephone1;
            parameters[8].Value = model.Telephone2;
            parameters[9].Value = model.Email1;
            parameters[10].Value = model.Email2;
            parameters[11].Value = model.UpdateTime;
            //parameters[12].Value = model.CreateTime;
            //parameters[13].Value = model.UpdateTime;
            parameters[12].Value = model.Id;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateAccount(UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Nat_Org_Code=@Nat_Org_Code,");
            //strSql.Append("Company=@Company,");
            strSql.Append("Password=@Password,");
            //strSql.Append("Linkman1=@Linkman1,");
            //strSql.Append("LinkMan2=@LinkMan2,");
            //strSql.Append("MobilePhone1=@MobilePhone1,");
            //strSql.Append("MobilePhone2=@MobilePhone2,");
            //strSql.Append("Telephone1=@Telephone1,");
            //strSql.Append("Telephone2=@Telephone2,");
            strSql.Append("Email1=@Email1,");
            //strSql.Append("Email2=@Email2,");
            //strSql.Append("State=@State,");
            //strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Nat_Org_Code", SqlDbType.NVarChar,50),
                    //new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@Password", SqlDbType.NVarChar,20),
                    //new SqlParameter("@Linkman1", SqlDbType.NVarChar,20),
                    //new SqlParameter("@LinkMan2", SqlDbType.NVarChar,20),
                    //new SqlParameter("@MobilePhone1", SqlDbType.NVarChar,11),
                    //new SqlParameter("@MobilePhone2", SqlDbType.NVarChar,11),
                    //new SqlParameter("@Telephone1", SqlDbType.NVarChar,20),
                    //new SqlParameter("@Telephone2", SqlDbType.NVarChar,20),
                    new SqlParameter("@Email1", SqlDbType.NVarChar,50),
                    //new SqlParameter("@Email2", SqlDbType.NVarChar,50),
                    //new SqlParameter("@State", SqlDbType.Int,4),
                    //new SqlParameter("@CreateTime", SqlDbType.Date,3),
                    new SqlParameter("@UpdateTime", SqlDbType.Date,3),
                    new SqlParameter("@Id", SqlDbType.Int, 4)};
            parameters[0].Value = model.Nat_Org_Code;
            //parameters[1].Value = model.Company;
            parameters[1].Value = model.Password;
            //parameters[3].Value = model.LinkMan1;
            //parameters[4].Value = model.LinkMan2;
            //parameters[5].Value = model.MobilePhone1;
            //parameters[6].Value = model.MobilePhone2;
            //parameters[7].Value = model.Telephone1;
            //parameters[8].Value = model.Telephone2;
            parameters[2].Value = model.Email1;
            //parameters[10].Value = model.Email2;
            parameters[3].Value = model.UpdateTime;
            //parameters[12].Value = model.CreateTime;
            //parameters[13].Value = model.UpdateTime;
            parameters[4].Value = model.Id;

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
            strSql.Append("delete from Users ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
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
        public UsersModel GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Nat_Org_Code,Company,Password,Linkman1,LinkMan2,MobilePhone1,MobilePhone2,Telephone1,Telephone2,Email1,Email2,State,CreateTime,UpdateTime from Users ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            UsersModel model = new UsersModel();
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
        public UsersModel DataRowToModel(DataRow row)
        {
            UsersModel model = new UsersModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Nat_Org_Code"] != null)
                {
                    model.Nat_Org_Code = row["Nat_Org_Code"].ToString();
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Linkman1"] != null)
                {
                    model.LinkMan1 = row["Linkman1"].ToString();
                }
                if (row["LinkMan2"] != null)
                {
                    model.LinkMan2 = row["LinkMan2"].ToString();
                }
                if (row["MobilePhone1"] != null)
                {
                    model.MobilePhone1 = row["MobilePhone1"].ToString();
                }
                if (row["MobilePhone2"] != null)
                {
                    model.MobilePhone2 = row["MobilePhone2"].ToString();
                }
                if (row["Telephone1"] != null)
                {
                    model.Telephone1 = row["Telephone1"].ToString();
                }
                if (row["Telephone2"] != null)
                {
                    model.Telephone2 = row["Telephone2"].ToString();
                }
                if (row["Email1"] != null)
                {
                    model.Email1 = row["Email1"].ToString();
                }
                if (row["Email2"] != null)
                {
                    model.Email2 = row["Email2"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
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
            strSql.Append("select Id,Nat_Org_Code,Company,Password,Linkman1,LinkMan2,MobilePhone1,MobilePhone2,Telephone1,Telephone2,Email1,Email2,State,CreateTime,UpdateTime ");
            strSql.Append(" FROM Users ");
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
            strSql.Append(" Id,Nat_Org_Code,Company,Password,Linkman1,LinkMan2,MobilePhone1,MobilePhone2,Telephone1,Telephone2,Email1,Email2,State,CreateTime,UpdateTime ");
            strSql.Append(" FROM Users ");
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
            strSql.Append("select count(1) FROM Users ");
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
            strSql.Append(")AS Row, T.*  from Users T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Users";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

            /// <summary>
            /// 根据nat_Org_Code password 获取model
            /// </summary>
            /// <param name="nat_Org_Code"></param>
            /// <param name="password"></param>
            /// <returns></returns>
        public UsersModel GetModel(string nat_Org_Code,string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Nat_Org_Code,Company,Password,Linkman1,LinkMan2,MobilePhone1,MobilePhone2,Telephone1,Telephone2,Email1,Email2,State,CreateTime,UpdateTime from Users");
            strSql.Append(" where Nat_Org_Code=@Nat_Org_Code and Password=@Password");
            SqlParameter[] parameters = {
                    new SqlParameter("@Nat_Org_Code", SqlDbType.NVarChar,50),
                     new SqlParameter("@Password", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = nat_Org_Code;
            parameters[1].Value = password;

            UsersModel model = new UsersModel();
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

        #endregion  ExtensionMethod
    }
}


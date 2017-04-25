using System;
using System.Data;
using System.Collections.Generic;
using FundApply.Model;
using FundApply.DAL;

namespace FundApply.BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class UsersBll
    {
        private readonly UsersDal dal = new UsersDal();
        public UsersBll()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }
        public bool Exists(string  nat_org_code)
        {
            return dal.Exists(nat_org_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UsersModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UsersModel model)
        {
            return dal.Update(model);
        }

        public bool UpdateAccount(UsersModel model)
        {
            return dal.UpdateAccount(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersModel> DataTableToList(DataTable dt)
        {
            List<UsersModel> modelList = new List<UsersModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UsersModel model;
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

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据nat_Org_Code password 获取model
        /// </summary>
        /// <param name="nat_Org_Code"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UsersModel GetModel(string nat_Org_Code, string password)
        {
            return dal.GetModel(nat_Org_Code, password);
        }

        #endregion  ExtensionMethod
    }
}


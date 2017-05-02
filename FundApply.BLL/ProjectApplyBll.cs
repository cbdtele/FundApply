
using System;
using System.Data;
using System.Collections.Generic;
using FundApply.Model;
namespace FundApply.BLL
{
    /// <summary>
    /// ProjectApply
    /// </summary>
    public partial class ProjectApplyBll
    {
        private readonly FundApply.DAL.ProjectApplyDal dal = new FundApply.DAL.ProjectApplyDal();
        public ProjectApplyBll()
        {
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProjectApplyModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProjectApplyModel model)
        {
            return dal.Update(model);
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
        public ProjectApplyModel GetModel(int userId)
        {
            return dal.GetModel(userId);
        }
        public ProjectApplyModel GetModel(string id)
        {
            return dal.GetModel(id);
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
        public List<ProjectApplyModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ProjectApplyModel> DataTableToList(DataTable dt)
        {
            List<ProjectApplyModel> modelList = new List<ProjectApplyModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ProjectApplyModel model;
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
        /// 该用户是否在这一年申请过项目
        /// </summary>
        public bool ExistsProject(int userId)
        {
            return dal.ExistsProject(userId);
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        public DataSet GetApplyProjectList(int ProjectState, string Company)
        {
            return dal.GetApplyProjectList(ProjectState, Company);
        }
    }
}


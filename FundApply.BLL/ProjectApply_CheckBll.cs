
using System;
using System.Data;
using System.Collections.Generic;
using FundApply.Model;
using FundApply.DAL;

namespace FundApply.BLL
{
	/// <summary>
	/// ProjectApply_CheckModel
	/// </summary>
	public partial class ProjectApply_CheckBll
	{
		private readonly ProjectApply_CheckDal dal=new ProjectApply_CheckDal();
		public ProjectApply_CheckBll()
		{}

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

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ProjectApply_CheckModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ProjectApply_CheckModel model)
		{
			return dal.UpDate(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}

        public bool DeleteByProjectApplyId(int projectApplyId)
        {
            return dal.DeleteByProjectApplyId(projectApplyId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProjectApply_CheckModel GetModel(int Id)
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
		/// 获得数据列表
		/// </summary>
		public List<ProjectApply_CheckModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ProjectApply_CheckModel> DataTableToList(DataTable dt)
		{
			List<ProjectApply_CheckModel> modelList = new List<ProjectApply_CheckModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ProjectApply_CheckModel model;
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
	}
}

